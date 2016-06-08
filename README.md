# Instamojo.NET

Assists you to programmatically create and list Payment Requests & Refunds on Instamojo in .NET.

* Requires .NET 4.5 or higher
* Requires Json.NET (7.0.1)
* All operations are asynchronus


## Usage

### Add reference to Instamojo.NET.dll

Download the `Instamojo.NET.dll` from the build folder and add it as a reference to your project. Add the following lines to use the same. Make sure you have also added reference to Json.NET.

      using Instamojo.NET;
      using Instamojo.NET.Models;

### Initialize Instamojo

    Instamojo.NET.Instamojo im = new Instamojo.NET.Instamojo("[API_KEY]", "[AUTH_TOKEN]");

We will use the newly created Object to talk with the server.

### Create a Payment Request

     PaymentRequest pr = new PaymentRequest();
     pr.allow_repeated_payments = false;        
     pr.amount = "100";
     pr.buyer_name = "Naveen Babu";
     pr.email = "naveenb@github.com";
     pr.phone = "9876543210";
     pr.send_email = true;
     pr.send_sms = true;
     pr.redirect_url = "https://naveen.me/success";
     pr.webhook = "https://naveen.me/webhook";
     pr.purpose = "GitHub Demo";
     PaymentRequest npr = await im.CreatePaymentRequest(pr);

The `CreatePaymentRequest` method returns a new Payment Request Object which will contain `id` as well as the `longurl` for further use. Please see Model Definitions for more info on this. You might need the longurl from the returned Object which is the link to the payment page that you will be sending to the client.

     String PaymentURL = npr.payment_request.longurl;

You might also need the payment request id which you can later use to query the status of the payment request. 

     String PaymentRequestId = npr.payment_request.id;

### Get status of a Payment Request

      PaymentRequest npr = await im.GetPaymentRequest("[PaymentRequestId]");

You can get the status of a payment request by calling the `GetPaymentRequest` method passing the payment request id as the Parameter.

### List all Payment Requests

      List<PaymentRequest> nprs = await im.GetPaymentRequests();

The `GetPaymentRequests` method will return a List of objects of type `PaymentRequest`. 

      foreach (PaymentRequest pr in nprs)
                // Do Something with pr

### Get a Payment

      Payment pr = await im.GetPayment("[PaymentRequestId]", "[PaymentId]");

The `GetPayment` method will return an object of type `Payment`. 

### Create a Refund

     Refund refund = new Refund();
     refund.payment_id = "MOJOb023488902249";
     refund.type = RefundType.RFD;
     refund.refund_amount = "10";
     refund.body = "Testing Refunds";
     Refund newRefund = await im.CreateRefund(refund);

The `CreateRefund` method returns a new Refund Object which will contain `id`. Please see Model Definitions for more info on this. 

You might need the refund id which you can later use to query the status of the refund. 

     String RefundId = newRefund.id;

### Get status of a Refund

      Refund refund = await im.GetRefund("[RefundId]");

You can get the status of a refund request by calling the `GetRefund` method passing the RefundId as the Parameter.

### List all Refunds

      List<Refund> refunds = await im.GetRefunds();

The `GetRefunds` method will return a List of objects of type `Refund`. 

      foreach (Refund refund in refunds)
                // Do Something with refund

## Available Functions

You have these functions to interact with the API:

  * `CreatePaymentRequest(PaymentRequest)` Create a new payment request.
  * `GetPaymentRequests()` List all Payment Requests.
  * `GetPaymentRequest(PaymentRequestId)` Get details of a Payment Request specified by its unique Payment Request ID.
  * `GetPayment(PaymentRequestId,PaymentId)` Get a Payment.
  * `CreateRefund(Refund)` Create a new refund.
  * `GetRefunds()` List all Refunds.
  * `GetRefund(RefundId)` Get details of a Refund specified by its unique Refund ID.

### Object Models

These are the currently available object models. They are present in the `Instamojo.NET.models` Namespace.

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
        public List<dynamic> variants { get; set; }
        public Dictionary<dynamic, dynamic> custom_fields { get; set; }
        public object affiliate_id { get; set; }
        public string affiliate_commission { get; set; }
        public string created_at { get; set; }
    }
    
    public class Refund
    {
        public string id { get; set; }
        public string payment_id { get; set; }
        public string status { get; set; }
        [JsonConverter(typeof(StringEnumConverter))]
        public RefundType type { get; set; }
        public string body { get; set; }
        public string refund_amount { get; set; }
        public string total_amount { get; set; }
        public string created_at { get; set; }
    }
    
    public enum RefundType
    {
        RFD,
        TNR,
        QFL,
        QNR,
        EWN,
        TAN,
        PTH
    }
    
    public enum PartnerFeeType
    {
        @fixed,
        percentage
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

Further documentation is available at https://www.instamojo.com/developers/
