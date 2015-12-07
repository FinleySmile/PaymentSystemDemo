namespace PaymentSystemDemo.Source.PaymentClassification
{
    /// <summary>
    /// 小时工支付
    /// </summary>
    class HourlyClassification:PaymentClasscification
    {
        public override bool IsPayDay()
        {
            throw new System.NotImplementedException();
        }

        public override int GetSalary()
        {
            throw new System.NotImplementedException();
        }
    }
}
