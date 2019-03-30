using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassInheritance
{
    class Program
    {
        static void Main()
        {
            //Person p = new Person();
            Person e = new Employee(); // Person e je referencia na instanciu typu Employee
            e.KillYourself(); // zavola sa overridnuta verzia metody


            Customer c = new Customer();
            c.KillYourself();

            //p.KillYourself();

            Console.ReadLine();
        }

        // Parameter funkcie typu Person, nevie aka instancia pride
        // nevie ktora verzia p.KillYourself() sa vykona = polymorphism
        static void SendEmailTo(Person p) // p ma atributy iba classy Person, enkapsulacia
        {
            // InvalidCastException v pripade ze v p je instancia Customer
            Employee e = p as Employee; // ak sa nepodari vrati null
            if (e != null)
            {
                // ...
            }

            if (p is Employee)
            {
                e = (Employee)p; // explicitna konverzia "cast"
            }

            var textToSend = "Dear Mr. " + p.Name + ", ";
            p.KillYourself();
            // send him the email
        }
    }

    public class Person
    {
        internal protected int _count;
        // properties
        public int Age { get; protected set; }
        public string Name { get; }

        // methods
        public virtual void KillYourself()
        {
            Console.WriteLine("zomieram");
        }
    }

    class Employee : Person
    {
        public Employee()
        {
            _count++;
            Age = 21;
        }

        public double Salary { get; }

        public override void KillYourself()
        {
            Console.WriteLine("zomieram narobeny");
        }
    }

    class Customer : Person
    {
        public Customer()
        {
            Age = 80;
        }

        public List<string> PastOrders { get; }

        public override void KillYourself()
        {
            Console.WriteLine("zomieram ako rich bitch");
        }
    }
}
