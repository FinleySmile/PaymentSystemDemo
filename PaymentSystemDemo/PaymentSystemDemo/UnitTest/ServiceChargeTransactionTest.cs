using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using PaymentSystemDemo.Source;
using PaymentSystemDemo.Source.AddEmployeeTransaction;
using PaymentSystemDemo.Source.Database;
using PaymentSystemDemo.UnitTest;

namespace PaymentSystemDemo.UnitTest
{
    [TestFixture]
    class ServiceChargeTransactionTest
    {
        [Test]
        public void TestAddServiceCharge()
        {
            int empId = 3;
            int memberId = 30;

            var transaction = new AddHourlyEmployeeTransaction(empId, "Beijing", "Jack", 10.2);
            transaction.Execute();

            UnionAffiliation af = new UnionAffiliation(memberId, 10);
            Employee emp = PayrollDatabase.GetEmployee(empId);
            emp.Affiliation = af;
            PayrollDatabase.AddUnionMember(memberId, emp);
            ServiceChargeTransaction sct = new ServiceChargeTransaction(memberId, "20150101", 12.95);
            sct.Execute();
            ServiceCharge sc = af.GetServiceCharge("20150101");
            Assert.IsNotNull(sc);
            Assert.AreEqual(12.95, sc.Amount);

        }
    }
}
