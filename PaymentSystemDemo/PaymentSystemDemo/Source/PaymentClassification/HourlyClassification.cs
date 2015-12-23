using System;
using System.Collections.Generic;

namespace PaymentSystemDemo.Source.PaymentClassification
{
    /// <summary>
    /// 小时工（保存每小时的报酬，以及TimeCard列表）
    /// </summary>
    class HourlyClassification:PaymentClasscification
    {
        private readonly Dictionary<string,TimeCard> _timeCards;

        public double Rate { get; set; }

        public HourlyClassification(double rate)
        {
            Rate = rate;
            _timeCards = new Dictionary<string, TimeCard>();
        }

        public override bool IsPayDay()
        {
            throw new NotImplementedException();
        }

        public override double GetSalary()
        {
            throw new NotImplementedException();
        }

        public TimeCard this[string workDate]
        {
            get
            {
                TimeCard timeCard;
                if (_timeCards.TryGetValue(workDate, out timeCard))
                {
                    return _timeCards[workDate];
                }
                return null;
            }
            set { _timeCards[value.Date] = value; }
        }
    }
}
