using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Instamojo.NET.Models
{
    public static class Endpoints
    {
        public static string baseURL = "https://www.instamojo.com/api/1.1/";

        public static string paymentRequests = "payment-requests/";

        public static string refunds = "refunds/";

        public static string paymentRequest(string id)
        {
            return paymentRequests + id + "/";
        }

        public static string payment(string paymentRequestId, string paymentId)
        {
            return paymentRequests + paymentRequestId + "/" + paymentId + "/";
        }

        public static string refund(string id)
        {
            return refunds + id + "/";
        }
    }
}
