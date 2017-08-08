using System;

namespace Implicit_Explicit
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            Dollar d1 = new Dollar(1000m);
            Won w1 = new Won(1000m);

			Console.WriteLine(d1);
			Console.WriteLine(w1);

            Dollar d2 = (Dollar)w1;
            Won w2 = (Won)d1;
			Console.WriteLine(d2);
			Console.WriteLine(w2);
        }
    }

    class Currency
    {
        decimal money;

        public Currency(decimal money)
        {
            this.money = money;
        }

        public decimal Money
        {
            get { return this.money; }
        }

        public override string ToString()
        {
            return string.Format("[{0}: Money={1}]", this.GetType(), Money);
        }
    }

    class Won : Currency
    {
        public Won(decimal money) : base(money)
        {
            
        }

        public static explicit operator Dollar(Won won)
        {
            return new Dollar(won.Money * 0.001m);
        }
    }

    class Dollar : Currency
    {
        public Dollar(decimal money) : base(money)
        {
            
        }

        public static explicit operator Won(Dollar dollar)
        {
            return new Won(dollar.Money * 1000m);
        }
    }
}