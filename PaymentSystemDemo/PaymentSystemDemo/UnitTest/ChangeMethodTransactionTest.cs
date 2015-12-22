using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using PaymentSystemDemo.Source;
using PaymentSystemDemo.Source.AddEmployeeTransaction;
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
            Assert.AreEqual(newName,emp.Name );
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
        public void TestChangeMethodTransaction()
        {
            int empId = 2;
            
            var transaction = new AddHourlyEmployeeTransaction(empId, "Beijing", "Jack", 10.2);
            transaction.Execute();

            string account = "123456";
            BankType bankType = BankType.ICBC;
            var paymentMethod = new BankCardPaymentMethod(){Account = account,BankType = bankType};
            var changeMethodTransaction = new ChangeMethodTransaction(empId,paymentMethod);
            changeMethodTransaction.Execute();

            Employee emp = PayrollDatabase.GetEmployee(empId);
            var bankCardPaymentMethod = emp.PaymentMethod as BankCardPaymentMethod;
            Assert.IsNotNull(bankCardPaymentMethod);
            Assert.AreEqual(bankCardPaymentMethod.BankType,bankType);
            Assert.AreEqual(bankCardPaymentMethod.Account, account);
        }
    }

  
    public abstract class ChangeEmployeeTransaction : ITransaction
    {
        private int _empId;
        protected ChangeEmployeeTransaction(int empId)
        {
            _empId = empId;
        }
        public abstract void Change(Employee emp);
        public void Execute()
        {
            Employee emp = PayrollDatabase.GetEmployee(_empId);
            if (emp != null)
            {
                Change(emp);
            }
        }
    }

    public class ChangeNameTransaction : ChangeEmployeeTransaction
    {
        private string _name;
        public ChangeNameTransaction(int empId, string name):base(empId)
        {
            _name = name;
        }
        public override void Change(Employee emp)
        {
            emp.Name = _name;

        }
    }

    internal class ChangeAddressTransaction : ChangeEmployeeTransaction
    {
        private string _address;
        public ChangeAddressTransaction(int empId, string newAddress)
            : base(empId)
        {
            _address = newAddress;
        }

        public override void Change(Employee emp)
        {
            emp.Address = _address;
        }
    }


    public class ChangeMethodTransaction : ChangeEmployeeTransaction
    {
        private IPaymentMethod _paymentMethod;
        public ChangeMethodTransaction(int empId,IPaymentMethod paymentMethod) : base(empId)
        {
            _paymentMethod = paymentMethod;
        }

        public override void Change(Employee emp)
        {
            emp.PaymentMethod = _paymentMethod;
        }
    }






}
