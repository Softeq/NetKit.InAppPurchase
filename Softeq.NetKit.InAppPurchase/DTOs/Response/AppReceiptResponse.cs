// Developed by Softeq Development Corporation
// http://www.softeq.com

using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace Softeq.NetKit.InAppPurchase.DTOs.Response
{
    public class AppReceiptResponse
    {
        [JsonProperty("bundle_id")]
        public string BundleId { get; set; }
        [JsonProperty("application_version")]
        public string AppVersion { get; set; }
        [JsonProperty("receipt_type")]
        public string ReceiptType { get; set; }
        [JsonProperty("original_application_version")]
        public string OriginalAppVersion { get; set; }
        [JsonProperty("receipt_creation_date")]
        public DateTime ReceiptCreatedDate { get; set; }
        [JsonProperty("app_item_id")]
        public string AppItemId { get; set; }
        [JsonProperty("version_external_identifier")]
        public string ExternalVersionId { get; set; }
        // In-app purchase receipt fields.
        [JsonProperty("in_app")]
        public IEnumerable<InAppReceiptResponse> InAppReceiptResponses { get; set; }

        //This fields are commented, because they are only present for auto-renewable subscription receipts. 
        //[JsonProperty("web_order_line_item_id")]
        //public string WebOrderLineId { get; set; }
        //[JsonProperty("auto_renew_status")]
        //public int SubscriptionAutoRenewStatus { get; set; }
        //[JsonProperty("auto_renew_product_id")]
        //public string SubscriptionAutoRenewPreference { get; set; }
        //[JsonProperty("price_consent_status")]
        //public int SubscriptionPriceConsentStatus { get; set; }
    }
}