// Developed by Softeq Development Corporation
// http://www.softeq.com

using System;

namespace Softeq.NetKit.InAppPurchase.Exceptions
{
    public class InvalidTransactionException : BaseAppPurchaseException
    {
        public InvalidTransactionException(string message) : base(message)
        {
        }

        public InvalidTransactionException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
}
