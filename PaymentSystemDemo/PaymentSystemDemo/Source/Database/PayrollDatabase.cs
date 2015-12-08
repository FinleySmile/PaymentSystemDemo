using System.Collections.Generic;

namespace PaymentSystemDemo.Source.Database
{
    class PayrollDatabase
    {
        public static Dictionary<int, Employee> EmployeeDict = new Dictionary<int, Employee>(); 
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

    }
}
