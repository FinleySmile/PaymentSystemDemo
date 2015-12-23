using System.Collections.Generic;

namespace PaymentSystemDemo.Source
{
    public class UnionAffiliation : IAffiliation
    {
        public double Dues { get; set; }
        public int MemberId { get; set; }
        private List<ServiceCharge> _serviceCharges;

        
        public UnionAffiliation(int memberId, double dues)
        {
            MemberId = memberId;
            Dues = dues;
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