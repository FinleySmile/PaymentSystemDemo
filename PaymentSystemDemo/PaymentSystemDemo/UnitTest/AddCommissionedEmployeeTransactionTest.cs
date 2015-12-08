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
    class AddCommissionedEmployeeTransactionTest
    {
        [Test]
        public void TestAddCommissionedEmployeeTrasaction()
        {
            int empId = 1301;
            var salariedEmployeeTransaction = new AddCommissionedEmployeeTransaction(empId, "Beijing", "Jack", 1000,0.1);
            salariedEmployeeTransaction.Execute();

            Employee emp = PayrollDatabase.GetEmployee(empId);

            Assert.AreEqual(empId,emp.EmpId);

            CommissionedClassification cc = emp.PaymentClasscification as CommissionedClassification;
            Assert.NotNull(cc);

            BiweeklySchedule bs = emp.PaymentSchedule as BiweeklySchedule;
            Assert.NotNull(bs);

            HoldPaymentMethod pm = emp.PaymentMethod as HoldPaymentMethod;
            Assert.NotNull(pm);
        }
    }
}
