using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using PaymentSystemDemo.Source;
using PaymentSystemDemo.Source.AddEmployeeTransaction;
using PaymentSystemDemo.Source.ChangeEmpAttribute;
using PaymentSystemDemo.Source.Database;
using PaymentSystemDemo.Source.PaymentClassification;
using PaymentSystemDemo.Source.PaymentSchedule;
using PaymentSystemDemo.UnitTest;

namespace PaymentSystemDemo.UnitTest
{
    [TestFixture]
    class ChangeClassificationTransactionTest
    {
        [Test]
        public void TestChangeSalariedTrasnsaction()
        {
            int empId = 2;

            var transaction = new AddHourlyEmployeeTransaction(empId, "Beijing", "Jack", 10.2);
            transaction.Execute();


            double salaray = 1000;
            var cct = new ChangeSalariedTransaction(empId, salaray);
            cct.Execute();

            Employee emp = PayrollDatabase.GetEmployee(empId);
            Assert.IsNotNull(emp);
            Assert.IsNotNull(emp.PaymentSchedule as MonthlySchedule);
            var salariedClassification = emp.PaymentClasscification as SalariedClassification;
            Assert.IsNotNull(salariedClassification);
            Assert.AreEqual(salariedClassification.Salary,salaray);
        }

        [Test]
        public void TestChangeHourlyTrasnsaction()
        {
            int empId = 3;

            var transaction = new AddSalariedEmployeeTransaction(empId, "Beijing", "Jack", 1000);
            transaction.Execute();


            double rate = 12.5;
            var cht = new ChangeHourlyTransaction(empId, rate);
            cht.Execute();

            Employee emp = PayrollDatabase.GetEmployee(empId);
            Assert.IsNotNull(emp);
            Assert.IsNotNull(emp.PaymentSchedule as WeeklySchudule);
            var hourlyClassification = emp.PaymentClasscification as HourlyClassification;
            Assert.IsNotNull(hourlyClassification);
            Assert.AreEqual(hourlyClassification.Rate, rate);
        }

        [Test]
        public void TestChangeCommissionedTrasnsaction()
        {
            int empId = 3;

            var transaction = new AddHourlyEmployeeTransaction(empId, "Beijing", "Jack", 10.2);
            transaction.Execute();

            double baseSalary = 1000;
            double rate = 12.5;
            var cct = new ChangeCommissionedTransaction(empId,baseSalary, rate);
            cct.Execute();

            Employee emp = PayrollDatabase.GetEmployee(empId);
            Assert.IsNotNull(emp);
            Assert.IsNotNull(emp.PaymentSchedule as BiweeklySchedule);
            var commissionedClassification = emp.PaymentClasscification as CommissionedClassification;
            Assert.IsNotNull(commissionedClassification);
            Assert.AreEqual(commissionedClassification.Rate, rate);
            Assert.AreEqual(commissionedClassification.BaseSalary, baseSalary);
        }
    }
}
