using NUnit.Framework;
using PaymentSystemDemo.Source;
using PaymentSystemDemo.Source.AddEmployeeTransaction;
using PaymentSystemDemo.Source.Database;

namespace PaymentSystemDemo.UnitTest
{
    [TestFixture]
    class DeleteEmployeeTransactionTest
    {
        [Test]
        public void TestDeleteEmployeeTransaction()
        {
            int empId = 1301;
            var salariedEmployeeTransaction = new AddCommissionedEmployeeTransaction(empId, "Beijing", "Jack", 1000, 0.1);
            salariedEmployeeTransaction.Execute();

            Employee emp = PayrollDatabase.GetEmployee(empId);
            Assert.AreEqual(empId, emp.EmpId);

            //delete
            var deleteEmployeeTransaciton = new DeleteEmployeeTransaction(empId);
            deleteEmployeeTransaciton.Execute();

            emp = PayrollDatabase.GetEmployee(empId);
            Assert.Null(emp);

        }
    }
}
