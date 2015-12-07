namespace PaymentSystemDemo.Source.PaymentClassification
{
    public class SalariedClassification:PaymentClasscification
    {
        public int Salary { get; set; }

        public SalariedClassification(int salary=0)
        {
            Salary = salary;
        }

        public override bool IsPayDay()
        {
            throw new System.NotImplementedException();
        }

        public override int GetSalary()
        {
            return Salary;
        }

    }
}