namespace PaymentSystemDemo.Source.PaymentClassification
{
     /// <summary>
     /// 销售支付（底薪+提成）
     /// </summary>
    class CommissionedClassification:PaymentClasscification
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
