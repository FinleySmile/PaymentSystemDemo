using PaymentSystemDemo.Source.PaymentMethod;

namespace PaymentSystemDemo.Source.ChangeEmpAttribute
{
    public abstract class ChangeMemberTransaction : ChangeEmployeeTransaction
    {
        protected ChangeMemberTransaction(int empId)
            : base(empId)
        {
        }

        public abstract void RecordMemberShip(Employee emp);
        public abstract IAffiliation GetAffiliation();
        public override void Change(Employee emp)
        {
            emp.Affiliation = GetAffiliation();
            RecordMemberShip(emp);
        }
    }
}