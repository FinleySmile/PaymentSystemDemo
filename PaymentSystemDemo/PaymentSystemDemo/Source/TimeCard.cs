namespace PaymentSystemDemo.Source
{
    public class TimeCard
    {
        public string Date { private set; get; }
        public double  Hours { private set; get; }
        public TimeCard(string date, double hours)
        {
            Date = date;
            Hours = hours;
        }
    }
}