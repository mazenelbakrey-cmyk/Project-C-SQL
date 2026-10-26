using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Quiz___Exam
{
    public class Teacher : Person
    {
        private static int _teacherid=0;
        private string _title;
        private  List<Course> _courses = new List<Course>();
        private  List<Quiz> _quiz = new List<Quiz>();


        public Teacher( string name, string email, string password ,string title): base(name ,email,password)
        {
            if (string.IsNullOrEmpty(title))
                throw new ArgumentException("Title cannot be empty.");
            _title = title;
            _id = ++_teacherid;
        }

        public string Title
        {
            get
            {
                return _title;
            }
        }


        public List<Course> Courses
        {
            get
            {
                return _courses;
            }
        }

        public List<Quiz> Quizzes
        {
            get
            {
                return _quiz;
            }
        }

        public override void Login()
        {
            if (!_teachers.ContainsKey(_email) || _teachers[_email] != _password)
            {
                throw new ArgumentException();
            }
            else
            {
                Console.WriteLine("you Logged in Sucessfully ");
            }
        }

        public override void Register()
        {
            if (_teachers.ContainsKey(_email))
            {
                throw new ArgumentException("this User  Already exist");
            }
            else
            {
                _teachers.Add(_email, _password);
                Console.WriteLine("You registered Sucessfully");
            }
        }

        public void AssignToCourse(Course course)
        {
            if(course == null)
            {
                throw new Exception();
            }
            if (course.Teacher != null)
            {
                throw new ArgumentException("This course already has a teacher.");
            }
            course.AssignTeacher(this);
            _courses.Add(course);
            
        }

        public void ReleaseCourse(Course course)
        {
            if (course == null)
            {
                throw new ArgumentNullException();
            }
            course.UnassignTeacher(this);
            _courses.Remove(course);
        }

        public void DisplayCourses()
        {
            if (_courses.Count == 0)
            {
                Console.WriteLine("You have no assigned courses.");
                return;
            }

            foreach (var course in _courses)
            {
                Console.WriteLine(course.Id);
                Console.WriteLine(course.Name);
                Console.WriteLine(course.NumberOfLessons);
                Console.WriteLine(course.Duration);
                Console.WriteLine(course.Category);
                Console.WriteLine(course.Quizzes.Count);
            }
        }

        public void CreateQuiz(Course course, string quizName, string category, int duration)
        {
            if (course == null)
            {
                throw new ArgumentNullException();
            }
            if (course.Teacher != this)
            {
                throw new ArgumentException("You are not the teacher of this course.");
            }

            Quiz quiz = new Quiz(quizName, category, duration);
            course.Quizzes.Add(quiz);
            _quiz.Add(quiz);
        }


        public void DisplayQuizzes(Course course)
        {
            foreach (Quiz quiz in course.Quizzes)
            {
                Console.WriteLine(quiz.Name);
                Console.WriteLine(quiz.Duration);
                Console.WriteLine(quiz.Category);
                Console.WriteLine(quiz.StudentsTookCount);
                foreach (Questions q in quiz.Questions)
                {
                    Console.WriteLine(q);
                }
            }
        }
    }

}
