// Developed by Softeq Development Corporation
// http://www.softeq.com

using System;

namespace Softeq.NoName.Integration.InAppPurchase.Exceptions
{
    public class InvalidEnvironmentException : BaseAppPurchaseException
    {
        public InvalidEnvironmentException(string message) : base(message)
        {
        }

        public InvalidEnvironmentException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
}
