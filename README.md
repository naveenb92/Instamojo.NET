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

Further documentation is available at https://www.instamojo.com/developers/
