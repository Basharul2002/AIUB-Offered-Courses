using System;
using System.Windows.Forms;
using System.Threading.Tasks;

namespace AIUB_Offered_Course
{
    public partial class Online : UserControl
    {
        public Online()
        {
            InitializeComponent();
        }

        private async void login_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(id_tb.Text))
            {
                MessageBox.Show("Enter the id");
                return;
            }

            if (string.IsNullOrWhiteSpace(password_tb.Text))
            {
                MessageBox.Show("Enter the password");
                return;
            }

            try
            {
                // Call the asynchronous method and get the result
                var (gradeReportData, routineData) = await WebScraperInjector.Connection(id_tb.Text, password_tb.Text);

                if (gradeReportData != null)
                {
                    // Handle the grade report data
                    label1.Text = $"{gradeReportData[0]}\n"; 
                    label2.Text = $"{gradeReportData[1]}\n"; 
                    label3.Text = $"{gradeReportData[2]}\n"; 
                    label4.Text = $"{gradeReportData[3]}\n"; 
                    label5.Text = $"{gradeReportData[4]}\n"; 


                }

                if (routineData != null)
                {
                    /*
                    // Handle the routine data
                    for (int i = 0; i < routineData.Count; i++)

                        guna2TextBox2.Text = $"{item}\n"; // Or display in a suitable UI control
                    */

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}");
            }
        }
    }
}
