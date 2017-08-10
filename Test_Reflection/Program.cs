using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.Remoting;
using System.Text;
using System.Threading.Tasks;

namespace Test_Reflection
{
    class Program
    {
        static void Main(string[] args)
        {
            //AppDomain current = AppDomain.CurrentDomain;
            //Console.WriteLine("Current Domain : " + current.FriendlyName);
            //foreach (Assembly asm in current.GetAssemblies())
            //{
            //    Console.WriteLine("Assembly : " + asm.FullName);
            //    foreach (Module m in asm.GetModules())
            //    {
            //        Console.WriteLine("Module : " + m.FullyQualifiedName);
            //        foreach (Type t in m.GetTypes())
            //        {
            //            Console.WriteLine("Type : " + t.FullName);
            //            foreach (MemberInfo mi in t.GetMembers())
            //            {
            //                Console.WriteLine("Member : " + mi.Name);
            //            }
            //        }
            //    }
            //}

            AppDomain newAppDomain = AppDomain.CreateDomain("MyAppDomain");
            string dllPath = @"E:\Programming\C#\Study_CSharp\Test_Library\bin\Debug\Test_Library.dll";

            ObjectHandle objHandle1 = newAppDomain.CreateInstanceFrom(dllPath, "Test_Library.Class1");

            //AppDomain.Unload(newAppDomain);

            AppDomain.CurrentDomain.CreateInstanceFrom(dllPath, "Test_Library.Class2");

            //AppDomain.Unload(AppDomain.CurrentDomain);

            Console.WriteLine("objHandle1 : " + objHandle1.ToString());
        }
    }
}
