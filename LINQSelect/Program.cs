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
            //someSequence = someSequence.Select(n => n * n);

            //equivalent to above statement
            //someSequence = someSequence
            //                            .Select((int n) =>
            //                                {
            //                                    int b = 2;
            //                                    return n * b;
            //                                });
            //for custom where
            //sequence = sequence.Where(s => s.ToString().Length < 2);
            //foreach (int val in someSequence)
            //    Console.WriteLine(val);

            //For Custom Select
            //var someselectSequence = sequence.Select(n => n.ToString());

            //For Generic Custom Select// Map
            //var someselectSequence = sequence.Where(n => n % 5 == 0).Select((n, index) =>
            //          new
            //          {
            //              index = ++index,
            //              formatedResult = n.ToString().PadLeft(20)
            //          });
            //foreach (var item in someselectSequence)
            //    Console.WriteLine(item.index + "." + item.formatedResult);
            //Console.ReadLine();

            //starting Reduce Function

            //starting Any Implemetation

            //var input = MyLinqImplementation.SequenceFromConsole();
            //foreach (var item in input)
            //    Console.WriteLine("\t" + item);
            //Console.ReadLine();

            //var input = MyLinqImplementation.SequenceFromConsole().Any();
            //Console.WriteLine("\t" + input);

            //Console.WriteLine(MyLinqImplementation.SequenceFromConsole().Any(s => s.Contains("hello")));
            //Console.WriteLine(MyLinqImplementation.SequenceFromConsole().Any(s => s!=null && s.Contains("hello")));
            //Console.ReadLine();
            //return;

            //Console.ReadLine();
            //any implemetation ends here

            //Count Implementation Starts
            var input = MyLinqImplementation.SequenceFromConsole();
            Console.WriteLine(input.Count());
            Console.ReadLine();
            //Count Implementation Ends

            //end Reduce Function
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
        public static int Count<T>(this IEnumerable<T> source)
        {
            int finalCount = 0;
            foreach (var item in source)
                finalCount++;
            return finalCount;
        }
        public static IEnumerable<T> Where<T>(this IEnumerable<T> source, Func<T, bool> predicate)
        {
            foreach (T item in source)
                if (predicate(item))
                    yield return item;
        }

        public static IEnumerable<string> Select(this IEnumerable<int> source, Func<int, string> selector)
        {
            Console.WriteLine("Using Custom Implementation");
            foreach (int item in source)
                yield return selector(item);
            Console.WriteLine("Using Custom Implementation");
        }

        public static IEnumerable<TResult> Select<TResult, TSource>(this IEnumerable<TSource> source, Func<TSource, TResult> selector)
        {
            Console.WriteLine("Using Generic Implementation Starts");
            var save = Console.ForegroundColor;
            foreach (TSource item in source)
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("$item = " + item);
                Console.ForegroundColor = save;
                yield return selector(item);
            }
            Console.WriteLine("Using Generic Implementation Ends");
        }

        public static IEnumerable<string> SequenceFromConsole()
        {
            string text = default(string);
            //if (!string.IsNullOrEmpty(text))
            //{
                while (text != "done")
                {
                    yield return text;
                    text = Console.ReadLine();
                }
            //}
        }

        public static bool Any<T>(this IEnumerable<T> source)
        {
            return source.GetEnumerator().MoveNext();
        }

        public static bool Any<T>(this IEnumerable<T> source, Func<T, bool> predicate)
        {
            return source.Where(predicate).GetEnumerator().MoveNext();
        }

    }
}
