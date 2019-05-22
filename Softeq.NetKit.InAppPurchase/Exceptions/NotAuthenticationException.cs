// Developed by Softeq Development Corporation
// http://www.softeq.com

using System;

namespace Softeq.NetKit.InAppPurchase.Exceptions
{
    public class NotAuthenticationException : BaseAppPurchaseException
    {
        public NotAuthenticationException(string message) : base(message)
        {
        }

        public NotAuthenticationException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
}
