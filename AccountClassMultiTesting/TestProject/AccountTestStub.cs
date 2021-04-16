using bank;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace TestProject
{
    class AccountTestStub
    {


        [Test]
        [TestCase(200, 0, 10)]
        public void TransferFundsFromAmount_version2(int a, int b, int c)
        {
            //arange
            Account source = new Account();
            Account destination = new Account();
            source.Deposit(a);
            destination.Deposit(b);
            var rateEurRon = 4.99F;
            var convertor = new CurrencyConvertorStub(rateEurRon);

            //act
            source.TransferFundsFromAmount_version2(destination, c, convertor);

            //assert
            Assert.AreEqual(b + (rateEurRon * 10), destination.Balance);
            Assert.AreEqual(a - (rateEurRon * 10), source.Balance);
            //Assert.AreEqual(200, source.Balance);
        }
    }
}
