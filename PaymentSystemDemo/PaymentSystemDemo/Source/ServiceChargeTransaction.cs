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
                IAffiliation affiliation = emp.Affiliation;
                UnionAffiliation ua = affiliation as UnionAffiliation;
                if (ua != null)
                {
                    ua.AddServiceCharge(sc);
                }

            }
        }
    }
}