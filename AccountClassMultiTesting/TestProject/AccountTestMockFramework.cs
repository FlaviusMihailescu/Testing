using bank;
using bank.Code;
using bank.Dependecies;
using bank.TestDoubles;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace TestProject
{
    [TestFixture]
    public class AccountTestMockFramework
    {

        [SetUp]
        public void InitAccount()
        {
            //arrange
        }

        [Test]
        [Category("pass")]
        public void TransferFunds()
        {

            //arrange the MockObject
            var logMock = new Moq.Mock<ILogger>();

            //arrange SUT

            var client = new ClientDummy();
            var source = new AccountForLogSpy(200, client, logMock.Object);
            var destination = new AccountForLogSpy(150, client, logMock.Object);

            //set mocked logger expectations

            logMock.Setup(d => d.Log("method Log was called with message : Transaction : 100 & 250"));

            //logMock.ExpectedNumberOfCalls(1);
            //act

            source.TransferFunds(destination, 100.00F);

            //assert 
            Assert.AreEqual(250.00F, destination.Balance);
            Assert.AreEqual(100.00F, source.Balance);

            //mock object verify

            logMock.Verify();


        }

        [Test]
        public void TransferFundsFromEurAmount_MockFramework_ShouldWork()
        {

            //arrange

            var source = new Account(200);
            var destination = new Account(150);

            var rateEurRon = 4.4F;
            var convertorMock = new Mock<ICurrencyConvertor>();

            convertorMock.Setup(_ => _.EurToRon(20)).Returns(20 * rateEurRon); // set mock to act as a TestDouble Stub - gives IndirectInputs to the SUT

            //act
            source.TransferFundsFromEurAmount_Version3(destination, 20.00F, convertorMock.Object);

            //assert
            Assert.AreEqual(150.00F + 20 * rateEurRon, destination.Balance);
            Assert.AreEqual(200.00F - 20 * rateEurRon, source.Balance);

            convertorMock.Verify(_ => _.EurToRon(20), Times.Once()); //verify behavior 
        }
    }
}
