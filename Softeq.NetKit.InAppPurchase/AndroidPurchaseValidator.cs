// Developed by Softeq Development Corporation
// http://www.softeq.com

using System;
using System.IO;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;
using Google;
using Google.Apis.AndroidPublisher.v2;
using Google.Apis.Auth.OAuth2;
using Google.Apis.Services;
using Softeq.NetKit.InAppPurchase.DTOs;
using Softeq.NetKit.InAppPurchase.DTOs.Request;
using Softeq.NetKit.InAppPurchase.Exceptions;
using ArgumentNullException = Softeq.NetKit.InAppPurchase.Exceptions.ArgumentNullException;

namespace Softeq.NetKit.InAppPurchase
{
    public class AndroidPurchaseValidator : IAndroidPurchaseValidator
    {
        private const string CertificateNotFoundExceptionMessage = "There is no file {0}";
        private const string GoogleApiExceptionMessage = "Something went wrong during your request. Service name: {0}.";
        private const string PurchaseCancelledExceptionMessage = "Purchase was cancelled.";
        private const string AndroidPublisherServiceNotSetupedExceptionMessage = "AndroidPublisherService for purchase verification wasn't setup.";
        private const string AndroidPublisherServiceCreationFailedExceptionMessage = "Exception while creating Android Publisher Service.";
        private const string ApplicationName = "PurchaseVerification";

        private readonly string _googlePlayApiServiceAccountEmail;
        private readonly string _googlePlayApiCertificatePassword;
        private readonly string _googlePlayApiAuthUrl;
        private readonly string _certificateFileName;
        private AndroidPublisherService _androidPublisherService;

        public AndroidPurchaseValidator(
            bool isPlayStoreSupported, 
            string googlePlayApiServiceAccountEmail, 
            string googlePlayApiCertificatePassword,
            string googlePlayApiAuthUrl,
            string certificateFileName)
        {
            _googlePlayApiServiceAccountEmail = googlePlayApiServiceAccountEmail;
            _googlePlayApiCertificatePassword = googlePlayApiCertificatePassword;
            _googlePlayApiAuthUrl = googlePlayApiAuthUrl;
            _certificateFileName = certificateFileName;
            _androidPublisherService = InitialAndroidPublisherService(isPlayStoreSupported);
        }

        public async Task VerifyPaymentAsync(AndroidPurchaseVerificationRequest request)
        {
            if (_androidPublisherService == null)
            {
                throw new ArgumentNullException(AndroidPublisherServiceNotSetupedExceptionMessage);
            }
           
            try
            {
                var requestValidation = _androidPublisherService
                    .Purchases
                    .Products
                    .Get(request.BundleId, request.ProductId, request.Receipt);

                var productPurchase = await requestValidation
                    .ExecuteAsync()
                    .ConfigureAwait(false);

                if (productPurchase.PurchaseState != null && 
                    productPurchase.PurchaseState.Value == (int) AndroidPurchaseStateEnum.Cancelled)
                {
                    throw new PurchaseCancelledException(PurchaseCancelledExceptionMessage);
                }
            }
            catch (GoogleApiException ex)
            {
                throw new HttpRequestFailedException(string.Format(GoogleApiExceptionMessage, ex.ServiceName), ex);
            }
        }

        public void Dispose()
        {
            if (_androidPublisherService != null)
            {
                _androidPublisherService.Dispose();
                _androidPublisherService = null;
            }
        }

        private AndroidPublisherService InitialAndroidPublisherService(bool isPlayStoreSupported)
        {
            AndroidPublisherService androidPublisherService;

            if (!isPlayStoreSupported)
            {
                return null;
            }

            try
            {
                var certificateFilePath = Path.Combine(Directory.GetCurrentDirectory(), _certificateFileName);
                if (!File.Exists(certificateFilePath))
                {
                    throw new CertificateNotFoundException(string.Format(CertificateNotFoundExceptionMessage, certificateFilePath));
                }

                var certificate = new X509Certificate2(certificateFilePath, _googlePlayApiCertificatePassword, X509KeyStorageFlags.Exportable);
                var serviceAccountCredential = new ServiceAccountCredential(
                    new ServiceAccountCredential.Initializer(_googlePlayApiServiceAccountEmail)
                    { 
                        Scopes = new[] { _googlePlayApiAuthUrl }
                    }
                    .FromCertificate(certificate));

                androidPublisherService = new AndroidPublisherService(
                    new BaseClientService.Initializer
                    {
                        HttpClientInitializer = serviceAccountCredential,
                        ApplicationName = ApplicationName,
                    });
            }
            catch (Exception ex)
            {
                throw new HttpRequestFailedException(AndroidPublisherServiceCreationFailedExceptionMessage, ex);
            }

            return androidPublisherService;
        }
    }
}
