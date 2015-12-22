using System.Collections.Generic;

namespace PaymentSystemDemo.Source
{
    public class UnionAffiliation : IAffiliation
    {
        private int _memberId;
        private double _rate;
        private List<ServiceCharge> _serviceCharges;
        public UnionAffiliation(int memberId, double rate)
        {
            _memberId = memberId;
            _rate = rate;
            _serviceCharges = new List<ServiceCharge>();
        }

        public ServiceCharge GetServiceCharge(string date)
        {
            foreach (var sc in _serviceCharges)
            {
                if (sc.Date.Equals(date))
                {
                    return sc;
                }
            }
            return null;
        }

        public void AddServiceCharge(ServiceCharge sc)
        {
            _serviceCharges.Add(sc);
        }
    }
}