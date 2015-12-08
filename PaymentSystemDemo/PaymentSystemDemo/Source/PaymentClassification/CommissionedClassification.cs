using System;
using System.Collections.Generic;

namespace PaymentSystemDemo.Source.PaymentClassification
{
     /// <summary>
     /// 销售支付（底薪+提成）
     /// </summary>
    class CommissionedClassification:PaymentClasscification
    {
        private Dictionary<string,SalesReceipt> salesReceipts = new Dictionary<string, SalesReceipt>(); 
         public override bool IsPayDay()
         {
             throw new NotImplementedException();
         }

         public override int GetSalary()
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
