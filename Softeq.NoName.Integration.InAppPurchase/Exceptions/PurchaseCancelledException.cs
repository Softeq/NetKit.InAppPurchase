// Developed by Softeq Development Corporation
// http://www.softeq.com

using System;

namespace Softeq.NoName.Integration.InAppPurchase.Exceptions
{
    public class PurchaseCancelledException : BaseAppPurchaseException
    {
        public PurchaseCancelledException(string message) : base(message)
        {
        }

        public PurchaseCancelledException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
}