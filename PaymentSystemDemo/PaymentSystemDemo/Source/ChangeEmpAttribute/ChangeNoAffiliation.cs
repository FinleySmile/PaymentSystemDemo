using PaymentSystemDemo.Source.Database;

namespace PaymentSystemDemo.Source.ChangeEmpAttribute
{
    public class ChangeNoAffiliation : ChangeMemberTransaction
    {
        public ChangeNoAffiliation(int empId)
            : base(empId)
        {
        }

        public override void RecordMemberShip(Employee emp)
        {
            UnionAffiliation ua = emp.Affiliation as UnionAffiliation;
            if (ua != null)
            {
                PayrollDatabase.DeleteMember(ua.MemberId);
            }   
        }

        public override IAffiliation GetAffiliation()
        {
            return new NoAffiliation();
        }
    }
}