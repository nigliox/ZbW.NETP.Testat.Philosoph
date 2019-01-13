using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace TestatMFPhilosoph
{
    class Philosoph
    {
        private readonly int philosNum;
        private readonly int thinkDelay;
        private readonly int eatDelay;
        private readonly int leftFork;
        private readonly int rightFork;
        private readonly Forks forks;


        public Philosoph(int philosNum, int thinkDelay, int eatDelay, Forks forks)
        {

            this.philosNum = philosNum;
            this.thinkDelay = thinkDelay;
            this.eatDelay = eatDelay;
            this.forks = forks;
            leftFork = philosNum == 0 ? 4 : philosNum - 1; rightFork = (philosNum + 1) % 5;
            new Thread(this.Run).Start();
        }

        public void Run()
        {
        
            while(true)
            {
                try
                {
                    Thread.Sleep(thinkDelay);
                    forks.GetForks(leftFork,rightFork);
                    Console.WriteLine("Philosopher " + philosNum + " is eating!");
                    Thread.Sleep(eatDelay);
                    forks.PutForks(leftFork,rightFork);

                  
                }
                catch
                {
                    return;
                }

            }
        }
    }
}
