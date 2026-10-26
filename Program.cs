using System;
using System.Collections.Generic;

namespace Quiz___Exam
{
    public enum UserType
    {
        Admin = 1,
        Teacher ,
        Student ,
        Exit 
    }

    public enum AuthMenuOption
    {
        Register = 1,
        Login 
    }

    public enum AdminMenuOption
    {
        AddCourse = 1,
        ViewAllCourses ,
        ViewAllTeachers ,
        ViewAllStudents ,
        Logout 
    }

    public enum TeacherMenuOption
    {
        ViewAssignedCourses = 1,
        ViewUnassignedCourses ,
        AssignToCourse ,
        CreateQuiz ,
        ViewQuizDetails ,
        ReleaseCourse ,
        Logout 
    }

    public enum StudentMenuOption
    {
        ViewAllCourses = 1,
        EnrollInCourse ,
        ViewEnrolledCourses ,
        TakeQuiz ,
        ViewMyQuizzes ,
        Logout 
    }

    public enum QuestionType
    {
        TrueFalse = 1,
        MultipleChoice ,
        ShortAnswer 
    }
    public class Program
    {
        static void Main(string[] args)
        {
            List<Admin> admins = new List<Admin>();
            List<Teacher> teachers = new List<Teacher>();
            List<Student> students = new List<Student>();
            List<Course> courses = new List<Course>();

            admins.Add(new Admin("Admin", "admin@gmail.com", "123456"));

            while (true)
            {
                Console.Clear();
                Console.WriteLine("1- Admin");
                Console.WriteLine("2- Teacher");
                Console.WriteLine("3- Student");
                Console.WriteLine("4- Exit");
                Console.Write("Enter the number: ");

                UserType choice = (UserType)Convert.ToInt32(Console.ReadLine());

                switch (choice)
                {
                    case UserType.Admin:
                        Console.Write("Email: ");
                        string adminEmail = Console.ReadLine();
                        Console.Write("Password: ");
                        string adminPassword = Console.ReadLine();

                        Admin admin = null;
                        foreach (Admin a in admins)
                        {
                            if (a.Email == adminEmail && a.Password == adminPassword)
                            {
                                admin = a;
                                break;
                            }
                        }

                        if (admin == null)
                        {
                            Console.WriteLine("Invalid data.");
                            break;
                        }

                        bool adminLoggedIn = true;
                        while (adminLoggedIn)
                        {
                            Console.Clear();
                            Console.WriteLine("1- Add Course");
                            Console.WriteLine("2- View All Courses");
                            Console.WriteLine("3- View All Teachers");
                            Console.WriteLine("4- View All Students");
                            Console.WriteLine("5- Logout");
                            Console.Write("Enter your choice: ");

                            AdminMenuOption adminChoice = (AdminMenuOption)Convert.ToInt32(Console.ReadLine());

                            switch (adminChoice)
                            {
                                case AdminMenuOption.AddCourse:
                                    Console.Write("Name: ");
                                    string cName = Console.ReadLine();
                                    Console.Write("Number of Lessons: ");
                                    int cLessons = Convert.ToInt32(Console.ReadLine());
                                    Console.Write("Category: ");
                                    string cCategory = Console.ReadLine();
                                    Console.Write("Duration: ");
                                    string cDuration = Console.ReadLine();

                                    Course newCourse = new Course(cName, cLessons, cCategory, cDuration);
                                    admin.AddCourse(newCourse);
                                    courses.Add(newCourse);
                                    Console.WriteLine("Course added.");
                                    break;

                                case AdminMenuOption.ViewAllCourses:
                                    admin.DisplayCourses();
                                    break;

                                case AdminMenuOption.ViewAllTeachers:
                                    admin.DisplayTeachers();
                                    break;

                                case AdminMenuOption.ViewAllStudents:
                                    admin.DisplayStudents();
                                    break;

                                case AdminMenuOption.Logout:
                                    adminLoggedIn = false;
                                    break;

                                default:
                                    Console.WriteLine("Invalid choice");
                                    break;
                            }
                        }
                        break;

                    case UserType.Teacher:
                        Console.WriteLine("1- Register");
                        Console.WriteLine("2- Login");
                        Console.Write("Enter your choice: ");
                        AuthMenuOption tAuth = (AuthMenuOption)Convert.ToInt32(Console.ReadLine());

                        if (tAuth == AuthMenuOption.Register)
                        {
                            Console.Write("Name: ");
                            string tName = Console.ReadLine();
                            Console.Write("Email: ");
                            string tEmail = Console.ReadLine();
                            Console.Write("Password: ");
                            string tPassword = Console.ReadLine();
                            Console.Write("Title: ");
                            string tTitle = Console.ReadLine();

                            Teacher newTeacher = new Teacher(tName, tEmail, tPassword, tTitle);
                            newTeacher.Register();
                            teachers.Add(newTeacher);
                            if (admins.Count > 0)
                            {
                                admins[0].AddTeacher(newTeacher);
                            }
                            Console.WriteLine("Registered.");
                        }
                        else if (tAuth == AuthMenuOption.Login)
                        {
                            Console.Write("Email: ");
                            string tEmail = Console.ReadLine();
                            Console.Write("Password: ");
                            string tPassword = Console.ReadLine();

                            Teacher teacher = null;
                            foreach (Teacher t in teachers)
                            {
                                if (t.Email == tEmail && t.Password == tPassword)
                                {
                                    teacher = t;
                                    break;
                                }
                            }

                            if (teacher == null)
                            {
                                Console.WriteLine("Invalid data.");
                                break;
                            }

                            bool teacherLoggedIn = true;
                            while (teacherLoggedIn)
                            {
                                Console.Clear();
                                Console.WriteLine("1- View Assigned Courses");
                                Console.WriteLine("2- View Unassigned Courses");
                                Console.WriteLine("3- Assign to Course");
                                Console.WriteLine("4- Create Quiz");
                                Console.WriteLine("5- View Quiz Details");
                                Console.WriteLine("6- Release Course");
                                Console.WriteLine("7- Logout");
                                Console.Write("Enter your choice: ");

                                TeacherMenuOption tChoice = (TeacherMenuOption)Convert.ToInt32(Console.ReadLine());

                                switch (tChoice)
                                {
                                    case TeacherMenuOption.ViewAssignedCourses:
                                        teacher.DisplayCourses();
                                        break;

                                    case TeacherMenuOption.ViewUnassignedCourses:
                                        foreach (Course c in courses)
                                        {
                                            if (c.Teacher == null)
                                            {
                                                Console.WriteLine($"{c.Id} - {c.Name} ({c.Category}) - {c.Duration}");
                                            }
                                        }
                                        break;

                                    case TeacherMenuOption.AssignToCourse:
                                        Console.Write("Course ID: ");
                                        int cid = Convert.ToInt32(Console.ReadLine());

                                        Course courseToAssign = null;
                                        foreach (Course c in courses)
                                        {
                                            if (c.Id == cid)
                                            {
                                                courseToAssign = c;
                                                break;
                                            }
                                        }

                                        if (courseToAssign == null)
                                        {
                                            Console.WriteLine("Course not found.");
                                        }
                                        else
                                        {
                                            teacher.AssignToCourse(courseToAssign);
                                            Console.WriteLine("Assigned.");
                                        }
                                        break;

                                    case TeacherMenuOption.CreateQuiz:
                                        Console.Write("Course ID: ");
                                        int quizCid = Convert.ToInt32(Console.ReadLine());

                                        Course quizCourse = null;
                                        foreach (Course c in courses)
                                        {
                                            if (c.Id == quizCid)
                                            {
                                                quizCourse = c;
                                                break;
                                            }
                                        }

                                        if (quizCourse == null)
                                        {
                                            Console.WriteLine("Course not found.");
                                            break;
                                        }

                                        Console.Write("Quiz Name: ");
                                        string qName = Console.ReadLine();
                                        Console.Write("Category: ");
                                        string qCategory = Console.ReadLine();
                                        Console.Write("Duration: ");
                                        int qDuration = Convert.ToInt32(Console.ReadLine());

                                        teacher.CreateQuiz(quizCourse, qName, qCategory, qDuration);
                                        Console.WriteLine("Quiz created.");
                       
                                        break;

                                    case TeacherMenuOption.ViewQuizDetails:
                                        Console.Write("Course ID: ");
                                        int vCid = Convert.ToInt32(Console.ReadLine());

                                        Course vCourse = null;
                                        foreach (Course c in courses)
                                        {
                                            if (c.Id == vCid)
                                            {
                                                vCourse = c;
                                                break;
                                            }
                                        }

                                        if (vCourse == null)
                                        {
                                            Console.WriteLine("Course not found.");
                                        }
                                        else
                                        {
                                            teacher.DisplayQuizzes(vCourse);
                                        }
                         
                                        break;

                                    case TeacherMenuOption.ReleaseCourse:
                                        Console.Write("Course ID: ");
                                        int rCid = Convert.ToInt32(Console.ReadLine());

                                        Course rCourse = null;
                                        foreach (Course c in courses)
                                        {
                                            if (c.Id == rCid)
                                            {
                                                rCourse = c;
                                                break;
                                            }
                                        }

                                        if (rCourse == null)
                                        {
                                            Console.WriteLine("Course not found.");
                                        }
                                        else
                                        {
                                            teacher.ReleaseCourse(rCourse);
                                            Console.WriteLine("Released.");
                                        }
                     
                                        break;

                                    case TeacherMenuOption.Logout:
                                        teacherLoggedIn = false;
                                        break;

                                    default:
                                        Console.WriteLine("Invalid choice");
                                        break;
                                }
                            }
                        }
                        break;

                    case UserType.Student:
                        Console.WriteLine("1- Register");
                        Console.WriteLine("2- Login");
                        Console.Write("Enter your choice: ");
                        AuthMenuOption sAuth = (AuthMenuOption)Convert.ToInt32(Console.ReadLine());

                        if (sAuth == AuthMenuOption.Register)
                        {
                            Console.Write("Name: ");
                            string sName = Console.ReadLine();
                            Console.Write("Email: ");
                            string sEmail = Console.ReadLine();
                            Console.Write("Password: ");
                            string sPassword = Console.ReadLine();

                            Student newStudent = new Student(sName, sEmail, sPassword);
                            newStudent.Register();
                            students.Add(newStudent);
                            if (admins.Count > 0)
                            {
                                admins[0].AddStudent(newStudent);
                            }
                            Console.WriteLine("Registered.");

                        }
                        else if (sAuth == AuthMenuOption.Login)
                        {
                            Console.Write("Email: ");
                            string sEmail = Console.ReadLine();
                            Console.Write("Password: ");
                            string sPassword = Console.ReadLine();

                            Student student = null;
                            foreach (Student s in students)
                            {
                                if (s.Email == sEmail && s.Password == sPassword)
                                {
                                    student = s;
                                    break;
                                }
                            }

                            if (student == null)
                            {
                                Console.WriteLine("Invalid credentials.");
           
                                break;
                            }

                            bool studentLoggedIn = true;
                            while (studentLoggedIn)
                            {
                                Console.Clear();
                                Console.WriteLine("1- View All Courses");
                                Console.WriteLine("2- Enroll in Course");
                                Console.WriteLine("3- View Enrolled Courses");
                                Console.WriteLine("4- Take Quiz");
                                Console.WriteLine("5- View My Quizzes");
                                Console.WriteLine("6- Logout");
                                Console.Write("Enter your choice: ");

                                StudentMenuOption sChoice = (StudentMenuOption)Convert.ToInt32(Console.ReadLine());

                                switch (sChoice)
                                {
                                    case StudentMenuOption.ViewAllCourses:
                                        foreach (Course c in courses)
                                        {
                                            Console.WriteLine($"{c.Name} -  {(c.Teacher != null ? c.Teacher.Name : "None")}");
                                            Console.WriteLine($" {c.Duration} -  {c.NumberOfLessons} -  {c.Category}");
                                            Console.WriteLine(c.Quizzes.Count);
                                            foreach (Quiz q in c.Quizzes)
                                            {
                                                Console.WriteLine($"  - {q.Name}");
                                            }
                                        }
 
                                        break;

                                    case StudentMenuOption.EnrollInCourse:
                                        Console.Write("Course ID: ");
                                        int eCid = Convert.ToInt32(Console.ReadLine());

                                        Course eCourse = null;
                                        foreach (Course c in courses)
                                        {
                                            if (c.Id == eCid)
                                            {
                                                eCourse = c;
                                                break;
                                            }
                                        }

                                        if (eCourse == null)
                                        {
                                            Console.WriteLine("Course not found.");
                                        }
                                        else
                                        {
                                            student.AssignToCourse(eCourse);
                                            Console.WriteLine("Enrolled.");
                                        }

                                        break;

                                    case StudentMenuOption.ViewEnrolledCourses:
                                        student.DisplayCourses();

                                        break;

                                    case StudentMenuOption.TakeQuiz:
                                        Console.Write("Quiz Name: ");
                                        string searchName = Console.ReadLine();

                                        Quiz foundQuiz = null;
                                        foreach (Course c in courses)
                                        {
                                            foreach (Quiz q in c.Quizzes)
                                            {
                                                if (q.Name == searchName)
                                                {
                                                    foundQuiz = q;
                                                    break;
                                                }
                                            }
                                            if (foundQuiz != null) break;
                                        }

                                        if (foundQuiz == null)
                                        {
                                            Console.WriteLine("Quiz not found.");
                                            break;
                                        }

                                        List<string> answers = new List<string>();
                                        foreach (Questions q in foundQuiz.Questions)
                                        {
                                            Console.WriteLine(q.Text);
                                            Console.Write("Answer: ");
                                            answers.Add(Console.ReadLine());
                                        }

                                        QuizAttempt attempt = student.TakeQuiz(foundQuiz, answers, 0);
                                        Console.WriteLine($"Score: {attempt.Score}");
            
                                        break;

                                    case StudentMenuOption.ViewMyQuizzes:
                                        foreach (Quiz q in student.Quizzes)
                                        {
                                            Console.WriteLine($"{q.Name} -  {q.Course.Name} -  {q.Duration}");
                                        }
             
                                        break;

                                    case StudentMenuOption.Logout:
                                        studentLoggedIn = false;
                                        break;

                                    default:
                                        Console.WriteLine("Invalid choice");

                                        break;
                                }
                            }
                        }
                        break;

                    case UserType.Exit:
                        return;

                    default:
                        Console.WriteLine("Invalid choice");
                        break;
                }
            }
        }
    }
}