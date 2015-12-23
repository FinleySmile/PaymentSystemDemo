using System;
using System.Collections.Generic;

namespace PaymentSystemDemo.Source.PaymentClassification
{
    /// <summary>
    /// 销售支付（底薪+提成）
    /// </summary>
    class CommissionedClassification : PaymentClasscification
    {
        private Dictionary<string, SalesReceipt> salesReceipts = new Dictionary<string, SalesReceipt>();
        private double _baseSalary;        //底薪
        private double _rate;              //提成

        public double BaseSalary
        {
            get { return _baseSalary; }
            set { _baseSalary = value; }
        }
        public double Rate
        {
            get { return _rate; }
            set { _rate = value; }
        }

        public CommissionedClassification(double baseSalary, double rate)
        {
            _baseSalary = baseSalary;
            _rate = rate;
        }
        public override bool IsPayDay()
        {
            throw new NotImplementedException();
        }

        public override double GetSalary()
        {
            throw new NotImplementedException();
        }

        public SalesReceipt this[string date]
        {
            get
            {
                SalesReceipt timeCard;
                if (salesReceipts.TryGetValue(date, out timeCard))
                {
                    return salesReceipts[date];
                }
                return null;
            }
            set { salesReceipts[value.Date] = value; }
        }
    }
}
