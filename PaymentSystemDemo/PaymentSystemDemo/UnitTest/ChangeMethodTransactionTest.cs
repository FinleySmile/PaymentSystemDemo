using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using PaymentSystemDemo.Source;
using PaymentSystemDemo.Source.AddEmployeeTransaction;
using PaymentSystemDemo.Source.ChangeEmpAttribute;
using PaymentSystemDemo.Source.Database;
using PaymentSystemDemo.Source.PaymentMethod;
using PaymentSystemDemo.UnitTest;

namespace PaymentSystemDemo.UnitTest
{
    [TestFixture]
    internal class ChangeMethodTransactionTest
    {
        [Test]
        public void TestChangeNameTransaction()
        {
            int empId = 2;

            var transaction = new AddHourlyEmployeeTransaction(empId, "Beijing", "Jack", 10.2);
            transaction.Execute();
            string newName = "Bob";
            var changeNameTransaction = new ChangeNameTransaction(empId, newName);
            changeNameTransaction.Execute();
            Employee emp = PayrollDatabase.GetEmployee(empId);
            Assert.AreEqual(newName, emp.Name);
        }

        [Test]
        public void TestChangeAddressTransaction()
        {
            int empId = 2;
            var transaction = new AddHourlyEmployeeTransaction(empId, "Beijing", "Jack", 10.2);
            transaction.Execute();

            string newAddress = "Shanghai";
            var changeAddressTransaction = new ChangeAddressTransaction(empId, newAddress);
            changeAddressTransaction.Execute();
            Employee emp = PayrollDatabase.GetEmployee(empId);
            Assert.AreEqual(newAddress, emp.Address);
        }

        [Test]
        public void TestChangeDirectMehtodTransaction()
        {
            int empId = 2;

            var transaction = new AddHourlyEmployeeTransaction(empId, "Beijing", "Jack", 10.2);
            transaction.Execute();

            string account = "123456";
            BankType bankType = BankType.ICBC;
            var changeDirectTransaction = new ChangeDirectTransaction(empId, account, bankType);
            changeDirectTransaction.Execute();

            Employee emp = PayrollDatabase.GetEmployee(empId);
            var bankCardPaymentMethod = emp.PaymentMethod as BankCardPaymentMethod;
            Assert.IsNotNull(bankCardPaymentMethod);
            Assert.AreEqual(bankCardPaymentMethod.BankType, bankType);
            Assert.AreEqual(bankCardPaymentMethod.Account, account);
        }

        [Test]
        public void TestChangeMailMehtodTransaction()
        {
            int empId = 2;

            var transaction = new AddHourlyEmployeeTransaction(empId, "Beijing", "Jack", 10.2);
            transaction.Execute();

            string address = "Beijing";
            var changeMailTransaction = new ChangeMailTransaction(empId, address);
            changeMailTransaction.Execute();

            Employee emp = PayrollDatabase.GetEmployee(empId);
            var mailPaymentMethod = emp.PaymentMethod as MailPaymentMethod;
            Assert.IsNotNull(mailPaymentMethod);
            Assert.AreEqual(mailPaymentMethod.Address, address);
        }


        [Test]
        public void TestChangeHoldMehtodTransaction()
        {
            int empId = 2;

            var transaction = new AddHourlyEmployeeTransaction(empId, "Beijing", "Jack", 10.2);
            transaction.Execute();

            string address = "Beijing";
            var changeHoldTransaction = new ChangeHoldTransaction(empId, address);
            changeHoldTransaction.Execute();

            Employee emp = PayrollDatabase.GetEmployee(empId);
            var holdPaymentMethod = emp.PaymentMethod as HoldPaymentMethod;
            Assert.IsNotNull(holdPaymentMethod);


        }
    }
}
