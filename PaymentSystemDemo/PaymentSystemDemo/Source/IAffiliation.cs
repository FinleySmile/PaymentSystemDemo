using PaymentSystemDemo.UnitTest;

namespace PaymentSystemDemo.Source
{
    public interface IAffiliation
    {
        ServiceCharge GetServiceCharge(string date);
        void AddServiceCharge(ServiceCharge sc);
    }
}