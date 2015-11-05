using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Instamojo.NET.Models
{
    // Payment Request Object
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
    }

    public class PaymentRequestResponse
    {
        public bool success { get; set; }
        public PaymentRequest payment_request { get; set; }
    }

    public class PaymentRequestsResponse
    {
        public bool success { get; set; }
        public List<PaymentRequest> payment_requests { get; set; }
    }

    public class Webhook
    {
        public string amount { get; set; }
        public string buyer { get; set; }
        public string buyer_name { get; set; }
        public string buyer_phone { get; set; }
        public string currency { get; set; }
        public string fees { get; set; }
        public string longurl { get; set; }
        public string mac { get; set; }
        public string payment_id { get; set; }
        public string payment_request_id { get; set; }
        public string purpose { get; set; }
        public string shorturl { get; set; }
        public string status { get; set; }
    }

    public class Payment
    {
        public string payment_id { get; set; }
        public int quantity { get; set; }
        public string status { get; set; }
        public object link_slug { get; set; }
        public object link_title { get; set; }
        public string buyer_name { get; set; }
        public string buyer_phone { get; set; }
        public string buyer_email { get; set; }
        public string currency { get; set; }
        public string unit_price { get; set; }
        public string amount { get; set; }
        public string fees { get; set; }
        public object shipping_address { get; set; }
        public object shipping_city { get; set; }
        public object shipping_state { get; set; }
        public object shipping_zip { get; set; }
        public object shipping_country { get; set; }
        public object discount_code { get; set; }
        public object discount_amount_off { get; set; }
        public List<object> variants { get; set; }
        public object affiliate_id { get; set; }
        public string affiliate_commission { get; set; }
        public string created_at { get; set; }
    }
}
