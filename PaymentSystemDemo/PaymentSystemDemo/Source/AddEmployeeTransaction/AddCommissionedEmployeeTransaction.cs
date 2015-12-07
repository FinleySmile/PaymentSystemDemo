using System;
using PaymentSystemDemo.Source.PaymentClassification;
using PaymentSystemDemo.Source.PaymentSchedule;

namespace PaymentSystemDemo.Source.AddEmployeeTransaction
{
    class AddCommissionedEmployeeTransaction : AddEmployeeTransaction 
    {
        public AddCommissionedEmployeeTransaction(string empId, string address, string name) : base(empId, address, name)
        {
        }

        public override PaymentClasscification GetClasscification()
        {
            throw new NotImplementedException();
        }

        public override PaymenetSchedule GetSchedule()
        {
            throw new NotImplementedException();
        }
    }
}