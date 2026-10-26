using System;
using System.Collections.Generic;
using System.Text;

namespace Quiz___Exam
{
    public class TrueFalseQuestion : Questions
    {
        private bool _correctAnswer;

        public bool CorrectAnswer
        {
            get { return _correctAnswer; }
        }

        public TrueFalseQuestion(string text, int marks, bool correctAnswer)
            : base(text, marks)
        {
            _correctAnswer = correctAnswer;
        }

        public override string CheckAnswer(string studentAnswer)
        {
            if (studentAnswer == null)
            {
                return "Wrong";
            }

            string answer = studentAnswer;

            if (answer == "true" && _correctAnswer == true)
            {
                return "Correct";
            }
            if (answer == "false" && _correctAnswer == false)
            {
                return "Correct";
            }

            return "Wrong";
        }
    }
}
