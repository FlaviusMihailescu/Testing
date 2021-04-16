using System;
using System.Collections.Generic;
using System.Text;

namespace bank
{
    public class CurrencyConvertor : ICurrencyConvertor
    {
        float rateEurRon;

        public CurrencyConvertor()
        {
            rateEurRon = GetExternalEurToRon();
        }
        float GetExternalEurToRon()
        {
            float _rateEurRon;
            //....

            _rateEurRon = 4.4F;
            return _rateEurRon;
        }

        public float EurToRon(float ValueInEur)
        {
            return ValueInEur * rateEurRon;
        }

        public float RonToEur(float ValueInRon)
        {
            return ValueInRon / rateEurRon;
        }
    }
}
