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
            department_choosing_panel.Visible = true;
            course_chosing_panel.Visible = false;
            department_combobox.StartIndex = 0;
            course_datagridview.Visible = false;
            offered_courses_panel.Visible = false;

            department_warning_label.Visible = false;

            course_number_warning_label.Visible = false;
            course_number_textbox.Clear();

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
            if (String.IsNullOrWhiteSpace(input))
            {
                course_number_warning_label.Visible = true;
                course_number_warning_label.Text = "**Please Enter Course ID**";
                return;
            }

            try
            {
                List<int> completedCourses = ParseInput(input, dept);

                // Check for duplicate course IDs
                if (completedCourses.Count != completedCourses.Distinct().Count())
                {
                    course_number_warning_label.Text = "**Duplicate Course IDs Are Not Allowed**";
                    course_number_warning_label.Visible = true;
                    return;
                }

                if (!InvalidSequence(completedCourses))
                {
                    course_number_warning_label.Text = "**Invalid Course ID Sequence!**";
                    course_number_warning_label.Visible = true;
                    return;
                }

                int totalCreditCompleted = 0;
                foreach (int courseNum in completedCourses)
                {
                    if (courseNum >= 1 && courseNum <= allCourses.Count)
                        totalCreditCompleted += allCourses[courseNum - 1].CourseCredit;
                    else
                        outOfRange = true;
                }

                if (outOfRange || inValidFormat)
                {
                    if (inValidFormat)
                        course_number_warning_label.Text = "**Invalid Input Format**";
                    else if (outOfRange)
                        course_number_warning_label.Text = "**Invalid Input**";

                    core_courses_datagridview.Rows.Clear();
                    course_number_warning_label.Visible = true;
                    DepartmentChoose();

                    return;
                }

                int notCompletedPrerequisitCourseNumber;
                if (!ValidatePrerequisites(completedCourses, allCourses, totalCreditCompleted, out notCompletedPrerequisitCourseNumber))
                {
                    // Find the first course with incomplete prerequisites
                    notCompletedPrerequisitCourseNumber = FindCourseWithIncompletePrerequisites(completedCourses, allCourses);

                    course_number_warning_label.Text = $"Some Prerequisites are Not Completed.";
                    course_number_warning_label.Visible = true;

                    offered_courses_panel.Visible = false;
                    course_datagridview.Visible = true;
                    return;
                }

                congratulation_panel.Visible = false;
                course_number_warning_label.Visible = false;
                course_datagridview.Visible = false;

                if ((dept == 1 && totalCreditCompleted == 268) || (dept == 2 && totalCreditCompleted == 186) || (dept == 3 && totalCreditCompleted == 201) || (dept == 4 && totalCreditCompleted == 630))
                {
                    congratulation_panel.Visible = true;
                    return;
                }

                course_number_warning_label.Visible = false;
                course_datagridview.Visible = false;
                offered_courses_panel.Visible = true;

                course_heading_label.Text = $"Total credit completed: {totalCreditCompleted} \t\nRecommended courses you can take next semester";

                RecommendCourses(completedCourses, totalCreditCompleted);
            }
            catch (Exception ex)
            {
               // MessageBox.Show($"Function name is CourseDataUserInput and error: {ex.Message}");
                course_number_warning_label.Text = "Duplicate Course IDs are Not Allowed";
                course_number_warning_label.Visible = true;
            }
        }

        // Helper function to find the course with incomplete prerequisites
        private int FindCourseWithIncompletePrerequisites(List<int> completedCourses, List<Course> allCourses)
        {
            var completedCoursesSet = new HashSet<int>(completedCourses);

            for (int i = 0; i < allCourses.Count; i++)
            {
                if (!completedCoursesSet.Contains(i + 1))
                {
                    var prerequisites = allCourses[i].Prerequisites;
                    if (!prerequisites.All(prereq => completedCoursesSet.Contains(prereq)))
                    {
                        return i + 1;
                    }
                }
            }

            // No course found with incomplete prerequisites
            return -1;
        }
        // Helper function to parse input line into course numbers
        private List<int> ParseInput(string input, int dept)
        {
            List<int> courseNumbers = new List<int>();
            var parts = input.Split(new[] { ',', ' ' }, StringSplitOptions.RemoveEmptyEntries);
            outOfRange = false;
            inValidFormat = false;
            bool hasDuplicates = false;

            HashSet<int> uniqueNumbers = new HashSet<int>();

            foreach (var part in parts)
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
                                hasDuplicates = true;
                                break;
                            }
                            courseNumbers.Add(number);
                        }
                        else
                        {
                            outOfRange = true;
                            break;
                        }
                    }
                    else
                    {
                        var rangeParts = part.Split('-');
                        if (rangeParts.Length == 2 && int.TryParse(rangeParts[0].Trim(), out int start) && int.TryParse(rangeParts[1].Trim(), out int end))
                        {
                            for (int i = start; i <= end; i++)
                            {
                                if (IsValidCourseNumber(i, dept))
                                {
                                    if (!uniqueNumbers.Add(i))
                                    {
                                        hasDuplicates = true;
                                        break;
                                    }
                                    courseNumbers.Add(i);
                                }
                                else
                                {
                                    outOfRange = true;
                                    break;
                                }
                            }
                        }
                        else
                        {
                            inValidFormat = true;
                            break;
                        }
                    }
                }
                catch (FormatException)
                {
                    inValidFormat = true;
                    break;
                }
                catch (OverflowException)
                {
                    inValidFormat = true;
                    break;
                }

                if (hasDuplicates)
                    break;
                
            }

            if (hasDuplicates)
            {
                throw new ArgumentException("Duplicate course ID's are Not Allowed");
            }

            return courseNumbers;
        }
        private bool InvalidSequence(List<int> sequence)
        {
            for (int i = 1; i < sequence.Count; i++)
            {
                if (sequence[i] < sequence[i - 1])
                    return false;
                
            }
            return true;
        }

        private bool IsValidCourseNumber(int number, int dept)
        {
            return (dept == 1 && number <= 99) || (dept == 2 && number <= 74) || (dept == 3 && number <= 67) || (dept == 4 && number <= 211);
        }

        // Validate prerequisites for each inputted course
        private bool ValidatePrerequisites(List<int> completedCourses, List<Course> allCourses, int totalCreditCompleted, out int mess)
        {
            var completedCoursesSet = new HashSet<int>(completedCourses);

            foreach (int courseNum in completedCourses)
            {
                if (courseNum >= 1 && courseNum <= allCourses.Count)
                {
                    var course = allCourses[courseNum - 1];
                    var prerequisites = course.Prerequisites;

                    // Check if all prerequisites are completed
                    if (!prerequisites.All(prereq => completedCoursesSet.Contains(prereq)))
                    {
                        mess = courseNum;
                        return false;
                    }

                    // Check for "RESEARCH METHODOLOGY" course with less than 100 completed credits
                    if (departmentNumber == 1 && (course.Name == "RESEARCH METHODOLOGY" && totalCreditCompleted < 100)  || (course.Name == "INTERNSHIP" && totalCreditCompleted < 139) // CSE
                        || (departmentNumber == 2 && course.Name == "CAPSTONE PROJECT 1" && totalCreditCompleted < 105)  // EEE
                        || (departmentNumber == 2 && (course.CourseType == 2 || course.CourseType == 3) && totalCreditCompleted < 60) // English
                        || (departmentNumber == 4 && (course.Name == "INTERNSHIP" && totalCreditCompleted < 137))) // For bba
                    {
                        mess = courseNum;
                        return false;
                    }
                }
            }

            mess = 0;
            return true;
        }


        private void SetupElectiveDataGridViews()
        {
            if (departmentNumber == 1) // CSE (3 Major)
            {
                SetupDataGridView(elective1_courses_datagridview, "<b>Major in Information</b>", new int[] { 326, 58, 91 }, DataGridViewContentAlignment.MiddleCenter);
                SetupDataGridView(elective2_courses_datagridview, "<b>Major in Software Engineering</b>", new int[] { 326, 58, 91 }, DataGridViewContentAlignment.MiddleCenter);
                SetupDataGridView(elective3_courses_datagridview, "<b>Major in Computational Theory</b>", new int[] { 326, 58, 91 }, DataGridViewContentAlignment.MiddleCenter);
                SetupDataGridView(elective4_courses_datagridview, "<b>Major in Computer Engineering</b>", new int[] { 326, 58, 91 }, DataGridViewContentAlignment.MiddleCenter);
            }
            else if (departmentNumber == 2)  // EEE (1 Major)
                SetupDataGridView(elective1_courses_datagridview, "", new int[] { 417, 58 }, DataGridViewContentAlignment.MiddleCenter);
            
            else if (departmentNumber == 3) // English (2 Major)
            {
                SetupDataGridView(elective1_courses_datagridview, "<b>Major in Linguistics & TESL</b>  <br>First Major: Complete any 10 courses in Linguistics & TESL <br> Second Major: Complete any 6 courses in Linguistics & TESL <br>Minor: Complete any FOUR 4 courses in Linguistics & TESL", new int[] { 417, 58 }, DataGridViewContentAlignment.MiddleCenter);
                SetupDataGridView(elective2_courses_datagridview, "<b>Major In Literature</b> <br>First Major: Complete any 10 courses in Literature <br> Second Major: Complete any 6 courses in Literature <br>Minor: Complete any FOUR 4 courses in Literature", new int[] { 417, 58 }, DataGridViewContentAlignment.MiddleCenter);
            }

            else if (departmentNumber == 4) // BBA (13 major)
            {
                SetupDataGridView(elective1_courses_datagridview, "<b>Major in ACCOUNTING</b>", new int[] { 417, 58 }, DataGridViewContentAlignment.MiddleCenter);
                SetupDataGridView(elective2_courses_datagridview, "<b>Major In BUSINESS ANALYTICS (BA)</b>", new int[] { 417, 58 }, DataGridViewContentAlignment.MiddleCenter);
                SetupDataGridView(elective3_courses_datagridview, "<b>Major in BUSINESS ECONOMICS (BECO)</b>", new int[] {417, 58 }, DataGridViewContentAlignment.MiddleCenter);
                SetupDataGridView(elective4_courses_datagridview, "<b>Major In FINANCE (FIN)</b>", new int[] { 417, 58 }, DataGridViewContentAlignment.MiddleCenter);
                SetupDataGridView(elective5_courses_datagridview, "<b>Major in HUMAN RESOURCE MANAGEMENT (HRM)</b>", new int[] { 417, 58 }, DataGridViewContentAlignment.MiddleCenter);

                SetupDataGridView(elective6_courses_datagridview, "<b>Major In INNOVATION AND ENTREPRENEURSHIP DEVELOPMENT (IED)</b>", new int[] { 417, 58 }, DataGridViewContentAlignment.MiddleCenter);
                SetupDataGridView(elective7_courses_datagridview, "<b>Major in INTERNATIONAL BUSINESS (IB)</b>", new int[] { 417, 58 }, DataGridViewContentAlignment.MiddleCenter);
                SetupDataGridView(elective8_courses_datagridview, "<b>Major In INVESTMENT MANAGEMENT (IM)</b>", new int[] { 417, 58 }, DataGridViewContentAlignment.MiddleCenter);
                SetupDataGridView(elective9_courses_datagridview, "<b>Major in MANAGEMENT (MGT)</b>", new int[] { 417, 58 }, DataGridViewContentAlignment.MiddleCenter);
                SetupDataGridView(elective10_courses_datagridview, "<b>Major In  MANAGEMENT INFORMATION SYSTEMS (MIS)</b>", new int[] { 417, 58 }, DataGridViewContentAlignment.MiddleCenter);
                SetupDataGridView(elective11_courses_datagridview, "<b>Major in MARKETING (MKT)</b>", new int[] { 417, 58 }, DataGridViewContentAlignment.MiddleCenter);
                SetupDataGridView(elective12_courses_datagridview, "<b>Major In  TOURISM AND HOSPITALITY MANAGEMENT (THM)</b>", new int[] { 417, 58 }, DataGridViewContentAlignment.MiddleCenter);
                SetupDataGridView(elective13_courses_datagridview, "<b>Major In  OPERATIONS AND SUPPLY CHAIN MANAGEMENT (OSCM)</b>", new int[] { 417, 58 }, DataGridViewContentAlignment.MiddleCenter);

            }

           
        }

        private void ClearDataGridViews(Dictionary<int, (Guna2DataGridView, Guna2HtmlLabel)> courseTypeMappings)
        {


            foreach (var kvp in courseTypeMappings)
            {
                var (dgv, label) = kvp.Value;

                dgv.Rows.Clear();

                if (kvp.Key != 1)
                    dgv.Columns.Clear();
                
            }

        }

        private void SetupDataGridView(DataGridView dgv, string labelText, int[] columnWidths, DataGridViewContentAlignment alignment)
        {
            // Add columns
            dgv.Columns.Add("CourseName", "Course Name");
            dgv.Columns.Add("CourseCredit", "Credit");
            if (columnWidths.Length == 3)
                dgv.Columns.Add("CourseType", "Course Type");
            

            // Set properties
            dgv.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgv.Dock = DockStyle.Top;

            // Set column widths
            for (int i = 0; i < columnWidths.Length; i++)
            {
                dgv.Columns[i].Width = columnWidths[i];
                if (i > 0) // Center align second and third columns
                    dgv.Columns[i].DefaultCellStyle.Alignment = alignment;
                
            }

            // Set header alignment
            foreach (DataGridViewColumn column in dgv.Columns)
                column.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            

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

        private void HideAllDataGridViews(Dictionary<int, (Guna2DataGridView, Guna2HtmlLabel)> courseTypeMappings)
        {
            foreach (var (dgv, label) in courseTypeMappings.Values)
            {
                label.Visible = false;
                dgv.Visible = false;
            }
            
        }


        // Function to recommend courses based on prerequisites and completed courses
        private void RecommendCourses(List<int> completedCourses, int totalCreditCompleted)
        {
            try
            {
                var completedCoursesSet = new HashSet<int>(completedCourses);

                var courseTypeMappings = new Dictionary<int, (Guna2DataGridView, Guna2HtmlLabel)>
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

                ClearDataGridViews(courseTypeMappings);             // Clear existing rows and columns in DataGridViews

                SetupElectiveDataGridViews();
                HideAllDataGridViews(courseTypeMappings);
                recomended_courses_panel.Visible = true;



                var courseTypeIndexes = new Dictionary<int, int>();
                foreach (var key in courseTypeMappings.Keys)
                    courseTypeIndexes[key] = 1; // Initialize all indexes to 1


                for (int i = 0; i < allCourses.Count; i++)
                {
                    // Skip if course is already completed
                    if (completedCoursesSet.Contains(i + 1))
                        continue;

                    var prerequisites = allCourses[i].Prerequisites;

                    // Check if all prerequisites are completed

                    if (completedCoursesSet.Contains(i) || (!prerequisites.All(prereq => completedCoursesSet.Contains(prereq))) || ShouldSkipCourse(allCourses[i], totalCreditCompleted))
                        continue;


                    if (courseTypeMappings.TryGetValue(allCourses[i].CourseType, out var mapping))
                    {
                        var (dgv, label) = mapping;
                        int index = courseTypeIndexes[allCourses[i].CourseType];
                        AddCourseToDataGridView(dgv, ref index, allCourses[i], departmentNumber == 1 ? ((CseCourse)allCourses[i].CourseDept).ToString() : null);
                        courseTypeIndexes[allCourses[i].CourseType] = index; // Update the dictionary with the new index
                    }
                }


                //   AdjustAllDataGridViews();

                foreach (var (dgv, label) in courseTypeMappings.Values)
                {
                    AdjustDataGridViewHeight(dgv);
                    ToggleDataGridViewVisibility(dgv, label);
                    dgv.Refresh();
                }


                // Skip the first entry (core courses) when setting elective_courses_label visibility
                elective_courses_label.Visible = courseTypeMappings.Skip(1).Any(mapping => mapping.Value.Item1.Visible);
            }

            catch (Exception ex)
            {
                // MessageBox.Show($"Function: RecommendCourses and exception: {ex.Message}");
            }
            



        }

        // Method to add course details to the DataGridView
        private void AddCourseToDataGridView(DataGridView dgv, ref int index, Course course, string additionalInfo = null)
        {
            if (additionalInfo == null)
                dgv.Rows.Add($"{index++}. {course.Name}", $"{course.CourseCredit}");
            else
                dgv.Rows.Add($"{index++}. {course.Name}", $"{course.CourseCredit}", additionalInfo);
            
        }

        // Method to determine if a course should be skipped based on total credits completed
        private bool ShouldSkipCourse(Course course, int totalCreditCompleted)
        {
            return ((departmentNumber == 1 &&  (course.Name == "RESEARCH METHODOLOGY" && totalCreditCompleted < 100) || (course.Name == "INTERNSHIP" && totalCreditCompleted < 139)) ||
                    (departmentNumber == 2 && course.Name == "CAPSTONE PROJECT 1" && totalCreditCompleted < 105) ||
                    (departmentNumber == 3 && (course.CourseType == 2 || course.CourseType == 3) && totalCreditCompleted < 60) ||
                    (departmentNumber == 4 && (course.Name == "INTERNSHIP" && totalCreditCompleted < 137)));
        }

        // Method to toggle visibility of DataGridView and its corresponding label
        private void ToggleDataGridViewVisibility(DataGridView dgv, Guna2HtmlLabel label)
        {
            label.Visible = dgv.Visible = dgv.Rows.Count > 0;
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
