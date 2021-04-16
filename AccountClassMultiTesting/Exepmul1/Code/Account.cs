using bank.TestDoubles;
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace bank
{
    public class Account
    {
        protected float balance;
        protected float minBalance = 10;
        public LogSpy logger;

        public Account()
        {
            balance = 0;
        }

        public Account(int value)
        {
            balance = value;
        }

        public void Deposit(float amount)
        {
            balance += amount;
        }

        public void Withdraw(float amount) 
        {
            balance -= amount;
        }

        public void TransferFunds(Account destination, float amount)
        {
            destination.Deposit(amount);
            Withdraw(amount);
        }

        public Account TransferMinFunds(Account destination, float amount)
        {
            if (Balance - amount > MinBalance)
            {
                if (VerifyAmount(amount))
                {
                    destination.Deposit(amount);
                    Withdraw(amount);
                }
                else throw new FundsFormatException();
            }
            else throw new NotEnoughFundsException();
            return destination;
        }

        public bool VerifyAmount(float amount)
        {
            if (amount > 0)
                return true;
            else
                return false;
        }


        public float Balance
        {
            get { return balance; }
        }

        public float MinBalance
        {
            get { return minBalance; }
        }

        public void TransferFundsFromAmount_version1(Account destination, float amountInEur, float rate)
        {
            float amountInRon = amountInEur * rate;
            destination.Deposit(amountInRon);
            Withdraw(amountInRon);
        }

        

        public void TransferFundsFromAmount_version2(Account destination, float amountInEur, ICurrencyConvertor convertor) // trebuie sa folosim interfata, deoarece atunci cand testam apelam metoda din clasa
                                                                                                                           //creata de noi (CurrencyConvertorStub), nu cea implementata de programator
                                                                                                                  // Astfel am definit in interfata o metoda implementata identic in cele 2 clase
        {
            float amountInRon = convertor.EurToRon(amountInEur);
            destination.Deposit(amountInRon);
            Withdraw(amountInRon);
        }

        public void TransferFundsFromEurAmount_Version3(Account destination, float amountInEur, ICurrencyConvertor convertor)
        {
            float amountInRon = convertor.EurToRon(amountInEur);
            destination.Deposit(amountInRon);
            Withdraw(amountInRon);
        }

    }

    [Serializable]
    internal class FundsFormatException : Exception
    {
    }

    internal class NotEnoughFundsException : Exception
    { }
}
