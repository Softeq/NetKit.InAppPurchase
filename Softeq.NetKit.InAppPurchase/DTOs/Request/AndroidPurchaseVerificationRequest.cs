// Developed by Softeq Development Corporation
// http://www.softeq.com

namespace Softeq.NetKit.InAppPurchase.DTOs.Request
{
    public class AndroidPurchaseVerificationRequest
    {
        public string BundleId { get; set; }
        public string ProductId { get; set; }
        public string Receipt { get; set; }
    }
}
