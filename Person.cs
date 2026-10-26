using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Text;

namespace Quiz___Exam
{
    public abstract class Person
    {
        protected static int _counter = 0;

        protected  int _id;
        protected string _email;
        protected string _name;
        protected string _password;
        protected static Dictionary<string, string> _students = new Dictionary<string, string>();
        protected static Dictionary<string, string> _Admins = new Dictionary<string, string>();
        protected static Dictionary<string, string> _teachers = new Dictionary<string, string>();

        public int Id
        {
            get { return _id; }
        }
        public string Name
        {
            get
            {
                return _name;
            }
            protected set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentException("Name cannot be empty.");
                }
                _name = value;
            }
        }

        public string Email
        {
            get
            {
                return _email;
            }
            protected set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentException("Invalid email ");
                }
                _email = value;
            }
        }

        public string Password
        {
            get
            {
                return _password;
            }
            protected set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentException("Invalid password");
                }
                _password = value;
            }
        }

        protected Person(string name, string email, string password)
        {
            _id = ++_counter;
            Name = name;
            Email = email;
            Password = password;
        }


        public virtual void Login() { }

        public virtual void Register() { }

    }
}
