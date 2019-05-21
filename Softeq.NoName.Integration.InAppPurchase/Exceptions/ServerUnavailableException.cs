// Developed by Softeq Development Corporation
// http://www.softeq.com

using System;

namespace Softeq.NoName.Integration.InAppPurchase.Exceptions
{
    public class ServerUnavailableException : BaseAppPurchaseException
    {
        public ServerUnavailableException(string message) : base(message)
        {
        }

        public ServerUnavailableException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
}
