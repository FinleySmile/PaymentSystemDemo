using NUnit.Framework;
using PaymentSystemDemo.Source;
using PaymentSystemDemo.Source.AddEmployeeTransaction;
using PaymentSystemDemo.Source.Database;
using PaymentSystemDemo.Source.PaymentClassification;
using PaymentSystemDemo.Source.PaymentMethod;
using PaymentSystemDemo.Source.PaymentSchedule;

namespace PaymentSystemDemo.UnitTest
{
    [TestFixture]
    class AddHourlyEmployeeTransactionTest
    {
        [Test]
        public void TestAddHourlyEmployeeTrasaction()
        {
            int empId = 1102;
            var salariedEmployeeTransaction = new AddHourlyEmployeeTransaction(empId,"Beijing","Jack",10);
            salariedEmployeeTransaction.Execute();

            Employee emp = PayrollDatabase.GetEmployee(empId);

            Assert.AreEqual(empId,emp.EmpId);

            HourlyClassification hc = emp.PaymentClasscification as HourlyClassification;
            Assert.NotNull(hc);

            //int salary = sc.GetSalary();
            //Assert.AreEqual(salary,1000);


            WeeklySchudule ws = emp.PaymentSchedule as WeeklySchudule;
            Assert.NotNull(ws);

            HoldPaymentMethod pm = emp.PaymentMethod as HoldPaymentMethod;
            Assert.NotNull(pm);
        }
    }
}
