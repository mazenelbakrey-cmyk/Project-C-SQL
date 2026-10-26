using System;
using System.Collections.Generic;
using System.Text;

namespace Quiz___Exam
{
    public class Student : Person
    {
        private static int _studentid;
        private int _grade;
        private  List<Course> _courses = new List<Course>();
        private  List<Quiz> _quiz = new List<Quiz>();

        public Student(string name , string email , string password):base(name, email, password)
        {
            
            _id = ++_studentid;

        }

        public int Grade
        {
            get { return _grade; }
            set { _grade = value; }
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
            if (!_students.ContainsKey(_email) || _students[_email] != _password)
            {
                throw new ArgumentException("invalid user");
            }
            else
            {
                Console.WriteLine("you Logged in Sucessfully ");
            }
        }

        public override void Register()
        {
            if (_students.ContainsKey(_email))
            {
                throw new ArgumentException("this User is Already exist");
            }
            else
            {
                _students.Add(_email, _password);
                Console.WriteLine("You registered Sucessfully");
            }
        }

        public void AssignToCourse(Course course)
        {
            if((course == null) || (course.Teacher == null))
            {
                throw new ArgumentException();
            }
            course.AssignStudent(this);
        }

        public void DisplayCourses()
        {
            if (_courses.Count == 0)
            {
                Console.WriteLine("You are not enrolled in any course.");
                return;
            }

            foreach (Course course in _courses)
            {
                Console.WriteLine(course.Name);
                Console.WriteLine(course.Teacher != null ? course.Teacher.Name : "Not Assigned");
                Console.WriteLine(course.Duration);
                Console.WriteLine(course.NumberOfLessons);
                Console.WriteLine(course.Category);
                Console.WriteLine(course.Quizzes.Count);
                foreach (Quiz quiz in course.Quizzes)
                {
                    Console.WriteLine(quiz.Name);
                }
            }
        }


        public QuizAttempt TakeQuiz(Quiz quiz, List<string> answers, int timeTaken)
        {
            if (quiz == null)
            {
                throw new ArgumentNullException();
            }
            if (!_courses.Contains(quiz.Course))
            {
                throw new ArgumentException("You are not enrolled in this course.");
            }

            QuizAttempt attempt = new QuizAttempt(this, quiz, timeTaken);
            foreach (string answer in answers)
            {
                attempt.AddAnswer(answer);
            }
            attempt.CalculateScore();
            _grade += attempt.Score;
            quiz.AddAttempt(attempt);
            _quiz.Add(quiz);

            return attempt;
        }



    }
}