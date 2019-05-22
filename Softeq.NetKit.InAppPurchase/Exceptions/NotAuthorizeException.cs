// Developed by Softeq Development Corporation
// http://www.softeq.com

using System;

namespace Softeq.NetKit.InAppPurchase.Exceptions
{
    public class NotAuthorizeException : BaseAppPurchaseException
    {
        public NotAuthorizeException(string message) : base(message)
        {
        }

        public NotAuthorizeException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
}
