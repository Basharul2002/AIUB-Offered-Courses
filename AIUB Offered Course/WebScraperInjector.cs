using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AIUB_Offered_Course
{
    internal class WebScraperInjector
    {
        private static CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        private static bool _isConnected = true;

        public static async Task<(List<string> GradeReportData, List<string> RoutineData)> Connection(string id, string password)
        {
            // Start the internet connection monitoring task
            _ = MonitorInternetConnectionAsync(_cancellationTokenSource.Token);

            while (true)
            {
                if (_isConnected)
                {
                    string loginUrl = "https://portal.aiub.edu/";
                    string targetUrl = "https://portal.aiub.edu/Student/GradeReport/BySemester";
                    string routineUrl = "https://portal.aiub.edu/Student/Registration";

                    using (HttpClient client = new HttpClient())
                    {
                        string loginResponseContent = await SafeLoginAsync(client, loginUrl, id, password);
                        if (loginResponseContent != null)
                        {
                            MessageBox.Show("Login successful!");

                            var gradeReportData = await ScrapeGradeReportPageAsync(client, targetUrl);
                            var routineData = await ScrapeRoutinePageAsync(client, routineUrl);

                            return (gradeReportData, routineData); // Return collected data
                        }
                        else
                        {
                            MessageBox.Show("Login failed!");
                            return (null, null);
                        }
                    }
                }
                else
                {
                    // Wait before rechecking the connection
                    await Task.Delay(1000);
                }
            }
        }

        private static async Task MonitorInternetConnectionAsync(CancellationToken token)
        {
            while (!token.IsCancellationRequested)
            {
                bool currentlyConnected = await IsInternetAvailableAsync();

                if (!currentlyConnected && _isConnected)
                {
                    _isConnected = false;
                    MessageBox.Show("No internet connection available. Please check your connection and try again.");
                }
                else if (currentlyConnected && !_isConnected)
                {
                    _isConnected = true;
                    MessageBox.Show("Internet connection restored.");

                    // Restart the Main function
                    _cancellationTokenSource.Cancel(); // Cancel the ongoing monitoring task
                    _cancellationTokenSource = new CancellationTokenSource(); // Create a new token source
                }

                await Task.Delay(1000, token); // Check connection every second
            }
        }

        private static async Task<bool> IsInternetAvailableAsync()
        {
            try
            {
                using (HttpClient client = new HttpClient())
                {
                    client.Timeout = TimeSpan.FromSeconds(5);
                    HttpResponseMessage response = await client.GetAsync("https://www.google.com");
                    return response.IsSuccessStatusCode;
                }
            }
            catch (HttpRequestException)
            {
                return false;
            }
        }

        private static async Task<string> SafeLoginAsync(HttpClient client, string loginUrl, string id, string password)
        {
            // Check internet connection before proceeding
            if (!await IsInternetAvailableAsync())
            {
                MessageBox.Show("No internet connection available. Please check your connection and try again.");
                return null;
            }

            try
            {
                var loginHtml = await client.GetStringAsync(loginUrl);
                var formActionUrl = ExtractFormActionUrl(loginHtml, loginUrl);

                if (string.IsNullOrEmpty(formActionUrl))
                {
                    MessageBox.Show("Unable to find login form.");
                    return null;
                }

                var formData = new FormUrlEncodedContent(new[]
                {
                    new KeyValuePair<string, string>("UserName", id),
                    new KeyValuePair<string, string>("Password", password)
                });

                var loginResponse = await client.PostAsync(formActionUrl, formData);
                if (loginResponse.IsSuccessStatusCode)
                    return await loginResponse.Content.ReadAsStringAsync();

                MessageBox.Show("Login failed!");
                return null;
            }
            catch (HttpRequestException ex)
            {
                MessageBox.Show($"Request error: {ex.Message}");
                return null;
            }
        }

        private static string ExtractFormActionUrl(string html, string baseUrl)
        {
            var doc = new HtmlAgilityPack.HtmlDocument();
            doc.LoadHtml(html);

            var formNode = doc.DocumentNode.SelectSingleNode("//form[@id='loginForm']");
            string formActionUrl = formNode?.GetAttributeValue("action", "");

            if (!string.IsNullOrEmpty(formActionUrl) && !formActionUrl.StartsWith("http"))
                formActionUrl = baseUrl + formActionUrl.TrimStart('/');

            return formActionUrl;
        }

        private static async Task<List<string>> ScrapeGradeReportPageAsync(HttpClient client, string targetUrl)
        {
            if (!_isConnected) return null;

            try
            {
                var targetHtml = await client.GetStringAsync(targetUrl);
                var targetDoc = new HtmlAgilityPack.HtmlDocument();
                targetDoc.LoadHtml(targetHtml);

                var gradeReportData = new List<string>();
                ExtractAndDisplayGradeReportPageFirstTableData(targetDoc, gradeReportData);
                ExtractAndDisplayGradeReportPageSecondTableData(targetDoc, gradeReportData);

                return gradeReportData;
            }
            catch (HttpRequestException ex)
            {
                MessageBox.Show($"Request error: {ex.Message}");
                return null;
            }
        }

        private static void ExtractAndDisplayGradeReportPageFirstTableData(HtmlAgilityPack.HtmlDocument doc, List<string> data)
        {
            var rows = doc.DocumentNode.SelectNodes("//div[@class='grade-report']/table[1]//tr");

            if (rows != null && rows.Count > 0)
            {
                var studentId = rows[0].SelectNodes("td")[2]?.InnerText.Trim();
                var studentName = rows[1].SelectNodes("td")[2]?.InnerText.Trim();
                var creditsCompleted = rows[2].SelectNodes("td")[2]?.InnerText.Trim();
                var coursesCompleted = rows[3].SelectNodes("td")[2]?.InnerText.Trim();
                var cgpa = rows[4].SelectNodes("td")[2]?.InnerText.Trim();

                data.Add($"Student ID: {studentId}");
                data.Add($"Student Name: {studentName}");
                data.Add($"Credits Completed: {creditsCompleted}");
                data.Add($"Courses Completed: {coursesCompleted}");
                data.Add($"CGPA: {cgpa}");
            }
            else
                data.Add("No rows found in the first table.");
        }

        private static void ExtractAndDisplayGradeReportPageSecondTableData(HtmlAgilityPack.HtmlDocument doc, List<string> data)
        {
            var rows = doc.DocumentNode.SelectNodes("//div[@class='grade-report']/table[2]//tr");

            if (rows != null)
            {
                var classDetails = rows
                    .Where(row => row.SelectNodes("td") != null && row.SelectNodes("td").Count > 0
                                  && !row.SelectNodes("td")[0]?.InnerText.Contains("***") == true) // Exclude rows with label
                    .Select(row =>
                    {
                        var cells = row.SelectNodes("td");
                        return new
                        {
                            ClassId = cells.Count > 0 ? DecodeHtmlEntities(cells[0]?.InnerText.Trim()) : string.Empty,
                            CourseName = cells.Count > 1 ? DecodeHtmlEntities(cells[1]?.InnerText.Trim()) : string.Empty,
                            Credits = cells.Count > 2 ? DecodeHtmlEntities(cells[2]?.InnerText.Trim()) : string.Empty,
                            MTG = cells.Count > 3 ? DecodeHtmlEntities(cells[3]?.InnerText.Trim()) : string.Empty,
                            FTG = cells.Count > 4 ? DecodeHtmlEntities(cells[4]?.InnerText.Trim()) : string.Empty,
                            FG = cells.Count > 5 ? DecodeHtmlEntities(cells[5]?.InnerText.Trim()) : string.Empty,
                            TGP = cells.Count > 6 ? DecodeHtmlEntities(cells[6]?.InnerText.Trim()) : string.Empty,
                            ECR = cells.Count > 7 ? DecodeHtmlEntities(cells[7]?.InnerText.Trim()) : string.Empty,
                            GPA = cells.Count > 8 ? DecodeHtmlEntities(cells[8]?.InnerText.Trim()) : string.Empty,
                            CGPA = cells.Count > 9 ? DecodeHtmlEntities(cells[9]?.InnerText.Trim()) : string.Empty,
                            STS = cells.Count > 10 ? DecodeHtmlEntities(cells[10]?.InnerText.Trim()) : string.Empty,
                            PRN = cells.Count > 11 ? DecodeHtmlEntities(cells[11]?.InnerText.Trim()) : string.Empty
                        };
                    }).ToList();

                if (classDetails.Count > 0)
                {
                    for (int i = 1; i < classDetails.Count - 1; i++)
                    {
                        data.Add($"Class ID: {classDetails[i].ClassId}");
                        data.Add($"Course Name: {classDetails[i].CourseName}");
                        data.Add($"Credits: {classDetails[i].Credits}");
                        data.Add($"MTG: {classDetails[i].MTG}");
                        data.Add($"FTG: {classDetails[i].FTG}");
                        data.Add($"FG: {classDetails[i].FG}");
                        data.Add($"TGP: {classDetails[i].TGP}");
                        data.Add($"ECR: {classDetails[i].ECR}");
                        data.Add($"GPA: {classDetails[i].GPA}");
                        data.Add($"CGPA: {classDetails[i].CGPA}");
                        data.Add($"STS: {classDetails[i].STS}");
                        data.Add($"PRN: {classDetails[i].PRN}");
                    }
                }
                else
                    data.Add("No class details found in the second table.");
                
            }
            else
                data.Add("Second table not found.");
            
        }

        private static async Task<List<string>> ScrapeRoutinePageAsync(HttpClient client, string routineUrl)
        {
            if (!_isConnected) return null;

            try
            {
                var routineHtml = await client.GetStringAsync(routineUrl);
                var routineDoc = new HtmlAgilityPack.HtmlDocument();
                routineDoc.LoadHtml(routineHtml);

                var routineData = new List<string>();
                ExtractRoutineData(routineDoc, routineData);

                return routineData;
            }
            catch (HttpRequestException ex)
            {
                MessageBox.Show($"Request error: {ex.Message}");
                return null;
            }
        }

        private static void ExtractRoutineData(HtmlAgilityPack.HtmlDocument doc, List<string> data)
        {
            var rows = doc.DocumentNode.SelectNodes("//table[@id='routine']//tr");

            if (rows != null)
            {
                foreach (var row in rows)
                {
                    var cells = row.SelectNodes("td");
                    if (cells != null && cells.Count > 0)
                        data.Add($"Routine Data: {string.Join(", ", cells.Select(cell => DecodeHtmlEntities(cell.InnerText.Trim())))}");
                    
                }
            }
            else
                data.Add("No routine data found.");
            
        }

        private static string DecodeHtmlEntities(string input)
        {
            var decodedString = WebUtility.HtmlDecode(input);
            return decodedString;
        }
    }
}
