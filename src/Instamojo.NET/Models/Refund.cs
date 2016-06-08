using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Instamojo.NET.Models
{
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

    class RefundResponse
    {
        public bool success { get; set; }
        public Refund refund { get; set; }
    }

    class RefundsResponse
    {
        public bool success { get; set; }
        public List<Refund> refunds { get; set; }
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
}
