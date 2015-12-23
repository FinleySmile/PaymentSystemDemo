using PaymentSystemDemo.Source.PaymentClassification;
using PaymentSystemDemo.Source.PaymentSchedule;

namespace PaymentSystemDemo.Source.AddEmployeeTransaction
{
    class AddHourlyEmployeeTransaction : AddEmployeeTransaction
    {
        private double _rate; 

        public AddHourlyEmployeeTransaction(int empId, string address, string name, double rate)
            : base(empId, address, name)
        {
            _rate = rate;
        }

        public override PaymentClasscification GetClasscification()
        {
            return new HourlyClassification(_rate);
        }

        public override PaymenetSchedule GetSchedule()
        {
            return new WeeklySchudule();
        }
    }
}
