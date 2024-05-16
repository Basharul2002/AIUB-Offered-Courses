#include <bits/stdc++.h>
using namespace std;

void course();
void printCourses(const vector<Course>& courses);
void recommendCourses(const vector<Course>& allCourses, const vector<int>& completedCourses);


// Define a structure to hold course information
struct Course 
{
    string name;
    unordered_set<int> prerequisites;
    int courseCredit;
};


int main() {
    
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
                                /*3*/  {"PHYSICS 1 LAB", {}, {1}},
                                /*4*/  {"ENGLISH READING SKILLS & PUBLIC SPEAKING", {}, 3},
                                /*5*/  {"INTRODUCTION TO PROGRAMMING", {}, 3},
                                /*6*/  {"INTRODUCTION TO PROGRAMMING LAB", {}, 3},
                                /*7*/  {"INTRODUCTION TO COMPUTER STUDIES", {}, 3},
                                                             
                                // Semester 2
                                /*7*/  {"DISCRETE MATHEMATICS", {1, 5}, 3},
                                /*8*/  {"INTEGRAL CALCULUS & ORDINARY DIFFERENTIAL EQUATIONS", {1}, 3},
                                /*9*/  {"OBJECT ORIENTED PROGRAMMING 1", {5, 6}, 3},
                                /*10*/ {"PHYSICS 2", {2}, 3},
                                /*11*/ {"PHYSICS 2 LAB", {3}, 3},
                                /*12*/ {"ENGLISH WRITING SKILLS & COMMUNICATION", {4}, 3},
                                /*13*/ {"INTRODUCTION TO ELECTRICAL CIRCUITS", {2}, 3},
                                /*14*/ {"INTRODUCTION TO ELECTRICAL CIRCUITS LAB", {3}, 1},
                                
                                // Semester 3
                                /*15*/ {"CHEMISTRY", {11}, 3},
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
                                /*34*/ {"BUSINESS COMMUNICATION", {28}, {3}},
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
                                
                                // Elective
                                /*50*/ //{"ADVANCE DATABASE MANAGEMENT SYSTEM", {}},
                                /*51*/ {"BASIC MECHANICAL ENGG.", {}, 3},
                                /*52*/ {"MANAGEMENT INFORMATION SYSTEM", {}, 3},
                                /*53*/ {"SIGNALS & LINEAR SYSTEM", {}, 3},
                                /*54*/ {"BASIC GRAPH THEORY", {}, 3},
                                /*55*/ {"DIGITAL SYSTEM DESIGN", {}, 3},
                                /*56*/ {"IMAGE PROCESSING", {}},
                                /*57*/ {"MULTIMEDIA SYSTEMS", {}},
                                /*58*/ {"SIMULATION & MODELING", {}},
                                /*59*/ {"ENTERPRISE RESOURCE PLANNING", {}},
                                /*60*/ {"DATA WAREHOUSE AND DATA MINING", {}},
                                /*61*/ {"NATURAL LANGUAGE PROCESSING", {}},
                                /*62*/ {"SOFTWARE DEVELOPMENT PROJECT MANAGEMENT", {}},
                                /*52*/ {"COMPUTER SCIENCE MATHEMATICS", {}},
                                /*50*/ {"MACHINE LEARNING", {}},
                                /*51*/ {"WIRELESS SENSOR NETWORKS", {}},
                                /*52*/ {"INDUSTRIAL ELECTRONICS, DRIVES & INSTRUMENTATION", {}},
                                /*53*/ {"MOBILE APPLICATION DEVELOPMENT", {}},
                                /*54*/ {"SOFTWARE ARCHITECTURE AND DESIGN PATTERNS", {}},
                                /*55*/ {"HUMAN COMPUTER INTERACTION", {}},
                                /*56*/ {"ADVANCED COMPUTER NETWORKS", {}},
                                /*57*/ {"SOFTWARE REQUIREMENT ENGINEERING", {}},
                                /*58*/ {"COMPUTER VISION AND PATTERN RECOGNITION", {}},
                                
                                
                                /*55*/ {"DIGITAL MARKETING", {}},
                                /*56*/ {"E-COMMERCE, E-GOVERNANCE & E-SERIES", {}},
                                /*57*/ {"DIGITAL SIGNAL PROCESSING", {}},
                                /*58*/ {"VLSI CIRCUIT DESIGN", {}}
                                
                            };
                            
    // Print available courses
    printCourses(allCourses);
                            
    cout<<"Enter total credit completed: ";
    int creditCompleted;
    cin>>creditCompleted;
    
    cin.ignore(); // Clear the input buffer
    
    // Get completed courses from the user
    cout << "Enter completed course numbers separated by spaces: ";
    string line;
    getline(cin, line);
    istringstream iss(line);
    int courseNumber;
    vector<int> completedCourses;
    while (iss >> courseNumber) 
        completedCourses.push_back(courseNumber);
    
    
    // Recommend next semester courses
    recommendCourses(allCourses, completedCourses);
    
    if(creditCompleted>=100)
        cout<<"- \n";
}


// Function to print available courses
void printCourses(const vector<Course>& courses) 
{
    cout << "Available Courses:\n";
    for (int i = 0; i < courses.size(); ++i) 
        cout << i + 1 << ". " << courses[i].name << endl;
    
}

// Function to recommend next semester courses
void recommendCourses(const vector<Course>& allCourses, const vector<int>& completedCourses) 
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
        
        if (canTake) 
            cout << "- " << course.name << endl;
    }
}
