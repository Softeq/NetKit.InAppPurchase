// Developed by Softeq Development Corporation
// http://www.softeq.com

using System.Threading.Tasks;
using Softeq.NetKit.InAppPurchase.DTOs.Request;
using Softeq.NetKit.InAppPurchase.DTOs.Response;

namespace Softeq.NetKit.InAppPurchase
{
    public interface IIosPurchaseValidator
    {
        Task<IosPurchaseVerificationResponse> VerifyPaymentAsync(IosPurchaseVerificationRequest request);
    }
}
