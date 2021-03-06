﻿using PaymentSystemDemo.Source.Database;
using PaymentSystemDemo.Source.PaymentClassification;
using PaymentSystemDemo.Source.PaymentMethod;
using PaymentSystemDemo.Source.PaymentSchedule;

namespace PaymentSystemDemo.Source.AddEmployeeTransaction
{
    /// <summary>
    /// 添加Employee基类
    /// </summary>
    public abstract class AddEmployeeTransaction : ITransaction
    {
        public int EmpId { get; set; }
        public string Address { get; set; }
        public string Name { get; set; }

        protected AddEmployeeTransaction(int empId, string address, string name)
        {
            EmpId = empId;
            Address = address;
            Name = name;
        }

        public abstract PaymentClasscification GetClasscification();

        public abstract PaymenetSchedule GetSchedule();

        public void Execute()
        {
            Employee emp = new Employee(EmpId, Address, Name);
            PayrollDatabase.AddEmployee(emp);
            PaymentClasscification pc = GetClasscification();

            //emp.SetPaymentMethod();
            emp.PaymentClasscification = pc;
            emp.PaymentMethod = new HoldPaymentMethod();
            emp.PaymentSchedule = GetSchedule();
        }
    }
}
