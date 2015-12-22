namespace PaymentSystemDemo.Source.PaymentMethod
{
    public enum BankType
    {
        ConstructionBank,
        ICBC,
        BeijingBank
    }
    class BankCardPaymentMethod : IPaymentMethod
    {
        public string Account;
        public BankType BankType;
    }
}
