using Instamojo.NET.Exceptions;
using Instamojo.NET.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Instamojo.NET
{
    public class Instamojo
    {
        private string api_key;
        private string auth_token;

        private HttpClient httpClient;

        /// <summary>
        // Instantiate Instamojo with the API Key and Auth Token.
        /// </summary>
        public Instamojo(string api_key, string auth_token)
        {
            this.api_key = api_key;
            this.auth_token = auth_token;
        }

        /// <summary>
        ///  Create a payment request.
        /// </summary>
        /// <returns>An object of type PaymentRequest.</returns>
        /// <exception cref = "ArgumentNullException"> paymentRequest was null; amount and/or purpose was null; </exception>
        /// <exception cref = "BadRequestException"> Can happen due to a number of reasons. </exception>
        /// <exception cref = "UnauthorizedAccessException"> Raised due to invalid credentials. </exception>
        public async Task<PaymentRequest> CreatePaymentRequest(PaymentRequest paymentRequest)
        {
            if (paymentRequest == null)
                throw new ArgumentNullException("paymentRequest cannot be null");

            if (paymentRequest.amount == null)
                throw new ArgumentNullException("paymentRequest.amount");

            if (paymentRequest.purpose == null)
                throw new ArgumentNullException("paymentRequest.purpose");

            StringContent jsonContent = new StringContent(JsonConvert.SerializeObject(paymentRequest, new JsonSerializerSettings { NullValueHandling = NullValueHandling.Ignore }), Encoding.UTF8, "application/json");

            using (httpClient = new HttpClient())
            {
                httpClient.BaseAddress = new Uri(Endpoints.baseURL);
                httpClient.DefaultRequestHeaders.Add("X-API-KEY", this.api_key);
                httpClient.DefaultRequestHeaders.Add("X-AUTH-TOKEN", this.auth_token);

                var response = await httpClient.PostAsync(Endpoints.paymentRequests, jsonContent);
                string content = response.Content.ReadAsStringAsync().Result;

                if (response.StatusCode == HttpStatusCode.Created)
                {
                    return JsonConvert.DeserializeObject<PaymentRequestResponse>(content).payment_request;
                }
                else if (response.StatusCode == HttpStatusCode.Unauthorized)
                {
                    throw new UnauthorizedAccessException("Please check the apiKey and authToken.");
                }
                else
                {
                    Dictionary<string, dynamic> values = JsonConvert.DeserializeObject<Dictionary<string, dynamic>>(content);
                    throw new BadRequestException(values["message"].ToString());
                }
            }
        }

        /// <summary>
        ///  Get all payment request.
        /// </summary>
        /// <returns>A List of PaymentRequest objects.</returns>
        /// <exception cref = "UnauthorizedAccessException"> Raised due to invalid credentials. </exception>
        public async Task<List<PaymentRequest>> GetPaymentRequests()
        {
            using (httpClient = new HttpClient())
            {
                httpClient.BaseAddress = new Uri(Endpoints.baseURL);
                httpClient.DefaultRequestHeaders.Add("X-API-KEY", this.api_key);
                httpClient.DefaultRequestHeaders.Add("X-AUTH-TOKEN", this.auth_token);

                var response = await httpClient.GetAsync(Endpoints.paymentRequests);
                string content = response.Content.ReadAsStringAsync().Result;

                if (response.StatusCode == HttpStatusCode.OK)
                {
                    return JsonConvert.DeserializeObject<PaymentRequestsResponse>(content).payment_requests;
                }
                else if (response.StatusCode == HttpStatusCode.Unauthorized)
                {
                    throw new UnauthorizedAccessException("Please check the apiKey and authToken.");
                }

                return null;
            }
        }

        /// <summary>
        ///  Get a payment request.
        /// </summary>
        /// <returns>A PaymentRequest object.</returns>
        /// <exception cref = "UnauthorizedAccessException"> Raised due to invalid credentials. </exception>
        /// <exception cref = "PaymentRequestNotFoundException"> Raised if Payment request is not found. </exception>
        public async Task<PaymentRequest> GetPaymentRequest(string id)
        {
            using (httpClient = new HttpClient())
            {
                httpClient.BaseAddress = new Uri(Endpoints.baseURL);
                httpClient.DefaultRequestHeaders.Add("X-API-KEY", this.api_key);
                httpClient.DefaultRequestHeaders.Add("X-AUTH-TOKEN", this.auth_token);

                var response = await httpClient.GetAsync(Endpoints.paymentRequest(id));
                string content = response.Content.ReadAsStringAsync().Result;

                if (response.StatusCode == HttpStatusCode.OK)
                {
                    return JsonConvert.DeserializeObject<PaymentRequestResponse>(content).payment_request;
                }
                else if (response.StatusCode == HttpStatusCode.Unauthorized)
                {
                    throw new UnauthorizedAccessException("Please check the apiKey and authToken.");
                }
                else
                {
                    throw new PaymentRequestNotFoundException(id);
                }
            }
        }

        /// <summary>
        ///  Get a payment.
        /// </summary>
        /// <returns>A Payment object.</returns>
        /// <exception cref = "UnauthorizedAccessException"> Raised due to invalid credentials. </exception>
        /// <exception cref = "PaymentNotFoundException"> Raised if Payment is not found. </exception>
        public async Task<Payment> GetPayment(string id, string payment_id)
        {
            using (httpClient = new HttpClient())
            {
                httpClient.BaseAddress = new Uri(Endpoints.baseURL);
                httpClient.DefaultRequestHeaders.Add("X-API-KEY", this.api_key);
                httpClient.DefaultRequestHeaders.Add("X-AUTH-TOKEN", this.auth_token);

                var response = await httpClient.GetAsync(Endpoints.payment(id, payment_id));
                string content = response.Content.ReadAsStringAsync().Result;

                if (response.StatusCode == HttpStatusCode.OK)
                {
                    return JsonConvert.DeserializeObject<PaymentRequestResponseForPayment>(content).payment_request.payment;
                }
                else if (response.StatusCode == HttpStatusCode.Unauthorized)
                {
                    throw new UnauthorizedAccessException("Please check the apiKey and authToken.");
                }
                else
                {
                    throw new PaymentNotFoundException(id, payment_id);
                }
            }
        }

        /// <summary>
        ///  Create a refund.
        /// </summary>
        /// <returns>An object of type Refund.</returns>
        /// <exception cref = "ArgumentNullException"> refund was null; payment_id was null; </exception>
        /// <exception cref = "BadRequestException"> Can happen due to a number of reasons. </exception>
        /// <exception cref = "UnauthorizedAccessException"> Raised due to invalid credentials. </exception>
        public async Task<Refund> CreateRefund(Refund refund)
        {
            if (refund == null)
                throw new ArgumentNullException("refund");

            if (refund.payment_id == null)
                throw new ArgumentNullException("refund.payment_id");

            StringContent jsonContent = new StringContent(JsonConvert.SerializeObject(refund, new JsonSerializerSettings { NullValueHandling = NullValueHandling.Ignore }), Encoding.UTF8, "application/json");

            using (httpClient = new HttpClient())
            {
                httpClient.BaseAddress = new Uri(Endpoints.baseURL);
                httpClient.DefaultRequestHeaders.Add("X-API-KEY", this.api_key);
                httpClient.DefaultRequestHeaders.Add("X-AUTH-TOKEN", this.auth_token);

                var response = await httpClient.PostAsync(Endpoints.refunds, jsonContent);
                string content = response.Content.ReadAsStringAsync().Result;

                if (response.StatusCode == HttpStatusCode.Created)
                {
                    return JsonConvert.DeserializeObject<RefundResponse>(content).refund;
                }
                else if (response.StatusCode == HttpStatusCode.Unauthorized)
                {
                    throw new UnauthorizedAccessException("Please check the apiKey and authToken.");
                }
                else
                {
                    Dictionary<string, dynamic> values = JsonConvert.DeserializeObject<Dictionary<string, dynamic>>(content);
                    throw new BadRequestException(values["message"].ToString());
                }
            }
        }

        /// <summary>
        ///  Get all refunds.
        /// </summary>
        /// <returns>A List of Refund objects.</returns>
        /// <exception cref = "UnauthorizedAccessException"> Raised due to invalid credentials. </exception>
        public async Task<List<Refund>> GetRefunds()
        {
            using (httpClient = new HttpClient())
            {
                httpClient.BaseAddress = new Uri(Endpoints.baseURL);
                httpClient.DefaultRequestHeaders.Add("X-API-KEY", this.api_key);
                httpClient.DefaultRequestHeaders.Add("X-AUTH-TOKEN", this.auth_token);

                var response = await httpClient.GetAsync(Endpoints.refunds);
                string content = response.Content.ReadAsStringAsync().Result;

                if (response.StatusCode == HttpStatusCode.OK)
                {
                    return JsonConvert.DeserializeObject<RefundsResponse>(content).refunds;
                }
                else if (response.StatusCode == HttpStatusCode.Unauthorized)
                {
                    throw new UnauthorizedAccessException("Please check the apiKey and authToken.");
                }

                return null;
            }
        }

        /// <summary>
        ///  Get a refund.
        /// </summary>
        /// <returns>A Refund object.</returns>
        /// <exception cref = "UnauthorizedAccessException"> Raised due to invalid credentials. </exception>
        /// <exception cref = "RefundNotFoundException"> Raised if refund is not found. </exception>
        public async Task<Refund> GetRefund(string id)
        {
            using (httpClient = new HttpClient())
            {
                httpClient.BaseAddress = new Uri(Endpoints.baseURL);
                httpClient.DefaultRequestHeaders.Add("X-API-KEY", this.api_key);
                httpClient.DefaultRequestHeaders.Add("X-AUTH-TOKEN", this.auth_token);

                var response = await httpClient.GetAsync(Endpoints.refund(id));
                string content = response.Content.ReadAsStringAsync().Result;

                if (response.StatusCode == HttpStatusCode.OK)
                {
                    return JsonConvert.DeserializeObject<RefundResponse>(content).refund;
                }
                else if (response.StatusCode == HttpStatusCode.Unauthorized)
                {
                    throw new UnauthorizedAccessException("Please check the apiKey and authToken.");
                }
                else
                {
                    throw new RefundNotFoundException(id);
                }
            }
        }
    }
}
