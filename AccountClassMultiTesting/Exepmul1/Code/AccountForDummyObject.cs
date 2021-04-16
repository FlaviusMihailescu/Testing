using bank.TestDoubles;
using System;
using System.Collections.Generic;
using System.Text;

namespace bank.Code
{
    public class AccountForDummyObject : Account
    {
        private IClient clientDetails;

        public AccountForDummyObject(float _startBalance, IClient _clientDetails)
        {
            this.balance = _startBalance;
            clientDetails = _clientDetails;
        }

        public string GetFormatedBalance()
        {
            return Balance.ToString("N");
        }
    }
}
