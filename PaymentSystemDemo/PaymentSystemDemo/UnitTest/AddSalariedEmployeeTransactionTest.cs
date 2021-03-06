﻿using NUnit.Framework;
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
            int empId = 1101;
            var salariedEmployeeTransaction = new AddSalariedEmployeeTransaction(empId,"Beijing","Jack",1000);
            salariedEmployeeTransaction.Execute();

            Employee emp = PayrollDatabase.GetEmployee(empId);

            Assert.AreEqual(empId,emp.EmpId);

            SalariedClassification sc = emp.PaymentClasscification as SalariedClassification;
            Assert.NotNull(sc);

            MonthlySchedule ms = emp.PaymentSchedule as MonthlySchedule;
            Assert.NotNull(ms);

            HoldPaymentMethod pm = emp.PaymentMethod as HoldPaymentMethod;
            Assert.NotNull(pm);
        }
    }
}
