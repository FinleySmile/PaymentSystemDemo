using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
    class AddSalariedEmployeeTransactionTest
    {
        [Test]
        public void TestAddSalariedEmployeeTrasaction()
        {
            string empId = "1101";
            var salariedEmployeeTransaction = new AddSalariedEmployeeTransaction(empId,"Beijing","Jack",1000);
            salariedEmployeeTransaction.Execute();

            Employee emp = PayrollDatabase.GetEmployee(empId);

            Assert.AreEqual(empId,emp.EmpId);

            SalariedClassification sc = emp.PaymentClasscification as SalariedClassification;
            Assert.NotNull(sc);
            int salary = sc.GetSalary();
            Assert.AreEqual(salary,1000);


            MonthlySchedule ms = emp.PaymentSchedule as MonthlySchedule;
            Assert.NotNull(ms);

            HoldPaymentMethod pm = emp.PaymentMethod as HoldPaymentMethod;
            Assert.NotNull(pm);
        }
    }
}
