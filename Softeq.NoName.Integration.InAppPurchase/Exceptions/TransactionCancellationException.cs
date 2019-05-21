// Developed by Softeq Development Corporation
// http://www.softeq.com

using System;

namespace Softeq.NoName.Integration.InAppPurchase.Exceptions
{
    public class TransactionCancellationException : BaseAppPurchaseException
    {
        public TransactionCancellationException(string message) : base(message)
        {
        }

        public TransactionCancellationException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
}
