// Developed by Softeq Development Corporation
// http://www.softeq.com

using System;

namespace Softeq.NoName.Integration.InAppPurchase.Exceptions
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
