using System.Collections.Generic;
using System.Linq;

namespace LinQ
{
    class ScLinqTutorial
    {

        // Refactor following imperative function implementations
        // using the declarative (LINQ) style
        class Exercise1
        {
            /// <summary>
            /// Given a list of units, function returns unit names
            /// that are 5 or less characters long
            /// </summary>
            List<string> GetShortNamesOnly(List<Unit> units)
            {
                var shortNames = new List<string>();

                foreach (var unit in units)
                {
                    if (unit.Name.Length <= 5)
                    {
                        shortNames.Add(unit.Name);
                    }
                }

                return shortNames;
            }

            List<string> GetShortNamesLinq(List<Unit> units)
            {
                return units.Select(unit => unit.Name).Where(name => name.Length <= 5).ToList();
            }

            /// <summary>
            /// Given a list of own workers, returns the first worker
            /// which is not carrying any minerals, but is not mining gas either
            /// </summary>
            Unit TryGetFreeWorker(List<Unit> myWorkers)
            {
                foreach (var worker in myWorkers)
                {
                    if (!worker.IsCarryingMinerals && !worker.IsMiningGas)
                    {
                        return worker;
                    }
                }

                return null;
            }

            Unit TryGetFreeWorkerLinq(List<Unit> myWorkers)
            {
                return myWorkers.FirstOrDefault(x => !x.IsCarryingMinerals && !x.IsMiningGas);
            }

            /// <summary>
            /// Given a list of own workers, returns the count of workers
            /// that are mining gas
            /// </summary>
            int GetGasWorkersCount(List<Unit> myWorkers)
            {
                int gasWorkersCount = 0;
                foreach (var worker in myWorkers)
                {
                    if (worker.IsMiningGas)
                    {
                        gasWorkersCount++;
                    }
                }

                return gasWorkersCount;
            }

            int GetGasWorkersCountLinq(List<Unit> myWorkers)
            {
                return myWorkers.Count(x => x.IsMiningGas);
            }

            /// <summary>
            /// Given a list of own gas workers, if there are more than 3 workers mining gas,
            /// order the extra ones to gather the closest mineral
            /// </summary>
            void SendExtraGasWorkersToMineral(List<Unit> myWorkers)
            {
                var gasWorkers = new List<Unit>();

                foreach (var worker in myWorkers)
                {
                    if (worker.IsMiningGas)
                    {
                        gasWorkers.Add(worker);
                    }
                }

                // this is redundant
                // if (gasWorkers.Count <= 3)
                // {
                //     return;
                // }

                // { w0, w1, w2, w3, w4 } -> 3, 4
                for (int i = 3; i < gasWorkers.Count; i++)
                {
                    var extraGasWorker = gasWorkers[i];
                    extraGasWorker.GatherClosestMineral();
                }
            }

            void SendExtraGasWorkerToMineralLinq(List<Unit> myWorkers)
            {
                myWorkers.Where(worker => worker.IsMiningGas)
                    .Skip(3)
                    .ToList()
                    .ForEach(worker => worker.GatherClosestMineral());
            }

            /// <summary>
            /// Given a list of own units and an enemy intruder,
            /// order all idle fighters inside the base to attack the intruder
            /// </summary>
            void OrderAllFightersToAttackBaseIntruder(List<Unit> myUnits, Unit intruder)
            {
                foreach (var myUnit in myUnits)
                {
                    if (myUnit.IsInBase && myUnit.CanAttack && !myUnit.IsWorker)
                    {
                        myUnit.Attack(intruder);
                    }
                }
            }

            void OrderAllFightersToAttackBaseIntruderLINQ(List<Unit> myUnits, Unit intruder)
            {
                myUnits.Where(unit => unit.IsInBase)
                    .Where(unit => unit.CanAttack)
                    .Where(unit => !unit.IsWorker)
                    .ToList()
                    .ForEach(unit => unit.Attack(intruder));
            }
        }

        /// <summary>
        /// A dummy helper class
        /// </summary>
        class Unit
        {
            public string Name { get; } // "Zealot", "Drone", "Zergling" ...
            public bool IsCarryingMinerals { get; }
            public bool IsMiningGas { get; }
            public bool IsInBase { get; }
            public bool IsWorker { get; }
            public bool CanAttack { get; }

            public void GatherClosestMineral()
            {
            }

            public void Attack(Unit target)
            {
            }
        }
    }
}