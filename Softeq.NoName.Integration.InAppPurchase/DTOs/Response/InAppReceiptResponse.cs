// Developed by Softeq Development Corporation
// http://www.softeq.com

using System;
using Newtonsoft.Json;

namespace Softeq.NoName.Integration.InAppPurchase.DTOs.Response
{
    public class InAppReceiptResponse
    {
        [JsonProperty("quantity")]
        public int Quantity { get; set; }
        [JsonProperty("product_id")]
        public string ProductId { get; set; }
        [JsonProperty("transaction_id")]
        public string TransactionId { get; set; }
        [JsonProperty("original_transaction_id")]
        public string ParentTransactionId { get; set; }
        [JsonProperty("purchase_date")]
        public DateTime PurchaseDate { get; set; }
        [JsonProperty("original_purchase_date")]
        public DateTime ParentPurchaseDate { get; set; }
        [JsonProperty("cancellation_date")]
        public DateTime? TransactionCancellationDate { get; set; }
        [JsonProperty("cancellation_reason")]
        public int? TransactionCancellationReason { get; set; }

        //This fields are commented, because they are only present for auto-renewable subscription receipts. 
        //[JsonProperty("expires_date")]
        //public DateTime SubscriptionExpirationDate { get; set; }
        //[JsonProperty("expiration_intent")]
        //public string SubscriptionExpirationReason { get; set; }
        //[JsonProperty("is_in_billing_retry_period")]
        //public string RenewSubscriptionFlag { get; set; }
        //[JsonProperty("is_trial_period")]
        //public string SubscriptionHasTrialPeriod { get; set; }
        //[JsonProperty("is_in_intro_offer_period")]
        //public string SubscriptionHasIntroductoryPricePeriod { get; set; }
    }
}