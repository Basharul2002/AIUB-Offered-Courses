using System;
using System.Collections.Generic;

namespace AIUB_Offered_Course
{
    

    public class TrieNode
    {
        public Dictionary<char, TrieNode> Children { get; set; }
        public List<Course> Courses { get; set; }

        public TrieNode()
        {
            Children = new Dictionary<char, TrieNode>();
            Courses = new List<Course>();
        }
    }

    public class CourseSearchEngine
    {
        private TrieNode root;

        public CourseSearchEngine(List<Course> allCourses)
        {
            root = new TrieNode();
            foreach (var course in allCourses)
            {
                Insert(course);
            }
        }

        private void Insert(Course course)
        {
            string normalizedCourseName = course.Name.ToLowerInvariant();
            for (int i = 0; i < normalizedCourseName.Length; i++)
            {
                TrieNode node = root;
                for (int j = i; j < normalizedCourseName.Length; j++)
                {
                    char c = normalizedCourseName[j];
                    if (!node.Children.ContainsKey(c))
                    {
                        node.Children[c] = new TrieNode();
                    }
                    node = node.Children[c];
                    node.Courses.Add(course);
                }
            }
        }

        public List<Course> SearchCourses(string searchText)
        {
            string normalizedSearchText = searchText.ToLowerInvariant();
            TrieNode node = root;
            foreach (char c in normalizedSearchText)
            {
                if (!node.Children.ContainsKey(c))
                {
                    return new List<Course>(); // Return an empty list if no courses found
                }
                node = node.Children[c];
            }
            return new List<Course>(node.Courses);
        }
    }
}
