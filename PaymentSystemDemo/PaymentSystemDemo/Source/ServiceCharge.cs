namespace PaymentSystemDemo.Source
{
    public class ServiceCharge
    {
        public string Date { get; set; }

        public double Amount { get; set; }

        public ServiceCharge()
        {

        }
        public ServiceCharge(string date, double amount)
        {
            Date = date;
            Amount = amount;
        }
    }
}