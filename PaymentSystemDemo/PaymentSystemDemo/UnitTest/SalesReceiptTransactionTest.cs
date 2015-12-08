using NUnit.Framework;
using PaymentSystemDemo.Source;
using PaymentSystemDemo.Source.AddEmployeeTransaction;
using PaymentSystemDemo.Source.Database;
using PaymentSystemDemo.Source.PaymentClassification;

namespace PaymentSystemDemo.UnitTest
{
    [TestFixture]
    class SalesReceiptTransactionTest
    {
        [Test]
        public void TestSalesReceiptTransaction()
        {
            int empId = 1102;
            var commissionedEmployeeTransaction = new AddCommissionedEmployeeTransaction(empId, "Beijing", "Jack", 1000,0.1);
            commissionedEmployeeTransaction.Execute();

            string salesDate = "2015-01-01";
            double amount = 1000;

            var timeCardTransation = new SalesReceiptTransaction(empId, salesDate, amount);
            timeCardTransation.Execute();

            Employee emp = PayrollDatabase.GetEmployee(empId);
            Assert.NotNull(emp);

            var cc = emp.PaymentClasscification as CommissionedClassification;
            Assert.NotNull(cc);
            SalesReceipt salesReceipt = cc[salesDate];
            Assert.NotNull(salesReceipt);
            Assert.AreEqual(salesReceipt.Amount, amount);

        }
    }
}
