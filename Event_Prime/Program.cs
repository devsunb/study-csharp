using System;

namespace Event_Prime
{
<<<<<<< HEAD
    //class CallbackArg { }

    //class PrimeCallbackArg : CallbackArg
    class PrimeCallbackArg : EventArgs
    {
        public long Prime;

        public PrimeCallbackArg(long prime)
        {
            this.Prime = prime;
        }
    }

    class PrimeGenerator
    {
        //public delegate void PrimeDelegate(object sender, CallbackArg);

        //PrimeDelegate callbacks;

        //public void AddDelegate(PrimeDelegate callback)
        //{
        //    callbacks = Delegate.Combine(callbacks, callback) as PrimeDelegate;
        //}

        //public void RemoveDelegate(PrimeDelegate callback)
        //{
        //    callbacks = Delegate.Remove(callbacks, callback) as PrimeDelegate;
        //}

        public event EventHandler PrimeGenerated;

        public void Run(long start, long limit)
        {
            for (long i = start; i <= limit; i++)
            {
				//if (IsPrime(i) == true && callbacks != null)
                if (IsPrime(i) == true && PrimeGenerated != null)
                {
					//callbacks(this, new PrimeCallbackArg(i));
                    PrimeGenerated(this, new PrimeCallbackArg(i));
                }
            }
        }

        private bool IsPrime(long candidate)
        {
            if((candidate & 1) == 0)
            {
                return candidate == 2;
            }

            for (long i = 3; (i * i) <= candidate; i += 2)
            {
                if ((candidate % i) == 0) return false;
            }

            return candidate != 1;
        }
    }

    class MainClass
    {
        //static void PrintPrime(object sender, CallbackArg arg)
        static void PrintPrime(object sender, EventArgs arg)
        {
            Console.Write((arg as PrimeCallbackArg).Prime + ", ");
        }

        static long Sum;

		//static void SumPrime(object sender, CallbackArg arg)
        static void SumPrime(object sender, EventArgs arg)
        {
            Sum += (arg as PrimeCallbackArg).Prime;
        }

        public static void Main(string[] args)
        {
            PrimeGenerator gen = new PrimeGenerator();

            //PrimeGenerator.PrimeDelegate callprint = PrintPrime;
            //gen.AddDelegate(callprint);

            //PrimeGenerator.PrimeDelegate callsum = SumPrime;
            //gen.AddDelegate(callsum);
            gen.PrimeGenerated += PrintPrime;
            gen.PrimeGenerated += SumPrime;

            gen.Run(1000000000000000, 1000000000000000000);
            Console.WriteLine();
            Console.WriteLine(Sum);

            //gen.RemoveDelegate(callsum);
            gen.PrimeGenerated -= SumPrime;
=======
    class MainClass
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
>>>>>>> cdaa176958055a4255c3c7df3bc1e898519e31af
        }
    }
}
