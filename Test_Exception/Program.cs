using System;

namespace Test_Exception
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            for (int i = 0; i < 1000000;i++)
            {
                try {
                    int j = int.Parse("5T");
                } catch (System.FormatException) {}
            }

        }

        public static void ExceptionFunc(string str)
        {
            if(str == null)
            {
                throw new UserException("a");
            }
        }
    }

    class UserException : Exception
    {
        public UserException(string msg) : base(msg)
        {
        }
    }
}
