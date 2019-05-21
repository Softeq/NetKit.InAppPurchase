// Developed by Softeq Development Corporation
// http://www.softeq.com

namespace Softeq.NetKit.InAppPurchase.DTOs.Request
{
    public class IosPurchaseVerificationRequest
    {
        public string TransactionId { get; set; }
        public string Receipt { get; set; }
        public string ProductId { get; set; }
    }
}
