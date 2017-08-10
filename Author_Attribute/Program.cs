using System;
using System.Configuration;

namespace Author_Attribute
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Interface)]
    class AuthorAttribute : System.Attribute
    {
        string Name;
        int version;

        public AuthorAttribute(string name)
        {
            this.Name = name;
        }

        public int Version
        {
            get { return this.version; }
            set { this.version = value; }
        }
    }

	[Author("infreljs", Version = 1)]
    class MainClass
    {
        public static void Main(string[] args)
        {
			Console.WriteLine(Environment.Version);
			Console.WriteLine(ConfigurationManager.AppSettings["AdminEmailAddress"]);
			Console.WriteLine(ConfigurationManager.AppSettings["Delay"]);
        }
	}

	[Author("infreljs", Version = 1)]
	class Class1
	{
	}

	[Author("infreljs", Version = 1)]
	class Class2
	{
	}
}
