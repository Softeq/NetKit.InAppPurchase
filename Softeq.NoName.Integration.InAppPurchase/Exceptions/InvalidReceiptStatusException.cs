// Developed by Softeq Development Corporation
// http://www.softeq.com

using System;

namespace Softeq.NoName.Integration.InAppPurchase.Exceptions
{
    public class InvalidReceiptStatusException : BaseAppPurchaseException
    {
        public InvalidReceiptStatusException(string message) : base(message)
        {
        }

        public InvalidReceiptStatusException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
}
