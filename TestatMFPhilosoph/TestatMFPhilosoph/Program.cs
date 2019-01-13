using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestatMFPhilosoph
{
    class Program
    {
        static void Main(string[] args)
        {
            var forks = new Forks();

            new Philosoph(1, 1000, 5000, forks);
            new Philosoph(2, 2000, 4000, forks);
            new Philosoph(3, 3000, 3000, forks);
            new Philosoph(4, 4000, 2000, forks);
            new Philosoph(5, 5000, 1000, forks);

        }

    }
}
