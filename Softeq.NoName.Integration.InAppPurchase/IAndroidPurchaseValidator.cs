// Developed by Softeq Development Corporation
// http://www.softeq.com

using System;
using System.Threading.Tasks;
using Softeq.NoName.Integration.InAppPurchase.DTOs.Request;

namespace Softeq.NoName.Integration.InAppPurchase
{
    public interface IAndroidPurchaseValidator : IDisposable
    {
        Task VerifyPaymentAsync(AndroidPurchaseVerificationRequest request);
    }
}