using PaymentSystemDemo.Source.PaymentMethod;

namespace PaymentSystemDemo.Source.ChangeEmpAttribute
{
    public class ChangeHoldTransaction : ChangeMethodTransaction
    {
        public string Address { get; set; }

        public ChangeHoldTransaction(int empId, string address)
            : base(empId)
        {
            Address = address;
        }

        public override IPaymentMethod GetMethod()
        {
            return new HoldPaymentMethod() { Address = Address };
        }
    }
}