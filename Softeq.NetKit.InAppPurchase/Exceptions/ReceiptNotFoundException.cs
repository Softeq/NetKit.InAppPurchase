// Developed by Softeq Development Corporation
// http://www.softeq.com

using System;

namespace Softeq.NetKit.InAppPurchase.Exceptions
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
