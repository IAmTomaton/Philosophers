using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Philosophers
{
    class Philosopher
    {
        public int SumEationgTime { get; private set; }

        private readonly Fork LeftFork;
        private readonly Fork RightFork;
        private readonly Table Table;

        private readonly int EatingTime = 10;
        private readonly int ThinkingTime = 10;

        public Philosopher(Table table, Fork leftFork, Fork rightFork)
        {
            LeftFork = leftFork;
            RightFork = rightFork;
            Table = table;
        }

        public void Work()
        {
            while (true)
            {
                Table.Lock();
                if (!LeftFork.TryLock())
                {
                    Table.Release();
                    continue;
                }
                if (!RightFork.TryLock())
                {
                    LeftFork.Release();
                    Table.Release();
                    continue;
                }
                Table.Release();

                Thread.Sleep(EatingTime);
                SumEationgTime += 1;

                LeftFork.Release();
                RightFork.Release();

                Thread.Sleep(ThinkingTime);
            }
        }
    }
}
