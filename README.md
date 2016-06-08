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

## Available Functions

You have these functions to interact with the API:

  * `CreatePaymentRequest(PaymentRequest)` List all Links created by authenticated User.
  * `GetPaymentRequest(PaymentRequestId)` Get details of a Payment Request specified by its unique Payment Request ID. You may receive the Payment Request ID via `CreatePaymentRequest()` or via URL Redirect function or as a part of Webhook data.
  * `GetPaymentRequests()` List all Payment Requests.

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

Further documentation is available at https://www.instamojo.com/developers/
