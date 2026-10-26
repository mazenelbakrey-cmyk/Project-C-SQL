using System;
using System.Collections.Generic;
using System.Text;

namespace Quiz___Exam
{
    public class Quiz
    {
        private static int _quizid=0;
        private int _id;
        private string _name;
        private string _category;
        private int _duration;


        private Course _course;
        private List<Questions> _questions = new List<Questions>();
        private List<QuizAttempt> _attempts = new List<QuizAttempt>();

        public Quiz(string name,string category,int duration)
        {
            if (String.IsNullOrEmpty(name))
            {
                throw new ArgumentNullException("name");
            }
            
            if (String.IsNullOrEmpty(category))
            {
                throw new ArgumentNullException("category");
            }
            if (duration <= 0)
            {
                throw new ArgumentOutOfRangeException("Duration must be greater than 0.");
            }
            _name = name;
            _category = category;
            _duration = duration;
            _id = ++_quizid;    
        }

        public int Id
        {
            get
            {
                return _id;
            }
        }

        public Course Course
        {
            get { return _course; }
        }

        public List<Questions> Questions
        {
            get { return _questions; }
        }

        public List<QuizAttempt> Attempts
        {
            get { return _attempts; }
        }

        public string Name
        {
            get
            {
                return _name;
            }
        }

        public string Category
        {
            get
            {
                return _category;
            }
        }

        public int Duration
        {
            get { return _duration; }
        }

        public int StudentsTookCount
        {
            get { return _attempts.Count; }
        }

        public void AssignToCourse(Course course)
        {
            if (course == null)
            {
                throw new ArgumentNullException();
            }
            _course = course;
        }

        public bool CanEdit()
        {
            return _attempts.Count == 0;
        }

        public void AddQuestion(Questions question)
        {
            if (question == null)
            {
                throw new ArgumentNullException();
            }
            if (!CanEdit())
            {
                throw new ArgumentException("Cannot edit quiz, students have taken it.");
            }
            _questions.Add(question);
        }

        public void RemoveQuestion(Questions question)
        {
            if (question == null)
            {
                throw new ArgumentNullException();
            }
            if (!CanEdit())
            {
                throw new ArgumentException("Cannot edit quiz, students have taken it.");
            }
            _questions.Remove(question);
        }

        public void AddAttempt(QuizAttempt attempt)
        {
            if (attempt == null)
            {
                throw new ArgumentNullException();
            }
            _attempts.Add(attempt);
        }

    }
}
