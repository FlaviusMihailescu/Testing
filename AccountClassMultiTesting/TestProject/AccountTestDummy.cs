
using System;
using System.Collections.Generic;
using System.Text;
using NUnit.Framework;
using bank;
using bank.Dependecies;
using bank.Code;
using bank.TestDoubles;

namespace TestProject
{
    [TestFixture]
    public class AccountTestDummy
    {
        [Test, Category("pass")]
        public void GetBalance_ShowCodeWithoutDummyObject_ShouldWork()
        {
            //arange
            var client = new Client("Victor", "Blaga", "Timisoara, Cetatii 10, Ap.11", 27);
            var source = new AccountForDummyObject(2000F, client);

            //act
            var formateBalance = source.GetFormatedBalance();

            //asert
            Assert.AreEqual(formateBalance, "2,000.00");
        }

        [Test, Category("pass")]
        public void GetBalance_ShowCHowDummyObject_ShouldWork()
        {
            //arange
            var client = new ClientDummy(); //SUT do not care about client's details
            var source = new AccountForDummyObject(2000F, client);

            //act
            var formatedBalance = source.GetFormatedBalance();

            //assert
            Assert.AreEqual(formatedBalance, "2,000.00");
        }
    }
}
