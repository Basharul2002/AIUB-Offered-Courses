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


        static bool outOfRange = false, inValidFormat = false;
        private int departmentNumber = 0;
        private List<Course> allCourses;

        // Define a class to hold course information
        class Course
        {
            public string Name { get; set; }
            public HashSet<int> Prerequisites { get; set; }
            public int CourseCredit { get; set; }
        }


        // Function to prompt the user to choose a department
        private void DepartmentOption()
        {
            if (department_combobox.Text == "CSE")
                departmentNumber = 1;

            else if (department_combobox.Text == "EEE")
                departmentNumber = 2;

            DepartmentChoose();
        }


        // Function to handle the department choice
        private void DepartmentChoose()
        {

            // department = department.ToUpper()

            if (departmentNumber == 1)
            {
                rightside_initial_state_panel.Visible = false;
                department_choosing_panel.Visible = false;
                course_chosing_panel.Visible = true;
                course_datagridview.Visible = true;
                offered_courses_panel.Visible = false;
                this.AcceptButton = completed_course_number_button;

                CseCourses();
                // RepeatExecution("1");
            }

            else if (departmentNumber == 2)
            {
                rightside_initial_state_panel.Visible = false;
                department_choosing_panel.Visible = false;
                course_chosing_panel.Visible = true;
                course_datagridview.Visible = true;
                offered_courses_panel.Visible = false;
                this.AcceptButton = completed_course_number_button;

                EeeCourses();
                // RepeatExecution("2");
            }

            else
                department_warning_label.Visible = true;
            
            // CseCourses();

            
        }

        // Function to handle CSE courses
        private void CseCourses()
        {
            allCourses = new List<Course>
                        {
                            // Semester 1
                            new Course { Name = "DIFFERENTIAL CALCULUS & CO-ORDINATE GEOMETRY", Prerequisites = new HashSet<int>(), CourseCredit = 3 },
                            new Course { Name = "PHYSICS 1", Prerequisites = new HashSet<int>(), CourseCredit = 3 },
                            new Course { Name = "PHYSICS 1 LAB", Prerequisites = new HashSet<int> { 2 }, CourseCredit = 1 },
                            new Course { Name = "ENGLISH READING SKILLS & PUBLIC SPEAKING", Prerequisites = new HashSet<int>(), CourseCredit = 3 },
                            new Course { Name = "INTRODUCTION TO PROGRAMMING", Prerequisites = new HashSet<int>(), CourseCredit = 3 },
                            new Course { Name = "INTRODUCTION TO PROGRAMMING LAB", Prerequisites = new HashSet<int> { 5 }, CourseCredit = 1 },
                            new Course { Name = "INTRODUCTION TO COMPUTER STUDIES", Prerequisites = new HashSet<int>(), CourseCredit = 1 },

                            // Semester 2
                            new Course { Name = "DISCRETE MATHEMATICS", Prerequisites = new HashSet<int> { 1, 5 }, CourseCredit = 3 },
                            new Course { Name = "INTEGRAL CALCULUS & ORDINARY DIFFERENTIAL EQUATIONS", Prerequisites = new HashSet<int> { 1 }, CourseCredit = 3 },
                            new Course { Name = "OBJECT ORIENTED PROGRAMMING 1", Prerequisites = new HashSet<int> { 5, 6 }, CourseCredit = 3 },
                            new Course { Name = "PHYSICS 2", Prerequisites = new HashSet<int> { 2 }, CourseCredit = 3 },
                            new Course { Name = "PHYSICS 2 LAB", Prerequisites = new HashSet<int> { 3 }, CourseCredit = 1 },
                            new Course { Name = "ENGLISH WRITING SKILLS & COMMUNICATION", Prerequisites = new HashSet<int> { 4 }, CourseCredit = 3 },
                            new Course { Name = "INTRODUCTION TO ELECTRICAL CIRCUITS", Prerequisites = new HashSet<int> { 2 }, CourseCredit = 3 },
                            new Course { Name = "INTRODUCTION TO ELECTRICAL CIRCUITS LAB", Prerequisites = new HashSet<int> { 3 }, CourseCredit = 1 },

                            // Semester 3
                            new Course { Name = "CHEMISTRY", Prerequisites = new HashSet<int> { 11 }, CourseCredit = 3 },
                            new Course { Name = "COMPLEX VARIABLE, LAPLACE & Z-TRANSFORMATION", Prerequisites = new HashSet<int> { 9 }, CourseCredit = 3 },
                            new Course { Name = "INTRODUCTION TO DATABASE", Prerequisites = new HashSet<int> { 10 }, CourseCredit = 3 },
                            new Course { Name = "ELECTRONIC DEVICES", Prerequisites = new HashSet<int> { 14 }, CourseCredit = 3 },
                            new Course { Name = "ELECTRONIC DEVICES LAB", Prerequisites = new HashSet<int> { 15 }, CourseCredit = 1 },
                            new Course { Name = "PRINCIPLES OF ACCOUNTING", Prerequisites = new HashSet<int> { 9 }, CourseCredit = 3 },
                            new Course { Name = "DATA STRUCTURE", Prerequisites = new HashSet<int> { 8, 10 }, CourseCredit = 3 },
                            new Course { Name = "DATA STRUCTURE LAB", Prerequisites = new HashSet<int> { 8, 10 }, CourseCredit = 1 },
                            new Course { Name = "COMPUTER AIDED DESIGN & DRAFTING", Prerequisites = new HashSet<int>(), CourseCredit = 1 },
                            new Course { Name = "ALGORITHMS", Prerequisites = new HashSet<int> { 22, 23 }, CourseCredit = 3 },
                            new Course { Name = "MATRICES, VECTORS, FOURIER ANALYSIS", Prerequisites = new HashSet<int> { 17 }, CourseCredit = 3 },
                            new Course { Name = "OBJECT ORIENTED PROGRAMMING 2", Prerequisites = new HashSet<int> { 10, 19 }, CourseCredit = 3 },
                            new Course { Name = "OBJECT ORIENTED ANALYSIS AND DESIGN", Prerequisites = new HashSet<int> { 20 }, CourseCredit = 3 },
                            new Course { Name = "BANGLADESH STUDIES", Prerequisites = new HashSet<int> { 6 }, CourseCredit = 3 },

                            // Semester 4
                            new Course { Name = "DIGITAL LOGIC AND CIRCUITS", Prerequisites = new HashSet<int> { 15 }, CourseCredit = 3 },
                            new Course { Name = "DIGITAL LOGIC AND CIRCUITS LAB", Prerequisites = new HashSet<int> { 16 }, CourseCredit = 1 },
                            new Course { Name = "COMPUTATIONAL STATISTICS AND PROBABILITY", Prerequisites = new HashSet<int> { 17 }, CourseCredit = 3 },
                            new Course { Name = "THEORY OF COMPUTATION", Prerequisites = new HashSet<int> { 25 }, CourseCredit = 3 },
                            new Course { Name = "PRINCIPLES OF ECONOMICS", Prerequisites = new HashSet<int> { 31 }, CourseCredit = 2 },
                            new Course { Name = "BUSINESS COMMUNICATION", Prerequisites = new HashSet<int> { 28 }, CourseCredit = 3 },
                            new Course { Name = "NUMERICAL METHODS FOR SCIENCE AND ENGINEERING", Prerequisites = new HashSet<int> { 25 }, CourseCredit = 3 },
                            new Course { Name = "DATA COMMUNICATION", Prerequisites = new HashSet<int> { 31, 32 }, CourseCredit = 3 },
                            new Course { Name = "MICROPROCESSOR AND EMBEDDED SYSTEM", Prerequisites = new HashSet<int> { 31, 32 }, CourseCredit = 3 },
                            new Course { Name = "SOFTWARE ENGINEERING", Prerequisites = new HashSet<int> { 27, 28 }, CourseCredit = 3 },
                            new Course { Name = "ARTIFICIAL INTELLIGENCE AND EXPERT SYS.", Prerequisites = new HashSet<int> { 25, 31 }, CourseCredit = 3 },
                            new Course { Name = "COMPUTER NETWORKS", Prerequisites = new HashSet<int> { 37 }, CourseCredit = 3 },
                            new Course { Name = "COMPUTER ORGANIZATION AND ARCHITECTURE", Prerequisites = new HashSet<int> { 38 }, CourseCredit = 3 },
                            new Course { Name = "OPERATING SYSTEM", Prerequisites = new HashSet<int> { 25, 38 }, CourseCredit = 3 },
                            new Course { Name = "WEB TECHNOLOGIES", Prerequisites = new HashSet<int> { 39 }, CourseCredit = 3 },
                            new Course { Name = "ENGINEERING ETHICS", Prerequisites = new HashSet<int> { 38, 39 }, CourseCredit = 2 },
                            new Course { Name = "COMPILER DESIGN", Prerequisites = new HashSet<int> { 32 }, CourseCredit = 3 },
                            new Course { Name = "COMPUTER GRAPHICS", Prerequisites = new HashSet<int> { 25, 26 }, CourseCredit = 3 },
                            new Course { Name = "ENGINEERING MANAGEMENT", Prerequisites = new HashSet<int> { 44 }, CourseCredit = 3 },
                            new Course { Name = "RESEARCH METHODOLOGY", Prerequisites = new HashSet<int>(), CourseCredit = 3 },
                            new Course { Name = "ADVANCE DATABASE MANAGEMENT SYSTEM", Prerequisites = new HashSet<int> { 18 }, CourseCredit = 3 },
                            new Course { Name = "BASIC MECHANICAL ENGG.", Prerequisites = new HashSet<int> { 11 }, CourseCredit = 3 },
                            new Course { Name = "COMPUTER SCIENCE MATHEMATICS", Prerequisites = new HashSet<int> { 25, 36 }, CourseCredit = 3 },
                            new Course { Name = "MANAGEMENT INFORMATION SYSTEM", Prerequisites = new HashSet<int> { 39 }, CourseCredit = 3 },
                            new Course { Name = "SIGNALS & LINEAR SYSTEM", Prerequisites = new HashSet<int> { 26 }, CourseCredit = 3 },
                            new Course { Name = "BASIC GRAPH THEORY", Prerequisites = new HashSet<int> { 25 }, CourseCredit = 3 },
                            new Course { Name = "DIGITAL SYSTEM DESIGN", Prerequisites = new HashSet<int> { 42 }, CourseCredit = 3 },
                            new Course { Name = "IMAGE PROCESSING", Prerequisites = new HashSet<int> { 47 }, CourseCredit = 3 },
                            new Course { Name = "MULTIMEDIA SYSTEMS", Prerequisites = new HashSet<int> { 44 }, CourseCredit = 3 },
                            new Course { Name = "SIMULATION & MODELING", Prerequisites = new HashSet<int> { 40 }, CourseCredit = 3 },
                            new Course { Name = "ENTERPRISE RESOURCE PLANNING", Prerequisites = new HashSet<int> { 39, 54 }, CourseCredit = 3 },
                            new Course { Name = "DATA WAREHOUSE AND DATA MINING", Prerequisites = new HashSet<int> { 83 }, CourseCredit = 3 },
                            new Course { Name = "NATURAL LANGUAGE PROCESSING", Prerequisites = new HashSet<int> { 40, 77 }, CourseCredit = 3 },
                            new Course { Name = "SOFTWARE DEVELOPMENT PROJECT MANAGEMENT", Prerequisites = new HashSet<int> { 67 }, CourseCredit = 3 },
                            new Course { Name = "HUMAN COMPUTER INTERACTION", Prerequisites = new HashSet<int> { 40, 44 }, CourseCredit = 3 },
                            new Course { Name = "ADVANCED COMPUTER NETWORKS", Prerequisites = new HashSet<int> { 41 }, CourseCredit = 3 },
                            new Course { Name = "SOFTWARE REQUIREMENT ENGINEERING", Prerequisites = new HashSet<int> { 39 }, CourseCredit = 3 },
                            new Course { Name = "COMPUTER VISION AND PATTERN RECOGNITION", Prerequisites = new HashSet<int> { 40, 47 }, CourseCredit = 3 },
                            new Course { Name = "LINEAR PROGRAMMING", Prerequisites = new HashSet<int> { 40, 32 }, CourseCredit = 3 },
                            new Course { Name = "NETWORK SECURITY", Prerequisites = new HashSet<int> { 41 }, CourseCredit = 3 },
                            new Course { Name = "SOFTWARE QUALITY AND TESTING", Prerequisites = new HashSet<int> { 67 }, CourseCredit = 3 },
                            new Course { Name = "ADVANCED OPERATING SYSTEM", Prerequisites = new HashSet<int> { 43 }, CourseCredit = 3 },
                            new Course { Name = "DIGITAL DESIGN WITH SYSTEM [VERILOG, VHDL & FPGAS]", Prerequisites = new HashSet<int> { 97 }, CourseCredit = 3 },
                            new Course { Name = "ROBOTICS ENGINEERING", Prerequisites = new HashSet<int> { 40 }, CourseCredit = 3 },
                            new Course { Name = "BUSINESS INTELLIGENCE AND DECISION SUPPORT", Prerequisites = new HashSet<int> { 61 }, CourseCredit = 3 },
                            new Course { Name = "TELECOMMUNICATIONS ENGINEERING", Prerequisites = new HashSet<int> { 37 }, CourseCredit = 3 },
                            new Course { Name = "PROGRAMMING IN PYTHON", Prerequisites = new HashSet<int> { 44 }, CourseCredit = 3 },
                            new Course { Name = "ADVANCED PROGRAMMING WITH JAVA", Prerequisites = new HashSet<int> { 44 }, CourseCredit = 3 },
                            new Course { Name = "ADVANCED PROGRAMMING WITH .NET", Prerequisites = new HashSet<int> { 44 }, CourseCredit = 3 },
                            new Course { Name = "ADVANCED PROGRAMMING IN WEB TECHNOLOGY", Prerequisites = new HashSet<int> { 44 }, CourseCredit = 3 },
                            new Course { Name = "ADVANCED ALGORITHM TECHNIQUES", Prerequisites = new HashSet<int> { 40 }, CourseCredit = 3 },
                            new Course { Name = "NETWORK RESOURCE MANAGEMENT & ORGANIZATION", Prerequisites = new HashSet<int> { 37, 41 }, CourseCredit = 3 },
                            new Course { Name = "INTRODUCTION TO DATA SCIENCE", Prerequisites = new HashSet<int> { 40 }, CourseCredit = 3 },
                            new Course { Name = "CYBER LAWS & INFORMATION SECURITY", Prerequisites = new HashSet<int> { 44 }, CourseCredit = 3 },
                            new Course { Name = "BIOINFORMATICS", Prerequisites = new HashSet<int> { 40 }, CourseCredit = 3 },
                            new Course { Name = "PARALLEL COMPUTING", Prerequisites = new HashSet<int> { 25, 40 }, CourseCredit = 3 },
                            new Course { Name = "MACHINE LEARNING", Prerequisites = new HashSet<int> { 40 }, CourseCredit = 3 },
                            new Course { Name = "WIRELESS SENSOR NETWORKS", Prerequisites = new HashSet<int> { 37, 41 }, CourseCredit = 3 },
                            new Course { Name = "INDUSTRIAL ELECTRONICS, DRIVES & INSTRUMENTATION", Prerequisites = new HashSet<int> { 30 }, CourseCredit = 3 },
                            new Course { Name = "MOBILE APPLICATION DEVELOPMENT", Prerequisites = new HashSet<int> { 44 }, CourseCredit = 3 },
                            new Course { Name = "SOFTWARE ARCHITECTURE AND DESIGN PATTERNS", Prerequisites = new HashSet<int> { 67 }, CourseCredit = 3 },
                            new Course { Name = "DIGITAL MARKETING", Prerequisites = new HashSet<int> { 44, 54 }, CourseCredit = 3 },
                            new Course { Name = "E-COMMERCE, E-GOVERNANCE & E-SERIES", Prerequisites = new HashSet<int> { 44 }, CourseCredit = 3 },
                            new Course { Name = "DIGITAL SIGNAL PROCESSING", Prerequisites = new HashSet<int> { 55 }, CourseCredit = 3 },
                            new Course { Name = "VLSI CIRCUIT DESIGN", Prerequisites = new HashSet<int> { 91 }, CourseCredit = 3 }
                        };

            PrintCourses(allCourses);
        }
       


        // Function to handle EEE courses
        private void EeeCourses()
        {
            allCourses = new List<Course>
            {
                // Semester 1
                new Course { Name = "CHEMISTRY", Prerequisites = new HashSet<int>(), CourseCredit = 3 },
                new Course { Name = "DIFFERENTIAL CALCULUS & CO-ORDINATE GEOMETRY", Prerequisites = new HashSet<int>(), CourseCredit = 3 },
                new Course { Name = "PHYSICS 1", Prerequisites = new HashSet<int>(), CourseCredit = 3 },
                new Course { Name = "PHYSICS 1 LAB", Prerequisites = new HashSet<int> { 3 }, CourseCredit = 1 },
                new Course { Name = "ENGLISH READING SKILLS & PUBLIC SPEAKING", Prerequisites = new HashSet<int>(), CourseCredit = 3 },
                new Course { Name = "INTRODUCTION TO ENGINEERING STUDIES", Prerequisites = new HashSet<int>(), CourseCredit = 1 },

                // Semester 2
                new Course { Name = "BASIC MECHANICAL ENGINEERING", Prerequisites = new HashSet<int> { 3 }, CourseCredit = 3 },
                new Course { Name = "ELECTICAL CIRCUIT-1 (DC)", Prerequisites = new HashSet<int> { 3, 5 }, CourseCredit = 3 },
                new Course { Name = "ELECTICAL CIRCUIT-1 (DC) LAB", Prerequisites = new HashSet<int> { 6, 4 }, CourseCredit = 1 },
                new Course { Name = "INTEGRAL CALCULUS & ORDINARY DIFFERENTIAL EQUATIONS", Prerequisites = new HashSet<int> { 2 }, CourseCredit = 3 },
                new Course { Name = "PHYSICS 2", Prerequisites = new HashSet<int> { 1, 3 }, CourseCredit = 3 },
                new Course { Name = "PHYSICS 2 LAB", Prerequisites = new HashSet<int> { 1, 4 }, CourseCredit = 1 },
                new Course { Name = "PRINCIPLE OF ACCOUNTING", Prerequisites = new HashSet<int> { 2 }, CourseCredit = 3 },
                new Course { Name = "ENGLISH WRITING SKILLS & COMMUNICATION", Prerequisites = new HashSet<int> { 4 }, CourseCredit = 3 },

                // Semester 3
                new Course { Name = "COMPLEX VARIABLE, LAPLACE & Z-TRANSFORMATION", Prerequisites = new HashSet<int> { 10 }, CourseCredit = 3 },
                new Course { Name = "ELECTRICAL CIRCUIT 2 (AC)", Prerequisites = new HashSet<int> { 3, 5 }, CourseCredit = 3 },
                new Course { Name = "ELECTRICAL CIRCUITS-2 (AC) LAB", Prerequisites = new HashSet<int> { 9 }, CourseCredit = 1 },
                new Course { Name = "ELECTRICAL MACHINES 1", Prerequisites = new HashSet<int> { 7, 16 }, CourseCredit = 3 },
                new Course { Name = "ELECTRICAL MACHINES 1 LAB", Prerequisites = new HashSet<int> { 7, 16 }, CourseCredit = 1 },
                new Course { Name = "ELECTRONIC DEVICES", Prerequisites = new HashSet<int> { 16 }, CourseCredit = 3 },
                new Course { Name = "ELECTRONIC DEVICES LAB", Prerequisites = new HashSet<int> { 17 }, CourseCredit = 1 },
                new Course { Name = "PROGRAMMING LANGUAGE 1 (STRUCTURED PROGRAMMING LANGUAGE)", Prerequisites = new HashSet<int> { 15 }, CourseCredit = 3 },
                new Course { Name = "BANGLADESH STUDIES", Prerequisites = new HashSet<int>(), CourseCredit = 3 },

                // Semester 4
                new Course { Name = "ELECTRICAL MACHINES 2", Prerequisites = new HashSet<int> { 18 }, CourseCredit = 3 },
                new Course { Name = "ELECTRICAL MACHINES 2 LAB", Prerequisites = new HashSet<int> { 19 }, CourseCredit = 1 },
                new Course { Name = "ELECTRICAL POWER TRANSMISSION & DISTRIBUTION", Prerequisites = new HashSet<int> { 18 }, CourseCredit = 3 },
                new Course { Name = "MATRICES, VECTORS, FOURIER ANALYSIS", Prerequisites = new HashSet<int> { 15 }, CourseCredit = 3 },
                new Course { Name = "SIGNALS & LINEAR SYSTEMS", Prerequisites = new HashSet<int> { 27 }, CourseCredit = 3 },
                new Course { Name = "ENGINEERING ETHICS AND ENVIRONMENTAL PROTECTION", Prerequisites = new HashSet<int> { 6 }, CourseCredit = 1 },
                new Course { Name = "ANALOG ELECTRONICS", Prerequisites = new HashSet<int> { 20 }, CourseCredit = 3 },
                new Course { Name = "ANALOG ELECTRONICS LAB", Prerequisites = new HashSet<int> { 21 }, CourseCredit = 1 },
                new Course { Name = "COMPUTER AIDED DESIGN & DRAFTING", Prerequisites = new HashSet<int> { 8 }, CourseCredit = 1 },

                // Semester 5
                new Course { Name = "MODERN PHYSICS", Prerequisites = new HashSet<int> { 11 }, CourseCredit = 3 },
                new Course { Name = "ELECTROMAGNETICS FIELDS AND WAVES", Prerequisites = new HashSet<int> { 7, 11 }, CourseCredit = 3 },
                new Course { Name = "PRINCIPLES OF ECONOMICS", Prerequisites = new HashSet<int> { 13 }, CourseCredit = 2 },
                new Course { Name = "DIGITAL LOGIC AND CIRCUITS", Prerequisites = new HashSet<int> { 20 }, CourseCredit = 3 },
                new Course { Name = "DIGITAL LOGIC AND CIRCUITS LAB", Prerequisites = new HashSet<int> { 21 }, CourseCredit = 1 },
                new Course { Name = "ENGINEERING SHOP", Prerequisites = new HashSet<int> { 30 }, CourseCredit = 1 },
                new Course { Name = "INDUSTRIAL ELECTRONICS AND DRIVES", Prerequisites = new HashSet<int> { 24 }, CourseCredit = 3 },
                new Course { Name = "INDUSTRIAL ELECTRONICS AND DRIVES LAB", Prerequisites = new HashSet<int> { 25 }, CourseCredit = 1 },
                new Course { Name = "DIGITAL SIGNAL PROCESSING", Prerequisites = new HashSet<int> { 27, 28 }, CourseCredit = 3 },

                // Semester 6
                new Course { Name = "ELECTRICAL PROPERTIES OF MATERIALS", Prerequisites = new HashSet<int> { 33 }, CourseCredit = 3 },
                new Course { Name = "PROGRAMMING LANGUAGE 2 (OBJECT ORIENTED PROGRAMMING LANGUAGE)", Prerequisites = new HashSet<int> { 22 }, CourseCredit = 3 },
                new Course { Name = "POWER SYSTEMS ANALYSIS", Prerequisites = new HashSet<int> { 26 }, CourseCredit = 3 },
                new Course { Name = "NUMERICAL METHODS FOR SCIENCE AND ENGINEERING", Prerequisites = new HashSet<int> { 27, 43 }, CourseCredit = 3 },
                new Course { Name = "COMPUTATIONAL STATISTICS AND PROBABILITY", Prerequisites = new HashSet<int> { 34 }, CourseCredit = 3 },
                new Course { Name = "PRINCIPLES OF COMMUNICATION", Prerequisites = new HashSet<int> { 34 }, CourseCredit = 3 },

                // Semester 7
                new Course { Name = "BUSINESS COMMUNICATION", Prerequisites = new HashSet<int> { 14 }, CourseCredit = 3 },
                new Course { Name = "ENGINEERING MANAGEMENT", Prerequisites = new HashSet<int> { 29 }, CourseCredit = 3 },
                new Course { Name = "MODERN CONTROL SYSTEMS", Prerequisites = new HashSet<int> { 28 }, CourseCredit = 3 },
                new Course { Name = "MODERN CONTROL SYSTEMS LAB", Prerequisites = new HashSet<int> { 28 }, CourseCredit = 1 },
                new Course { Name = "MICROPROCESSOR AND EMBEDDED SYSTEM", Prerequisites = new HashSet<int> { 41, 43 }, CourseCredit = 3 },

                // Semester 8
                new Course { Name = "INTERNSHIP/ SEMINAR/ WORKSHOP", Prerequisites = new HashSet<int> { 48 }, CourseCredit = 1 },
                new Course { Name = "ELECTRICAL SERVICES DESIGN LAB", Prerequisites = new HashSet<int> { 38 }, CourseCredit = 1 },
                new Course { Name = "TELECOMMUNICATIONS ENGINEERING", Prerequisites = new HashSet<int> { 47 }, CourseCredit = 3 },
                new Course { Name = "TELECOMMUNICATIONS ENGINEERING", Prerequisites = new HashSet<int> { 44 }, CourseCredit = 3 },
                new Course { Name = "MEASUREMENT AND INSTRUMENTATION", Prerequisites = new HashSet<int> { 50 }, CourseCredit = 3 },
                new Course { Name = "VLSI CIRCUIT DESIGN", Prerequisites = new HashSet<int> { 41 }, CourseCredit = 3 },
                new Course { Name = "CAPSTONE PROJECT", Prerequisites = new HashSet<int>(), CourseCredit = 3 }
            };

            PrintCourses(allCourses);
            // CourseDataUserInput(allCourses, 2);
        }


        // Function to print available courses
        private void PrintCourses(List<Course> courses)
        {
            // Clear existing columns (if any)
            course_datagridview.Rows.Clear();

            // Iterate through all courses
            for (int i = 0; i < courses.Count; i++)
            {
                // Add a new row to DataGridView for each course
                course_datagridview.Rows.Add
                (
                    $"{i + 1}" ,
                    $"{courses[i].Name} ", // Display course number and name
                    $"{courses[i].CourseCredit}"
                );
            }
       //     AdjustColumnWidths();
        }


        private void CourseDataUserInput(string line, List<Course> allCourses, int dept, bool error = false)
        {
            if (String.IsNullOrWhiteSpace(line))
            {
                course_number_warning_label.Visible = true;
                course_number_warning_label.Text = "**Please Enter Course ID**";
                return;
            }

            try
            {
                List<int> completedCourses = ParseInput(line, dept);

                int totalCreditCompleted = 0;
                foreach (int courseNum in completedCourses)
                {
                    if (courseNum >= 1 && courseNum <= allCourses.Count)
                    {
                        int index = courseNum - 1;
                        totalCreditCompleted += allCourses[index].CourseCredit;
                    }
                }

                if (!outOfRange && !inValidFormat)
                {
                    congratulation_panel.Visible = false;
                    course_number_warning_label.Visible = false;
                    course_datagridview.Visible = false;

                    if ((departmentNumber == 1 && totalCreditCompleted == 262) || (departmentNumber == 2 && totalCreditCompleted == 142))
                    {
                        congratulation_panel.Visible = true;
                        return;
                    }

                    course_number_warning_label.Visible = false;
                    course_datagridview.Visible = false;
                    offered_courses_panel.Visible = true;

                    course_heading_label.Text = $@"Total credit completed: {totalCreditCompleted}
Recommended courses you can take next semester";

                    RecommendCourses(allCourses, completedCourses, totalCreditCompleted);
                }

                else 
                {
                    if (outOfRange)
                        course_number_warning_label.Text = "**Invalid input**";
                    else 
                        course_number_warning_label.Text = "**Invalid input format**";

                    offered_courses_datagridview.Rows.Clear();
                    course_number_warning_label.Visible = true;

                    DepartmentChoose();
                }


            }
            catch (Exception ex)
            {
                course_number_warning_label.Text = "Invalid input format!";
                course_number_warning_label.Visible = true;
            }
        }

        // Helper function to parse input line into course numbers
        private List<int> ParseInput(string input, int dept)
        {
            List<int> courseNumbers = new List<int>();
            var parts = input.Split(new[] { ',', ' ' }, StringSplitOptions.RemoveEmptyEntries);
            outOfRange = false;

            foreach (var part in parts)
            {
                try
                {
                    if (!part.Contains('-'))
                    {
                        int number = int.Parse(part.Trim());
                        if (IsValidCourseNumber(number, dept))
                            courseNumbers.Add(number);
                        else
                        {
                            outOfRange = true;
                            break;
                        }
                    }
                    else
                    {
                        var rangeParts = part.Split('-');
                        if (rangeParts.Length == 2 &&
                            int.TryParse(rangeParts[0].Trim(), out int start) &&
                            int.TryParse(rangeParts[1].Trim(), out int end))
                        {
                            for (int i = start; i <= end; i++)
                            {
                                if (IsValidCourseNumber(i, dept))
                                    courseNumbers.Add(i);
                                
                                else
                                {
                                    outOfRange = true;
                                    break;
                                }
                            }
                        }
                        else
                        {
                            outOfRange = true;
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
            }

            return courseNumbers;
        }

        private bool IsValidCourseNumber(int number, int dept)
        {
            return (dept == 1 && number <= 94) || (dept == 2 && number <= 59);
        }

        // Function to recommend courses based on prerequisites and completed courses
        private void RecommendCourses(List<Course> allCourses, List<int> completedCourses,int totalCreditCompleted)
        {
            var completedCoursesSet = new HashSet<int>(completedCourses);

            // Clear existing rows in DataGridView
            offered_courses_datagridview.Rows.Clear();


            // Iterate through all courses
            for (int i = 0, j = 1; i < allCourses.Count; i++)
            {
                // Skip if course is already completed
                if (completedCoursesSet.Contains(i + 1))
                    continue;

                var prerequisites = allCourses[i].Prerequisites;

                // Check if all prerequisites are completed
                if (prerequisites.All(prereq => completedCoursesSet.Contains(prereq)))
                {
                    // Skip "RESEARCH METHODOLOGY" and "CAPSTONE PROJECT" if total credits completed < 100
                    if ((allCourses[i].Name == "RESEARCH METHODOLOGY" || allCourses[i].Name == "CAPSTONE PROJECT") && totalCreditCompleted < 100)
                    {
                        continue;
                    }

                    // Add a new row to DataGridView for recommended course
                    offered_courses_datagridview.Rows.Add
                    (
                        $"{j++}. {allCourses[i].Name}", // Display course number and name
                        $"{allCourses[i].CourseCredit}"
                        
                    );

                }
            }
        }

        private void department_choose_button_Click(object sender, EventArgs e)
        {
            DepartmentOption();
        }

        private void completed_course_button_Click(object sender, EventArgs e)
        {
            inValidFormat = false;
            outOfRange = false;
            CourseDataUserInput(course_number_textbox.Text, allCourses, departmentNumber);
        }

        private void back_button_Click(object sender, EventArgs e)
        {
            DepartmentEnviroment();
        }

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
        }



        private void CourseSolution_KeyDown(object sender, KeyEventArgs e)
        {

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
    }
}