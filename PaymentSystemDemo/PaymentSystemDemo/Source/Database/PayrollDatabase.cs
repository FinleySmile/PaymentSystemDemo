using System.Collections.Generic;

namespace PaymentSystemDemo.Source.Database
{
    class PayrollDatabase
    {
        public static Dictionary<int, Employee> EmployeeDict = new Dictionary<int, Employee>();
        public static Dictionary<int, Employee> MemberDict = new Dictionary<int, Employee>(); 
        public static Employee GetEmployee(int empId)
        {
            Employee emp;
            if (EmployeeDict.TryGetValue(empId, out emp))
            {
                return EmployeeDict[empId];    
            }
            return null;
        }

        public static void AddEmployee(Employee emp)
        {
            EmployeeDict[emp.EmpId] = emp;
        }

        public static void DeleteEmployee(int empId)
        {
            EmployeeDict.Remove(empId);
        }

        public static void Clear()
        {
            EmployeeDict.Clear();
        }

        public static Employee GetUnionMember(int memberId)
        {
            Employee emp;
            if (MemberDict.TryGetValue(memberId, out emp))
            {
                return MemberDict[memberId];
            }
            return null;
        }

        public static void AddUnionMember(int memberId, Employee emp)
        {
            MemberDict.Add(memberId, emp);
        }

        public static void DeleteMember(int memberId)
        {
            MemberDict.Remove(memberId);
        }
    }
}
