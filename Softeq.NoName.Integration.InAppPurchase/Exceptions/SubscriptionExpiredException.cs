// Developed by Softeq Development Corporation
// http://www.softeq.com

using System;

namespace Softeq.NoName.Integration.InAppPurchase.Exceptions
{
    public class SubscriptionExpiredException : BaseAppPurchaseException
    {
        public SubscriptionExpiredException(string message) : base(message)
        {
        }

        public SubscriptionExpiredException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
}
