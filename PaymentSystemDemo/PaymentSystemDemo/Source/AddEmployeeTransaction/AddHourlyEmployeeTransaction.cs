using PaymentSystemDemo.Source.PaymentClassification;
using PaymentSystemDemo.Source.PaymentSchedule;

namespace PaymentSystemDemo.Source.AddEmployeeTransaction
{
    class AddHourlyEmployeeTransaction : AddEmployeeTransaction
    {
        public double Rate { get; set; }

        public AddHourlyEmployeeTransaction(int empId, string address, string name, double rate)
            : base(empId, address, name)
        {
            Rate = rate;
        }

        public override PaymentClasscification GetClasscification()
        {
            return new HourlyClassification();
        }

        public override PaymenetSchedule GetSchedule()
        {
            return new WeeklySchudule();
        }
    }
}
