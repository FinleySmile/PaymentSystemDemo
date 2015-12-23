namespace PaymentSystemDemo.Source
{
    public class NoAffiliation : IAffiliation
    {
        public ServiceCharge GetServiceCharge(string date)
        {
            throw new System.NotImplementedException();
        }

        public void AddServiceCharge(ServiceCharge sc)
        {
            throw new System.NotImplementedException();
        }
    }
}