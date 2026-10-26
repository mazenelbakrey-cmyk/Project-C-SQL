using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Linq;

namespace Quiz___Exam
{
    public class Admin : Person
    {
        private static int _adminCounter = 0;
        private List<Course> _courses = new List<Course>();
        private List<Teacher> _teacher = new List<Teacher>();
        private List<Student> _studentsList = new List<Student>();

        public Admin(string name ,string email,string password):base(name, email, password)
        {
            _id = ++_adminCounter;
        }

        public override void Login()
        {
            if (_Admins.ContainsKey(_email) && _Admins[_email]==_password)
            {
                Console.WriteLine("Login Succesfully ..");
            }
            else
            {
                throw new ArgumentException("InValid Data of this Admin ");
            }
        }

        public void AddCourse(Course course)
        {
            if (course == null)
            {
                throw new ArgumentNullException();
            }
            else
            {
                _courses.Add(course);
                course.AssignAdminToCourse(Id);
            }
        }

        public void AddTeacher(Teacher teacher)
        {
            if (teacher == null)
            {
                throw new ArgumentNullException();
            }
            _teacher.Add(teacher);
        }

        public void AddStudent(Student student)
        {
            if (student == null)
            {
                throw new ArgumentNullException();
            }
            _studentsList.Add(student);
        }

        public void DisplayCourses()
        {
            if (_courses.Count == 0)
            {
                Console.WriteLine("No courses available.");
                return;
            }

            foreach (Course course in _courses)
            {
                Console.WriteLine(course.Name);
                Console.WriteLine(course.Teacher.Name);
                Console.WriteLine(course.Duration);
                Console.WriteLine(course.Category);
                Console.WriteLine(course.NumberOfLessons);
                Console.WriteLine(course.Students.Count);
                Console.WriteLine(course.Quizzes.Count);
                foreach(Quiz quizz in course.Quizzes)
                {
                    Console.WriteLine(quizz.Name);
                }

                foreach (Student student in course.Students)
                {
                    Console.WriteLine(student.Name);
                }
            }
        }

        public void DisplayTeachers()
        {
            if (_teacher.Count == 0)
            {
                Console.WriteLine("No teachers available.");
                return;
            }

            foreach (Teacher teacher in _teacher)
            {
                Console.WriteLine(teacher.Name);
                Console.WriteLine(teacher.Email);
                Console.WriteLine(teacher.Title);
                Console.WriteLine(teacher.Courses.Count);
                Console.WriteLine(teacher.Quizzes.Count);
                foreach(Course course in teacher.Courses)
                { 
                    Console.WriteLine($"{course.Name} : {course.Category}");
                    
                }
                foreach(Quiz quiz1 in teacher.Quizzes)
                {
                    Console.WriteLine(quiz1.Name);
                }
            }
        }


        public void DisplayStudents()
        {
            if (_studentsList.Count == 0)
            {
                Console.WriteLine("No students available.");
                return;
            }

            foreach (Student student in _studentsList)
            {
                Console.WriteLine(student.Name);
                Console.WriteLine(student.Email);
                Console.WriteLine(student.Grade);
                Console.WriteLine(student.Courses.Count);
                Console.WriteLine(student.Quizzes.Count);
                foreach (Course course in student.Courses)
                {
                    Console.WriteLine(course.Name);
                }
                foreach (Quiz quiz1 in student.Quizzes)
                {
                    Console.WriteLine(quiz1.Name);
                }
            }
        }




    }

}
