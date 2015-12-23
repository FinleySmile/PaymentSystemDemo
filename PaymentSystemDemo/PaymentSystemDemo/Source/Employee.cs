using System.Collections.Generic;
using PaymentSystemDemo.Source.PaymentClassification;
using PaymentSystemDemo.Source.PaymentMethod;
using PaymentSystemDemo.Source.PaymentSchedule;
using PaymentSystemDemo.UnitTest;

namespace PaymentSystemDemo.Source
{
    /// <summary>
    /// Employee实体类
    /// </summary>
    public class Employee
    {
        public int EmpId { get; set; }
        public string Address { get; set; }
        public string Name { get; set; }

        public IAffiliation Affiliation { get; set; }

        public Employee(int empId, string address, string name)
        {
            EmpId = empId;
            Address = address;
            Name = name;
        }

        public PaymentClasscification PaymentClasscification { get; set; }

        public PaymenetSchedule PaymentSchedule { get; set; }

        public IPaymentMethod PaymentMethod { get; set; }

    }
}
