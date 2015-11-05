using Instamojo.NET.Models;
using Newtonsoft.Json;
using System;
using System.IO;
using System.Net;

namespace Instamojo.NET
{
    public class Instamojo
    {
        private WebHeaderCollection Headers;

        // End Points
        public String baseURL = "https://www.instamojo.com/api/1.1/";
        public String EndPoint_PaymentRequest = "payment-requests/";

        // Instantiate Instamojo with the API Key and Auth Token
        public Instamojo(String api_key, String auth_token)
        {
            Headers = new WebHeaderCollection();
            Headers.Add("X-API-KEY: " + api_key);
            Headers.Add("X-AUTH-TOKEN: " + auth_token);
        }

        public PaymentRequestResponse CreatePaymentRequest(PaymentRequest paymentRequest)
        {
            HttpWebRequest httpReq = (HttpWebRequest)WebRequest.Create(baseURL + EndPoint_PaymentRequest);
            httpReq.Headers = Headers;
            httpReq.ContentType = "application/json";
            httpReq.Method = "POST";
            String json = JsonConvert.SerializeObject(paymentRequest, new JsonSerializerSettings { NullValueHandling = NullValueHandling.Ignore });
            using (var writer = new StreamWriter(httpReq.GetRequestStream()))
            {
                writer.Write(json);
                writer.Flush();
                writer.Close();
            }
            using (HttpWebResponse response = (HttpWebResponse)httpReq.GetResponse())
            {
                using (StreamReader reader = new StreamReader(response.GetResponseStream()))
                {
                    PaymentRequestResponse prr = JsonConvert.DeserializeObject<PaymentRequestResponse>(reader.ReadToEnd());
                    reader.Close();
                    response.Close();
                    return prr;
                }
            }
        }

        public PaymentRequestResponse GetPaymentRequestStatus(String id)
        {
            HttpWebRequest httpReq = (HttpWebRequest)WebRequest.Create(baseURL + EndPoint_PaymentRequest + id + "/");
            httpReq.Headers = Headers;
            httpReq.Method = "GET";
            using (HttpWebResponse response = (HttpWebResponse)httpReq.GetResponse())
            {
                using (StreamReader reader = new StreamReader(response.GetResponseStream()))
                {
                    PaymentRequestResponse jobj = JsonConvert.DeserializeObject<PaymentRequestResponse>(reader.ReadToEnd());
                    reader.Close();
                    response.Close();
                    return jobj;
                }
            }
        }

        public PaymentRequestsResponse ListPaymentRequests()
        {
            HttpWebRequest httpReq = (HttpWebRequest)WebRequest.Create(baseURL + EndPoint_PaymentRequest);
            httpReq.Headers = Headers;
            httpReq.Method = "GET";
            using (HttpWebResponse response = (HttpWebResponse)httpReq.GetResponse())
            {
                using (StreamReader reader = new StreamReader(response.GetResponseStream()))
                {
                    PaymentRequestsResponse prr = JsonConvert.DeserializeObject<PaymentRequestsResponse>(reader.ReadToEnd());
                    reader.Close();
                    response.Close();
                    return prr;
                }
            }
        }

        public PaymentRequestsResponse ListPaymentRequests(DateTime? min_created_at = null, DateTime? max_created_at = null, DateTime? min_modified_at = null, DateTime? max_modified_at = null)
        {
            String temp = "";
            if (min_created_at != null)
                temp += (temp == "") ? "?min_created_at=" + min_created_at.Value.ToString("s", System.Globalization.CultureInfo.InvariantCulture) : "&min_created_at=" + min_created_at.Value.ToString("s", System.Globalization.CultureInfo.InvariantCulture);
            if (max_created_at != null)
                temp += (temp == "") ? "?max_created_at=" + max_created_at.Value.ToString("s", System.Globalization.CultureInfo.InvariantCulture) : "&max_created_at=" + max_created_at.Value.ToString("s", System.Globalization.CultureInfo.InvariantCulture);
            if (min_modified_at != null)
                temp += (temp == "") ? "?min_modified_at=" + min_modified_at.Value.ToString("s", System.Globalization.CultureInfo.InvariantCulture) : "&min_modified_at=" + min_modified_at.Value.ToString("s", System.Globalization.CultureInfo.InvariantCulture);
            if (max_modified_at != null)
                temp += (temp == "") ? "?max_modified_at=" + max_modified_at.Value.ToString("s", System.Globalization.CultureInfo.InvariantCulture) : "&max_modified_at=" + max_modified_at.Value.ToString("s", System.Globalization.CultureInfo.InvariantCulture);

            String FilteredURL = baseURL + EndPoint_PaymentRequest + temp;
            HttpWebRequest httpReq = (HttpWebRequest)WebRequest.Create(FilteredURL);
            httpReq.Headers = Headers;
            httpReq.Method = "GET";

            using (HttpWebResponse response = (HttpWebResponse)httpReq.GetResponse())
            {
                using (StreamReader reader = new StreamReader(response.GetResponseStream()))
                {
                    PaymentRequestsResponse jobj = JsonConvert.DeserializeObject<PaymentRequestsResponse>(reader.ReadToEnd());
                    reader.Close();
                    response.Close();
                    return jobj;
                }
            }
        }
    }
}
