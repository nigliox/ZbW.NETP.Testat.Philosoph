using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using NUnit.Framework;
using TestatMFPhilosoph;

namespace TestatMFPhiliosophTests
{
    [TestFixture]

    class ForksTest
    {
        [Test]
        public void GetForksShouldsetTwoDefinedForksNumberToTrue()
        {
            //arrange
            var sut = new Forks();

            int fork1 = 0;
            int fork2 = 1;

            //act 

            sut.GetForks(fork1,fork2);

            //assert
            Assert.That(sut.GetForkArray()[0] == true);
            Assert.That(sut.GetForkArray()[1] == true);
            Assert.That(sut.GetForkArray()[2] == false);
            Assert.That(sut.GetForkArray()[3] == false);
            Assert.That(sut.GetForkArray()[4] == false);
            


        }

        [Test]

        public void GetForksShouldsetTwoDefinedForksNumberToTrueAndLockThemBytheMonitor()
        {
            //arrange
            var sut = new Forks();

            int fork1 = 0;
            int fork2 = 1;

            //act 

            sut.GetForks(fork1, fork2);
            

            //assert
            Assert.That(sut.GetForkArray()[0] == true && sut.GetMonitorisO() == true);
            Assert.That(sut.GetForkArray()[1] == true && sut.GetMonitorisO() == true);
            Assert.That(sut.GetForkArray()[2] == false);
            Assert.That(sut.GetForkArray()[3] == false);
            Assert.That(sut.GetForkArray()[4] == false);
           
        }

        [Test]

        public void PutForksShouldsetTwoDefinedForksNumberToFalse()
        {
            //arrange

            var sut = new Forks();

            /* 
            /set Forks 0,1,2,3 to true
           */
            sut.GetForks(0,1);
            sut.GetForks(2,3);
          

            //act

            sut.PutForks(0,1);

            //assert
            Assert.That(sut.GetForkArray()[0] == false && sut.GetForkArray()[1] == false);
            Assert.That(sut.GetForkArray()[2] == true && sut.GetForkArray()[3] == true);
            Assert.That(sut.GetForkArray()[4] == false);
        }

        [Test]

        public void PutForksShouldsetTwoDefinedForksNumberToFalseAndDeactivateLock()
        {
            //arrange

            var sut = new Forks();

            /* 
            /set Forks 0,1,2,3 to true
           */
            sut.GetForks(0, 1);
            sut.GetForks(2, 3);


            //act

            sut.PutForks(0, 1);

            //assert
            Assert.That(sut.GetForkArray()[0] == false && sut.GetForkArray()[1] == false && sut.GetMonitorisO() ==false);
            Assert.That(sut.GetForkArray()[2] == true && sut.GetForkArray()[3] == true && sut.GetMonitorisO() == false);
            Assert.That(sut.GetForkArray()[4] == false);
        }

    }
}
