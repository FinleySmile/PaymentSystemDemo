namespace PaymentSystemDemo.Source.PaymentClassification
{
    /// <summary>
    /// ֧��ʱ��(��н Сʱ�� �������)
    /// </summary>
    public abstract class PaymentClasscification
    {
        public abstract  bool IsPayDay();
        public abstract int GetSalary();
    }
}