using System;

namespace Recursive_Call
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            RecursiveCall(1);
        }

        private static long Factorial(long n)
        {
            if (n == 0) return 1;
            return n * Factorial(n - 1);
        }

        private static void RecursiveCall(long n)
        {
            long a, b, c, d, e, f, g, h, i, j, k, l, m, o, p, q, r, s, t, u, v, w, x, y, z;
            Console.WriteLine(n);
            RecursiveCall(n + 1);
        }
    }
}
