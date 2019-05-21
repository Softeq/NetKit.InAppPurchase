// Developed by Softeq Development Corporation
// http://www.softeq.com

using System;

namespace Softeq.NoName.Integration.InAppPurchase.Exceptions
{
    public class UnspecifiedPurchaseStatusException : BaseAppPurchaseException
    {
        public UnspecifiedPurchaseStatusException(string message) : base(message)
        {
        }

        public UnspecifiedPurchaseStatusException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
}