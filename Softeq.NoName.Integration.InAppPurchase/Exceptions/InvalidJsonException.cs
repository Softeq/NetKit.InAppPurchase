// Developed by Softeq Development Corporation
// http://www.softeq.com

using System;

namespace Softeq.NoName.Integration.InAppPurchase.Exceptions
{
    public class InvalidJsonException : BaseAppPurchaseException
    {
        public InvalidJsonException(string message) : base(message)
        {
        }

        public InvalidJsonException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
}
