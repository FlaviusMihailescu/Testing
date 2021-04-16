using bank;
using NUnit.Framework;

namespace TestProject
{
    public class AccountTest
    {
        //HomeWork Curs 2

        Account source;
        Account destination;

        //inainte de fiecare test se executa setup ul
        //setup:
        //arrange: seteaza valorile initiale(ex pentru cazul nostru: depune niste sume in cont uri)
        //Test:
        //act: creaza cazuri de test
        //asert: testeaza daca valorile obtinute sunt aceleasi cu cele asteptate

        [SetUp]
        public void Setup()
        {
            //arange
            source = new Account();
            source.Deposit(200.00F);
            destination = new Account();
            destination.Deposit(150.00F);
        }

        [Test]
        public void TransferFunds()
        {
            //act
            source.TransferFunds(destination, 90F);

            //asert
            Assert.AreEqual(240.00f, destination.Balance);
            Assert.AreEqual(110.00F, source.Balance);
        }

        [Test]
        [TestCase(200, 0, 72)]
        [TestCase(200, 0, 189)]
        [TestCase(200, 0, 1)]
        [TestCase(200, 0, 191)] // in contul sursa suma ramasa < minBalance => testul pica 
        [TestCase(200, 0, -100)] //am creat o clasa care nu permite sa sa facem un transfer cu o suma negativa, deoarece am putea astfel sa extragem bani dintr un alt cont
        public void TransferMinFunds(int a, int b, int c) 
        {
            //arange
            Account source = new Account();
            source.Deposit(a);
            Account destination = new Account();
            destination.Deposit(b);

            //act
            source.TransferMinFunds(destination, c);

            //assert
            Assert.AreEqual(c, destination.Balance);
        }


        //HomeWork Curs 3
        [Test]
        [TestCase(200, 0, 10)]
        public void TransferFundsFromAmount_version1(int a, int b, int c)
        {
            //arange
            Account source = new Account();
            Account destination = new Account();
            source.Deposit(a);
            destination.Deposit(b);
            var rate = 4.87F;

            //act
            source.TransferFundsFromAmount_version1(destination, c, rate);

            //assert
            Assert.AreEqual(c*rate, destination.Balance);
        }
    }
}