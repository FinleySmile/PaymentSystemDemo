using System.Collections.Generic;

namespace PaymentSystemDemo.Source.Database
{
    class PayrollDatabase
    {
        public static Dictionary<string, Employee> EmployeeDict = new Dictionary<string, Employee>(); 
        public static Employee GetEmployee(string empId)
        {
            return EmployeeDict[empId];
        }

        public static void SetEmployee(Employee emp)
        {
            EmployeeDict[emp.EmpId] = emp;
        }

    }
}
