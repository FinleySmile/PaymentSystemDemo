using PaymentSystemDemo.Source.Database;

namespace PaymentSystemDemo.Source.ChangeEmpAttribute
{
    public class ChangeUnionAffiliation : ChangeMemberTransaction
    {
        private readonly int _memberId;
        private readonly double _dues;
        public ChangeUnionAffiliation(int empId, int memberId, double dues)
            : base(empId)
        {
            _memberId = memberId;
            _dues = dues;
        }

        public override void RecordMemberShip(Employee emp)
        {
            PayrollDatabase.AddUnionMember(_memberId, emp);
        }

        public override IAffiliation GetAffiliation()
        {
            return new UnionAffiliation(_memberId, _dues);
        }
    }
}