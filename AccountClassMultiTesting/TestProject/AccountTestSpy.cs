using bank.TestDoubles;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace TestProject
{
    public class AccountTestSpy
    {
        [Test, Category("pass")]
        public void GetBalance_ShowHowDummyWorks_ShouldWork()
        {
            //arange
            var source = new InternalAccountSpy();
            source.Deposit(200.00F);
            var destination = new InternalAccountSpy();
            destination.Deposit(150.00F);

            //act
            source.TransferFunds(destination, 40.00F);

            //asesrt
            Assert.AreEqual("Deposit 150", destination.GetActions()[0]);
            Assert.AreEqual("Deposit 40", destination.GetActions()[1]);
            Assert.AreEqual("Deposit 200", source.GetActions()[0]);
            Assert.AreEqual("Deposit 40", source.GetActions()[1]);
        }
    }
}
