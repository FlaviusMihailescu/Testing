using bank.Code;
using bank.TestDoubles;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using CategoryAttribute = System.ComponentModel.CategoryAttribute;

namespace TestProject
{
    public class AccountTestMockObject
    {
        public void InitAccount()
        {
            //arange
        }
        [Test]
        [Category("pass")]
        public void TransferFunds()
        {
            //arrange the MockObject
            var logMock = new LogMockObject();

            //arrange SUT

            var client = new ClientDummy();
            var source = new AccountForLogSpy(200, client, logMock);
            var destination = new AccountForLogSpy(150, client, logMock);

            //set mocked logger exceptions
            logMock.AddExcpectedLogMessage("method Log was called with message : Tra nsaction: 100 & 250");
            // ma astept ca mesajul sa fie cel de mai sus
            logMock.ExceptedNumberOfCalls(1); // ma astept ca nr de apeluri sa fie 1

            //act

            source.TransferFunds(destination, 100.00F);

            //assert
            Assert.AreEqual(250.00F, destination.Balance);
            Assert.AreEqual(100.00F, source.Balance);

            //mock object verify
            Assert.True(logMock.Verify());
        }
    }
}
