using System;
using System.Reflection;

[assembly: AssemblyVersion("1.0.0.0")]

namespace Preprocessor_Constant
{
    class MainClass
    {
        public static void Main(string[] args)
        {
#if DEBUG
            Console.WriteLine(Environment.Is64BitProcess);
#endif
            Console.WriteLine("Hello World!");
        }
    }
}
