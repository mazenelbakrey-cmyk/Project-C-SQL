using System;
using System.Collections.Generic;
using System.Text;

namespace Quiz___Exam
{
    public abstract class Questions
    {
        protected static int _questionCounter = 0;

        protected int _id;
        protected string _text;
        protected int _marks;

        public int Id
        {
            get { return _id; }
        }

        public string Text
        {
            get { return _text; }
        }

        public int Marks
        {
            get { return _marks; }
        }

        protected Questions(string text, int marks)
        {
            if (string.IsNullOrEmpty(text))
            {
                throw new ArgumentNullException("text");
            }
            if (marks <= 0)
            {
                throw new ArgumentOutOfRangeException("Marks must be greater than 0.");
            }

            _id = ++_questionCounter;
            _text = text;
            _marks = marks;
        }

        public abstract string CheckAnswer(string studentAnswer);

    }
}
