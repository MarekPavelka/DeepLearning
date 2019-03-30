using System;
using System.Collections.Generic;
using System.Linq;

namespace LinQ
{
    class Linq2
    {
            // Linq 1
            // Select(), Where(), Any(), All(), Count(), First(),
            // Min(), Max(), Sum(), Average(), ToList(), ToArray()
            // Skip(), SkipWhile(), Take()

            // Linq 2
            // Zip(), GroupBy(), Join(), SelectMany(), Aggregate()

            // Materializing Methods
            // Any(), All(), Count(), First(), 
            // Min(), Max(), Sum(), Average(), ToList(), ToArray()
    }

    class Linq2Examples
    {
        // List<TLeft> .Zip(List<TRight>, (TLeft, TRight) => TResult) : List<TResult>
        public static void ZipExample()
        {
            var inputsCount = 3;
            var inputs = new List<double> { 1.2, 3.4, 7.2 };
            var weights = new int[] { 8, -1, 7 };

            // Neuron.Evaluate(double[] inputs)
            var sum = 0.0;
            for (int i = 0; i < inputsCount; i++)
            {
                sum = sum + inputs[i] * weights[i];
            }

            var sum2 = inputs.Zip(weights, (i, w) => i * w).Sum();
        }

        // EvaluateNet
        public static void ZipExample2()
        {
            var inputs = new[] { 1.2, -5.3, 4 };
            var inputNeurons = new[] { new Neuron(), new Neuron(), new Neuron() };
            var hiddenNeurons = new[] { new Neuron(), new Neuron(), new Neuron() };
            var outputNeurons = new[] { new Neuron(), new Neuron(), new Neuron() };

            var inputLayerResults = inputs.Zip(inputNeurons, (input, neuron) => neuron.Evaluate(new[] { input })).ToArray();
            var hiddenResults = hiddenNeurons.Select(neuron => neuron.Evaluate(inputLayerResults)).ToArray();
            var outputResults = outputNeurons.Select(neuron => neuron.Evaluate(hiddenResults));
        }

        class Neuron
        {
            public double Evaluate(double[] inputs) => 0.0;
        }

        public static void GroupByExample()
        {
            var names = new[] { "Jozo", "Ferdinand", "Harabin", "Vlado", "Fedor", "Kubo" };
            var groupsWithSameLength = names.GroupBy(x => x.Length).ToList(); // x => x.Length keySelector 
                                                                              // { <4, {Jozo, Kubo}>, <5, {Vlado, Fedor}>, <7, {Harabin}>, <9, {Ferdinand}>}
            var jozo = groupsWithSameLength[0].First(); // alternatively [0].ToList()[0];
        }

        public static void JoinExample()
        {
            var numbers = new[] { 1, 2, 3, 4, 5, 6, 7, 8 };
            var labels = new[] { "parne", "neparne" };

            var pairs =
                numbers.Join(labels,
                    n => n % 2 == 0,  // true alebo false
                    l => l == "parne",
                    (n, l) => new Pair(n, l));
        }

        class Pair
        {
            public int Number { get; }
            public string Label { get; }

            public Pair(int number, string label)
            {
                Number = number;
                Label = label;
            }
        }

        public static void JoinExample2()
        {
            var people = new[] { new Person(1, "Jozef"), new Person(2, "Ferdinand"), new Person(1, "Peter") };
            var cities = new[] { new City(1, "Bratislava"), new City(2, "Zilina") };


            var personRecords = people.Join(cities,
                p => p.CityId,                              // left key selector
                c => c.Id,                                  // right key selector
                (p, c) => $"{c.CityName} - {p.Name}"       // result selector
            ).ToList();
        }

        class Person
        {
            public int CityId { get; set; } // property
            public string Name; // public field

            public Person(int cityId, string name)
            {
                CityId = cityId;
                Name = name;
            }
        }

        class City
        {
            public int Id;
            public string CityName;

            public City(int id, string cityName)
            {
                Id = id;
                CityName = cityName;
            }
        }

        // named "FlatMap" in other languages
        public static void SelectManyExample()
        {
            var personGroups = new[]
            {
                new[] { "Jozef", "Vlado" },
                new[] { "Peto" },
                new[] { "Marek" }
            };

            // Flatten
            var personList = personGroups.SelectMany(group => group).ToList();
            // { "Jozef", "Vlado", "Peto", "Marek" }
        }

        // dummy impl
        private IEnumerable<T> SelectMany<T>(List<List<T>> nestedCollection)
        {
            var result = new List<T>();

            foreach (var nestedList in nestedCollection)
                foreach (var item in nestedList)
                    result.Add(item);

            return result;
        }

        // named FoldLeft or Reduce in other languages
        public static void AggregateExample()
        {
            var numbers = new[] { 1, 2, 3, 4, 5 };
            var sum = numbers.Aggregate((accu, b) => accu + b); // 15
            var sumWithOffset = numbers.Aggregate(6, (accu, b) => accu + b); // 21

            string numbersStringRepresentation =
                numbers.Aggregate("", (accu, b) => $"{accu}{b}");

            // { "1", "2", "3", "4", "5" }
            // "abc12345"
        }
    }
}
