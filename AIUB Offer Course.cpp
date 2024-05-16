#include <bits/stdc++.h>
using namespace std;

// Define a structure to hold course information
struct Course 
{
    string name;
    unordered_set<int> prerequisites;
    int courseCredit;
};

// Function prototypes
void course();
void printCourses(const vector<Course>& courses);
void recommendCourses(const vector<Course>& allCourses, const vector<int>& completedCourses, int totalCreditCompleted);

int main() 
{
    course();
    return 0;
}


void course()
{
     // Define courses with their prerequisites
    vector<Course> allCourses = 
                            {
                                /*1*/  {"DIFFERENTIAL CALCULUS & CO-ORDINATE GEOMETRY", {}, 3},
                                /*2*/  {"PHYSICS 1", {}, 3},
                                /*3*/  {"PHYSICS 1 LAB", {}, 1},
                                /*4*/  {"ENGLISH READING SKILLS & PUBLIC SPEAKING", {}, 3},
                                /*5*/  {"INTRODUCTION TO PROGRAMMING", {}, 3},
                                /*6*/  {"INTRODUCTION TO PROGRAMMING LAB", {}, 1},
                                /*7*/  {"INTRODUCTION TO COMPUTER STUDIES", {}, 3},
                                                             
                                // Semester 2
                                /*8*/  {"DISCRETE MATHEMATICS", {1, 5}, 3},
                                /*9*/  {"INTEGRAL CALCULUS & ORDINARY DIFFERENTIAL EQUATIONS", {1}, 3},
                                /*10*/ {"OBJECT ORIENTED PROGRAMMING 1", {5, 6}, 3},
                                /*11*/ {"PHYSICS 2", {2}, 3},
                                /*12*/ {"PHYSICS 2 LAB", {3}, 1},
                                /*13*/ {"ENGLISH WRITING SKILLS & COMMUNICATION", {4}, 3},
                                /*14*/ {"INTRODUCTION TO ELECTRICAL CIRCUITS", {2}, 3},
                                /*15*/ {"INTRODUCTION TO ELECTRICAL CIRCUITS LAB", {3}, 1},
                                
                                // Semester 3
                                /*16*/ {"CHEMISTRY", {11}, 3},
                                /*17*/ {"COMPLEX VARIABLE,LAPLACE & Z-TRANSFORMATION", {9}, 3},
                                /*18*/ {"INTRODUCTION TO DATABASE", {10}, 3},
                                /*19*/ {"ELECTRONIC DEVICES", {14}, 3},
                                /*20*/ {"ELECTRONIC DEVICES LAB", {15}, 1},
                                /*21*/ {"DATA STRUCTURE", {8, 10}, 3},
                                /*22*/ {"DATA STRUCTURE LAB", {8, 10}, 1},
                                /*23*/ {"COMPUTER AIDED DESIGN & DRAFTING", {}, 1},
                                
                                // Semester 4
                                /*24*/ {"ALGORITHMS", {21, 22}, 3},
                                /*25*/ {"MATRICES, VECTORS, FOURIER ANALYSIS", {17}, 3},
                                /*26*/ {"OBJECT ORIENTED PROGRAMMING 2", {10, 19}, 3},
                                /*27*/ {"OBJECT ORIENTED ANALYSIS AND DESIGN", {20}, 3},
                                /*28*/ {"BANGLADESH STUDIES", {6}, 3},
                                /*29*/ {"DIGITAL LOGIC AND CIRCUITS", {15}, 3},
                                /*30*/ {"DIGITAL LOGIC AND CIRCUITS LAB", {16}, 1},
                                /*31*/ {"COMPUTATIONAL STATISTICS AND PROBABILITY", {17}, 3},
                                
                                // Semester 5
                                /*32*/ {"THEORY OF COMPUTATION", {24}, 3},
                                /*33*/ {"PRINCIPLES OF ECONOMICS", {31}, 2},
                                /*34*/ {"BUSINESS COMMUNICATION", {28}, 3},
                                /*35*/ {"NUMERICAL METHODS FOR SCIENCE AND ENGINEERING", {25}, 3},
                                /*36*/ {"DATA COMMUNICATION", {31, 32}, 3},
                                /*37*/ {"MICROPROCESSOR AND EMBEDDED SYSTEM", {31, 32}, 3},
                                /*38*/ {"SOFTWARE ENGINEERING", {27, 28}, 3},
                                
                                // Semester 6
                                /*39*/ {"ARTIFICIAL INTELLIGENCE AND EXPERT SYS.", {25, 31}, 3},
                                /*40*/ {"COMPUTER NETWORKS", {37}, 3},
                                /*41*/ {"COMPUTER ORGANIZATION AND ARCHITECTURE", {38}, 3},
                                /*42*/ {"OPERATING SYSTEM", {25, 38}, 3},
                                /*43*/ {"WEB TECHNOLOGIES", {39}, 3},
                                /*44*/ {"ENGINEERING ETHICS", {38, 39}, 2},
                                /*45*/ {"COMPILER DESIGN", {32}, 3},
                                
                                // Semester 7
                                /*46*/ {"COMPUTER GRAPHICS", {25, 26}, 3},
                                /*47*/ {"ENGINEERING MANAGEMENT", {44}, 3},
                                /*48*/ {"RESEARCH METHODOLOGY", {}, 3},
                                
                                // Semester 8
                                /*49*/ //{"THESIS / PROJECT", {}},
                                
                               
                                
                            };
                            
    // Print available courses
    printCourses(allCourses);
                            
    // Get completed courses from the user
    cout << "Enter completed course numbers separated by spaces: ";
    string line;
    getline(cin, line);
    istringstream iss(line);
    int courseNumber;
    vector<int> completedCourses;
    while (iss >> courseNumber) 
        completedCourses.push_back(courseNumber);
    
    // Calculate total credit for completed courses
    int totalCreditCompleted = 0;
    for (int courseNum : completedCourses) 
    {
        if (courseNum >= 1 && courseNum <= allCourses.size()) 
        {
            int index = courseNum - 1;
            totalCreditCompleted += allCourses[index].courseCredit;
        }
    }
    
    cout << "Total credit completed: " << totalCreditCompleted << endl;

    // Recommend next semester courses
    recommendCourses(allCourses, completedCourses, totalCreditCompleted);
    
}





// Function to print available courses
void printCourses(const vector<Course>& courses) 
{
    cout << "Available Courses:\n";
    for (int i = 0; i < courses.size(); ++i) 
        cout << i + 1 << ". " << courses[i].name << endl;
    
}

// Function to recommend next semester courses
void recommendCourses(const vector<Course>& allCourses, const vector<int>& completedCourses, int totalCreditCompleted) 
{
    // Store completed courses in a set for fast lookup
    unordered_set<int> completedSet(completedCourses.begin(), completedCourses.end());
    
    cout << "Recommended Courses:\n";
    for (int i = 0; i < allCourses.size(); ++i) 
    {
        // Skip courses that have already been completed
        if (completedSet.find(i + 1) != completedSet.end()) 
            continue;
        
        const Course& course = allCourses[i];
        
        bool canTake = true;
        // Check if all prerequisites are completed
        for (int prereq : course.prerequisites) 
        {
            if (completedSet.find(prereq) == completedSet.end()) 
            {
                canTake = false;
                break;
            }
        }
        
        // Check if the course is "RESEARCH METHODOLOGY" and total credit completed is less than 100
        if (course.name == "RESEARCH METHODOLOGY" && totalCreditCompleted < 100) 
            canTake = false;
        
        
        if (canTake) 
            cout << "- " << course.name << endl;
    }
}


void ElectiveCourse()
{
     // Elective
     vector<Course> allCourses = 
                                {
                                    /*50*/ //{"ADVANCE DATABASE MANAGEMENT SYSTEM", {}},
                                    /*51*/ {"BASIC MECHANICAL ENGG.", {}, 3},
                                    /*52*/ {"MANAGEMENT INFORMATION SYSTEM", {}, 3},
                                    /*53*/ {"SIGNALS & LINEAR SYSTEM", {}, 3},
                                    /*54*/ {"BASIC GRAPH THEORY", {}, 3},
                                    /*55*/ {"DIGITAL SYSTEM DESIGN", {}, 3},
                                    /*56*/ {"IMAGE PROCESSING", {}, 3},
                                    /*57*/ {"MULTIMEDIA SYSTEMS", {}, 3},
                                    /*58*/ {"SIMULATION & MODELING", {}, 3},
                                    /*59*/ {"ENTERPRISE RESOURCE PLANNING", {}, 3},
                                    /*60*/ {"DATA WAREHOUSE AND DATA MINING", {}, 3},
                                    /*61*/ {"NATURAL LANGUAGE PROCESSING", {}, 3},
                                    /*62*/ {"SOFTWARE DEVELOPMENT PROJECT MANAGEMENT", {}, 3},
                                    /*63*/ {"COMPUTER SCIENCE MATHEMATICS", {}, 3},
                                    /*64*/ {"MACHINE LEARNING", {}, 3},
                                    /*65*/ {"WIRELESS SENSOR NETWORKS", {}, 3},
                                    /*66*/ {"INDUSTRIAL ELECTRONICS, DRIVES & INSTRUMENTATION", {}, 3},
                                    /*67*/ {"MOBILE APPLICATION DEVELOPMENT", {}, 3},
                                    /*68*/ {"SOFTWARE ARCHITECTURE AND DESIGN PATTERNS", {}, 3},
                                    /*69*/ {"HUMAN COMPUTER INTERACTION", {}, 3},
                                    /*70*/ {"ADVANCED COMPUTER NETWORKS", {}, 3},
                                    /*71*/ {"SOFTWARE REQUIREMENT ENGINEERING", {}, 3},
                                    /*72*/ {"COMPUTER VISION AND PATTERN RECOGNITION", {}, 3},
                                    
                                    
                                    /*73*/ {"DIGITAL MARKETING", {}, 3},
                                    /*74*/ {"E-COMMERCE, E-GOVERNANCE & E-SERIES", {}, 3},
                                    /*75*/ {"DIGITAL SIGNAL PROCESSING", {}, 3},
                                    /*76*/ {"VLSI CIRCUIT DESIGN", {}, 3}
                               };
}

