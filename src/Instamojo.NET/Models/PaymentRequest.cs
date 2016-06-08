using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Instamojo.NET.Models
{
    public class PaymentRequest
    {
        public string id { get; set; }
        public string phone { get; set; }
        public string email { get; set; }
        public string buyer_name { get; set; }
        public string amount { get; set; }
        public string purpose { get; set; }
        public string status { get; set; }
        public bool send_sms { get; set; }
        public bool send_email { get; set; }
        public string sms_status { get; set; }
        public string email_status { get; set; }
        public string shorturl { get; set; }
        public string longurl { get; set; }
        public string redirect_url { get; set; }
        public string webhook { get; set; }
        public string created_at { get; set; }
        public string modified_at { get; set; }
        public bool allow_repeated_payments { get; set; }
        [JsonConverter(typeof(StringEnumConverter))]
        public PartnerFeeType partner_fee_type { get; set; }
        public string partner_fee { get; set; }
    }

    class PaymentRequestResponse
    {
        public bool success { get; set; }
        public PaymentRequest payment_request { get; set; }
    }

    class PaymentRequestsResponse
    {
        public string success { get; set; }

        public List<PaymentRequest> payment_requests { get; set; }
    }

    public enum PartnerFeeType
    {
        @fixed,
        percentage
    }
}
