using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExtensionMethods
{
    public class ExtensionMethods
    {
        void Usage()
        {
            var x = new List<int>();
            var y = new List<string>();

            var result = x.Bullshit("fero"); // usage
            var result2 = y.Bullshit("jozef");

            ListExtensions.Bullshit(x, "fero"); // replaced after compilation
        }
    }

    public static class ListExtensions
    {
        public static int Bullshit<T>(this List<T> list, string name)
        {
            return 0;
        }
    }

    public static class LinqExtensions

    {
        static void MyOwnLinq(string[] args)
        {
            var list = new List<int> { 1, 2, 3, 4, 5 };
            var result = list.MySelect(ConvertToStringRepresentation).ToList();

            var result2 = list.Select(x => ConvertToStringRepresentation(x)).ToList();

            var result3 = list.Where(x => IsEven(x)).ToList();
        }

        static bool IsEven(int x)
        {
            return x % 2 == 0;
        }

        static string ConvertToStringRepresentation(int x)
        {
            //

            //
            //
            //
            //
            return "abc" + x;
        }

        public static IEnumerable<TResult> MySelect<TSource, TResult>(this IEnumerable<TSource> source, Func<TSource, TResult> selector)
        {
            foreach (var item in source)
            {
                yield return selector(item);
            }
        }

        public static IEnumerable<TSource> MyWhere<TSource>(this IEnumerable<TSource> source, Func<TSource, bool> predicate)
        {
            foreach (var item in source)
            {
                if (predicate(item)) yield return item;
            }
        }
    }
}
