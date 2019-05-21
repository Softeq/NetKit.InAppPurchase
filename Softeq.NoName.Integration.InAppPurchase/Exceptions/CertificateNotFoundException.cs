// Developed by Softeq Development Corporation
// http://www.softeq.com

using System;

namespace Softeq.NoName.Integration.InAppPurchase.Exceptions
{
    public class CertificateNotFoundException : BaseAppPurchaseException
    {
        public CertificateNotFoundException(string message) : base(message)
        {
        }

        public CertificateNotFoundException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
}