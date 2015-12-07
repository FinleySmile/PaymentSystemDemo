﻿using System;
using PaymentSystemDemo.Source.PaymentClassification;
using PaymentSystemDemo.Source.PaymentSchedule;

namespace PaymentSystemDemo.Source.AddEmployeeTransaction
{
    /// <summary>
    /// 添加月薪支付的员工
    /// </summary>
    class AddSalariedEmployeeTransaction:AddEmployeeTransaction
    {
        public int Salary { get; set; }

        public AddSalariedEmployeeTransaction(string empId, string address, string name,int salary) : base(empId, address, name)
        {
            Salary = salary;
        }

        public override PaymentClasscification GetClasscification()
        {
            return new SalariedClassification(Salary);
        }

        public override PaymenetSchedule GetSchedule()
        {
            return new MonthlySchedule();
        }
    }
}
