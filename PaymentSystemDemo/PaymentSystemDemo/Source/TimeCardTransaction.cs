using PaymentSystemDemo.Source.Database;
using PaymentSystemDemo.Source.PaymentClassification;

namespace PaymentSystemDemo.Source
{
    public class TimeCardTransaction:ITransaction
    {
        private readonly int _empId ;
        private readonly string _workDate;
        private readonly double _workHours;
        public TimeCardTransaction(int empId, string workDate, double workHours )
        {
            _empId = empId;
            _workDate = workDate;
            _workHours = workHours;
            
        }

        public void Execute()
        {
            TimeCard timeCard = new TimeCard(_workDate, _workHours);
            Employee emp = PayrollDatabase.GetEmployee(_empId);
            if (emp != null)
            {
                var hourlyClassification = emp.PaymentClasscification as HourlyClassification;
                if (hourlyClassification != null)
                {
                    hourlyClassification[_workDate] = timeCard;
                }
            }
        }
    }
}