using System;
using System.Collections.Generic;
using System.Text;

namespace Quiz___Exam
{
    public class MultipleChoiceQuestion : Questions
    {
        private List<string> _choices;
        private int _correctIndex;

        public List<string> Choices
        {
            get { return _choices; }
        }

        public int CorrectIndex
        {
            get { return _correctIndex; }
        }

        public MultipleChoiceQuestion(string text, int marks, List<string> choices, int correctIndex)
            : base(text, marks)
        {
            if (choices == null || choices.Count < 2)
            {
                throw new ArgumentException("A multiple choice question must have at least 2 choices.");
            }
            if (correctIndex < 0 || correctIndex >= choices.Count)
            {
                throw new ArgumentOutOfRangeException("Correct index is out of range.");
            }

            _choices = choices;
            _correctIndex = correctIndex;
        }

        public override string CheckAnswer(string studentAnswer)
        {
            if (studentAnswer == null)
            {
                return "Wrong";
            }

            if (studentAnswer == _correctIndex.ToString())
            {
                return "Correct";
            }

            return "Wrong";
        }
    }
}
