using System;
using System.Collections.Generic;
using System.Text;

namespace Quiz___Exam
{
    public class ShortAnswerQuestion : Questions
    {
        private string _correctAnswer;

        public string CorrectAnswer
        {
            get { return _correctAnswer; }
        }

        public ShortAnswerQuestion(string text, int marks, string correctAnswer)
            : base(text, marks)
        {
            if (string.IsNullOrEmpty(correctAnswer))
            {
                throw new ArgumentNullException("correctAnswer");
            }
            _correctAnswer = correctAnswer;
        }

        public override string CheckAnswer(string studentAnswer)
        {
            if (studentAnswer == null)
            {
                return "Wrong";
            }

            if (studentAnswer == _correctAnswer)
            {
                return "Correct";
            }

            return "Wrong";
        }
    }
}
