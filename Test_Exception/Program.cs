using System;

namespace Test_Exception
{
    class MainClass
    {
        public static void Main(string[] args)
        {
<<<<<<< HEAD
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
=======
            Console.WriteLine("Hello World!");
>>>>>>> cdaa176958055a4255c3c7df3bc1e898519e31af
        }
    }
}
