// Developed by Softeq Development Corporation
// http://www.softeq.com

using System;

namespace Softeq.NetKit.InAppPurchase.Exceptions
{
    public abstract class BaseAppPurchaseException : Exception
    {
        protected BaseAppPurchaseException(string message) : base(message)
        {
        }

        protected BaseAppPurchaseException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
}