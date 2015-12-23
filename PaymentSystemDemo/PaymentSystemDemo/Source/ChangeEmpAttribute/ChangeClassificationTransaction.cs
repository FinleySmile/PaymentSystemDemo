using System.Runtime.InteropServices;
using PaymentSystemDemo.Source.Database;
using PaymentSystemDemo.Source.PaymentClassification;
using PaymentSystemDemo.Source.PaymentSchedule;

namespace PaymentSystemDemo.Source.ChangeEmpAttribute
{
    public abstract class ChangeClassificationTransaction : ChangeEmployeeTransaction
    {
        protected ChangeClassificationTransaction(int empId)
            : base(empId)
        {
        }

        public abstract PaymentClassification.PaymentClasscification GetClassification();
        public abstract PaymentSchedule.PaymenetSchedule GetSchedule();

        public override void Change(Employee emp)
        {
            emp.PaymentClasscification = GetClassification();
            emp.PaymentSchedule = GetSchedule();
        }
    }

    public class ChangeSalariedTransaction : ChangeClassificationTransaction
    {
        private double _salary;

        public ChangeSalariedTransaction(int empId, double salary)
            : base(empId)
        {
            _salary = salary;
        }

        public override PaymentClasscification GetClassification()
        {
            return new SalariedClassification(_salary);
        }

        public override PaymenetSchedule GetSchedule()
        {
            return new MonthlySchedule();
        }
    }

    public class ChangeHourlyTransaction : ChangeClassificationTransaction
    {
        private double _rate;

        public ChangeHourlyTransaction(int empId, double rate)
            : base(empId)
        {
            _rate = rate;
        }

        public override PaymentClasscification GetClassification()
        {
            return new HourlyClassification(_rate);
        }

        public override PaymenetSchedule GetSchedule()
        {
            return new WeeklySchudule();
        }
    }

    public class ChangeCommissionedTransaction : ChangeClassificationTransaction
    {
        private double _rate;
        private double _baseSalary;
        public ChangeCommissionedTransaction(int empId, double baseSalary, double rate)
            : base(empId)
        {
            _baseSalary = baseSalary;
            _rate = rate;
        }

        public override PaymentClasscification GetClassification()
        {
            return new CommissionedClassification(_baseSalary, _rate);
        }

        public override PaymenetSchedule GetSchedule()
        {
            return new BiweeklySchedule();
        }
    }

}