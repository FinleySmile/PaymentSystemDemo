using PaymentSystemDemo.Source.Database;

namespace PaymentSystemDemo.Source
{
    class DeleteEmployeeTransaction:ITransaction
    {
        private readonly int _empId;
        public DeleteEmployeeTransaction(int empId)
        {
            _empId = empId;
        }

        public void Execute()
        {
            PayrollDatabase.DeleteEmployee(_empId);
        }

        
    }
}
