using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LINQSelect
{
    class Program
    {


        static void Main(string[] args)
        {
            var sequence = GenerateNumbers();

            //understanding how function call happen in LINQ
            var someSequence = GenerateNumbers();
            someSequence = someSequence.Select(n => n * n);

            //equivalent to above statement
            someSequence = someSequence
                                        .Select((int n) =>
                                            {
                                                int b = 2;
                                                return n * b;
                                            });

            sequence = sequence.Where(s => s.ToString().Length < 2);
            foreach (int val in someSequence)
                Console.WriteLine(val);

            Console.ReadLine();
        }

        public static IEnumerable<int> GenerateNumbers()
        {
            var i = 0;
            while (i++ < 100)
                yield return i;
        }

    }

    public static class MyLinqImplementation
    {
        public static IEnumerable<T> Where<T>(this IEnumerable<T> source, Func<T, bool> predicate)
        {
            foreach (T item in source)
                if (predicate(item))
                    yield return item;
        }
    }
}
