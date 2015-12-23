using PaymentSystemDemo.Source.PaymentMethod;

namespace PaymentSystemDemo.Source.ChangeEmpAttribute
{
    public class ChangeDirectTransaction : ChangeMethodTransaction
    {
        public string Account { get; set; }
        public BankType BankType { get; set; }

        public ChangeDirectTransaction(int empId, string account, BankType bankType)
            : base(empId)
        {
            Account = account;
            BankType = bankType;
        }

        public override IPaymentMethod GetMethod()
        {
            return new BankCardPaymentMethod() { Account = Account, BankType = BankType };
        }
    }
}