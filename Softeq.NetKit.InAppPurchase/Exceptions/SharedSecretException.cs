// Developed by Softeq Development Corporation
// http://www.softeq.com

using System;

namespace Softeq.NetKit.InAppPurchase.Exceptions
{
    public class SharedSecretException : BaseAppPurchaseException
    {
        public SharedSecretException(string message) : base(message)
        {
        }

        public SharedSecretException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
}
