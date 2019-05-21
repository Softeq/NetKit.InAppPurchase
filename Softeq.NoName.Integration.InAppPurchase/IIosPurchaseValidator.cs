// Developed by Softeq Development Corporation
// http://www.softeq.com

using System.Threading.Tasks;
using Softeq.NoName.Integration.InAppPurchase.DTOs.Request;
using Softeq.NoName.Integration.InAppPurchase.DTOs.Response;

namespace Softeq.NoName.Integration.InAppPurchase
{
    public interface IIosPurchaseValidator
    {
        Task<IosPurchaseVerificationResponse> VerifyPaymentAsync(IosPurchaseVerificationRequest request);
    }
}
