using PaymentSystemDemo.Source.Database;

namespace PaymentSystemDemo.Source.ChangeEmpAttribute
{
    public abstract class ChangeEmployeeTransaction : ITransaction
    {
        private int _empId;
        protected ChangeEmployeeTransaction(int empId)
        {
            _empId = empId;
        }
        public abstract void Change(Employee emp);
        public void Execute()
        {
            Employee emp = PayrollDatabase.GetEmployee(_empId);
            if (emp != null)
            {
                Change(emp);
            }
        }
    }
}