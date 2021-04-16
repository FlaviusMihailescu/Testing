using bank;
using bank.Code;
using bank.TestDoubles;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace TestProject
{
    public class AccountTestLogSpy
    {
        Account source;
        Account destination;
        [SetUp]
        public void Setup()
        {
            //arrange
            source = new AccountForLogSpy();
            source.Deposit(200.00F);
            destination = new AccountForLogSpy();
            destination.Deposit(150F);
        }
        [Test]
        [Category("pass")]
        public void TransferFunds()
        {
            //arrange
            var logSpy = new LogSpy();

            source.logger = logSpy;
            destination.logger = logSpy;

            //act
            source.TransferFunds(destination, 50.00F);

            //assert
            Assert.AreEqual(250.00F, destination.Balance);
            Assert.AreEqual(100.00F, source.Balance);

            //spy assert
            Assert.AreEqual(1, logSpy.GetActions());
            foreach (String log in logSpy.GetActions())
                Console.WriteLine(log);
        }
    }
}
