using System;
using System.Collections.Generic;
using System.Text;

namespace Quiz___Exam
{
    public class Course
    {
        private static int _courseCounter = 0;
        private int _adminId;
        private int _id;
        private string _name;
        private int _numberOfLessons;
        private string _category;
        private string _duration;
        private  Teacher _teacher;
        private List<Student> _students=new List<Student>()  ;
        private List<Quiz> _quizzes=new List<Quiz>();



        public Course(string name, int numberOfLessons, string category, string duration)
        {
            if (String.IsNullOrEmpty(name))
            {
                throw new ArgumentNullException("name");
            }
            if(numberOfLessons <= 0)
            {
                throw new ArgumentOutOfRangeException();
            }
            if (String.IsNullOrEmpty(category))
            {
                throw new ArgumentNullException("category");
            }
            if (String.IsNullOrEmpty(duration))
            {
                throw new ArgumentNullException("duration");
            }
            _id = ++_courseCounter;
            _name = name;
            _numberOfLessons= numberOfLessons;
            _category = category;
            _duration = duration;
        }

        public int AdminId
        {
            get { return _adminId; }
        }

        public int Id
        {
            get { return _id; }
        }

        public string Name
        {
            get
            {
                return _name;
            }
        }

        public int NumberOfLessons
        {
            get
            {
                return _numberOfLessons;
            }
        }

        public string Category
        {
            get
            {
                return _category;
            }
        }

        public string Duration
        {
            get
            {
                return _duration;
            }
        }

        public Teacher Teacher
        {
            get
            {
                return _teacher;
            }
        }

        public List<Student> Students
        {
            get { return _students; }
        }

        public List<Quiz> Quizzes
        {
            get { return _quizzes; }
        }

        public void AssignAdminToCourse(int id)
        {
            if (id <= 0)
            {
                throw new ArgumentOutOfRangeException("id");
            }
            _adminId = id;
        }

        public void AssignTeacher(Teacher t)
        {
            if(t == null)
            {
                throw new ArgumentNullException();
            }
            else
            {
                if (_teacher == null)
                {
                    _teacher = t;
                }
            }
        }

        public void UnassignTeacher(Teacher t)
        {
            if (t == null)
                throw new ArgumentNullException();
            if (_teacher == null)
                throw new Exception();
            if (_teacher != t)
                throw new Exception();
            if (Students.Count > 0)
                throw new Exception();

            _teacher = null;
        }

        public void AssignStudent(Student s)
        {
            if (s == null)
            {
                throw new ArgumentNullException();
            }
            if (_teacher == null)
            {
                throw new ArgumentException("Cannot enroll, this course has no teacher.");
            }
            if (_students.Contains(s))
            {
                throw new ArgumentException("Student already enrolled.");
            }
            
            Students.Add(s);
            s.Courses.Add(this);
        }

        public void AddQuiz(Quiz quiz)
        {
            if (quiz == null)
                throw new ArgumentNullException();
            _quizzes.Add(quiz);
        }
    }

}
