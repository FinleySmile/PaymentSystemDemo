using PaymentSystemDemo.Source;

namespace PaymentSystemDemo.UnitTest
{
    internal class ChangeAddressTransaction : ChangeEmployeeTransaction
    {
        private string _address;
        public ChangeAddressTransaction(int empId, string newAddress)
            : base(empId)
        {
            _address = newAddress;
        }

        public override void Change(Employee emp)
        {
            emp.Address = _address;
        }
    }
}