using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Delegates
{
    class Delegates
    {
        static void Usage()
        {
            // void funkcie
            Action<string, int> a = DoNothing;
            a("abc", 4); // rovnake ako  DoNothing("abc", 4);

            Action<string> lambda = name => { /* do nothing */ };

            // nevoid funkcie
            Func<string, int, int> b = GetNumber;
            int result = b("ferko", 92); // rovnake ako int result = GetNumber("ferko", 92);

            Select((int x) => "abc");
            Select(Whatevs2);
        }

        static string Whatevs(int x)
        {
            return "abc";
        }

        static string Whatevs2(int abc)
        {
            return "jozko";
        }

        static void DoNothing(string name, int age)
        {
            // do nothing
        }

        static int GetNumber(string name, int age) => 42;

        static void Select(Func<int, string> selector)
        {
            //
            //
            //
            //
        }

        static long MeasureElapsedMs(Action action)
        {
            var stopwatch = Stopwatch.StartNew();
            action();
            return stopwatch.ElapsedMilliseconds;
        }
    }
}
