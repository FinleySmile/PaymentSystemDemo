using System.Collections.Generic;
using PaymentSystemDemo.Source.Database;
using PaymentSystemDemo.UnitTest;

namespace PaymentSystemDemo.Source
{
    public class ServiceChargeTransaction : ITransaction
    {
        private readonly int _memberId;
        private readonly string _date;
        private readonly double _amount;
        public ServiceChargeTransaction(int memberId, string date, double amount)
        {
            _memberId = memberId;
            _date = date;
            _amount = amount;
        }

        public void Execute()
        {
            ServiceCharge sc = new ServiceCharge(_date, _amount);
            Employee emp = PayrollDatabase.GetUnionMember(_memberId);
            if (emp != null)
            {
                List<IAffiliation> affiliations = emp.Affiliations;
                foreach (var a in affiliations)
                {
                    UnionAffiliation ua = a as UnionAffiliation;
                    if (ua != null)
                    {
                        ua.AddServiceCharge(sc);
                    }
                }
            }
        }
    }
}