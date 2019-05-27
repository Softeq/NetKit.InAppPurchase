// Developed by Softeq Development Corporation
// http://www.softeq.com

using Newtonsoft.Json;

namespace Softeq.NetKit.InAppPurchase.DTOs.Response
{
    public class IosPurchaseVerificationResponse
    {
        [JsonProperty("status")]
        public int Status { get; set; }
        [JsonProperty("environment")]
        public string Environment { get; set; }
        [JsonProperty("receipt")]
        public AppReceiptResponse AppReceipt { get; set; }
    }
}
