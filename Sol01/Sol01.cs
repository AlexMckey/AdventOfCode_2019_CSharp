using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using MoreEnumerable = MoreLinq.MoreEnumerable;

namespace Sol01
{
    class Sol01
    {
        static int calcFuel(int weight) => weight / 3 - 2;

        static int calcFuels(int weight, int acc = 0)
        {
            var fuel = calcFuel(weight);
            if (fuel > 0)
                return calcFuels(fuel, acc + fuel);
            else
                return acc;
        }

        static IEnumerable<int> fuelValues(int start) =>
            MoreEnumerable.Generate(start, s => s / 3 - 2)
                .Skip(1)
                .TakeWhile(s => s > 0);

        static void Main(string[] args)
        {
            var input = File.ReadAllText("Sol01.txt");

            var weights = input
                        .TrimEnd()
                        .Split("\n")
                        .Select(int.Parse)
                        .ToList();

            var res1 = weights.Sum(calcFuel);

            Console.WriteLine($"{res1}"); //3342351

            // var r1 = calcFuels(14);
            // var r2 = calcFuels(1969);
            // var r3 = calcFuels(1007560);

            // Console.WriteLine($"{r1}, {r2}, {r3}");

            var res2_1 = weights.Sum(w => calcFuels(w, 0));
            var res2_2 = weights.Sum(w => fuelValues(w).Sum());

            Console.WriteLine($"{res2_1}"); //5010664
            Console.WriteLine($"{res2_2}"); //5010664
        }
    }
}
