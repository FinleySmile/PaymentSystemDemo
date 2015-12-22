namespace PaymentSystemDemo.Source.ChangeEmpAttribute
{
    public class ChangeNameTransaction : ChangeEmployeeTransaction
    {
        private string _name;
        public ChangeNameTransaction(int empId, string name):base(empId)
        {
            _name = name;
        }
        public override void Change(Employee emp)
        {
            emp.Name = _name;

        }
    }
}