using PaymentSystemDemo.Source.PaymentMethod;

namespace PaymentSystemDemo.Source.ChangeEmpAttribute
{
    public class ChangeMailTransaction : ChangeMethodTransaction
    {
        public string Address { get; set; }

        public ChangeMailTransaction(int empId, string address)
            : base(empId)
        {
            Address = address;
        }

        public override IPaymentMethod GetMethod()
        {
            return new MailPaymentMethod() { Address = Address };
        }
    }
}