using System;
using System.Collections.Generic;
using System.Text;

namespace Quiz___Exam
{
    public class QuizAttempt
    {
        private static int _attemptCounter = 0;

        private int _id;
        private Student _student;
        private Quiz _quiz;
        private List<string> _studentAnswers = new List<string>();
        private int _score;
        private int _timeTaken;

        public int Id
        {
            get { return _id; }
        }

        public Student Student
        {
            get { return _student; }
        }

        public Quiz Quiz
        {
            get { return _quiz; }
        }

        public List<string> StudentAnswers
        {
            get { return _studentAnswers; }
        }

        public int Score
        {
            get { return _score; }
        }

        public int TimeTaken
        {
            get { return _timeTaken; }
        }

        public QuizAttempt(Student student, Quiz quiz, int timeTaken)
        {
            if (student == null)
                throw new ArgumentNullException(nameof(student));
            if (quiz == null)
                throw new ArgumentNullException(nameof(quiz));
            if (timeTaken < 0)
                throw new ArgumentOutOfRangeException("Time taken cannot be negative.");

            _id = ++_attemptCounter;
            _student = student;
            _quiz = quiz;
            _timeTaken = timeTaken;
        }

        public void AddAnswer(string answer)
        {
            if (answer == null)
                answer = "";
            _studentAnswers.Add(answer);
        }

        public void CalculateScore()
        {
            int total = 0;

            for (int i = 0; i < _quiz.Questions.Count; i++)
            {
                if (i < _studentAnswers.Count)
                {
                    string result = _quiz.Questions[i].CheckAnswer(_studentAnswers[i]);
                    if (result == "Correct")
                    {
                        total += _quiz.Questions[i].Marks;
                    }
                }
            }

            _score = total;
        }
    }
}
