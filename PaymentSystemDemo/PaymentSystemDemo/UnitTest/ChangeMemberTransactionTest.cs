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
    class ChangeMemberTransactionTest
    {
        [Test]
        public void TestChangeUnionAffiliationTrasnsaction()
        {
            int empId = 2;
            int memberId = 20;
            double dues = 10.23;

            var transaction = new AddHourlyEmployeeTransaction(empId, "Beijing", "Jack", 10.2);
            transaction.Execute();

            var cua = new ChangeUnionAffiliation(empId, memberId, dues);
            cua.Execute();

            Employee emp = PayrollDatabase.GetEmployee(empId);
            Assert.IsNotNull(emp);
            var ua = emp.Affiliation as UnionAffiliation;
            Assert.IsNotNull(ua);
            Assert.AreEqual(ua.MemberId, memberId);
            Assert.AreEqual(ua.Dues, dues);

            Employee e = PayrollDatabase.GetUnionMember(memberId);
            Assert.AreEqual(emp, e);

        }

        [Test]
        public void TestChangeNoAffiliationTrasnsaction()
        {
            int empId = 2;
            int memberId = 20;

            var transaction = new AddHourlyEmployeeTransaction(empId, "Beijing", "Jack", 10.2);
            transaction.Execute();

            var cua = new ChangeNoAffiliation(empId);
            cua.Execute();

            Employee emp = PayrollDatabase.GetEmployee(empId);
            Assert.IsNotNull(emp);
            var na = emp.Affiliation as NoAffiliation;
            Assert.IsNotNull(na);

            Employee e = PayrollDatabase.GetUnionMember(memberId);
            Assert.IsNull(e);

        }


    }
}
