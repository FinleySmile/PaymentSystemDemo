namespace PaymentSystemDemo.Source
{
    internal class SalesReceipt
    {
        public string Date { get; private set; }
        public double Amount { get; private set; }

        public SalesReceipt(string date, double amount)
        {
            Date = date;
            Amount = amount;
        }
    }
}