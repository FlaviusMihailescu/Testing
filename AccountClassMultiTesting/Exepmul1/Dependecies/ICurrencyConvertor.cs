namespace bank
{
    public interface ICurrencyConvertor
    {
        float EurToRon(float amountInEur);
        float RonToEur(float amountInEur);
    }


}