using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PaymentSystemDemo.Source.PaymentClassification;
using PaymentSystemDemo.Source.PaymentSchedule;

namespace PaymentSystemDemo.Source.AddEmployeeTransaction
{
    class AddHourlyEmployeeTransaction:AddEmployeeTransaction
    {
        public AddHourlyEmployeeTransaction(string empId, string address, string name) : base(empId, address, name)
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
