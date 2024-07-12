using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AIUB_Offered_Course
{
    internal class CourseAdviser
    {
        public static List<Course> CourseInformation(int departmentNumber)
        {
            switch (departmentNumber)
            {
                case 1:
                    return CourseManager.CSECourses();
                case 2:
                    return CourseManager.EEECourses();
                case 3:
                    return CourseManager.EnglishCourses();
                case 4:
                    return CourseManager.BBACourses();
                case 5:
                    return CourseManager.IPECourses();
                default:
                    return null;
            }

        }
    }
}
