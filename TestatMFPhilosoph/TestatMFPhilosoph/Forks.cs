using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace TestatMFPhilosoph
{
    // This class will provide forks to the philosophers and monitor if the fork is in use or not


    class Forks
    {
        private readonly bool[] fork = new bool[5];

        // Attempt to pick up the forks with the designated nubers
        public void Get(int leftFork, int rightFork)
        {
            lock (this)
            {
                while (fork[leftFork] || fork[rightFork])
                {
                    Monitor.Wait(this);
                }

                fork[leftFork] = true;
                fork[rightFork] = true;
            }
        }

        public void Put(int leftFork, int rightFork)
        {
            lock (this)
            {
                fork[leftFork] = false;
                fork[rightFork] = false;
                Monitor.PulseAll(this);
            }
        }
    }
}
