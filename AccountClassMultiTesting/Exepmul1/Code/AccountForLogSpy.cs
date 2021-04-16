using bank.Dependecies;
using bank.TestDoubles;
using System;
using System.Collections.Generic;
using System.Text;

namespace bank.Code
{
    public class AccountForLogSpy : Account
    {
        private IClient clientDetails;
        public ILogger logger { get; set; }
        public AccountForLogSpy() : base()
        {

        }
        public AccountForLogSpy(float _startBalance, IClient _clientDetails, ILogger _logger)
        {
            this.balance = _startBalance;

            clientDetails = _clientDetails;
            logger = _logger;
        }

        public new void TransferFunds(Account destination, float amount)
        {
            base.TransferFunds(destination, amount);
            logger.Log("Transaction : " + this.Balance + " & " + destination.Balance);
        }
}
}
