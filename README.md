# Instamojo.NET

Assists you to programmatically create and list Payment Requests on Instamojo in .NET.


## Usage

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
     PaymentRequestResponse npr = im.CreatePaymentRequest(pr);

The PaymentRequestResponse Object contains the status of the Payment Request as well as the returned Payment Request Object. Please see Model Definitions for more info on this. You might need the LongURL from the returned Object which is the link to the payment page that you will be sending to the client.

     String PaymentURL = npr.payment_request.longurl;

Further documentation is available at https://www.instamojo.com/developers/
