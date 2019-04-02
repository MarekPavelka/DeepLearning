using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Generics
{
    class Usage
    {
        void Usage1()
        {
            var myVal = MyValue.Create("abc");
            var myValue = new MyValue<string>("abc");
            var ferko = new[] {1, 2, 3};
        }
    }

    // Generics <T>
    // Definition
    // I. Generic type (class)
    class MyValue<T>
    {
        public T Value { get; } // property

        public MyValue(T value)
        {
            Value = value;
        }
    }

    // Workaround for infering the generic type from usage
    // instead of specifying it explicitly
    static class MyValue
    {
        public static MyValue<T> Create<T>(T value)
        {
            return new MyValue<T>(value);
        }
    }

    // I. Generic type (interface)
    interface MyIEnumerable<T>
    {
        T Property { get; }
    }

    // II. Generic function
    class MyList2
    {
        public static List<T> Whatevs<T>(T value)
        {
            return new List<T>();
        }
    }
}
