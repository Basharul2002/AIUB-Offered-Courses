using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace AIUB_Offered_Course
{
    internal class CourseManager
    {

        // Function to handle CSE courses
        public static List<Course> CseCourses()
        {
            return new List<Course>
                        {
                            // Semester 1
                            new Course { Id = 1, Name = "DIFFERENTIAL CALCULUS & CO-ORDINATE GEOMETRY", Prerequisites = new HashSet<int>(), CourseCredit = 3, CourseType = 1}, // 1
                            new Course { Id = 2, Name = "PHYSICS 1", Prerequisites = new HashSet<int>(), CourseCredit = 3, CourseType = 1 }, // 2
                            new Course { Id = 3, Name = "PHYSICS 1 LAB", Prerequisites = new HashSet<int>(), CourseCredit = 1, CourseType = 1 }, // 3
                            new Course { Id = 4, Name = "ENGLISH READING SKILLS & PUBLIC SPEAKING", Prerequisites = new HashSet<int>(), CourseCredit = 3, CourseType = 1 }, // 4
                            new Course { Id = 5, Name = "INTRODUCTION TO PROGRAMMING", Prerequisites = new HashSet<int>(), CourseCredit = 3, CourseType = 1 }, // 5
                            new Course { Id = 6, Name = "INTRODUCTION TO PROGRAMMING LAB", Prerequisites = new HashSet<int>(), CourseCredit = 1, CourseType = 1 }, // 6
                            new Course { Id = 7, Name = "INTRODUCTION TO COMPUTER STUDIES", Prerequisites = new HashSet<int>(), CourseCredit = 1, CourseType = 1 }, // 7

                            // Semester 2
                            new Course { Id = 8, Name = "DISCRETE MATHEMATICS", Prerequisites = new HashSet<int> { 1, 5 }, CourseCredit = 3, CourseType = 1 }, // 8
                            new Course { Id = 9, Name = "INTEGRAL CALCULUS & ORDINARY DIFFERENTIAL EQUATIONS", Prerequisites = new HashSet<int> { 1 }, CourseCredit = 3, CourseType = 1 }, // 9
                            new Course { Id = 10, Name = "OBJECT ORIENTED PROGRAMMING 1", Prerequisites = new HashSet<int> { 5, 6 }, CourseCredit = 3, CourseType = 1 }, // 10
                            new Course { Id = 11, Name = "PHYSICS 2", Prerequisites = new HashSet<int> { 2 }, CourseCredit = 3, CourseType = 1 }, // 11
                            new Course { Id = 12, Name = "PHYSICS 2 LAB", Prerequisites = new HashSet<int> { 3 }, CourseCredit = 1, CourseType = 1 }, // 12
                            new Course { Id = 13, Name = "ENGLISH WRITING SKILLS & COMMUNICATION", Prerequisites = new HashSet<int> { 4 }, CourseCredit = 3, CourseType = 1 }, // 13
                            new Course { Id = 14, Name = "INTRODUCTION TO ELECTRICAL CIRCUITS", Prerequisites = new HashSet<int> { 2 }, CourseCredit = 3, CourseType = 1 }, // 14 
                            new Course { Id = 15, Name = "INTRODUCTION TO ELECTRICAL CIRCUITS LAB", Prerequisites = new HashSet<int> { 3 }, CourseCredit = 1, CourseType = 1 }, // 15

                            // Semester 3
                            new Course { Id = 16, Name = "CHEMISTRY", Prerequisites = new HashSet<int> { 11 }, CourseCredit = 3, CourseType = 1 }, // 16
                            new Course { Id = 17,  Name = "COMPLEX VARIABLE, LAPLACE & Z-TRANSFORMATION", Prerequisites = new HashSet<int> { 9 }, CourseCredit = 3, CourseType = 1 }, // 17
                            new Course { Id = 18, Name = "INTRODUCTION TO DATABASE", Prerequisites = new HashSet<int> { 10 }, CourseCredit = 3, CourseType = 1 }, // 18
                            new Course { Id = 19, Name = "ELECTRONIC DEVICES", Prerequisites = new HashSet<int> { 14 }, CourseCredit = 3, CourseType = 1 }, // 19
                            new Course { Id = 20, Name = "ELECTRONIC DEVICES LAB", Prerequisites = new HashSet<int> { 15 }, CourseCredit = 1, CourseType = 1 }, // 20 
                            new Course { Id = 21, Name = "PRINCIPLES OF ACCOUNTING", Prerequisites = new HashSet<int> { 9 }, CourseCredit = 3, CourseType = 1 }, // 21
                            new Course { Id = 22, Name = "DATA STRUCTURE", Prerequisites = new HashSet<int> { 8, 10 }, CourseCredit = 3, CourseType = 1}, // 22
                            new Course { Id = 23, Name = "DATA STRUCTURE LAB", Prerequisites = new HashSet<int> { 8, 10 }, CourseCredit = 1, CourseType = 1 }, // 23
                            new Course { Id = 24, Name = "COMPUTER AIDED DESIGN & DRAFTING", Prerequisites = new HashSet<int>(), CourseCredit = 1, CourseType = 1 }, // 24
                            
                            // Semester 4
                            new Course { Id = 25, Name = "ALGORITHMS", Prerequisites = new HashSet<int> { 22, 23 }, CourseCredit = 3, CourseType = 1 }, // 25
                            new Course { Id = 26, Name = "MATRICES, VECTORS, FOURIER ANALYSIS", Prerequisites = new HashSet<int> { 17 }, CourseCredit = 3, CourseType = 1 }, // 26
                            new Course { Id = 27, Name = "OBJECT ORIENTED PROGRAMMING 2", Prerequisites = new HashSet<int> { 18, 22 }, CourseCredit = 3, CourseType = 1 }, // 27
                            new Course { Id = 28, Name = "OBJECT ORIENTED ANALYSIS AND DESIGN", Prerequisites = new HashSet<int> { 18 }, CourseCredit = 3, CourseType = 1 }, // 28
                            new Course { Id = 29, Name = "BANGLADESH STUDIES", Prerequisites = new HashSet<int> { 7 }, CourseCredit = 3, CourseType = 1}, // 29
                            new Course { Id = 30, Name = "DIGITAL LOGIC AND CIRCUITS", Prerequisites = new HashSet<int> { 19 }, CourseCredit = 3, CourseType = 1 }, // 30
                            new Course { Id = 31, Name = "DIGITAL LOGIC AND CIRCUITS LAB", Prerequisites = new HashSet<int> { 20 }, CourseCredit = 1, CourseType = 1 }, // 31
                            new Course { Id = 32, Name = "COMPUTATIONAL STATISTICS AND PROBABILITY", Prerequisites = new HashSet<int> { 17 }, CourseCredit = 3, CourseType = 1 }, // 32
                            
                            // Semester 5
                            new Course { Id = 33, Name = "THEORY OF COMPUTATION", Prerequisites = new HashSet<int> { 25 }, CourseCredit = 3 , CourseType = 1}, // 33 
                            new Course { Id = 34, Name = "PRINCIPLES OF ECONOMICS", Prerequisites = new HashSet<int> { 32 }, CourseCredit = 2 , CourseType = 1}, // 34
                            new Course { Id = 35, Name = "BUSINESS COMMUNICATION", Prerequisites = new HashSet<int> { 29 }, CourseCredit = 3 , CourseType = 1}, // 35
                            new Course { Id = 36, Name = "NUMERICAL METHODS FOR SCIENCE AND ENGINEERING", Prerequisites = new HashSet<int> { 26 }, CourseCredit = 3, CourseType = 1 }, // 36
                            new Course { Id = 37, Name = "DATA COMMUNICATION", Prerequisites = new HashSet<int> { 30, 31 }, CourseCredit = 3, CourseType = 1 }, // 37
                            new Course { Id = 38, Name = "MICROPROCESSOR AND EMBEDDED SYSTEM", Prerequisites = new HashSet<int> { 30, 31 }, CourseCredit = 3, CourseType = 1}, // 38
                            new Course { Id = 39, Name = "SOFTWARE ENGINEERING", Prerequisites = new HashSet<int> { 27, 28 }, CourseCredit = 3 , CourseType = 1}, // 39
                            
                            // Semeter 6
                            new Course { Id = 40, Name = "ARTIFICIAL INTELLIGENCE AND EXPERT SYS.", Prerequisites = new HashSet<int> { 32, 33 }, CourseCredit = 3, CourseType = 1 },  // 40
                            new Course { Id = 41, Name = "COMPUTER NETWORKS", Prerequisites = new HashSet<int> { 37 }, CourseCredit = 3, CourseType = 1 }, // 41
                            new Course { Id = 42, Name = "COMPUTER ORGANIZATION AND ARCHITECTURE", Prerequisites = new HashSet<int> { 38 }, CourseCredit = 3, CourseType = 1 }, // 42
                            new Course { Id = 43, Name = "OPERATING SYSTEM", Prerequisites = new HashSet<int> { 33, 38 }, CourseCredit = 3, CourseType = 1 }, // 43
                            new Course { Id = 44, Name = "WEB TECHNOLOGIES", Prerequisites = new HashSet<int> { 39 }, CourseCredit = 3, CourseType = 1}, // 44
                            new Course { Id = 45, Name = "ENGINEERING ETHICS", Prerequisites = new HashSet<int> { 38, 39 }, CourseCredit = 2, CourseType = 1 }, // 45
                            new Course { Id = 46, Name = "COMPILER DESIGN", Prerequisites = new HashSet<int> { 33 }, CourseCredit = 3, CourseType = 1 }, // 46
                                     
                            // Semester 7
                            new Course { Id = 47, Name = "COMPUTER GRAPHICS", Prerequisites = new HashSet<int> { 26, 33 }, CourseCredit = 3, CourseType = 1 }, // 47
                            new Course { Id = 48, Name = "ENGINEERING MANAGEMENT", Prerequisites = new HashSet<int> { 45 }, CourseCredit = 3, CourseType = 1 }, // 48
                            new Course { Id = 49, Name = "RESEARCH METHODOLOGY", Prerequisites = new HashSet<int>(), CourseCredit = 3, CourseType = 1 }, // 49

                            // Change
                            // Semester 8
                            new Course { Id = 50, Name = "THESIS", Prerequisites= new HashSet<int> { 49 }, CourseCredit = 3, CourseType = 1}, // 50
                            new Course { Id = 51, Name = "INTERNSHIP", Prerequisites= new HashSet<int> (), CourseCredit = 3, CourseType = 1}, // 51

                            // ELECTIVE
                            // Information Systems
                            new Course { Id = 52, Name = "ADVANCE DATABASE MANAGEMENT SYSTEM", Prerequisites = new HashSet<int> { 18 }, CourseCredit = 3, CourseType = 2, CourseDept = 0}, // 52
                            new Course { Id = 53, Name = "MANAGEMENT INFORMATION SYSTEM", Prerequisites = new HashSet<int> { 39 }, CourseCredit = 3, CourseType = 2, CourseDept = 3 }, // 53
                            new Course { Id = 54, Name = "ENTERPRISE RESOURCE PLANNING", Prerequisites = new HashSet<int> { 39, 53 }, CourseCredit = 3, CourseType = 2, CourseDept = 3 }, // 54
                            new Course { Id = 55, Name = "DATA WAREHOUSE AND DATA MINING", Prerequisites = new HashSet<int> { 25, 32 }, CourseCredit = 3 , CourseType = 2, CourseDept = 0}, // 55
                            new Course { Id = 56, Name = "HUMAN COMPUTER INTERACTION", Prerequisites = new HashSet<int> { 40, 44 }, CourseCredit = 3 , CourseType = 2, CourseDept = 0}, // 56
                            new Course { Id = 57, Name = "BUSINESS INTELLIGENCE AND DECISION SUPPORT", Prerequisites = new HashSet<int> { 54 }, CourseCredit = 3 , CourseType = 2, CourseDept = 3}, // 57
                            new Course { Id = 58, Name = "INTRODUCTION TO DATA SCIENCE", Prerequisites = new HashSet<int> { 40 }, CourseCredit = 3 , CourseType = 2, CourseDept = 0}, // 58
                            new Course { Id = 59, Name = "CYBER LAWS & INFORMATION SECURITY", Prerequisites = new HashSet<int> { 44 }, CourseCredit = 3 , CourseType = 2, CourseDept = 0}, // 59
                            new Course { Id = 60, Name = "DIGITAL MARKETING", Prerequisites = new HashSet<int> { 44, 53 }, CourseCredit = 3 , CourseType = 2, CourseDept = 3}, // 60
                            new Course { Id = 61, Name = "E-COMMERCE, E-GOVERNANCE & E-SERIES", Prerequisites = new HashSet<int> { 44 }, CourseCredit = 3 , CourseType = 5, CourseDept = 3}, // 61

                            // Software Engineering
                            new Course { Id = 62, Name = "SOFTWARE DEVELOPMENT PROJECT MANAGEMENT", Prerequisites = new HashSet<int> { 63 }, CourseCredit = 3, CourseType = 3, CourseDept = 0 }, // 62
                            new Course { Id = 63, Name = "SOFTWARE REQUIREMENT ENGINEERING", Prerequisites = new HashSet<int> { 39 }, CourseCredit = 3, CourseType = 3, CourseDept = 0 }, // 63
                            new Course { Id = 64, Name = "SOFTWARE QUALITY AND TESTING", Prerequisites = new HashSet<int> { 63 }, CourseCredit = 3, CourseType = 3, CourseDept = 0 }, // 64
                            new Course { Id = 65, Name = "PROGRAMMING IN PYTHON", Prerequisites = new HashSet<int> { 44 }, CourseCredit = 3, CourseType = 3, CourseDept = 0 }, // 65
                            new Course { Id = 66, Name = "VIRTUAL REALITY SYSTEMS DESIGN", Prerequisites = new HashSet<int> { 27 }, CourseCredit = 3 , CourseType = 3, CourseDept = 0}, // 66
                            new Course { Id = 67, Name = "ADVANCED PROGRAMMING WITH JAVA", Prerequisites = new HashSet<int> { 44 }, CourseCredit = 3 , CourseType = 3, CourseDept = 0}, // 67
                            new Course { Id = 68, Name = "ADVANCED PROGRAMMING WITH .NET", Prerequisites = new HashSet<int> { 44 }, CourseCredit = 3 , CourseType = 3, CourseDept = 0}, // 68
                            new Course { Id = 69, Name = "ADVANCED PROGRAMMING IN WEB TECHNOLOGY", Prerequisites = new HashSet<int> { 44 }, CourseCredit = 3 , CourseType = 3, CourseDept = 0}, // 69
                            new Course { Id = 70, Name = "MOBILE APPLICATION DEVELOPMENT", Prerequisites = new HashSet<int> { 44 }, CourseCredit = 3 , CourseType = 3, CourseDept = 0}, // 70
                            new Course { Id = 71, Name = "SOFTWARE ARCHITECTURE AND DESIGN PATTERNS", Prerequisites = new HashSet<int> { 64 }, CourseCredit = 3 , CourseType = 3, CourseDept = 0}, // 71

                            // Computational Theory
                            new Course { Id = 72, Name = "COMPUTER SCIENCE MATHEMATICS", Prerequisites = new HashSet<int> { 25, 36 }, CourseCredit = 3 , CourseType = 4, CourseDept = 0}, // 72
                            new Course { Id = 73, Name = "BASIC GRAPH THEORY", Prerequisites = new HashSet<int> { 25 }, CourseCredit = 3, CourseType = 4, CourseDept = 0}, //73
                            new Course { Id = 74, Name = "ADVANCED ALGORITHM TECHNIQUES", Prerequisites = new HashSet<int> { 40 }, CourseCredit = 3, CourseType = 4, CourseDept = 0 }, // 74
                            new Course { Id = 75, Name = "NATURAL LANGUAGE PROCESSING", Prerequisites = new HashSet<int> { 40, 65 }, CourseCredit = 3, CourseType = 4, CourseDept = 0 }, // 75
                            new Course { Id = 76, Name = "LINEAR PROGRAMMING", Prerequisites = new HashSet<int> { 40, 32 }, CourseCredit = 3, CourseType = 4, CourseDept = 0 }, // 76
                            new Course { Id = 77, Name = "PARALLEL COMPUTING", Prerequisites = new HashSet<int> { 25, 40 }, CourseCredit = 3, CourseType = 4, CourseDept = 0 }, // 77
                            new Course { Id = 78, Name = "MACHINE LEARNING", Prerequisites = new HashSet<int> { 40 }, CourseCredit = 3, CourseType = 4, CourseDept = 0 }, // 78

                            // Computer Engineering                        
                            new Course { Id = 79, Name = "BASIC MECHANICAL ENGG.", Prerequisites = new HashSet<int> { 11 }, CourseCredit = 3, CourseType = 5, CourseDept = 4 }, // 79
                            new Course { Id = 80, Name = "SIGNALS & LINEAR SYSTEM", Prerequisites = new HashSet<int> { 26 }, CourseCredit = 3, CourseType = 5, CourseDept = 2 }, // 80
                            new Course { Id = 81, Name = "DIGITAL SYSTEM DESIGN", Prerequisites = new HashSet<int> { 42 }, CourseCredit = 3, CourseType = 5, CourseDept = 1 }, // 81
                            new Course { Id = 82, Name = "IMAGE PROCESSING", Prerequisites = new HashSet<int> { 47 }, CourseCredit = 3, CourseType = 5, CourseDept = 1}, // 82
                            new Course { Id = 83, Name = "MULTIMEDIA SYSTEMS", Prerequisites = new HashSet<int> { 44 }, CourseCredit = 3 , CourseType = 5, CourseDept = 1}, // 83
                            new Course { Id = 84, Name = "SIMULATION & MODELING", Prerequisites = new HashSet<int> { 40 }, CourseCredit = 3 , CourseType = 5, CourseDept = 1}, // 84
                            new Course { Id = 85, Name = "ADVANCED COMPUTER NETWORKS", Prerequisites = new HashSet<int> { 41 }, CourseCredit = 3 , CourseType = 5, CourseDept = 1}, // 85
                            new Course { Id = 86, Name = "COMPUTER VISION AND PATTERN RECOGNITION", Prerequisites = new HashSet<int> { 40, 47 }, CourseCredit = 3 , CourseType = 5, CourseDept = 1}, // 86
                            new Course { Id = 87, Name = "NETWORK SECURITY", Prerequisites = new HashSet<int> { 41 }, CourseCredit = 3 , CourseType = 5, CourseDept = 1}, // 87
                            new Course { Id = 88, Name = "ADVANCED OPERATING SYSTEM", Prerequisites = new HashSet<int> { 43 }, CourseCredit = 3 , CourseType = 5, CourseDept = 1}, // 88
                            new Course { Id = 89, Name = "DIGITAL DESIGN WITH SYSTEM [VERILOG, VHDL & FPGAS]", Prerequisites = new HashSet<int> { 96 }, CourseCredit = 3 , CourseType = 5, CourseDept = 2}, // 89
                            new Course { Id = 90, Name = "ROBOTICS ENGINEERING", Prerequisites = new HashSet<int> { 40 }, CourseCredit = 3 , CourseType = 5, CourseDept = 1}, // 90
                            new Course { Id = 91, Name = "TELECOMMUNICATIONS ENGINEERING", Prerequisites = new HashSet<int> { 37 }, CourseCredit = 3 , CourseType = 5, CourseDept = 2}, // 91
                            new Course { Id = 92, Name = "NETWORK RESOURCE MANAGEMENT & ORGANIZATION", Prerequisites = new HashSet<int> { 37, 41 }, CourseCredit = 3 , CourseType = 5, CourseDept = 1}, // 92
                            new Course { Id = 93, Name = "WIRELESS SENSOR NETWORKS", Prerequisites = new HashSet<int> { 37, 41 }, CourseCredit = 3 , CourseType = 5, CourseDept = 1}, // 93
                            new Course { Id = 94, Name = "INDUSTRIAL ELECTRONICS, DRIVES & INSTRUMENTATION", Prerequisites = new HashSet<int> { 30 }, CourseCredit = 3 , CourseType = 5, CourseDept = 2}, // 94
                            new Course { Id = 95, Name = "DIGITAL SIGNAL PROCESSING", Prerequisites = new HashSet<int> { 52 }, CourseCredit = 3 , CourseType = 5, CourseDept = 2}, // 95
                            new Course { Id = 96, Name = "VLSI CIRCUIT DESIGN", Prerequisites = new HashSet<int> { 94 }, CourseCredit = 3 , CourseType = 5, CourseDept = 2} // 96
                           // new Course { Id = 97,  Name = "BIOINFORMATICS", Prerequisites = new HashSet<int> { 40 }, CourseCredit = 3 , CourseType = 5}
                        };

        }

        // Function to handle EEE courses
        public static List<Course> EeeCourses()
        {
            return new List<Course>
            {
                // Semester 1
                new Course { Id = 1,  Name = "CHEMISTRY", Prerequisites = new HashSet<int>(), CourseCredit = 3, CourseType = 1 }, //1
                new Course { Id = 2,  Name = "DIFFERENTIAL CALCULUS & CO-ORDINATE GEOMETRY", Prerequisites = new HashSet<int>(), CourseCredit = 3, CourseType = 1 }, //2
                new Course { Id = 3,  Name = "PHYSICS 1", Prerequisites = new HashSet<int>(), CourseCredit = 3, CourseType = 1 }, // 3
                new Course { Id = 4,  Name = "PHYSICS 1 LAB", Prerequisites = new HashSet<int> (), CourseCredit = 1, CourseType = 1 }, // 4
                new Course { Id = 5,  Name = "ENGLISH READING SKILLS & PUBLIC SPEAKING", Prerequisites = new HashSet<int>(), CourseCredit = 3, CourseType = 1 }, // 5
                new Course { Id = 6, Name = "INTRODUCTION TO ENGINEERING STUDIES", Prerequisites = new HashSet<int>(), CourseCredit = 1, CourseType = 1 }, // 6

                // Semester 2
                new Course { Id = 7, Name = "BASIC MECHANICAL ENGINEERING", Prerequisites = new HashSet<int> { 3 }, CourseCredit = 3, CourseType = 1 }, // 7
                new Course { Id = 8, Name = "ELECTICAL CIRCUIT-1 (DC)", Prerequisites = new HashSet<int> { 3, 6 }, CourseCredit = 3, CourseType = 1 }, // 8
                new Course { Id = 9, Name = "ELECTICAL CIRCUIT-1 (DC) LAB", Prerequisites = new HashSet<int> { 6, 4 }, CourseCredit = 1, CourseType = 1 }, // 9
                new Course { Id = 10, Name = "INTEGRAL CALCULUS & ORDINARY DIFFERENTIAL EQUATIONS", Prerequisites = new HashSet<int> { 2 }, CourseCredit = 3, CourseType = 1 }, // 10
                new Course { Id = 11, Name = "PHYSICS 2", Prerequisites = new HashSet<int> { 1, 3 }, CourseCredit = 3, CourseType = 1 }, // 11
                new Course { Id = 12, Name = "PHYSICS 2 LAB", Prerequisites = new HashSet<int> { 1, 4 }, CourseCredit = 1, CourseType = 1 }, // 12
                new Course { Id = 13, Name = "PRINCIPLE OF ACCOUNTING", Prerequisites = new HashSet<int> { 2 }, CourseCredit = 3, CourseType = 1 }, // 13
                new Course { Id = 14, Name = "ENGLISH WRITING SKILLS & COMMUNICATION", Prerequisites = new HashSet<int> { 5 }, CourseCredit = 3, CourseType = 1 }, // 14

                // Semester 3
                new Course { Id = 15, Name = "COMPLEX VARIABLE, LAPLACE & Z-TRANSFORMATION", Prerequisites = new HashSet<int> { 10 }, CourseCredit = 3, CourseType = 1 }, // 15
                new Course { Id = 16, Name = "ELECTRICAL CIRCUIT 2 (AC)", Prerequisites = new HashSet<int> { 8 }, CourseCredit = 3, CourseType = 1 }, // 16
                new Course { Id = 17, Name = "ELECTRICAL CIRCUITS-2 (AC) LAB", Prerequisites = new HashSet<int> { 9 }, CourseCredit = 1, CourseType = 1 }, // 17
                new Course { Id = 18, Name = "ELECTRICAL MACHINES 1", Prerequisites = new HashSet<int> { 7, 16 }, CourseCredit = 3, CourseType = 1 }, // 18
                new Course { Id = 19, Name = "ELECTRICAL MACHINES 1 LAB", Prerequisites = new HashSet<int> { 7, 17 }, CourseCredit = 1, CourseType = 1 }, // 19
                new Course { Id = 20, Name = "ELECTRONIC DEVICES", Prerequisites = new HashSet<int> { 16 }, CourseCredit = 3, CourseType = 1 }, // 20
                new Course { Id = 21, Name = "ELECTRONIC DEVICES LAB", Prerequisites = new HashSet<int> { 17 }, CourseCredit = 1, CourseType = 1 }, // 21
                new Course { Id = 22, Name = "PROGRAMMING LANGUAGE 1 (STRUCTURED PROGRAMMING LANGUAGE)", Prerequisites = new HashSet<int> { 10 }, CourseCredit = 3, CourseType = 1 }, // 22
                new Course { Id = 23, Name = "BANGLADESH STUDIES", Prerequisites = new HashSet<int>(), CourseCredit = 3, CourseType = 1 }, // 23

                // Semester 4
                new Course { Id = 24, Name = "ELECTRICAL MACHINES 2", Prerequisites = new HashSet<int> { 18 }, CourseCredit = 3, CourseType = 1 }, // 24
                new Course { Id = 25, Name = "ELECTRICAL MACHINES 2 LAB", Prerequisites = new HashSet<int> { 19 }, CourseCredit = 1, CourseType = 1 }, // 25
                new Course { Id = 26, Name = "ELECTRICAL POWER TRANSMISSION & DISTRIBUTION", Prerequisites = new HashSet<int> { 18 }, CourseCredit = 3, CourseType = 1 }, // 26
                new Course { Id = 27, Name = "MATRICES, VECTORS, FOURIER ANALYSIS", Prerequisites = new HashSet<int> { 15 }, CourseCredit = 3, CourseType = 1 }, // 27
                new Course { Id = 28, Name = "SIGNALS & LINEAR SYSTEMS", Prerequisites = new HashSet<int> { 27 }, CourseCredit = 3, CourseType = 1 }, // 28
                new Course { Id = 29, Name = "ENGINEERING ETHICS AND ENVIRONMENTAL PROTECTION", Prerequisites = new HashSet<int> { 6 }, CourseCredit = 1, CourseType = 1 }, // 29
                new Course { Id = 30, Name = "ANALOG ELECTRONICS", Prerequisites = new HashSet<int> { 20 }, CourseCredit = 3, CourseType = 1 }, // 30
                new Course { Id = 31, Name = "ANALOG ELECTRONICS LAB", Prerequisites = new HashSet<int> { 21 }, CourseCredit = 1, CourseType = 1 }, // 31
                new Course { Id = 32, Name = "COMPUTER AIDED DESIGN & DRAFTING", Prerequisites = new HashSet<int> { 8 }, CourseCredit = 1, CourseType = 1 }, // 32

                // Semester 5
                new Course { Id = 33, Name = "MODERN PHYSICS", Prerequisites = new HashSet<int> { 11 }, CourseCredit = 3, CourseType = 1 }, // 33 
                new Course { Id = 34, Name = "ELECTROMAGNETICS FIELDS AND WAVES", Prerequisites = new HashSet<int> { 11, 27 }, CourseCredit = 3, CourseType = 1 }, // 34
                new Course { Id = 35, Name = "PRINCIPLES OF ECONOMICS", Prerequisites = new HashSet<int> { 13 }, CourseCredit = 2, CourseType = 1 }, // 35
                new Course { Id = 36, Name = "DIGITAL LOGIC AND CIRCUITS", Prerequisites = new HashSet<int> { 20 }, CourseCredit = 3, CourseType = 1 }, // 36
                new Course { Id = 37, Name = "DIGITAL LOGIC AND CIRCUITS LAB", Prerequisites = new HashSet<int> { 21 }, CourseCredit = 1, CourseType = 1 }, // 37
                new Course { Id = 38, Name = "ENGINEERING SHOP", Prerequisites = new HashSet<int> { 30 }, CourseCredit = 1, CourseType = 1 }, // 38
                new Course { Id = 39, Name = "INDUSTRIAL ELECTRONICS AND DRIVES", Prerequisites = new HashSet<int> { 24 }, CourseCredit = 3, CourseType = 1 }, // 39
                new Course { Id = 40, Name = "INDUSTRIAL ELECTRONICS AND DRIVES LAB", Prerequisites = new HashSet<int> { 25 }, CourseCredit = 1, CourseType = 1 }, // 40
                new Course { Id = 41, Name = "DIGITAL SIGNAL PROCESSING", Prerequisites = new HashSet<int> { 27, 28 }, CourseCredit = 3, CourseType = 1 }, // 41

                // Semester 6
                new Course { Id = 42, Name = "ELECTRICAL PROPERTIES OF MATERIALS", Prerequisites = new HashSet<int> { 33 }, CourseCredit = 3, CourseType = 1 }, // 42
                new Course { Id = 43, Name = "PROGRAMMING LANGUAGE 2 (OBJECT ORIENTED PROGRAMMING LANGUAGE)", Prerequisites = new HashSet<int> { 22 }, CourseCredit = 3, CourseType = 1 }, // 43
                new Course { Id = 44, Name = "POWER SYSTEMS ANALYSIS", Prerequisites = new HashSet<int> { 26 }, CourseCredit = 3, CourseType = 1 }, // 44
                new Course { Id = 45, Name = "NUMERICAL METHODS FOR SCIENCE AND ENGINEERING", Prerequisites = new HashSet<int> { 22, 27 }, CourseCredit = 3, CourseType = 1 }, // 45
                new Course { Id = 46, Name = "COMPUTATIONAL STATISTICS AND PROBABILITY", Prerequisites = new HashSet<int> { 45 }, CourseCredit = 3, CourseType = 1 }, // 46
                new Course { Id = 47, Name = "PRINCIPLES OF COMMUNICATION", Prerequisites = new HashSet<int> { 34 }, CourseCredit = 3, CourseType = 1 }, // 47

                // Semester 7
                new Course { Id = 48, Name = "BUSINESS COMMUNICATION", Prerequisites = new HashSet<int> { 14 }, CourseCredit = 3, CourseType = 1}, // 48
                new Course { Id = 49, Name = "ENGINEERING MANAGEMENT", Prerequisites = new HashSet<int> { 29 }, CourseCredit = 3, CourseType = 1}, // 49
                new Course { Id = 50, Name = "MODERN CONTROL SYSTEMS", Prerequisites = new HashSet<int> { 28 }, CourseCredit = 3, CourseType = 1 }, // 50
                new Course { Id = 51, Name = "MODERN CONTROL SYSTEMS LAB", Prerequisites = new HashSet<int> { 28 }, CourseCredit = 1, CourseType = 1 }, // 51
                new Course { Id = 52, Name = "MICROPROCESSOR AND EMBEDDED SYSTEM", Prerequisites = new HashSet<int> { 36, 43 }, CourseCredit = 3, CourseType = 1 }, // 52
                new Course { Id = 53, Name = "CAPSTONE PROJECT 1", Prerequisites = new HashSet<int> (), CourseCredit = 3, CourseType = 1}, // 53

                // Semester 8
                new Course { Id = 54, Name = "INTERNSHIP/ SEMINAR/ WORKSHOP", Prerequisites = new HashSet<int> { 48 }, CourseCredit = 1, CourseType = 1 }, // 54
                new Course { Id = 55, Name = "ELECTRICAL SERVICES DESIGN LAB", Prerequisites = new HashSet<int> { 38 }, CourseCredit = 1, CourseType = 1 }, // 55
                new Course { Id = 56, Name = "TELECOMMUNICATIONS ENGINEERING", Prerequisites = new HashSet<int> { 47 }, CourseCredit = 3, CourseType = 1 }, // 56
                new Course { Id = 57, Name = "POWER STATIONS AND SUBSTATIONS", Prerequisites = new HashSet<int> { 44 }, CourseCredit = 3, CourseType = 1 }, // 57
                new Course { Id = 58, Name = "MEASUREMENT AND INSTRUMENTATION", Prerequisites = new HashSet<int> { 50 }, CourseCredit = 3, CourseType = 1 }, // 58
                new Course { Id = 59, Name = "VLSI CIRCUIT DESIGN", Prerequisites = new HashSet<int> { 36 }, CourseCredit = 3, CourseType = 1 }, //59
                new Course { Id = 60, Name = "CAPSTONE PROJECT 2", Prerequisites = new HashSet<int> { 29, 48 }, CourseCredit = 2, CourseType = 1 }, //60

                
                // Elective course
                new Course { Id = 61, Name = "COMPUTER SYSTEM ARCHITECTURE", Prerequisites = new HashSet<int> { 52 }, CourseCredit = 3, CourseType = 2},
                new Course { Id = 62, Name = "MICROWAVE ENGINEERING", Prerequisites = new HashSet<int> { 34 }, CourseCredit = 3, CourseType = 2},
                new Course { Id = 63, Name = "COMPUTER INTERFACE DESIGN", Prerequisites = new HashSet<int> { 52 }, CourseCredit = 3,CourseType = 2 },
                new Course { Id = 64, Name = "OPTOELECTRONIC DEVICES", Prerequisites = new HashSet<int> { 47 }, CourseCredit = 3, CourseType = 2 },
                new Course { Id = 65, Name = "POWER SYSTEM PROTECTION", Prerequisites = new HashSet<int> { 44 }, CourseCredit = 3, CourseType = 2 },
                new Course { Id = 66, Name = "CELLULAR MOBILE COMMUNICATION", Prerequisites = new HashSet<int> { 56 }, CourseCredit = 3, CourseType = 2 },
                new Course { Id = 67, Name = "DIGITAL DESIGN WITH SYSTEM [ VERILOG,VHDL & FPGAS ]", Prerequisites = new HashSet<int> { 59 }, CourseCredit = 3, CourseType = 2 },
                new Course { Id = 68, Name = "INTRODUCTION TO ANIMATION", Prerequisites = new HashSet<int> { 43 }, CourseCredit = 3, CourseType = 2 },
                new Course { Id = 69, Name = "ROBOTICS ENGINEERING", Prerequisites = new HashSet<int> { 50 }, CourseCredit = 3, CourseType = 2 },
                new Course { Id = 70, Name = "RENEWABLE ENERGY TECHNOLOGY", Prerequisites = new HashSet<int> { 44 }, CourseCredit = 3, CourseType = 2 },
                new Course { Id = 71, Name = "BIOMEDICAL INSTRUMENTATION MEASUREMENT AND DESIGN", Prerequisites = new HashSet<int> { 58 }, CourseCredit = 3, CourseType = 2 },
                new Course { Id = 72, Name = "NUCLEAR POWER ENGINEERING", Prerequisites = new HashSet<int> { 57 }, CourseCredit = 3, CourseType = 2 },
                new Course { Id = 73, Name = "SOFTWARE ENGINEERING", Prerequisites = new HashSet<int> { 43 }, CourseCredit = 3, CourseType = 2 },
                new Course { Id = 74, Name = "NANOTECHNOLOGY FOR ENGINEERS", Prerequisites = new HashSet<int> { 42 }, CourseCredit = 3, CourseType = 2 },
            };

        }

        // Function to handle English courses
        public static List<Course> EnglishCourses()
        {
            return new List<Course>
            {
                // Semester 1
                new Course { Id = 1,  Name = "ENGLISH READING SKILLS & PUBLIC SPEAKING", Prerequisites = new HashSet<int>(), CourseCredit = 3, CourseType = 1}, //1
                new Course { Id = 2, Name = "BANGLA LANGUAGE AND LITERATURE", Prerequisites = new HashSet<int>(), CourseCredit = 3, CourseType = 1}, // 2
                new Course { Id = 3, Name = "FOUNDATIONS OF SOCIOLOGY", Prerequisites= new HashSet<int>(), CourseCredit = 3, CourseType = 1}, // 3
                new Course { Id = 4, Name = "COMPUTER FUNDAMENTALS", Prerequisites = new HashSet<int>(), CourseCredit = 3, CourseType = 1}, // 4
                new Course { Id = 5, Name = "INTRODUCTION TO ENGLISH LITERATURE", Prerequisites = new HashSet<int>(), CourseCredit = 3, CourseType = 1}, // 5
                new Course { Id = 6, Name = "INTRODUCTION TO LINGUISTICS", Prerequisites = new HashSet<int>(), CourseCredit = 3, CourseType = 1}, // 6


                // Semester 2
                new Course { Id = 7, Name = "ENGLISH WRITING", Prerequisites = new HashSet<int> {1}, CourseCredit = 3, CourseType = 1}, // 7
                new Course { Id = 8, Name = "MORPHOLOGY", Prerequisites = new HashSet<int> (), CourseCredit = 3, CourseType = 1}, // 8
                new Course { Id = 9, Name = "HISTORY OF EMERGENCE OF BANGLADESH", Prerequisites = new HashSet<int> (), CourseCredit = 3, CourseType = 1}, // 9
                new Course { Id = 10, Name = "APPRECIATION OF POETRY", Prerequisites = new HashSet<int> (), CourseCredit = 3, CourseType = 1}, // 10
                new Course { Id = 11, Name = "FUNDAMENTALS OF ECONOMICS", Prerequisites = new HashSet<int> (), CourseCredit = 3, CourseType = 1 }, // 11
                new Course { Id = 12, Name = "NATURAL SCIENCE", Prerequisites = new HashSet<int> (), CourseCredit = 3, CourseType = 1}, // 12


                // Semester 3
                new Course { Id = 13, Name = "WRITING FOR ARTS AND SOCIAL SCIENCES", Prerequisites = new HashSet<int> {7}, CourseCredit = 3, CourseType = 1}, // 13
                new Course { Id = 14, Name = "BANGLADESH STUDIES", Prerequisites = new HashSet<int> {8}, CourseCredit = 3, CourseType = 1}, // 14
                new Course { Id = 15, Name = "ARTS AND AESTHETICS", Prerequisites = new HashSet<int> (), CourseCredit = 3, CourseType = 1}, // 15
                new Course { Id = 16, Name = "STATISTICS FOR SOCIAL SCIENCE", Prerequisites = new HashSet<int> (), CourseCredit = 3, CourseType = 1}, // 16
                new Course { Id = 17, Name = "HISTORY OF ENGLISH LANGUAGE", Prerequisites = new HashSet<int> (), CourseCredit = 3, CourseType = 1}, // 17
                new Course { Id = 18, Name = "ELEMENTARY ACCOUNTING", Prerequisites = new HashSet<int> (), CourseCredit = 3, CourseType = 1}, // 18


                // Semester 4
                new Course { Id = 19, Name = "APPRECIATION OF PROSE", Prerequisites = new HashSet<int> (), CourseCredit = 3, CourseType = 1}, // 19
                new Course { Id = 20, Name = "CLASSROOM MANAGEMENT TECHNIQUES IN ELT", Prerequisites = new HashSet<int> {6}, CourseCredit = 3, CourseType = 1 }, //20
                new Course { Id = 21, Name = "APPRECIATION OF DRAMA", Prerequisites = new HashSet<int> (), CourseCredit = 3, CourseType = 1 }, // 21
                new Course { Id = 22, Name = "PROFESSIONAL ENGLISH", Prerequisites = new HashSet<int> {7}, CourseCredit = 3, CourseType = 1}, // 22
                new Course { Id = 23, Name = "SOCIAL SCIENCE RESEARCH METHODOLOGY", Prerequisites = new HashSet<int> {16}, CourseCredit = 3, CourseType = 1 }, // 23
                new Course { Id = 24, Name = "COGNITIVE AND SOCIAL PSYCHOLOGY", Prerequisites = new HashSet<int> (), CourseCredit = 3, CourseType = 1}, // 24


                // Semester 5
                new Course { Id = 25, Name = "PHILOSOPHY AND ETHICS", Prerequisites = new HashSet<int> (), CourseCredit = 3, CourseType = 1}, //25
                new Course { Id = 26, Name = "CLASSICAL LITERATURE", Prerequisites = new HashSet<int> {21}, CourseCredit = 3, CourseType = 1}, // 26
                new Course { Id = 27, Name = "FIRST LANGUAGE DEVELOPMENT", Prerequisites = new HashSet<int> (), CourseCredit = 3, CourseType = 1}, // 27
                new Course { Id = 28, Name = "TEACHING GRAMMAR AND VOCABULARY", Prerequisites = new HashSet<int>(), CourseCredit = 3, CourseType = 1}, // 28


                // Semester 6
                new Course { Id = 29, Name = "PHONETICS AND PHONOLOGY", Prerequisites = new HashSet<int> {8}, CourseCredit = 3, CourseType = 1},  // 29
                new Course { Id = 30, Name = "CONTEMPORARY SOUTH ASIAN LITERATURE IN ENGLISH", Prerequisites = new HashSet<int> (), CourseCredit = 3, CourseType = 1}, // 30
                new Course { Id = 31, Name = "ELT APPROACHES AND METHODS", Prerequisites = new HashSet<int> {20}, CourseCredit = 3, CourseType = 1}, // 31
                new Course { Id = 32, Name = "SOUTH ASIAN HISTORY AND DEVELOPMENT", Prerequisites = new HashSet<int> (), CourseCredit = 3, CourseType = 1}, // 32


                // Semeseter 7
                new Course { Id = 33, Name = "SHAKESPEARE", Prerequisites = new HashSet<int> (), CourseCredit = 3, CourseType = 1}, // 33
                new Course { Id = 34, Name  = "LITERARY THEORY AND CRITICISM", Prerequisites = new HashSet<int>(), CourseCredit = 3, CourseType = 1}, // 34
                new Course { Id = 35, Name = "SOCIOLINGUISTICS", Prerequisites = new HashSet<int> (), CourseCredit = 3, CourseType = 1 }, // 35


                // Semester 8
                new Course { Id = 36, Name = "PROFESSIONAL DEVELOPMENT", Prerequisites = new HashSet<int> (), CourseCredit = 3, CourseType = 1 }, // 36
                new Course { Id = 37, Name = "PROFESSIONAL DEVELOPMENT", Prerequisites = new HashSet<int> (), CourseCredit = 3, CourseType = 1 }, // 37
                new Course { Id = 38, Name = "TEACHING PRACTICUM", Prerequisites = new HashSet<int> (), CourseCredit = 3, CourseType = 1 }, // 38


                // Elecetive
                // Major in Linguistics & TESL
                new Course { Id = 39, Name = "ENGLISH SYNTAX", Prerequisites = new HashSet<int> (), CourseCredit = 3, CourseType = 2 }, // 39
                new Course { Id = 40, Name = "SEMANTICS AND PRAGMATICS", Prerequisites = new HashSet<int> (), CourseCredit = 3, CourseType = 2 }, // 40
                new Course { Id = 41, Name = "DISCOURSE ANALYSIS", Prerequisites = new HashSet<int> (), CourseCredit = 3, CourseType = 1 }, // 41
                new Course { Id = 42, Name = "GLOBAL ENGLISHES", Prerequisites = new HashSet<int> (), CourseCredit = 3 , CourseType = 2}, // 42
                new Course { Id = 43, Name = "SECOND LANGUAGE ACQUISITION", Prerequisites = new HashSet<int> (), CourseCredit = 3 , CourseType = 2}, // 43
                new Course { Id = 44, Name = "BILINGUALISM", Prerequisites = new HashSet<int> (), CourseCredit = 3 , CourseType = 2}, // 44
                new Course { Id = 45, Name = "TECHNOLOGY IN LANGUAGE LEARNING", Prerequisites = new HashSet<int> (), CourseCredit = 3, CourseType = 2}, // 45
                new Course { Id = 46, Name = "LANGUAGE TESTING", Prerequisites = new HashSet<int> (), CourseCredit = 3 , CourseType = 2}, // 46
                new Course { Id = 47, Name = "ENGLISH FOR SPECIFIC PURPOSES", Prerequisites = new HashSet<int> (), CourseCredit = 3 , CourseType = 2}, // 47
                new Course { Id = 48, Name = "TEACHING READING", Prerequisites = new HashSet<int> (), CourseCredit = 3 , CourseType = 2}, // 48
                new Course { Id = 49, Name = "TEACHING LISTENING AND SPEAKING", Prerequisites = new HashSet<int> (), CourseCredit = 3 , CourseType = 2}, // 49
                new Course { Id = 50, Name = "GLOBAL LANGUAGE", Prerequisites = new HashSet<int> (), CourseCredit = 3 , CourseType = 2}, // 50
                new Course { Id = 51, Name = "INDEPENDENT PROJECT", Prerequisites = new HashSet<int> (), CourseCredit = 3 , CourseType = 2}, // 51



                // Major In Literature
                new Course { Id = 52, Name = "OLD AND MIDDLE ENGLISH LITERATURE", Prerequisites = new HashSet<int> (), CourseCredit = 3 , CourseType = 3}, // 52
                new Course { Id = 53, Name = "ROMANTIC POETRY", Prerequisites = new HashSet<int> (), CourseCredit = 3, CourseType = 3 }, // 53
                new Course { Id = 54, Name = "VICTORIAN LITERATURE", Prerequisites = new HashSet<int> (), CourseCredit = 3, CourseType = 3 }, // 54
                new Course { Id = 55, Name = "MODERN FICTION AND NON-FICTION", Prerequisites = new HashSet<int> (), CourseCredit = 3, CourseType = 3 }, // 55
                new Course { Id = 56, Name = "MODERN DRAMA AND POETRY", Prerequisites = new HashSet<int> (), CourseCredit = 3, CourseType = 3 }, // 56
                new Course { Id = 57, Name = "AMERICAN LITERATURE", Prerequisites = new HashSet<int> (), CourseCredit = 3, CourseType = 3 }, // 57
                new Course { Id = 58, Name = "AFRICAN LITERATURE IN ENGLISH", Prerequisites = new HashSet<int> (), CourseCredit = 3, CourseType = 3 }, // 58
                new Course { Id = 59, Name = "16TH AND 17TH CENTURY ENGLISH LITERATURE", Prerequisites = new HashSet<int> (), CourseCredit = 3, CourseType = 3 }, // 59
                new Course { Id = 60, Name = "TRANSLATION STUDIES", Prerequisites = new HashSet<int> (), CourseCredit = 3, CourseType = 3 }, // 60
                new Course { Id = 61, Name = "EUROPEAN LITERATURE IN ENGLISH", Prerequisites = new HashSet<int> (), CourseCredit = 3, CourseType = 3}, //61
                new Course { Id = 62, Name = "CARIBBEAN LITERATURE IN ENGLISH", Prerequisites = new HashSet<int> (), CourseCredit = 3, CourseType = 3 }, // 62
                new Course { Id = 63, Name = "TEACHING ENGLISH LITERATURE", Prerequisites = new HashSet<int> (), CourseCredit = 3, CourseType = 3 }, // 63
                new Course { Id = 64, Name = "BANGLADESHI LITERATURE IN ENGLISH", Prerequisites = new HashSet<int> (), CourseCredit = 3, CourseType = 3}, // 64
                new Course { Id = 65, Name = "CREATIVE WRITING", Prerequisites = new HashSet<int> (), CourseCredit = 3, CourseType = 3 }, // 65
                new Course { Id = 66, Name = "GLOBAL LANGUAGES", Prerequisites = new HashSet<int> (), CourseCredit = 3, CourseType = 3 }, // 66
                new Course { Id = 67, Name = "INDEPENDENT PROJECT", Prerequisites = new HashSet<int> (), CourseCredit = 3, CourseType = 3 } // 67
            };

        }

        public static List<Course> BBACourses()
        {
            return new List<Course>
{
                                            // Semester 1
                                            new Course { Id = 1,  Name = "Foundation Course", Prerequisites = new HashSet<int>(), CourseCredit = 3, CourseType = 1}, // 1
                                            new Course { Id = 2, Name = "Introduction to Business", Prerequisites = new HashSet<int>(), CourseCredit = 3, CourseType = 1}, // 2
                                            new Course { Id = 3, Name = "Financial Accounting", Prerequisites = new HashSet<int>(), CourseCredit = 3, CourseType = 1},
                                            new Course { Id = 4, Name = "Business Mathematics 1", Prerequisites = new HashSet<int>(), CourseCredit = 3, CourseType = 1},
                                            new Course { Id = 5, Name = "English Reading", Prerequisites = new HashSet<int>(), CourseCredit = 3, CourseType = 1},
                                            new Course { Id = 6, Name = "Bangladesh Studies", Prerequisites = new HashSet<int>(), CourseCredit = 3, CourseType = 1},

                                            // Semester 2
                                            new Course { Id = 7, Name = "Business Management", Prerequisites = new HashSet<int>{1, 2}, CourseCredit = 3, CourseType = 1},
                                            new Course { Id = 8, Name = "Principles of Marketing", Prerequisites = new HashSet<int>{2}, CourseCredit = 3, CourseType = 1},
                                            new Course { Id = 9, Name = "Business Mathematics 2", Prerequisites = new HashSet<int>{4}, CourseCredit = 3, CourseType = 1},
                                            new Course { Id = 10, Name = "English Writing", Prerequisites = new HashSet<int>{5}, CourseCredit = 3, CourseType = 1},
                                            new Course { Id = 11, Name = "Micro Economics", Prerequisites = new HashSet<int>{4}, CourseCredit = 3, CourseType = 1},
                                            new Course { Id = 12, Name = "Introduction to Information Technology ", Prerequisites = new HashSet<int>{2}, CourseCredit = 3, CourseType = 1}, //1

                                            // Semester 3
                                            new Course { Id = 13, Name = "Organizational Behavior", Prerequisites = new HashSet<int>{7}, CourseCredit = 3, CourseType = 1},
                                            new Course { Id = 14, Name = "Managerial Accounting", Prerequisites = new HashSet<int>{3}, CourseCredit = 3, CourseType = 1},
                                            new Course { Id = 15, Name = "Business Statistics", Prerequisites = new HashSet<int>{9}, CourseCredit = 3, CourseType = 1},
                                            new Course { Id = 16, Name = "Basic in Social Science ", Prerequisites = new HashSet<int>{6}, CourseCredit = 3, CourseType = 1}, //1
                                            new Course { Id = 17, Name = "Office Management Technology ", Prerequisites = new HashSet<int>{12}, CourseCredit = 3, CourseType = 1}, //1
                                            new Course { Id = 18, Name = "Global Languages", Prerequisites = new HashSet<int>{10}, CourseCredit = 3, CourseType = 1},

                                            // Semester 4
                                            new Course { Id = 19, Name = "Principles of Finance", Prerequisites = new HashSet<int>{14}, CourseCredit = 3, CourseType = 1},
                                            new Course { Id = 20, Name = "Advanced Business Statistics", Prerequisites = new HashSet<int>{15}, CourseCredit = 3, CourseType = 1},
                                            new Course { Id = 21, Name = "Business Law", Prerequisites = new HashSet<int>{13}, CourseCredit = 3, CourseType = 1},
                                            new Course { Id = 22, Name = "Macro Economics", Prerequisites = new HashSet<int>{11}, CourseCredit = 3, CourseType = 1},
                                            new Course { Id = 23, Name = "Basics in Natural Science", Prerequisites = new HashSet<int>{9, 16}, CourseCredit = 3, CourseType = 1},
                                            new Course { Id = 24, Name = "Politics Philosophy and Public Affairs ", Prerequisites = new HashSet<int>{16}, CourseCredit = 3, CourseType = 1},
                                            
                                            // Semester 5
                                            new Course { Id = 25, Name = "Human Resource Management", Prerequisites = new HashSet<int>{13}, CourseCredit = 3, CourseType = 1},
                                            new Course { Id = 26, Name = "Financial Management", Prerequisites = new HashSet<int>{19}, CourseCredit = 3, CourseType = 1},
                                            new Course { Id = 27, Name = "Marketing Management", Prerequisites = new HashSet<int>{8, 22}, CourseCredit = 3, CourseType = 1},
                                            new Course { Id = 28, Name = "Operations and Supply Chain Management", Prerequisites = new HashSet<int>{15}, CourseCredit = 3, CourseType = 1},
                                            new Course { Id = 29, Name = "Management Information Systems", Prerequisites = new HashSet<int>{17}, CourseCredit = 3, CourseType = 1},
                                            new Course { Id = 30, Name = "International Business", Prerequisites = new HashSet<int>{21}, CourseCredit = 3, CourseType = 1}, //1

                                            // Semester 6
                                            new Course { Id = 31, Name = "Business Research", Prerequisites = new HashSet<int>{20, 27}, CourseCredit = 3, CourseType = 1},
                                            new Course { Id = 32, Name = "Principles and Practices of Taxation", Prerequisites = new HashSet<int>{19, 21}, CourseCredit = 3, CourseType = 1},
                                            new Course { Id = 33, Name = "Ethics, Sustainability, and Communication for Development ", Prerequisites = new HashSet<int>{24}, CourseCredit = 3, CourseType = 1},
                                            new Course { Id = 34, Name = "Innovation and Entrepreneurship Development ", Prerequisites = new HashSet<int>{13}, CourseCredit = 3, CourseType = 1},

                                            // Semester 7
                                            new Course { Id = 35, Name = "Project Management", Prerequisites = new HashSet<int>{28, 29}, CourseCredit = 3, CourseType = 1},
                                            new Course { Id = 36, Name = "Business Communication", Prerequisites = new HashSet<int>{18, 33}, CourseCredit = 3, CourseType = 1},
                                            new Course { Id = 37, Name = "Corporate Governance and Social Responsibility", Prerequisites = new HashSet<int>{26, 33}, CourseCredit = 3, CourseType = 1},
                                           
                                            // Semester 8
                                            new Course { Id = 38, Name = "Strategic Management", Prerequisites = new HashSet<int>{35, 36}, CourseCredit = 3, CourseType = 1},
                                            new Course { Id = 39, Name = "Professional Development Course ", Prerequisites = new HashSet<int>(), CourseCredit = 3, CourseType = 1},
                                            new Course { Id = 40, Name = "Internship", Prerequisites = new HashSet<int>(), CourseCredit = 3, CourseType = 1}, // After Completion of 132 Cr.



                                            // Accounting (ACT) - Prerequisite: BBA 26 Financial Management (For All Elective Courses)
                                            new Course { Id = 41, Name = "Intermediate Accounting", Prerequisites = new HashSet<int> {26}, CourseCredit = 3, CourseType = 2},
                                            new Course { Id = 42, Name = "Cost Accounting", Prerequisites = new HashSet<int> {26}, CourseCredit = 3, CourseType = 2},
                                            new Course { Id = 43, Name = "Financial Statement Analysis", Prerequisites = new HashSet<int> {26}, CourseCredit = 3, CourseType = 2},
                                            new Course { Id = 44, Name = "Accounting Information Systems", Prerequisites = new HashSet<int> {26}, CourseCredit = 3, CourseType = 2},
                                            new Course { Id = 45, Name = "Auditing", Prerequisites = new HashSet<int> {26}, CourseCredit = 3, CourseType = 2},
                                            new Course { Id = 46, Name = "Financial and Corporate Reporting", Prerequisites = new HashSet<int> {26}, CourseCredit = 3, CourseType = 2},
                                            new Course { Id = 47, Name = "Advanced Cost Accounting", Prerequisites = new HashSet<int> {26}, CourseCredit = 3, CourseType = 2},
                                            new Course { Id = 48, Name = "Advanced Financial Accounting", Prerequisites = new HashSet<int> {26}, CourseCredit = 3, CourseType = 2},
                                            new Course { Id = 49, Name = "Strategic Management Accounting", Prerequisites = new HashSet<int> {26}, CourseCredit = 3, CourseType = 2},
                                            new Course { Id = 50, Name = "Accounting Theory and Policy", Prerequisites = new HashSet<int> {26}, CourseCredit = 3, CourseType = 2},
                                            new Course { Id = 51, Name = "Accounting for Specialized Institutions", Prerequisites = new HashSet<int> {26}, CourseCredit = 3, CourseType = 2},
                                            new Course { Id = 52, Name = "Corporate Finance", Prerequisites = new HashSet<int> {26}, CourseCredit = 3, CourseType = 2},

                                            // Business Analytics (BA) - Prerequisite: BBA 2117 Office Management Technology (For All Elective Courses)
                                            new Course { Id = 53, Name = "Analytics for Business Professionals", Prerequisites = new HashSet<int> {17}, CourseCredit = 3, CourseType = 3},
                                            new Course { Id = 54, Name = "Technology Adoption Theories and Models", Prerequisites = new HashSet<int> {17}, CourseCredit = 3, CourseType = 3},
                                            new Course { Id = 55, Name = "Visualization and Communication of Business Data", Prerequisites = new HashSet<int> {17}, CourseCredit = 3, CourseType = 3},
                                            new Course { Id = 56, Name = "Analytics for Sports Management", Prerequisites = new HashSet<int> {17}, CourseCredit = 3, CourseType = 3},
                                            new Course { Id = 57, Name = "Legal and Ethical Issues in Data Management", Prerequisites = new HashSet<int> {17}, CourseCredit = 3, CourseType = 3},
                                            new Course { Id = 58, Name = "Analyzing Exploratory Data in Business", Prerequisites = new HashSet<int> {17}, CourseCredit = 3, CourseType = 3},
                                            new Course { Id = 59, Name = "Analytics for Healthcare and Medical Industries", Prerequisites = new HashSet<int> {17}, CourseCredit = 3, CourseType = 3},
                                            new Course { Id = 60, Name = "Data and Web Analytics", Prerequisites = new HashSet<int> {17}, CourseCredit = 3, CourseType = 3},
                                            new Course { Id = 61, Name = "Financial Analytics", Prerequisites = new HashSet<int> {17}, CourseCredit = 3, CourseType = 3},
                                            new Course { Id = 62, Name = "Retail Analytics", Prerequisites = new HashSet<int> {17}, CourseCredit = 3, CourseType = 3},
                                            new Course { Id = 63, Name = "Analytics for Talent Management", Prerequisites = new HashSet<int> {17}, CourseCredit = 3, CourseType = 3},
                                            new Course { Id = 64, Name = "Seminar (Business Analytics)", Prerequisites = new HashSet<int> {17}, CourseCredit = 3, CourseType = 3},
                                            new Course { Id = 65, Name = "Capstone Project (Business Analytics)", Prerequisites = new HashSet<int> {17}, CourseCredit = 3, CourseType = 3},
                                            new Course { Id = 66, Name = "Database Analysis and Design", Prerequisites = new HashSet<int> {17}, CourseCredit = 3, CourseType = 3},
                                            new Course { Id = 67, Name = "Object Oriented Programming", Prerequisites = new HashSet<int> {17}, CourseCredit = 3, CourseType = 3},
                                            new Course { Id = 68, Name = "Data Warehouse and Data Mining", Prerequisites = new HashSet<int> {17}, CourseCredit = 3, CourseType = 3},
                                            new Course { Id = 69, Name = "Social Media and Digital Marketing", Prerequisites = new HashSet<int> {17}, CourseCredit = 3, CourseType = 3},
                                            new Course { Id = 70, Name = "Supply Chain Analytics", Prerequisites = new HashSet<int> {17}, CourseCredit = 3, CourseType = 3},


                                            // Business Economics (BECO) - Prerequisite: BBA 2222 Macro Economics (For All Elective Courses)
                                            new Course { Id = 71, Name = "Microeconomic Theory", Prerequisites = new HashSet<int> {22}, CourseCredit = 3, CourseType = 4},
                                            new Course { Id = 72, Name = "Macroeconomics of Developing Countries", Prerequisites = new HashSet<int> {22}, CourseCredit = 3, CourseType = 4},
                                            new Course { Id = 73, Name = "Mathematical Economics", Prerequisites = new HashSet<int> {22}, CourseCredit = 3, CourseType = 4},
                                            new Course { Id = 74, Name = "Applied Econometric Models", Prerequisites = new HashSet<int> {22}, CourseCredit = 3, CourseType = 4},
                                            new Course { Id = 75, Name = "Development Economics", Prerequisites = new HashSet<int> {22}, CourseCredit = 3, CourseType = 4},
                                            new Course { Id = 76, Name = "Political Economy", Prerequisites = new HashSet<int> {22}, CourseCredit = 3, CourseType = 4},
                                            new Course { Id = 77, Name = "Economics of Natural Resources and Environment", Prerequisites = new HashSet<int> {22}, CourseCredit = 3, CourseType = 4},
                                            new Course { Id = 78, Name = "Comparative Economic Analysis", Prerequisites = new HashSet<int> {22}, CourseCredit = 3, CourseType = 4},
                                            new Course { Id = 79, Name = "Bangladesh Economy", Prerequisites = new HashSet<int> {22}, CourseCredit = 3, CourseType = 4},
                                            new Course { Id = 80, Name = "Introduction to Game Theory", Prerequisites = new HashSet<int> {22}, CourseCredit = 3, CourseType = 4},
                                            new Course { Id = 81, Name = "Labor Economics", Prerequisites = new HashSet<int> {22}, CourseCredit = 3, CourseType = 4},
                                            new Course { Id = 82, Name = "Health Economics", Prerequisites = new HashSet<int> {22}, CourseCredit = 3, CourseType = 4},

                                            // Finance (FIN) - Prerequisite: BBA 3126 Financial Management (For All Elective Courses)
                                            new Course { Id = 83, Name = "Corporate Finance", Prerequisites = new HashSet<int> {26}, CourseCredit = 3, CourseType = 5},
                                            new Course { Id = 84, Name = "Financial Institutions and Markets", Prerequisites = new HashSet<int> {26}, CourseCredit = 3, CourseType = 5},
                                            new Course { Id = 85, Name = "Investment Analysis and Portfolio Management", Prerequisites = new HashSet<int> {26}, CourseCredit = 3, CourseType = 5},
                                            new Course { Id = 86, Name = "Capital Budgeting", Prerequisites = new HashSet<int> {26}, CourseCredit = 3, CourseType = 5},
                                            new Course { Id = 87, Name = "Bank Fund Management", Prerequisites = new HashSet<int> {26}, CourseCredit = 3, CourseType = 5},
                                            new Course { Id = 88, Name = "Working Capital Management", Prerequisites = new HashSet<int> {26}, CourseCredit = 3, CourseType = 5},
                                            new Course { Id = 89, Name = "Islamic Finance and Banking", Prerequisites = new HashSet<int> {26}, CourseCredit = 3, CourseType = 5},
                                            new Course { Id = 90, Name = "Global Finance", Prerequisites = new HashSet<int> {26}, CourseCredit = 3, CourseType = 5},
                                            new Course { Id = 91, Name = "Financial Derivatives", Prerequisites = new HashSet<int> {26}, CourseCredit = 3, CourseType = 5},
                                            new Course { Id = 92, Name = "Comprehensive Financial Case Analysis", Prerequisites = new HashSet<int> {26}, CourseCredit = 3, CourseType = 5},
                                            new Course { Id = 93, Name = "Financial Statement Analysis", Prerequisites = new HashSet<int> {26}, CourseCredit = 3, CourseType = 5},

                                            // Human Resource Management (HRM) - Prerequisite: BBA 3125 Human Resource Management (For All Elective Courses)
                                            new Course { Id = 94, Name = "Human Resource Planning and Forecasting", Prerequisites = new HashSet<int> {25}, CourseCredit = 3, CourseType = 6},
                                            new Course { Id = 95, Name = "Performance Appraisal and Management", Prerequisites = new HashSet<int> {25}, CourseCredit = 3, CourseType = 6},
                                            new Course { Id = 96, Name = "Selection and Staffing", Prerequisites = new HashSet<int> {25}, CourseCredit = 3, CourseType = 6},
                                            new Course { Id = 97, Name = "Training and Development", Prerequisites = new HashSet<int> {25}, CourseCredit = 3, CourseType = 6},
                                            new Course { Id = 98, Name = "Labor Law of Bangladesh", Prerequisites = new HashSet<int> {25}, CourseCredit = 3, CourseType = 6},
                                            new Course { Id = 99, Name = "Compensation and Benefit Management", Prerequisites = new HashSet<int> {25}, CourseCredit = 3, CourseType = 6},
                                            new Course { Id = 100, Name = "Industrial Relations Management", Prerequisites = new HashSet<int> {25}, CourseCredit = 3, CourseType = 6},
                                            new Course { Id = 101, Name = "Human Resource Information System (HRIS)", Prerequisites = new HashSet<int> {25}, CourseCredit = 3, CourseType = 6},
                                            new Course { Id = 102, Name = "Human Resource in Global Business Environment", Prerequisites = new HashSet<int> {25}, CourseCredit = 3, CourseType = 6},
                                            new Course { Id = 103, Name = "Occupational Health and Safety Management", Prerequisites = new HashSet<int> {25}, CourseCredit = 3, CourseType = 6},
                                            new Course { Id = 104, Name = "Organizational Theory and Development", Prerequisites = new HashSet<int> {25}, CourseCredit = 3, CourseType = 6},
                                            new Course { Id = 105, Name = "Strategic Human Resource Management", Prerequisites = new HashSet<int> {25}, CourseCredit = 3, CourseType = 6},

                                            // Innovation and Entrepreneurship Development (IED) - Prerequisite: BBA 3234 Innovation and Entrepreneurship Development (For All Elective Courses)
                                            new Course { Id = 106, Name = "Entrepreneurial Mindset and Behavior", Prerequisites = new HashSet<int> {34}, CourseCredit = 3, CourseType = 7},
                                            new Course { Id = 107, Name = "Accounting for Entrepreneurs", Prerequisites = new HashSet<int> {34}, CourseCredit = 3, CourseType = 7},
                                            new Course { Id = 108, Name = "New Venture Development", Prerequisites = new HashSet<int> {34}, CourseCredit = 3, CourseType = 7},
                                            new Course { Id = 109, Name = "Entrepreneurial Finance", Prerequisites = new HashSet<int> {34}, CourseCredit = 3, CourseType = 7},
                                            new Course { Id = 110, Name = "Economics for the Entrepreneurs", Prerequisites = new HashSet<int> {34}, CourseCredit = 3, CourseType = 7},
                                            new Course { Id = 111, Name = "Consumer Behavior and Digital Marketing", Prerequisites = new HashSet<int> {34}, CourseCredit = 3, CourseType = 7},
                                            new Course { Id = 112, Name = "E-commerce", Prerequisites = new HashSet<int> {34}, CourseCredit = 3, CourseType = 7},
                                            new Course { Id = 113, Name = "Marketing Research for Entrepreneurs", Prerequisites = new HashSet<int> {34}, CourseCredit = 3, CourseType = 7},
                                            new Course { Id = 114, Name = "Business Risk Management", Prerequisites = new HashSet<int> {34}, CourseCredit = 3, CourseType = 7},
                                            new Course { Id = 115, Name = "Enterprise Resource Planning", Prerequisites = new HashSet<int> {34}, CourseCredit = 3, CourseType = 7},
                                            new Course { Id = 116, Name = "Business Intelligence and Decision Support System", Prerequisites = new HashSet<int> {34}, CourseCredit = 3, CourseType = 7},

                                            // International Business (IB) - Prerequisite: BBA 3130 International Business (For All Elective Courses)
                                            new Course { Id = 117, Name = "International Banking", Prerequisites = new HashSet<int> {30}, CourseCredit = 3, CourseType = 8},
                                            new Course { Id = 118, Name = "Global Business Strategy", Prerequisites = new HashSet<int> {30}, CourseCredit = 3, CourseType = 8},
                                            new Course { Id = 119, Name = "International Enterprises and Transactions", Prerequisites = new HashSet<int> {30}, CourseCredit = 3, CourseType = 8},
                                            new Course { Id = 120, Name = "International Business Governance, Ethics and Law", Prerequisites = new HashSet<int> {30}, CourseCredit = 3, CourseType = 8},
                                            new Course { Id = 121, Name = "Development Economics", Prerequisites = new HashSet<int> {30}, CourseCredit = 3, CourseType = 8},
                                            new Course { Id = 122, Name = "Labor Economics", Prerequisites = new HashSet<int> {30}, CourseCredit = 3, CourseType = 8},
                                            new Course { Id = 123, Name = "Global Finance", Prerequisites = new HashSet<int> {30}, CourseCredit = 3, CourseType = 8},
                                            new Course { Id = 124, Name = "Human Resource in Global Business Environment", Prerequisites = new HashSet<int> {30}, CourseCredit = 3, CourseType = 8},
                                            new Course { Id = 125, Name = "Negotiation Theory and Practice", Prerequisites = new HashSet<int> {30}, CourseCredit = 3, CourseType = 8},
                                            new Course { Id = 126, Name = "Enterprise Resource Planning", Prerequisites = new HashSet<int> {30}, CourseCredit = 3, CourseType = 8},
                                            new Course { Id = 127, Name = "International Marketing", Prerequisites = new HashSet<int> {30}, CourseCredit = 3, CourseType = 8},
                                            new Course { Id = 128, Name = "Logistics Management", Prerequisites = new HashSet<int> {30}, CourseCredit = 3, CourseType = 8},

                                            // Investment Management (IM) - Prerequisite: BBA 3126 Financial Management (For All Elective Courses)
                                            new Course { Id = 130, Name = "Regulations and Investment", Prerequisites = new HashSet<int> {26}, CourseCredit = 3, CourseType = 9},
                                            new Course { Id = 131, Name = "Doing Business in Bangladesh", Prerequisites = new HashSet<int> {26}, CourseCredit = 3, CourseType = 9},
                                            new Course { Id = 132, Name = "Macroeconomic Conditions for Investment", Prerequisites = new HashSet<int> {26}, CourseCredit = 3, CourseType = 9},
                                            new Course { Id = 133, Name = "Economics and Law", Prerequisites = new HashSet<int> {26}, CourseCredit = 3, CourseType = 9},
                                            new Course { Id = 134, Name = "Business Risk Management", Prerequisites = new HashSet<int> {26}, CourseCredit = 3, CourseType = 9},
                                            new Course { Id = 135, Name = "Development Economics", Prerequisites = new HashSet<int> {26}, CourseCredit = 3, CourseType = 9},
                                            new Course { Id = 136, Name = "Labor Economics", Prerequisites = new HashSet<int> {26}, CourseCredit = 3, CourseType = 9},
                                            new Course { Id = 137, Name = "Financial Institutions and Markets", Prerequisites = new HashSet<int> {26}, CourseCredit = 3, CourseType = 9},
                                            new Course { Id = 138, Name = "Investment Analysis and Portfolio Management", Prerequisites = new HashSet<int> {26}, CourseCredit = 3, CourseType = 9},
                                            new Course { Id = 139, Name = "Global Finance", Prerequisites = new HashSet<int> {26}, CourseCredit = 3, CourseType = 9},
                                            new Course { Id = 140, Name = "Financial Derivatives", Prerequisites = new HashSet<int> {26}, CourseCredit = 3, CourseType = 9},
                                            new Course { Id = 141, Name = "Agri-business Management", Prerequisites = new HashSet<int> {26}, CourseCredit = 3, CourseType = 9},
                                            new Course { Id = 142, Name = "Negotiation Theory and Practice", Prerequisites = new HashSet<int> {26}, CourseCredit = 3, CourseType = 9},

                                            // Management (MGT)
                                            new Course { Id = 143, Name = "Management of Change and Technology", Prerequisites = new HashSet<int> { 13 }, CourseCredit = 3, CourseType = 10},
                                            new Course { Id = 144, Name = "Public Sector Management", Prerequisites = new HashSet<int> { 13 }, CourseCredit = 3, CourseType = 10},
                                            new Course { Id = 145, Name = "Environment Management", Prerequisites = new HashSet<int> { 13 }, CourseCredit = 3, CourseType = 10},
                                            new Course { Id = 146, Name = "Managing of NGOs and Small Business", Prerequisites = new HashSet<int> { 13 }, CourseCredit = 3, CourseType = 10},
                                            new Course { Id = 147, Name = "Cooperative Management", Prerequisites = new HashSet<int> { 13 }, CourseCredit = 3, CourseType = 10},
                                            new Course { Id = 148, Name = "Disaster Management", Prerequisites = new HashSet<int> { 13 }, CourseCredit = 3, CourseType = 10},
                                            new Course { Id = 150, Name = "Agri-business Management", Prerequisites = new HashSet<int> { 13 }, CourseCredit = 3, CourseType = 10},
                                            new Course { Id = 151, Name = "Negotiation Theory and Practice", Prerequisites = new HashSet<int> { 13 }, CourseCredit = 3, CourseType = 10},
                                            new Course { Id = 152, Name = "Labor Law of Bangladesh", Prerequisites = new HashSet<int> { 13 }, CourseCredit = 3, CourseType = 10},
                                            new Course { Id = 153, Name = "Industrial Relations Management", Prerequisites = new HashSet<int> { 13 }, CourseCredit = 3, CourseType = 10},
                                            new Course { Id = 154, Name = "Occupational Health and Safety Management", Prerequisites = new HashSet<int> { 13 }, CourseCredit = 3, CourseType = 10},
                                            new Course { Id = 155, Name = "Organization Theory and Development", Prerequisites = new HashSet<int> { 13 }, CourseCredit = 3, CourseType = 10},
                                            new Course { Id = 156, Name = "Global Business Strategy", Prerequisites = new HashSet<int> { 13 }, CourseCredit = 3, CourseType = 10},
                                            new Course { Id = 157, Name = "Inventory Management", Prerequisites = new HashSet<int> { 13 }, CourseCredit = 3, CourseType = 10},
                                            new Course { Id = 158, Name = "Hospitality Management", Prerequisites = new HashSet<int> { 13 }, CourseCredit = 3, CourseType = 10},


                                            // Management Information Systems (MIS)
                                            new Course { Id = 159, Name = "Enterprise Resource Planning", Prerequisites = new HashSet<int> { 29 }, CourseCredit = 3, CourseType = 11},
                                            new Course { Id = 160, Name = "Database Analysis and Design", Prerequisites = new HashSet<int> { 29 }, CourseCredit = 3, CourseType = 11},
                                            new Course { Id = 161, Name = "Object Oriented Programming", Prerequisites = new HashSet<int> { 29 }, CourseCredit = 3, CourseType = 11},
                                            new Course { Id = 162, Name = "Digital Marketing", Prerequisites = new HashSet<int> { 29 }, CourseCredit = 3, CourseType = 11},
                                            new Course { Id = 163, Name = "Data Warehouse and Data Mining", Prerequisites = new HashSet<int> { 29 }, CourseCredit = 3, CourseType = 11},
                                            new Course { Id = 164, Name = "Business Intelligence and Decision Support System", Prerequisites = new HashSet<int> { 29 }, CourseCredit = 3, CourseType = 11},
                                            new Course { Id = 165, Name = "Special Topic in MIS", Prerequisites = new HashSet<int> { 29 }, CourseCredit = 3, CourseType = 11},
                                            new Course { Id = 166, Name = "Web Technology", Prerequisites = new HashSet<int> { 29 }, CourseCredit = 3, CourseType = 11},
                                            new Course { Id = 167, Name = "Business Graphics and Animation", Prerequisites = new HashSet<int> { 29 }, CourseCredit = 3, CourseType = 11},
                                            new Course { Id = 168, Name = "Network Resource Management", Prerequisites = new HashSet<int> { 29 }, CourseCredit = 3, CourseType = 11},
                                            new Course { Id = 169, Name = "E-Commerce and E-Governance", Prerequisites = new HashSet<int> { 29 }, CourseCredit = 3, CourseType = 11},
                                            new Course { Id = 170, Name = "Introduction to Data Science", Prerequisites = new HashSet<int> { 29 }, CourseCredit = 3, CourseType = 11},
                                            new Course { Id = 171, Name = "Cyber Security", Prerequisites = new HashSet<int> { 29 }, CourseCredit = 3, CourseType = 11},
                                            new Course { Id = 172, Name = "Blockchain Technologies in Business", Prerequisites = new HashSet<int> { 29 }, CourseCredit = 3, CourseType = 11},


                                            // MKT
                                            new Course { Id = 173, Name = "Consumer Behavior", Prerequisites = new HashSet<int> { 27 }, CourseCredit = 3, CourseType = 12},
                                            new Course { Id = 174, Name = "Integrated Marketing Communication", Prerequisites = new HashSet<int> { 27 }, CourseCredit = 3, CourseType = 12},
                                            new Course { Id = 175, Name = "Social Media and Digital Marketing", Prerequisites = new HashSet<int> { 27 }, CourseCredit = 3, CourseType = 12},
                                            new Course { Id = 176, Name = "Services Marketing", Prerequisites = new HashSet<int> { 27 }, CourseCredit = 3, CourseType = 12},
                                            new Course { Id = 177, Name = "Sales Management", Prerequisites = new HashSet<int> { 27 }, CourseCredit = 3, CourseType = 12},
                                            new Course { Id = 178, Name = "International Marketing", Prerequisites = new HashSet<int> { 27 }, CourseCredit = 3, CourseType = 12},
                                            new Course { Id = 179, Name = "Distribution and Channel Management", Prerequisites = new HashSet<int> { 27 }, CourseCredit = 3, CourseType = 12},
                                            new Course { Id = 180, Name = "Brand and Product Management", Prerequisites = new HashSet<int> { 27 }, CourseCredit = 3, CourseType = 12},
                                            new Course { Id = 181, Name = "Rural Marketing", Prerequisites = new HashSet<int> { 27 }, CourseCredit = 3, CourseType = 12},
                                            new Course { Id = 182, Name = "Agro-based Product Marketing", Prerequisites = new HashSet<int> { 27 }, CourseCredit = 3, CourseType = 12},
                                            new Course { Id = 183, Name = "Marketing Strategy", Prerequisites = new HashSet<int> { 27 }, CourseCredit = 3, CourseType = 12},
                                            new Course { Id = 184, Name = "Marketing Research", Prerequisites = new HashSet<int> { 27 }, CourseCredit = 3, CourseType = 12},
                                            new Course { Id = 185, Name = "Product Innovation and Management", Prerequisites = new HashSet<int> { 27 }, CourseCredit = 3, CourseType = 12},
                                            new Course { Id = 186, Name = "Tourism and Hospitality Marketing", Prerequisites = new HashSet<int> { 27 }, CourseCredit = 3, CourseType = 12},


                                            // Tourism and Hospitality Management (THM)
                                            new Course { Id = 187, Name = "Introduction to Tourism and Hospitality Industry", Prerequisites = new HashSet<int> { 27 }, CourseCredit = 3, CourseType = 13},
                                            new Course { Id = 188, Name = "Tourism and Hospitality Marketing", Prerequisites = new HashSet<int> { 27 }, CourseCredit = 3, CourseType = 13},
                                            new Course { Id = 189, Name = "Housekeeping Management", Prerequisites = new HashSet<int> { 27 }, CourseCredit = 3, CourseType = 13},
                                            new Course { Id = 190, Name = "Recreation Management", Prerequisites = new HashSet<int> { 27 }, CourseCredit = 3, CourseType = 13},
                                            new Course { Id = 191, Name = "Tourism and Hospitality Law", Prerequisites = new HashSet<int> { 27 }, CourseCredit = 3, CourseType = 13},
                                            new Course { Id = 192, Name = "Travel Agency and Tour Operation Management", Prerequisites = new HashSet<int> { 27 }, CourseCredit = 3, CourseType = 13},
                                            new Course { Id = 193, Name = "Event and MICE (Meeting, Incentives, Convention and Exhibitions) Management", Prerequisites = new HashSet<int> { 23 }, CourseCredit = 3, CourseType = 13},
                                            new Course { Id = 194, Name = "Airline Reservation and Ticketing", Prerequisites = new HashSet<int> { 27 }, CourseCredit = 3, CourseType = 13},
                                            new Course { Id = 195, Name = "Food and Beverage Service Management", Prerequisites = new HashSet<int> { 27 }, CourseCredit = 3, CourseType = 13},
                                            new Course { Id = 196, Name = "Destination Planning and Development", Prerequisites = new HashSet<int> { 27 }, CourseCredit = 3, CourseType = 13},
                                            new Course { Id = 197, Name = "Hospitality Management", Prerequisites = new HashSet<int> { 27 }, CourseCredit = 3, CourseType = 13},
                                            new Course { Id = 198, Name = "Consumer Behavior", Prerequisites = new HashSet<int> { 27 }, CourseCredit = 3, CourseType = 13},
                                            new Course { Id = 199, Name = "Services Marketing", Prerequisites = new HashSet<int> { 27 }, CourseCredit = 3, CourseType = 13},
                                            new Course { Id = 200, Name = "Marketing Strategy", Prerequisites = new HashSet<int> { 27 }, CourseCredit = 3, CourseType = 13},
                                            new Course { Id = 201, Name = "Marketing Research", Prerequisites = new HashSet<int> { 27 }, CourseCredit = 3, CourseType = 13},


                                            // Operations and Supply Chain Management (OSCM)
                                            new Course { Id = 202, Name = "Advanced Supply Chain Management", Prerequisites = new HashSet<int> { 28 }, CourseCredit = 3, CourseType = 14},
                                            new Course { Id = 203, Name = "Inventory Management", Prerequisites = new HashSet<int> { 28 }, CourseCredit = 3, CourseType = 14},
                                            new Course { Id = 204, Name = "Sourcing and Negotiation", Prerequisites = new HashSet<int> { 28 }, CourseCredit = 3, CourseType = 14},
                                            new Course { Id = 205, Name = "Logistics Management", Prerequisites = new HashSet<int> { 28 }, CourseCredit = 3, CourseType = 14},
                                            new Course { Id = 206, Name = "Managerial Forecasting", Prerequisites = new HashSet<int> { 28 }, CourseCredit = 3, CourseType = 14},
                                            new Course { Id = 207, Name = "Purchasing and Procurement", Prerequisites = new HashSet<int> { 28 }, CourseCredit = 3, CourseType = 14},
                                            new Course { Id = 208, Name = "Supply Chain Analytics", Prerequisites = new HashSet<int> { 28 }, CourseCredit = 3, CourseType = 14},
                                            new Course { Id = 209, Name = "Service Operations Management", Prerequisites = new HashSet<int> { 28 }, CourseCredit = 3, CourseType = 14},
                                            new Course { Id = 210, Name = "Total Quality Management", Prerequisites = new HashSet<int> { 28 }, CourseCredit = 3, CourseType = 14},
                                            new Course { Id = 211, Name = "Product Strategy Management", Prerequisites = new HashSet<int> { 28 }, CourseCredit = 3, CourseType = 14},
                                            new Course { Id = 212, Name = "Enterprise Resource Planning", Prerequisites = new HashSet<int> { 28 }, CourseCredit = 3, CourseType = 14},
                                            new Course { Id = 213, Name = "Blockchain Technologies in Business", Prerequisites = new HashSet<int> { 28 }, CourseCredit = 3, CourseType = 14},

            };
        }

        public static List<Course> IPECourses()
        {
            return new List<Course>
            {
                // Semester 1
                new Course { Id = 1, Name = "INTRODUCTION TO ENGINEERING STUDIES", Prerequisites = new HashSet<int>(), CourseCredit = 1, CourseType = 1}, // 1
                new Course { Id = 2, Name = "CHEMISTRY", Prerequisites = new HashSet<int>(), CourseCredit = 3, CourseType = 1}, // 2
                new Course { Id = 3, Name = "PHYSICS 1", Prerequisites = new HashSet<int>(), CourseCredit = 3, CourseType = 1}, // 3
                new Course { Id = 4, Name = "PHYSICS 1 LAB", Prerequisites = new HashSet<int>(), CourseCredit = 1, CourseType = 1}, // 4
                new Course { Id = 5, Name = "ENGINEERING DRAWING", Prerequisites = new HashSet<int>(), CourseCredit = 1, CourseType = 1}, // 5
                new Course { Id = 6, Name = "DIFFERENTIAL CALCULUS AND COORDINATE GEOMETRY", Prerequisites = new HashSet<int>(), CourseCredit = 3, CourseType = 1}, // 6
                new Course { Id = 7, Name = "ENGLISH READING SKILLS & PUBLIC SPEAKING", Prerequisites = new HashSet<int>(), CourseCredit = 3, CourseType = 1}, // 7
                new Course { Id = 8, Name = "BANGLADESH STUDIES", Prerequisites = new HashSet<int>(), CourseCredit = 3, CourseType = 1}, // 8
                new Course { Id = 9, Name = "MACHINE JOB SHOP- I (DRILLING, WELDING, MILLING AND TURNING)", Prerequisites = new HashSet<int>(), CourseCredit = 1, CourseType = 1}, // 9


                // Semester 2
                new Course { Id = 10, Name = "ENGINEERING MATERIALS", Prerequisites = new HashSet<int> { 9 }, CourseCredit = 3, CourseType = 1}, // 10
                new Course { Id = 11, Name = "ENGINEERING MATERIALS LAB", Prerequisites = new HashSet<int> { 9 }, CourseCredit = 1, CourseType = 1}, // 11
                new Course { Id = 12, Name = "ENGINEERING MECHANICS", Prerequisites = new HashSet<int> { 6 }, CourseCredit = 3, CourseType = 1}, // 12
                new Course { Id = 13, Name = "ENGINEERING MECHANICS LAB", Prerequisites = new HashSet<int> { 6 }, CourseCredit = 1, CourseType = 1}, // 13
                new Course { Id = 14, Name = "ENGLISH WRITING SKILLS & COMMUNICATIONS", Prerequisites = new HashSet<int> { 7 }, CourseCredit = 3, CourseType = 1}, // 14
                new Course { Id = 15, Name = "INTEGRAL CALCULUS & ORDINARY DIFFERENTIAL EQUATION", Prerequisites = new HashSet<int> { 6 }, CourseCredit = 3, CourseType = 1}, // 15
                new Course { Id = 16, Name = "BASIC MECHANICAL ENGINEERING", Prerequisites = new HashSet<int> { 1 }, CourseCredit = 3, CourseType = 1}, // 16
                new Course { Id = 17, Name = "COMPUTER AIDED DRAWING", Prerequisites = new HashSet<int> { 5 }, CourseCredit = 1, CourseType = 1}, // 17
                new Course { Id = 18, Name = "MACHINE JOB SHOP- II (SHEET METAL FORMING AND CASTING)", Prerequisites = new HashSet<int> { 9 }, CourseCredit = 1, CourseType = 1}, // 18


                // Semester 3
                new Course { Id = 19, Name = "INTRODUCTION TO ELECTRICAL CIRCUITS", Prerequisites = new HashSet<int> { 3 }, CourseCredit = 3, CourseType = 1}, // 19
                new Course { Id = 20, Name = "INTRODUCTION TO ELECTRICAL CIRCUITS LAB", Prerequisites = new HashSet<int> { 4 }, CourseCredit = 1, CourseType = 1}, // 20
                new Course { Id = 21, Name = "COMPLEX VARIABLE, LAPLACE & Z-TRANSFORMATION", Prerequisites = new HashSet<int> { 6 }, CourseCredit = 3, CourseType = 1}, // 21
                new Course { Id = 22, Name = "PHYSICS 2", Prerequisites = new HashSet<int> { 3 }, CourseCredit = 3, CourseType = 1}, // 22
                new Course { Id = 23, Name = "PHYSICS 2 LAB", Prerequisites = new HashSet<int> { 4 }, CourseCredit = 1, CourseType = 1}, // 23
                new Course { Id = 24, Name = "PRINCIPLES OF ACCOUNTING [IPE]", Prerequisites = new HashSet<int> { 15 }, CourseCredit = 2, CourseType = 1}, // 24
                new Course { Id = 25, Name = "MECHANICS OF SOLIDS", Prerequisites = new HashSet<int> { 12 }, CourseCredit = 3, CourseType = 1}, // 25
                new Course { Id = 26, Name = "MECHANICS OF SOLIDS LAB", Prerequisites = new HashSet<int> { 13 }, CourseCredit = 1, CourseType = 1}, // 26
                new Course { Id = 27, Name = "PROGRAMMING LANGUAGE 1 (STRUCTURED PROGRAMMING LANGUAGE)", Prerequisites = new HashSet<int> { 15 }, CourseCredit = 3, CourseType = 1}, // 27


                // Semeseter 4
                new Course { Id = 28, Name = "MANUFACTURING AND PRODUCTION PROCESS I", Prerequisites = new HashSet<int> { 18 }, CourseCredit = 3, CourseType = 1}, // 28
                new Course { Id = 29, Name = "MANUFACTURING AND PRODUCTION PROCESS I LAB", Prerequisites = new HashSet<int> { 18 }, CourseCredit = 1, CourseType = 1}, // 29
                new Course { Id = 30, Name = "STATISTICAL DECISION MAKING FOR ENGINEERS", Prerequisites = new HashSet<int> { 21 }, CourseCredit = 3, CourseType = 1}, // 30
                new Course { Id = 31, Name = "MATRICES, VECTORS, FOURIER ANALYSIS", Prerequisites = new HashSet<int> { 21 }, CourseCredit = 3, CourseType = 1}, // 31
                new Course { Id = 32, Name = "MACHINE TOOLS", Prerequisites = new HashSet<int> { 18 }, CourseCredit = 3, CourseType = 1}, // 32
                new Course { Id = 33, Name = "MACHINE TOOLS LAB", Prerequisites = new HashSet<int> { 18 }, CourseCredit = 1, CourseType = 1}, // 33
                new Course { Id = 34, Name = "PRINCIPLES OF ECONOMICS", Prerequisites = new HashSet<int> { 24 }, CourseCredit = 2, CourseType = 1}, // 34
                new Course { Id = 35, Name = "FLUID MECHANICS AND MACHINERY", Prerequisites = new HashSet<int> { 16 }, CourseCredit = 3, CourseType = 1}, // 35
                new Course { Id = 36, Name = "FLUID MECHANICS AND MACHINERY LAB", Prerequisites = new HashSet<int> { 16 }, CourseCredit = 1, CourseType = 1}, // 36
                //
                // Semester 5
                new Course { Id = 37, Name = "NUMERICAL METHODS FOR SCIENCE AND ENGINEERING", Prerequisites = new HashSet<int> { 31 }, CourseCredit = 3, CourseType = 1}, // 37
                new Course { Id = 38, Name = "TECH ELECTIVE 1", Prerequisites = new HashSet<int> { 30 }, CourseCredit = 3, CourseType = 1}, // 37
                new Course { Id = 39, Name = "LOGISTICS AND DISTRIBUTION MANAGEMENT", Prerequisites = new HashSet<int> { 24 }, CourseCredit = 3, CourseType = 1}, // 38
                new Course { Id = 40, Name = "PRODUCT DESIGN AND DEVELOPMENT", Prerequisites = new HashSet<int> { 30 }, CourseCredit = 3, CourseType = 1}, // 39
                new Course { Id = 41, Name = "MANUFACTURING AND PRODUCTION PROCESS II", Prerequisites = new HashSet<int> { 28 }, CourseCredit = 3, CourseType = 1}, // 40
                new Course { Id = 42, Name = "COMPUTER INTEGRATED MANUFACTURING", Prerequisites = new HashSet<int> { 17 }, CourseCredit = 3, CourseType = 1}, // 41
                new Course { Id = 43, Name = "ENGINEERING ECONOMY [IPE]", Prerequisites = new HashSet<int> { 24 }, CourseCredit = 3, CourseType = 1}, // 42


                // Semseter 6
                new Course { Id = 44, Name = "BUSINESS COMMUNICATION", Prerequisites = new HashSet<int> { 13 }, CourseCredit = 3, CourseType = 1}, // 43
                new Course { Id = 45, Name = "TECH ELECTIVE 2", Prerequisites = new HashSet<int> { 43 }, CourseCredit = 3, CourseType = 1}, // 44
                new Course { Id = 46, Name = "OPERATIONS MANAGEMENT [IPE]", Prerequisites = new HashSet<int> { 39 }, CourseCredit = 3, CourseType = 1}, // 45
                new Course { Id = 47, Name = "OPERATIONS RESEARCH [IPE]", Prerequisites = new HashSet<int> { 39 }, CourseCredit = 3, CourseType = 1}, // 46
                new Course { Id = 48, Name = "QUALITY MANAGEMENT", Prerequisites = new HashSet<int> { 39 }, CourseCredit = 3, CourseType = 1}, // 47
                new Course { Id = 49, Name = "PROJECT MANAGEMENT [IPE]", Prerequisites = new HashSet<int> { 39 }, CourseCredit = 3, CourseType = 1}, // 48


                // Semseter 7//
                new Course { Id = 50, Name = "MODERN CONTROL SYSTEMS", Prerequisites = new HashSet<int> { 31 }, CourseCredit = 3, CourseType = 1}, // 49
                new Course { Id = 51, Name = "MODERN CONTROL SYSTEMS LAB", Prerequisites = new HashSet<int> { 31 }, CourseCredit = 1, CourseType = 1}, // 50
                new Course { Id = 52, Name = "SUPPLY CHAIN MANAGEMENT [IPE]", Prerequisites = new HashSet<int> { 46 }, CourseCredit = 3, CourseType = 1}, // 51
                new Course { Id = 53, Name = "TECH ELECTIVE 3", Prerequisites = new HashSet<int> { 49 }, CourseCredit = 3, CourseType = 1}, // 52
                new Course { Id = 54, Name = "DESIGN AND SIMULATION IN IE", Prerequisites = new HashSet<int> { 42 }, CourseCredit = 3, CourseType = 1}, // 53
                new Course { Id = 55, Name = "DESIGN AND SIMULATION IN IE LAB", Prerequisites = new HashSet<int> { 42}, CourseCredit = 1, CourseType = 1}, // 54
                new Course { Id = 56, Name = "ENGINEERING ETHICS AND ENVIRONMENTAL PROTECTION", Prerequisites = new HashSet<int> { 49 }, CourseCredit = 1, CourseType = 1}, // 55


                // Semseter 8
                new Course { Id = 57, Name = "CAPSTONE PROJECT [IPE]", Prerequisites = new HashSet<int> { 49 }, CourseCredit = 3, CourseType = 1}, // 56
                new Course { Id = 58, Name = "TECH ELECTIVE 4", Prerequisites = new HashSet<int> { 56 }, CourseCredit = 3, CourseType = 1}, // 57
                new Course { Id = 59, Name = "INDUSTRIAL ERGONOMICS AND OCCUPATIONAL SAFETY", Prerequisites = new HashSet<int> { 41 }, CourseCredit = 3, CourseType = 1}, // 57
                new Course { Id = 60, Name = "MAINTENANCE MANAGEMENT", Prerequisites = new HashSet<int> { 41 }, CourseCredit = 3, CourseType = 1}, // 58
                new Course { Id = 61, Name = "VALUE CHAIN MANAGEMENT", Prerequisites = new HashSet<int> { 52 }, CourseCredit = 3, CourseType = 1}, // 59
                new Course { Id = 62, Name = "INDUSTRIAL TRAINING / INTERNSHIP", Prerequisites = new HashSet<int> { 44 }, CourseCredit = 1, CourseType = 1}, // 59


                // Elective Courses
                // MAJOR IN INDUSTRIAL ENGINEERING
                new Course { Id = 63, Name = "ENGINEERING MANAGEMENT [IPE]", Prerequisites = new HashSet<int> { 49 }, CourseCredit = 3, CourseType = 2}, // 60
                new Course { Id = 64, Name = "HUMAN FACTORS ENGINEERING", Prerequisites = new HashSet<int> { 39 }, CourseCredit = 3, CourseType = 2}, // 61
                new Course { Id = 65, Name = "OCCUPATIONAL ERGONOMICS", Prerequisites = new HashSet<int> { 59 }, CourseCredit = 3, CourseType = 2}, // 62
                new Course { Id = 66, Name = "MANAGERIAL COMMUNICATION FOR ENGINEERS", Prerequisites = new HashSet<int> { 49 }, CourseCredit = 3, CourseType = 2}, // 63
                new Course { Id = 67, Name = "FACILITY DESIGN AND MATERIAL HANDLING", Prerequisites = new HashSet<int> { 59 }, CourseCredit = 3, CourseType = 2}, // 64
                new Course { Id = 68, Name = "MARKETING MANAGEMENT [IPE]", Prerequisites = new HashSet<int> { 52 }, CourseCredit = 3, CourseType = 2}, // 65
                new Course { Id = 69, Name = "MANAGEMENT OF TECHNOLOGY [IPE]", Prerequisites = new HashSet<int> { 60 }, CourseCredit = 3, CourseType = 2}, // 66


                // MAJOR IN SYSTEM ENGINEERING
                new Course { Id = 70, Name = "PRODUCTION SYSTEMS PLANNING", Prerequisites = new HashSet<int> { 54 }, CourseCredit = 3, CourseType = 3}, // 67
                new Course { Id = 71, Name = "AUTOMATED SYSTEM ENGINEERING", Prerequisites = new HashSet<int> { 42 }, CourseCredit = 3, CourseType = 3}, // 68
                new Course { Id = 72, Name = "DESIGN AND ANALYSIS OF INDUSTRIAL SYSTEMS WITH SIMULATION", Prerequisites = new HashSet<int> { 54 }, CourseCredit = 3, CourseType = 3}, // 69
                new Course { Id = 73, Name = "PRINCIPLES OF PROGRAMMABLE AUTOMATION", Prerequisites = new HashSet<int> { 50 }, CourseCredit = 3, CourseType = 3}, // 70
                new Course { Id = 74, Name = "MANUFACTURING SYSTEMS DESIGN", Prerequisites = new HashSet<int> { 41 }, CourseCredit = 3, CourseType = 3}, // 71
                new Course { Id = 75, Name = "ENGINEERING DATABASE DESIGN", Prerequisites = new HashSet<int> { 46 }, CourseCredit = 3, CourseType = 3}, // 72
                new Course { Id = 76, Name = "IE SYSTEMS DESIGN", Prerequisites = new HashSet<int> { 37 }, CourseCredit = 3, CourseType = 3}, // 73


                // MAJOR IN PRODUCTION ENGINEERING
                new Course { Id = 77, Name = "MODERN MANUFACTURING TECHNOLOGY", Prerequisites = new HashSet<int> { 28 }, CourseCredit = 3, CourseType = 4}, // 74
                new Course { Id = 78, Name = "METAL CUTTING PROCESS", Prerequisites = new HashSet<int> { 10 }, CourseCredit = 3, CourseType = 4}, // 75
                new Course { Id = 79, Name = "MECHATRONICS ENGINEERING", Prerequisites = new HashSet<int> { 37 }, CourseCredit = 3, CourseType = 4}, // 76
                new Course { Id = 80, Name = "PRODUCTION PLANNING & PROCESS CONTROL", Prerequisites = new HashSet<int> { 41 }, CourseCredit = 3, CourseType = 4}, // 77
                new Course { Id = 81, Name = "MICRO MANUFACTURING", Prerequisites = new HashSet<int> {28 }, CourseCredit = 3, CourseType = 4}, // 78
                new Course { Id = 82, Name = "GREEN TECHNOLOGY", Prerequisites = new HashSet<int> { 2 }, CourseCredit = 3, CourseType = 4}, // 79
                new Course { Id = 83, Name = "ADVANCE MATERIAL AND PROCESS", Prerequisites = new HashSet<int> { 28 }, CourseCredit = 3, CourseType = 4}, // 80
            };
        }


    }
}
