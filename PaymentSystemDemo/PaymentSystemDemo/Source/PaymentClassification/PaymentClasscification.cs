namespace PaymentSystemDemo.Source.PaymentClassification
{
    /// <summary>
    /// 支付时间(月薪 小时工 销售提成)
    /// </summary>
    public abstract class PaymentClasscification
    {
        public abstract  bool IsPayDay();
        public abstract int GetSalary();
    }
}