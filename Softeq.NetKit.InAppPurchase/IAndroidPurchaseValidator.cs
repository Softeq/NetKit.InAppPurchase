// Developed by Softeq Development Corporation
// http://www.softeq.com

using System;
using System.Threading.Tasks;
using Softeq.NetKit.InAppPurchase.DTOs.Request;

namespace Softeq.NetKit.InAppPurchase
{
    public interface IAndroidPurchaseValidator : IDisposable
    {
        Task VerifyPaymentAsync(AndroidPurchaseVerificationRequest request);
    }
}