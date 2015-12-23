using System;

namespace PaymentSystemDemo.Source.PaymentClassification
{
    public class SalariedClassification:PaymentClasscification
    {
        public double Salary { get;private  set; }

        public SalariedClassification(double salary=0)
        {
            Salary = salary;
        }

        public override bool IsPayDay()
        {
            throw new NotImplementedException();
        }

        public override double GetSalary()
        {
            return Salary;
        }
    }
}