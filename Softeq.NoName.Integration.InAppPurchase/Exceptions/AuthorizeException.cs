// Developed by Softeq Development Corporation
// http://www.softeq.com

using System;

namespace Softeq.NoName.Integration.InAppPurchase.Exceptions
{
    public class AuthorizeException : BaseAppPurchaseException
    {
        public AuthorizeException(string message) : base(message)
        {
        }

        public AuthorizeException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
}
