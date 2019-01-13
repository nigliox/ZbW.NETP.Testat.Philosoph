using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace TestatMFPhilosoph
{
    // This class will provide forks to the philosophers and monitor if the fork is in use or not


    public class Forks
    {
        private readonly bool[] fork = new bool[5];

        private bool monitorIsO;

        // Attempt to pick up the forks with the designated nubers
        public void GetForks(int leftFork, int rightFork)
        {
            lock (this)
            {
                while (fork[leftFork] || fork[rightFork])
                {
                    Monitor.Wait(this);
                    
                }
                this.monitorIsO = true;
                fork[leftFork] = true;
                fork[rightFork] = true;
            }
        }

        public void PutForks(int leftFork, int rightFork)
        {
            lock (this)
            {
                fork[leftFork] = false;
                fork[rightFork] = false;
                Monitor.PulseAll(this);
                this.monitorIsO = false;
            }
        }

        public bool[] GetForkArray()
        {
            return fork;
        }

        public bool GetMonitorisO()
        {
            return monitorIsO;
        }
    }
}
