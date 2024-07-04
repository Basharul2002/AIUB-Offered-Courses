using Guna.UI2.WinForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ToolTip;

namespace AIUB_Offered_Course
{
    public partial class CourseSolution : Form
    {
        public CourseSolution()
        {
            InitializeComponent();

            this.AcceptButton = department_choose_button;
            this.KeyPreview = true;
        }

        static bool outOfRange = false, inValidFormat = false, inValidNumber = false;
        private int departmentNumber = 0;
        private List<Course> allCourses;


        private enum CseCourse
        {
            CSC,
            COE,
            EEE,
            MIS,
            BAE
        }


        // Function to prompt the user to choose a department
        private void DepartmentOption()
        {
            departmentNumber = Int32.Parse(department_combobox.SelectedIndex.ToString());

            // if department number is 0 that means department is not selected
            if (departmentNumber == 0)
            {
                department_warning_label.Visible = true;
                return;
            }

            // if any deoartment selected than perform this function
            DepartmentChoose();
        }

        // Function to handle the department choice
        private void DepartmentChoose()
        {
            rightside_initial_state_panel.Visible = false;
            department_choosing_panel.Visible = false;
            course_chosing_panel.Visible = true;
            course_datagridview.Visible = true;
            offered_courses_panel.Visible = false;
            elective_courses_label.Visible = false;
            completed_course_number_button.Focus();
            this.AcceptButton = completed_course_number_button;
            GetPreviousControl(course_chosing_panel);

            if (departmentNumber == 1)
                PrintCourses(CourseManager.CseCourses());
            else if (departmentNumber == 2)
                PrintCourses(CourseManager.EeeCourses());
            else if (departmentNumber == 3)
                PrintCourses(CourseManager.EnglishCourses());
            else if (departmentNumber == 4)
                PrintCourses(CourseManager.BBACourses()); 
        }

        // For comeback department choosing another panel 
        private void DepartmentEnviroment()
        {
            congratulation_panel.Visible = false;
            rightside_initial_state_panel.Visible = true;
           
            course_chosing_panel.Visible = false;
            department_combobox.StartIndex = 0;
            course_datagridview.Visible = false;
            offered_courses_panel.Visible = false;

            department_warning_label.Visible = false;

            course_number_warning_label.Visible = false;
            course_number_textbox.Clear();

            

            department_choosing_panel.Visible = true;
            this.AcceptButton = department_choose_button;

            departmentNumber = 0;
            inValidNumber = false;
        }


        // Function to print available courses
        private void PrintCourses(List<Course> courses)
        {
            allCourses  = courses;
            // Clear existing columns (if any)
            course_datagridview.Rows.Clear();

            // Iterate through all courses
            for (int i = 0; i < courses.Count; i++)
            {
                // Add a new row(Course ID, Name, Number of credit) to DataGridView for each course
                course_datagridview.Rows.Add
                (
                    $"{i + 1}" ,
                    $"{courses[i].Name} ", 
                    $"{courses[i].CourseCredit}"
                );
            }
        }


        // Proceses user input (Course numbers)
        private void CourseDataUserInput(string input, int dept, bool error = false)
        {
            congratulation_panel.Visible = false;
            course_number_warning_label.Visible = false;
            course_datagridview.Visible = false;

            if (string.IsNullOrWhiteSpace(input))
            {
                DisplayWarning("**Please Enter Course ID**");
                return;
            }

            try
            {
                List<int> completedCourses = ParseInput(input, dept);

                if (completedCourses.Count != completedCourses.Distinct().Count())
                {
                    DisplayWarning("**Duplicate Course IDs Are Not Allowed**");
                    return;
                }

                if (!IsValidSequence(completedCourses))
                {
                    DepartmentChoose();
                    DisplayWarning("**Invalid Course ID Sequence!**");
                    return;
                }

                int totalCreditCompleted = CalculateTotalCredits(completedCourses);
                if (outOfRange || inValidFormat)
                {
                    DisplayWarning(outOfRange ? "**Invalid Input**" : "**Invalid Input Format**");
                    core_courses_datagridview.Rows.Clear();
                    DepartmentChoose();
                    return;
                }

                if (!ValidatePrerequisites(completedCourses, out int notCompletedCourseNumber, out int notCompletedPrerequisiteCourseNumber))
                {
                    DisplayWarning($"Prerequisite Not Completed for <br>{allCourses[notCompletedCourseNumber - 1].Name} : <br>{allCourses[notCompletedPrerequisiteCourseNumber - 1].Name}");
                    offered_courses_panel.Visible = false;
                    course_datagridview.Visible = true;
                    return;
                }

                if (IsGraduationEligible(dept, totalCreditCompleted))
                {
                    congratulation_panel.Visible = true;
                    return;
                }

                DisplayRecommendedCourses(completedCourses, totalCreditCompleted);
            }
            catch (Exception)
            {
                DisplayWarning("**Duplicate Course IDs are Not Allowed**");
            }
        }

        private void DisplayWarning(string message)
        {
            course_number_warning_label.Text = message;
            course_number_warning_label.Visible = true;
        }

        private List<int> ParseInput(string input, int dept)
        {
            List<int> courseNumbers = new List<int>();
            var parts = input.Split(new[] { ',', ' ' }, StringSplitOptions.RemoveEmptyEntries);
            outOfRange = false;
            inValidFormat = false;

            HashSet<int> uniqueNumbers = new HashSet<int>();

            foreach (var part in parts)
            {
                if (!TryParseCoursePart(part, dept, uniqueNumbers, courseNumbers))
                {
                    break;
                }
            }

            return courseNumbers;
        }

        private bool TryParseCoursePart(string part, int dept, HashSet<int> uniqueNumbers, List<int> courseNumbers)
        {
            try
            {
                if (!part.Contains('-'))
                {
                    int number = int.Parse(part.Trim());
                    if (IsValidCourseNumber(number, dept))
                    {
                        if (!uniqueNumbers.Add(number))
                        {
                            DepartmentChoose();
                            DisplayWarning("**Duplicate Course IDs Are Not Allowed**");
                            //throw new ArgumentException("Duplicate course ID's are Not Allowed");
                        }
                        courseNumbers.Add(number);
                    }
                    else
                    {
                        outOfRange = true;
                        return false;
                    }
                }
                else
                {
                    if (!TryParseRange(part, dept, uniqueNumbers, courseNumbers))
                        return false;
                    
                }
            }
            catch
            {
                inValidFormat = true;
                return false;
            }

            return true;
        }

        private bool TryParseRange(string part, int dept, HashSet<int> uniqueNumbers, List<int> courseNumbers)
        {
            var rangeParts = part.Split('-');
            if (rangeParts.Length == 2 && int.TryParse(rangeParts[0].Trim(), out int start) && int.TryParse(rangeParts[1].Trim(), out int end))
            {
                for (int i = start; i <= end; i++)
                {
                    if (IsValidCourseNumber(i, dept))
                    {
                        if (!uniqueNumbers.Add(i))
                            throw new ArgumentException("Duplicate course ID's are Not Allowed");
                        
                        courseNumbers.Add(i);
                    }
                    else
                    {
                        outOfRange = true;
                        return false;
                    }
                }
            }
            else
            {
                inValidFormat = true;
                return false;
            }

            return true;
        }

        private bool IsValidSequence(List<int> sequence)
        {
            for (int i = 1; i < sequence.Count; i++)
            {
                if (sequence[i] < sequence[i - 1])
                    return false;   
            }
            return true;
        }

        private int CalculateTotalCredits(List<int> completedCourses)
        {
            int totalCreditCompleted = 0;
            foreach (int courseNum in completedCourses)
            {
                if (courseNum >= 1 && courseNum <= allCourses.Count)
                    totalCreditCompleted += allCourses[courseNum - 1].CourseCredit;
                else
                    outOfRange = true;
                
            }
            course_heading_label.Text = $"Total credit completed : {totalCreditCompleted}\r\nAvailable courses you can take next semester: ";
            return totalCreditCompleted;
        }

        private bool ValidatePrerequisites(List<int> completedCourses, out int courseNumber, out int incompleteCourseNumber)
        {
            var completedCoursesSet = new HashSet<int>(completedCourses);

            foreach (int courseNum in completedCourses)
            {
                if (courseNum >= 1 && courseNum <= allCourses.Count)
                {
                    var course = allCourses[courseNum - 1];
                    var incompletePrerequisite = course.Prerequisites.FirstOrDefault(prereq => !completedCoursesSet.Contains(prereq));

                    if (incompletePrerequisite != 0 || ShouldSkipCourse(course, CalculateTotalCredits(completedCourses)))
                    {
                        courseNumber = courseNum;
                        incompleteCourseNumber = incompletePrerequisite;
                        return false;
                    }
                }
            }

            courseNumber = 0;
            incompleteCourseNumber = 0;
            return true;
        }

        private bool ShouldSkipCourse(Course course, int totalCreditCompleted)
        {
            return ((departmentNumber == 1 && (course.Name == "RESEARCH METHODOLOGY" && totalCreditCompleted < 100) || (course.Name == "INTERNSHIP" && totalCreditCompleted < 139)) ||
                    (departmentNumber == 2 && course.Name == "CAPSTONE PROJECT 1" && totalCreditCompleted < 105) ||
                    (departmentNumber == 3 && (course.CourseType == 2 || course.CourseType == 3) && totalCreditCompleted < 60) ||
                    (departmentNumber == 4 && (course.Name == "Internship" && totalCreditCompleted < 137) || (totalCreditCompleted < 70 && course.CourseType != 1)));
        }

        private bool IsGraduationEligible(int dept, int totalCreditCompleted)
        {
            return (dept == 1 && totalCreditCompleted == 268) ||
                   (dept == 2 && totalCreditCompleted == 186) ||
                   (dept == 3 && totalCreditCompleted == 201) ||
                   (dept == 4 && totalCreditCompleted == 630);
        }

        private void DisplayRecommendedCourses(List<int> completedCourses, int totalCreditCompleted)
        {
            offered_courses_panel.Visible = true;
            recomended_courses_panel.Visible = true;

            var courseTypeMappings = GetCourseTypeMappings();
            ClearDataGridViews(courseTypeMappings);
            HideAllDataGridViews(courseTypeMappings);

            SetupElectiveDataGridViews();


            var completedCoursesSet = new HashSet<int>(completedCourses);
            var courseTypeIndexes = InitializeCourseTypeIndexes(courseTypeMappings);

            foreach (var course in allCourses)
            {
                if (completedCoursesSet.Contains(allCourses.IndexOf(course) + 1))
                    continue;

                bool allPrerequisitesCompleted = course.Prerequisites.All(prereq => completedCoursesSet.Contains(prereq));
                if (!allPrerequisitesCompleted || ShouldSkipCourse(course, totalCreditCompleted))
                    continue;

                AddCourseToMapping(courseTypeMappings, courseTypeIndexes, course);
            }

            AdjustAllDataGridViews(courseTypeMappings);
            elective_courses_label.Visible = courseTypeMappings.Skip(1).Any(mapping => mapping.Value.Item1.Visible);
        }

        private Dictionary<int, (Guna2DataGridView, Guna2HtmlLabel)> GetCourseTypeMappings()
        {
            return new Dictionary<int, (Guna2DataGridView, Guna2HtmlLabel)>
            {
                { 1, (core_courses_datagridview, core_courses_label) },
                { 2, (elective1_courses_datagridview, elective1_courses_label) },
                { 3, (elective2_courses_datagridview, elective2_courses_label) },
                { 4, (elective3_courses_datagridview, elective3_courses_label) },
                { 5, (elective4_courses_datagridview, elective4_courses_label) },
                { 6, (elective5_courses_datagridview, elective5_courses_label) },
                { 7, (elective6_courses_datagridview, elective6_courses_label) },
                { 8, (elective7_courses_datagridview, elective7_courses_label) },
                { 9, (elective8_courses_datagridview, elective8_courses_label) },
                { 10, (elective9_courses_datagridview, elective9_courses_label) },
                { 11, (elective10_courses_datagridview, elective10_courses_label) },
                { 12, (elective11_courses_datagridview, elective11_courses_label) },
                { 13, (elective12_courses_datagridview, elective12_courses_label) },
                { 14, (elective13_courses_datagridview, elective13_courses_label) }
            };
        }

        private void ClearDataGridViews(Dictionary<int, (Guna2DataGridView, Guna2HtmlLabel)> courseTypeMappings)
        {
            foreach (var mapping in courseTypeMappings)
            {
                mapping.Value.Item1.Rows.Clear();
                mapping.Value.Item1.Columns.Clear();
            }

        }

        private void HideAllDataGridViews(Dictionary<int, (Guna2DataGridView, Guna2HtmlLabel)> courseTypeMappings)
        {
            foreach (var mapping in courseTypeMappings)
            {
                mapping.Value.Item1.Visible = false;
                mapping.Value.Item2.Visible = false;
            }
        }

        private void SetupElectiveDataGridViews()
        {
            SetupDataGridView(core_courses_datagridview, "Core courses", new int[] { 417, 58 }, DataGridViewContentAlignment.MiddleCenter);
            if (departmentNumber == 1) // CSE (3 Majors)
            {
                SetupDataGridView(elective1_courses_datagridview, "<b>Major in Information</b>", new int[] { 326, 58, 91 }, DataGridViewContentAlignment.MiddleCenter);
                SetupDataGridView(elective2_courses_datagridview, "<b>Major in Software Engineering</b>", new int[] { 326, 58, 91 }, DataGridViewContentAlignment.MiddleCenter);
                SetupDataGridView(elective3_courses_datagridview, "<b>Major in Computational Theory</b>", new int[] { 326, 58, 91 }, DataGridViewContentAlignment.MiddleCenter);
                SetupDataGridView(elective4_courses_datagridview, "<b>Major in Computer Engineering</b>", new int[] { 326, 58, 91 }, DataGridViewContentAlignment.MiddleCenter);
            }
            else if (departmentNumber == 2) // EEE (1 Major)
            {
                SetupDataGridView(elective1_courses_datagridview, "", new int[] { 417, 58 }, DataGridViewContentAlignment.MiddleCenter);
            }
            else if (departmentNumber == 3) // English (2 Majors)
            {
                SetupDataGridView(elective1_courses_datagridview, "<b>Major in Linguistics & TESL</b>  <br>First Major: Complete any 10 courses in Linguistics & TESL <br> Second Major: Complete any 6 courses in Linguistics & TESL <br>Minor: Complete any FOUR 4 courses in Linguistics & TESL", new int[] { 417, 58 }, DataGridViewContentAlignment.MiddleCenter);
                SetupDataGridView(elective2_courses_datagridview, "<b>Major In Literature</b> <br>First Major: Complete any 10 courses in Literature <br> Second Major: Complete any 6 courses in Literature <br>Minor: Complete any FOUR 4 courses in Literature", new int[] { 417, 58 }, DataGridViewContentAlignment.MiddleCenter);
            }
            else if (departmentNumber == 4) // BBA (13 Majors)
            {
                SetupDataGridView(elective1_courses_datagridview, "<b>Major in ACCOUNTING</b>", new int[] { 417, 58 }, DataGridViewContentAlignment.MiddleCenter);
                SetupDataGridView(elective2_courses_datagridview, "<b>Major In BUSINESS ANALYTICS (BA)</b>", new int[] { 417, 58 }, DataGridViewContentAlignment.MiddleCenter);
                SetupDataGridView(elective3_courses_datagridview, "<b>Major in BUSINESS ECONOMICS (BECO)</b>", new int[] { 417, 58 }, DataGridViewContentAlignment.MiddleCenter);
                SetupDataGridView(elective4_courses_datagridview, "<b>Major In FINANCE (FIN)</b>", new int[] { 417, 58 }, DataGridViewContentAlignment.MiddleCenter);
                SetupDataGridView(elective5_courses_datagridview, "<b>Major in HUMAN RESOURCE MANAGEMENT (HRM)</b>", new int[] { 417, 58 }, DataGridViewContentAlignment.MiddleCenter);
                SetupDataGridView(elective6_courses_datagridview, "<b>Major In INNOVATION AND ENTREPRENEURSHIP DEVELOPMENT (IED)</b>", new int[] { 417, 58 }, DataGridViewContentAlignment.MiddleCenter);
                SetupDataGridView(elective7_courses_datagridview, "<b>Major in INTERNATIONAL BUSINESS (IB)</b>", new int[] { 417, 58 }, DataGridViewContentAlignment.MiddleCenter);
                SetupDataGridView(elective8_courses_datagridview, "<b>Major In INVESTMENT MANAGEMENT (IM)</b>", new int[] { 417, 58 }, DataGridViewContentAlignment.MiddleCenter);
                SetupDataGridView(elective9_courses_datagridview, "<b>Major in MANAGEMENT (MGT)</b>", new int[] { 417, 58 }, DataGridViewContentAlignment.MiddleCenter);
                SetupDataGridView(elective10_courses_datagridview, "<b>Major In MANAGEMENT INFORMATION SYSTEMS (MIS)</b>", new int[] { 417, 58 }, DataGridViewContentAlignment.MiddleCenter);
                SetupDataGridView(elective11_courses_datagridview, "<b>Major in MARKETING (MKT)</b>", new int[] { 417, 58 }, DataGridViewContentAlignment.MiddleCenter);
                SetupDataGridView(elective12_courses_datagridview, "<b>Major In TOURISM AND HOSPITALITY MANAGEMENT (THM)</b>", new int[] { 417, 58 }, DataGridViewContentAlignment.MiddleCenter);
                SetupDataGridView(elective13_courses_datagridview, "<b>Major In OPERATIONS AND SUPPLY CHAIN MANAGEMENT (OSCM)</b>", new int[] { 417, 58 }, DataGridViewContentAlignment.MiddleCenter);
            }
        }

        private void SetupDataGridView(DataGridView dgv, string labelText, int[] columnWidths, DataGridViewContentAlignment alignment)
        {
            // Clear existing columns
            dgv.Columns.Clear();

            // Add columns
            dgv.Columns.AddRange
            (
                new DataGridViewTextBoxColumn { Name = "CourseName", HeaderText = "Course Name", AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill },
                new DataGridViewTextBoxColumn { Name = "CourseCredit", HeaderText = "Credit", Width = columnWidths[1] }
            );


            // Add CourseType column conditionally
            if (columnWidths.Length == 3)
            {
                dgv.Columns.Add
                (
                    new DataGridViewTextBoxColumn { Name = "CourseType", HeaderText = "Course Type", Width = columnWidths[2] }
                );
            }
                
            

            // Set properties
            dgv.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.None; // Ensure automatic sizing is off
            dgv.Dock = DockStyle.Top;

            // Set header alignment for all columns
            foreach (DataGridViewColumn column in dgv.Columns)
                column.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;


            // Set default cell style alignment
            dgv.Columns["CourseCredit"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            if (columnWidths.Length == 3)
                dgv.Columns["CourseType"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            

            // Set the label text
            SetLabelText(dgv, labelText);
        }

        private void SetLabelText(DataGridView dgv, string labelText)
        {
            // Set the label text
            if (dgv == elective1_courses_datagridview)
            {
                elective1_courses_label.Text = labelText;
                elective1_courses_label.AutoSize = true;
            }
            else if (dgv == elective2_courses_datagridview)
            {
                elective2_courses_label.Text = labelText;
                elective2_courses_label.AutoSize = true;
            }
            else if (dgv == elective3_courses_datagridview)
            {
                elective3_courses_label.Text = labelText;
                elective3_courses_label.AutoSize = true;
            }
            else if (dgv == elective4_courses_datagridview)
            {
                elective4_courses_label.Text = labelText;
                elective4_courses_label.AutoSize = true;
            }
            else if (dgv == elective5_courses_datagridview)
            {
                elective5_courses_label.Text = labelText;
                elective5_courses_label.AutoSize = true;
            }
            else if (dgv == elective6_courses_datagridview)
            {
                elective6_courses_label.Text = labelText;
                elective6_courses_label.AutoSize = true;
            }
            else if (dgv == elective7_courses_datagridview)
            {
                elective7_courses_label.Text = labelText;
                elective7_courses_label.AutoSize = true;
            }
            else if (dgv == elective8_courses_datagridview)
            {
                elective8_courses_label.Text = labelText;
                elective8_courses_label.AutoSize = true;
            }
            else if (dgv == elective9_courses_datagridview)
            {
                elective9_courses_label.Text = labelText;
                elective9_courses_label.AutoSize = true;
            }
            else if (dgv == elective10_courses_datagridview)
            {
                elective10_courses_label.Text = labelText;
                elective10_courses_label.AutoSize = true;
            }
            else if (dgv == elective11_courses_datagridview)
            {
                elective11_courses_label.Text = labelText;
                elective11_courses_label.AutoSize = true;
            }
            else if (dgv == elective12_courses_datagridview)
            {
                elective12_courses_label.Text = labelText;
                elective12_courses_label.AutoSize = true;
            }
            else if (dgv == elective13_courses_datagridview)
            {
                elective13_courses_label.Text = labelText;
                elective13_courses_label.AutoSize = true;
            }

        }


        private Dictionary<int, int> InitializeCourseTypeIndexes(Dictionary<int, (Guna2DataGridView, Guna2HtmlLabel)> courseTypeMappings)
        {
            var courseTypeIndexes = new Dictionary<int, int>();
            foreach (var key in courseTypeMappings.Keys)
                courseTypeIndexes[key] = 1;
            

            return courseTypeIndexes;
        }

        private void AddCourseToMapping(Dictionary<int, (Guna2DataGridView, Guna2HtmlLabel)> courseTypeMappings, Dictionary<int, int> courseTypeIndexes, Course course)
        {
            int courseType = course.CourseType;
            var (dataGridView, label) = courseTypeMappings[courseType];
            int courseIndex = courseTypeIndexes[courseType];

            
            if(departmentNumber == 1)
                dataGridView.Rows.Add($"{courseIndex} {course.Name}", course.CourseCredit, (CseCourse)course.CourseType-1);

            else
                dataGridView.Rows.Add($"{courseIndex} {course.Name}", course.CourseCredit);
            dataGridView.Visible = true;
            label.Visible = true;

            courseTypeIndexes[courseType]++;
        }

        private void AdjustAllDataGridViews(Dictionary<int, (Guna2DataGridView, Guna2HtmlLabel)> courseTypeMappings)
        {
            foreach (var mapping in courseTypeMappings)
            {
                if (mapping.Value.Item1.Visible)
                    AdjustDataGridView(mapping.Value.Item1);
                
            }
        }

        private void AdjustDataGridView(Guna2DataGridView dataGridView)
        {
            dataGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.None;
            dataGridView.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            dataGridView.AutoResizeColumns();
            dataGridView.AutoResizeRows();

            AdjustDataGridViewHeight(dataGridView);
        }

        private bool IsValidCourseNumber(int number, int dept)
        {
            return number >= 1 && number <= (dept == 1 ? 269 : dept == 2 ? 187 : dept == 3 ? 202 : 631);
        }

        // Other supporting methods (SetupElectiveDataGridViews, AdjustAllDataGridViews, etc.) remain the same
        private void AdjustDataGridViewHeight(DataGridView dataGridView)
        {
            int rowHeight = dataGridView.RowTemplate.Height;
            int headerHeight = dataGridView.ColumnHeadersHeight;
            dataGridView.Height = (dataGridView.Rows.Count * rowHeight) + headerHeight + 20;
        }


        private Control GetPreviousControl(Control currentControl)
        {
            Control previousControl = null;
            Control.ControlCollection controls = this.Controls;

            for (int i = 0; i < controls.Count; i++)
            {
                if (controls[i] == currentControl)
                {
                    if (i > 0)
                        previousControl = controls[i - 1];

                    break;
                }
            }

            return previousControl;
        }

        // Action listener perform for after department choosed
        private void department_choose_button_Click(object sender, EventArgs e)
        {
            DepartmentOption();
        }

        private void refresh_button_Click(object sender, EventArgs e)
        {
            course_number_warning_label.Visible = false;
            core_courses_datagridview.Rows.Clear();
            course_number_textbox.Text = string.Empty;
            DepartmentChoose();

            return;
        }

        // Action listener perform for offered courses
        private void completed_course_button_Click(object sender, EventArgs e)
        {
            inValidFormat = false;
            outOfRange = false;
            inValidNumber = false;
            CourseDataUserInput(course_number_textbox.Text, departmentNumber);
        }

        // To return in 
        private void back_button_Click(object sender, EventArgs e)
        {
            DepartmentEnviroment();
        }
    }
}
