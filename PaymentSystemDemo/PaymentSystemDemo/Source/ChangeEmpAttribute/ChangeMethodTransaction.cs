using PaymentSystemDemo.Source;
using PaymentSystemDemo.Source.PaymentMethod;

namespace PaymentSystemDemo.UnitTest
{
    public class ChangeMethodTransaction : ChangeEmployeeTransaction
    {
        private IPaymentMethod _paymentMethod;
        public ChangeMethodTransaction(int empId,IPaymentMethod paymentMethod) : base(empId)
        {
            _paymentMethod = paymentMethod;
        }

        public override void Change(Employee emp)
        {
            emp.PaymentMethod = _paymentMethod;
        }
    }
}