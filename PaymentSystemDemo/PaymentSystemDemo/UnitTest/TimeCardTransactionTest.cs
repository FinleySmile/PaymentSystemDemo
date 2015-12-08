using NUnit.Framework;
using PaymentSystemDemo.Source;
using PaymentSystemDemo.Source.AddEmployeeTransaction;
using PaymentSystemDemo.Source.Database;
using PaymentSystemDemo.Source.PaymentClassification;

namespace PaymentSystemDemo.UnitTest
{
    [TestFixture]
    class TimeCardTransactionTest
    {
        [Test]
        public void TestTimeCardTransaction()
        {
            int empId = 1102;
            var hourlyEmployeeTransaction = new AddHourlyEmployeeTransaction(empId, "Beijing", "Jack", 10);
            hourlyEmployeeTransaction.Execute();

            string workDate = "2015-01-01";
            double workHours = 8;
            var timeCardTransation = new TimeCardTransaction(empId, workDate, workHours);
            timeCardTransation.Execute();

            Employee emp = PayrollDatabase.GetEmployee(empId);
            Assert.NotNull(emp);

            HourlyClassification hc = emp.PaymentClasscification as HourlyClassification;
            Assert.NotNull(hc);
            TimeCard timeCard = hc[workDate];
            Assert.NotNull(timeCard);
            Assert.AreEqual(timeCard.Hours,workHours);

        }
    }

    public class TimeCardTransaction:ITransaction
    {
        private int _empId ;
        private string _workDate;
        private double _workHours;
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
