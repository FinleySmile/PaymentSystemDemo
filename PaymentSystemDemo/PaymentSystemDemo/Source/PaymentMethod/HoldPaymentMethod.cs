using System.Diagnostics.Contracts;
using System.Net.Sockets;

namespace PaymentSystemDemo.Source.PaymentMethod
{
    //放在出纳处
    class HoldPaymentMethod:IPaymentMethod
    {
        public string Address { get; set; }
    }
}
