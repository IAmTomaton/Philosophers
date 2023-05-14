using System;
using System.Linq;
using System.Threading;

namespace Philosophers
{
    class Program
    {
        static void Main(string[] args)
        {
            var count = 5;
            var table = new Table();
            var forks = Enumerable.Range(0, count).Select(_ => new Fork()).ToArray();
            var philosophers = Enumerable.Range(0, count).Select(i => new Philosopher(table, forks[i], forks[(i + 1) % count])).ToArray();
            var threads = Enumerable.Range(0, count).Select(i => new Thread(new ThreadStart(philosophers[i].Work))).ToArray();

            foreach (var thread in threads)
                thread.Start();

            for (var i = 0; i < 50; i++)
            {
                Console.WriteLine(string.Join(", ", philosophers.Select(philosopher => philosopher.SumEationgTime)));
                Thread.Sleep(1000);
            }
        }
    }
}
