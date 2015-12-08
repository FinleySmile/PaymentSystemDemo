using PaymentSystemDemo.Source.Database;
using PaymentSystemDemo.Source.PaymentClassification;

namespace PaymentSystemDemo.Source
{
    internal class SalesReceiptTransaction:ITransaction
    {
        private readonly int _empId ;
        private readonly string _date;
        private readonly double _amount;

        public SalesReceiptTransaction(int empId, string date, double amount)
        {
            _empId = empId;
            _date = date;
            _amount = amount;
        }

        public void Execute()
        {
            var salesReceipt = new SalesReceipt(_date,_amount);
            Employee emp = PayrollDatabase.GetEmployee(_empId);
            if (emp != null)
            {
                var commissionedClassification = emp.PaymentClasscification as CommissionedClassification;
                if (commissionedClassification != null)
                {
                    commissionedClassification[_date] = salesReceipt;
                }
            }
        }
    }
}