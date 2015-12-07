using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PaymentSystemDemo.Source.PaymentMethod;

namespace PaymentSystemDemo.Source
{
    /// <summary>
    /// Employee实体类
    /// </summary>
    class Employee
    {
        public string EmpId { get; set; }
        public string Address { get; set; }
        public string Name { get; set; }

        public Employee(string empId, string address, string name)
        {
            EmpId = empId;
            Address = address;
            Name = name;
        }

       

        public PaymentClassification.PaymentClasscification PaymentClasscification { get; set; }

        public PaymentSchedule.PaymenetSchedule PaymentSchedule { get; set; }

        public PaymentMethod.IPaymentMethod PaymentMethod { get; set; }
    }
}
