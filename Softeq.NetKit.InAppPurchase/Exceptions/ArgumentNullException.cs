// Developed by Softeq Development Corporation
// http://www.softeq.com

using System;

namespace Softeq.NetKit.InAppPurchase.Exceptions
{
    public class ArgumentNullException : BaseAppPurchaseException
    {
        public ArgumentNullException(string message) : base(message)
        {
        }

        public ArgumentNullException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
}