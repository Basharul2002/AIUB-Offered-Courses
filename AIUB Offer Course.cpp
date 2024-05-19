#include <bits/stdc++.h>
using namespace std;

// Define a structure to hold course information
struct Course
{
    string name;
    unordered_set<int> prerequisites;
    int courseCredit;
};


// Function Prototypes
void departmentChoose();
void dept(string dept);
vector<int> parseInput(const string& input);
void cseCourses();
void eeeCourse();
void courseDataUserInput(vector<Course>allCourses, string dept);
void printCourses(const vector<Course>& courses);
void recommendCourses(const vector<Course>& allCourses, const vector<int>& completedCourses, int totalCreditCompleted);


int main()
{
    departmentChoose();
    cin.ignore(); // To consume the newline character left by previous input
    //cin.get(); // To wait for the user to press Enter
    return 0;
}


void departmentChoose()
{
    cout<<"Department name: \n1.CSE \n2.EEE \nChoose your department: ";
    string department;
    cin>>department;

    return dept(department);

}


void dept(string department)
{
    if(department == "1" || department == "CSE" || department == "cse")
    {

        cin.ignore();
        cseCourses();
        cout << "\n \nWould you like to run the program again? Enter 1 for Yes, 2 for No, or 3 to go back to the department selection: ";
        string flag;
        cin>>flag;

        if(flag == "1" || flag == "Yes")
            dept("1");

        else if(flag == "2" || flag == "No")
            return;

        else if(flag == "3")
            departmentChoose();

         else
        {
            cout<<"Invalid Input\n";
            departmentChoose();
        }

    }


    else if(department == "2" || department == "EEE" || department == "eee")
    {
        cin.ignore();
        eeeCourse();

        cout << "\n \nWould you like to run the program again? Enter 1 for Yes, 2 for No, or 3 to go back to the department selection: ";
        string flag;
        cin>>flag;

        if(flag == "1" || flag == "Yes")
            dept("2");

        else if(flag == "2" || flag == "No")
            return;

        else if(flag == "3")
            departmentChoose();

        else
        {
            cout<<"Invalid Input\n";
            departmentChoose();
        }

    }

    else
    {
        cout<<"INVALID INPUT\n\n";
        departmentChoose();
    }


}


// Course Plan for CSE
void cseCourses()
{
    vector<Course> allCourses =
    {
        // semester 1
        {"DIFFERENTIAL CALCULUS & CO-ORDINATE GEOMETRY", {}, 3},
        {"PHYSICS 1", {}, 3},
        {"PHYSICS 1 LAB", {1}, 1},
        {"ENGLISH READING SKILLS & PUBLIC SPEAKING", {}, 3},
        {"INTRODUCTION TO PROGRAMMING", {}, 3},
        {"INTRODUCTION TO PROGRAMMING LAB", {5}, 1},
        {"INTRODUCTION TO COMPUTER STUDIES", {}, 1},

        // semester 2
        {"DISCRETE MATHEMATICS", {1, 5}, 3},
        {"INTEGRAL CALCULUS & ORDINARY DIFFERENTIAL EQUATIONS", {1}, 3},
        {"OBJECT ORIENTED PROGRAMMING 1", {5, 6}, 3},
        {"PHYSICS 2", {2}, 3},
        {"PHYSICS 2 LAB", {3}, 1},
        {"ENGLISH WRITING SKILLS & COMMUNICATION", {4}, 3},
        {"INTRODUCTION TO ELECTRICAL CIRCUITS", {2}, 3},
        {"INTRODUCTION TO ELECTRICAL CIRCUITS LAB", {3}, 1},

        // semester 3
        {"CHEMISTRY", {11}, 3},
        {"COMPLEX VARIABLE, LAPLACE & Z-TRANSFORMATION", {9}, 3},
        {"INTRODUCTION TO DATABASE", {10}, 3},
        {"ELECTRONIC DEVICES", {14}, 3},
        {"ELECTRONIC DEVICES LAB", {15}, 1},
        {"PRINCIPLES OF ACCOUNTING", {9}, 3},
        {"DATA STRUCTURE", {8, 10}, 3},
        {"DATA STRUCTURE LAB", {8, 10}, 1},
        {"COMPUTER AIDED DESIGN & DRAFTING", {}, 1},
        {"ALGORITHMS", {22, 23}, 3},
        {"MATRICES, VECTORS, FOURIER ANALYSIS", {17}, 3},
        {"OBJECT ORIENTED PROGRAMMING 2", {10, 19}, 3},
        {"OBJECT ORIENTED ANALYSIS AND DESIGN", {20}, 3},
        {"BANGLADESH STUDIES", {6}, 3},
        {"DIGITAL LOGIC AND CIRCUITS", {15}, 3},
        {"DIGITAL LOGIC AND CIRCUITS LAB", {16}, 1},
        {"COMPUTATIONAL STATISTICS AND PROBABILITY", {17}, 3},
        {"THEORY OF COMPUTATION", {25}, 3},
        {"PRINCIPLES OF ECONOMICS", {31}, 2},
        {"BUSINESS COMMUNICATION", {28}, 3},
        {"NUMERICAL METHODS FOR SCIENCE AND ENGINEERING", {25}, 3},
        {"DATA COMMUNICATION", {31, 32}, 3},
        {"MICROPROCESSOR AND EMBEDDED SYSTEM", {31, 32}, 3},
        {"SOFTWARE ENGINEERING", {27, 28}, 3},
        {"ARTIFICIAL INTELLIGENCE AND EXPERT SYS.", {25, 31}, 3},
        {"COMPUTER NETWORKS", {37}, 3},
        {"COMPUTER ORGANIZATION AND ARCHITECTURE", {38}, 3},
        {"OPERATING SYSTEM", {25, 38}, 3},
        {"WEB TECHNOLOGIES", {39}, 3},
        {"ENGINEERING ETHICS", {38, 39}, 2},
        {"COMPILER DESIGN", {32}, 3},
        {"COMPUTER GRAPHICS", {25, 26}, 3},
        {"ENGINEERING MANAGEMENT", {44}, 3},
        {"RESEARCH METHODOLOGY", {}, 3},
        {"ADVANCE DATABASE MANAGEMENT SYSTEM", {18}, 3},
        {"BASIC MECHANICAL ENGG.", {11}, 3},
        {"COMPUTER SCIENCE MATHEMATICS", {25, 36}, 3},
        {"MANAGEMENT INFORMATION SYSTEM", {39}, 3},
        {"SIGNALS & LINEAR SYSTEM", {26}, 3},
        {"BASIC GRAPH THEORY", {25}, 3},
        {"DIGITAL SYSTEM DESIGN", {42}, 3},
        {"IMAGE PROCESSING", {47}, 3},
        {"MULTIMEDIA SYSTEMS", {44}, 3},
        {"SIMULATION & MODELING", {40}, 3},
        {"ENTERPRISE RESOURCE PLANNING", {39, 54}, 3},
        {"DATA WAREHOUSE AND DATA MINING", {83}, 3},
        {"NATURAL LANGUAGE PROCESSING", {40, 77}, 3},
        {"SOFTWARE DEVELOPMENT PROJECT MANAGEMENT", {67}, 3},
        {"HUMAN COMPUTER INTERACTION", {40, 44}, 3},
        {"ADVANCED COMPUTER NETWORKS", {41}, 3},
        {"SOFTWARE REQUIREMENT ENGINEERING", {39}, 3},
        {"COMPUTER VISION AND PATTERN RECOGNITION", {40, 47}, 3},
        {"LINEAR PROGRAMMING", {40, 32}, 3},
        {"NETWORK SECURITY", {41}, 3},
        {"SOFTWARE QUALITY AND TESTING", {67}, 3},
        {"ADVANCED OPERATING SYSTEM", {43}, 3},
        {"DIGITAL DESIGN WITH SYSTEM [VERILOG, VHDL & FPGAS]", {97}, 3},
        {"ROBOTICS ENGINEERING", {40}, 3},
        {"BUSINESS INTELLIGENCE AND DECISION SUPPORT", {61}, 3},
        {"TELECOMMUNICATIONS ENGINEERING", {37}, 3},
        {"PROGRAMMING IN PYTHON", {44}, 3},
        {"ADVANCED PROGRAMMING WITH JAVA", {44}, 3},
        {"ADVANCED PROGRAMMING WITH .NET", {44}, 3},
        {"ADVANCED PROGRAMMING IN WEB TECHNOLOGY", {44}, 3},
        {"ADVANCED ALGORITHM TECHNIQUES", {40}, 3},
        {"NETWORK RESOURCE MANAGEMENT & ORGANIZATION", {37, 41}, 3},
        {"INTRODUCTION TO DATA SCIENCE", {40}, 3},
        {"CYBER LAWS & INFORMATION SECURITY", {44}, 3},
        {"BIOINFORMATICS", {40}, 3},
        {"PARALLEL COMPUTING", {25, 40}, 3},
        {"MACHINE LEARNING", {40}, 3},
        {"WIRELESS SENSOR NETWORKS", {37, 41}, 3},
        {"INDUSTRIAL ELECTRONICS, DRIVES & INSTRUMENTATION", {30}, 3},
        {"MOBILE APPLICATION DEVELOPMENT", {44}, 3},
        {"SOFTWARE ARCHITECTURE AND DESIGN PATTERNS", {67}, 3},
        {"DIGITAL MARKETING", {44, 54}, 3},
        {"E-COMMERCE, E-GOVERNANCE & E-SERIES", {44}, 3},
        {"DIGITAL SIGNAL PROCESSING", {55}, 3},
        {"VLSI CIRCUIT DESIGN", {91}, 3}
    };

    // Print available courses
    printCourses(allCourses);

    courseDataUserInput(allCourses, "1");

}


// Course Plan for EEE
void eeeCourse()
{
    vector<Course> allCourses =
    {
        // Semester 1
        {"CHEMISTRY", {}, 3},
        {"DIFFERENTIAL CALCULUS & CO-ORDINATE GEOMETRY", {}, 3},
        {"PHYSICS 1", {}, 3},
        {"PHYSICS 1 LAB", {1}, 1},
        {"ENGLISH READING SKILLS & PUBLIC SPEAKING", {}, 3},
        {"INTRODUCTION TO ENGINEERING STUDIES", {}, 1},

        //Semester 2
        {"BASIC MECHANICAL ENGINEERING", {3}, 3},
        {"ELECTICAL CIRCUIT-1 (DC)", {3, 5}, 3},
        {"ELECTICAL CIRCUIT-1 (DC) LAB", {6,4}, 1},
        {"INTEGRAL CALCULUS & ORDINARY DIFFERENTIAL EQUATIONS", {2}, 3},
        {"PHYSICS 2", {1, 3}, 3},
        {"PHYSICS 2 LAB", {1,4}, 1},
        {"PRINCIPLE OF ACCOUNTING", {2}, 3},
        {"ENGLISH WRITING SKILLS & COMMUNICATION", {4}, 3},

        // Semester 3
        {"COMPLEX VARIABLE, LAPLACE & Z-TRANSFORMATION", {10}, 3},
        {"ELECTRICAL CIRCUIT 2 (AC)", {3, 5}, 3},
        {"ELECTRICAL CIRCUITS-2 (AC) LAB",{9}, 1},
        {"ELECTRICAL MACHINES 1",{7, 16}, 3},
        {"ELECTRICAL MACHINES 1 LAB",{7, 16}, 1},
        {"ELECTRONIC DEVICES",{16}, 3},
        {"ELECTRONIC DEVICES LAB", {17}, 1},
        {"PROGRAMMING LANGUAGE 1 (STRUCTURED PROGRAMMING LANGUAGE)", {15}, 3},
        {"BANGLADESH STUDIES", {}, 3},

        // Semester 4
        {"ELECTRICAL MACHINES 2", {18}, 3},
        {"ELECTRICAL MACHINES 2 LAB", {19}, 1},
        {"ELECTRICAL POWER TRANSMISSION & DISTRIBUTION", {18}, 3},
        {"MATRICES,VECTORS,FOURIER ANALYSIS", {15}, 3},
        {"SIGNALS & LINEAR SYSTEMS", {27}, 3},
        {"ENGINEERING ETHICS AND ENVIRONMENTAL PROTECTION", {6}, 1},
        {"ANALOG ELECTRONICS",{20}, 3},
        {"ANALOG ELECTRONICS LAB", {21}, 1},
        {"COMPUTER AIDED DESIGN & DRAFTING",{8}, 1},

         // Semester 5
        {"MODERN PHYSICS", {11}, 3},
        {"ELECTROMAGNETICS FIELDS AND WAVES", {7, 11}, 3},
        {"PRINCIPLES OF ECONOMICS",{13}, 2},
        {"DIGITAL LOGIC AND CIRCUITS",{20}, 3},
        {"DIGITAL LOGIC AND CIRCUITS LAB",{21}, 1},
        {"ENGINEERING SHOP",{30}, 1},
        {"INDUSTRIAL ELECTRONICS AND DRIVES",{24}, 3},
        {"INDUSTRIAL ELECTRONICS AND DRIVES LAB",{25}, 1},
        {"DIGITAL SIGNAL PROCESSING",{27, 28}, 3},

         // Semester 6
        {"ELECTRICAL PROPERTIES OF MATERIALS", {33}, 3},
        {"PROGRAMMING LANGUAGE 2 (OBJECT ORIENTED PROGRAMMING LANGUAGE)", {22}, 3},
        {"POWER SYSTEMS ANALYSIS",{26}, 3},
        {"NUMERICAL METHODS FOR SCIENCE AND ENGINEERING",{27, 43}, 3},
        {"COMPUTATIONAL STATISTICS AND PROBABILITY",{34}, 3},
        {"PRINCIPLES OF COMMUNICATION",{34}, 3},

        // Semester 7
        {"BUSINESS COMMUNICATION",{14}, 3},
        {"ENGINEERING MANAGEMENT",{29}, 3},
        {"MODERN CONTROL SYSTEMS",{28}, 3},
        {"MODERN CONTROL SYSTEMS LAB", {28}, 1},
        {"MICROPROCESSOR AND EMBEDDED SYSTEM", {41, 43}, 3},

        // Semester 8
        {"INTERNSHIP/ SEMINAR/ WORKSHOP",{48},1},
        {"ELECTRICAL SERVICES DESIGN LAB",{38},1},
        {"TELECOMMUNICATIONS ENGINEERING",{47}, 3},
        {"TELECOMMUNICATIONS ENGINEERING",{44}, 3},
        {"MEASUREMENT AND INSTRUMENTATION",{50}, 3},
        {"VLSI CIRCUIT DESIGN",{41}, 3},
    };

    printCourses(allCourses);

    cout << "\n\n";
    courseDataUserInput(allCourses, "2");

}



// Function to print available courses
void printCourses(const vector<Course>& courses)
{
    cout << "Available Courses:\n";
    for (size_t i = 0; i < courses.size(); ++i)
        cout << i + 1 << ". " << courses[i].name << endl;
}


void courseDataUserInput(vector<Course>allCourses, string dept)
{
    try
    {
         cout << "\n\n";
        // Get completed courses from the user
        cout << "Enter completed course numbers or ranges (e.g., 1-10) separated by spaces: ";
        string line;
        getline(cin, line);

        // Parse input line
        vector<int> completedCourses = parseInput(line);

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

    catch(exception ex)
    {
        cout<<"Invalid Input \n";
       // dept(dept);
    }

}

// Helper function to parse input line into course numbers
vector<int> parseInput(const string& input)
{
    vector<int> courseNumbers;
    istringstream iss(input);
    string part;

    while (iss >> part)
    {
        size_t dashPos = part.find('-');
         // Single number
        if (dashPos == string::npos)
            courseNumbers.push_back(stoi(part));

        // Range of numbers
        else
        {
            int start = stoi(part.substr(0, dashPos));
            int end = stoi(part.substr(dashPos + 1));
            for (int i = start; i <= end; ++i)
                courseNumbers.push_back(i);

        }
    }

    return courseNumbers;
}


// Function to recommend next semester courses
void recommendCourses(const vector<Course>& allCourses, const vector<int>& completedCourses, int totalCreditCompleted)
{
    // Store completed courses in a set for fast lookup
    unordered_set<int> completedSet(completedCourses.begin(), completedCourses.end());

    cout << "Recommended Courses:\n";
    for (size_t i = 0; i < allCourses.size(); ++i)
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

        // If total credit completed is less than 100, do not offer RESEARCH METHODOLOGY course
        if (course.name == "RESEARCH METHODOLOGY" && totalCreditCompleted < 100)
            canTake = false;

        if (canTake)
            cout << "- " << course.name << endl;
    }
}
