using PaymentSystemDemo.Source.PaymentMethod;

namespace PaymentSystemDemo.Source.ChangeEmpAttribute
{
    public abstract class ChangeMethodTransaction : ChangeEmployeeTransaction
    {
        public ChangeMethodTransaction(int empId) : base(empId)
        {
        }

        public abstract IPaymentMethod GetMethod();
        public override void Change(Employee emp)
        {
            emp.PaymentMethod = GetMethod();
        }
    }
}