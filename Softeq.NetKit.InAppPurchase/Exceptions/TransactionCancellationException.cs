// Developed by Softeq Development Corporation
// http://www.softeq.com

using System;

namespace Softeq.NetKit.InAppPurchase.Exceptions
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
