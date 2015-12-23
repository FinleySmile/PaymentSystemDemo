using PaymentSystemDemo.Source.PaymentClassification;
using PaymentSystemDemo.Source.PaymentSchedule;

namespace PaymentSystemDemo.Source.AddEmployeeTransaction
{
    class AddCommissionedEmployeeTransaction : AddEmployeeTransaction
    {
        private double _baseSalary;
        private double _rate;
        public AddCommissionedEmployeeTransaction(int empId, string address, string name,double baseSalary,double rate) : base(empId, address, name)
        {
            _baseSalary = baseSalary;
            _rate = rate;
        }

        public override PaymentClasscification GetClasscification()
        {
           return  new CommissionedClassification(_baseSalary,_rate);
        }

        public override PaymenetSchedule GetSchedule()
        {
            return new BiweeklySchedule();
        }
    }
}