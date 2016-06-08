using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Instamojo.NET.Exceptions
{
    class BadRequestException : System.Exception
    {
        public BadRequestException(string message) : base(message) { }
    }

    class PaymentRequestNotFoundException : System.Exception
    {
        public PaymentRequestNotFoundException(string id) : base(String.Format("Payment request with id : {0} was not found.", id)) { }
    }

    class PaymentNotFoundException : System.Exception
    {
        public PaymentNotFoundException(string id,string payment_id) : base(String.Format("Payment with id : {0} and payment_id : {1} was not found.", id, payment_id)) { }
    }

    class RefundNotFoundException : System.Exception
    {
        public RefundNotFoundException(string id) : base(String.Format("Refund with id : {0} was not found.", id)) { }
    }
}
