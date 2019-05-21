// Developed by Softeq Development Corporation
// http://www.softeq.com

using System;

namespace Softeq.NoName.Integration.InAppPurchase.Exceptions
{
    public class ReceiptNotFoundException : BaseAppPurchaseException
    {
        public ReceiptNotFoundException(string message) : base(message)
        {
        }

        public ReceiptNotFoundException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
}
