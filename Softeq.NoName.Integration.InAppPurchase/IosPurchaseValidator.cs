// Developed by Softeq Development Corporation
// http://www.softeq.com

using System;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Softeq.NoName.Integration.InAppPurchase.DTOs;
using Softeq.NoName.Integration.InAppPurchase.DTOs.Request;
using Softeq.NoName.Integration.InAppPurchase.DTOs.Response;
using Softeq.NoName.Integration.InAppPurchase.Exceptions;
using Softeq.NoName.Integration.InAppPurchase.Utility;

namespace Softeq.NoName.Integration.InAppPurchase
{
    public class IosPurchaseValidator : IIosPurchaseValidator
    {
        private const string ReceiptDataName = "receipt-data";
        private const string PostActionName = "POST";
        private const string InvalidJsonExceptionMessage = "The App Store could not read the JSON object you provided.";
        private const string MissingDataExceptionMessage = "The data in the receipt-data property was malformed or missing.";
        private const string AuthenticationExceptionMessage = "The receipt could not be authenticated.";
        private const string SharedSecretExceptionMessage = "The shared secret you provided does not match the shared secret on file for your account.";
        private const string ServerUnavailableExceptionMessage = "The receipt server is not currently available.";
        private const string SubscriptionExpiredExceptionMessage = "This receipt is valid but the subscription has expired.";
        private const string FailedProdEnvironmentVerificationExceptionMessage = "This receipt is from the test environment, but it was sent to the production environment for verification.";
        private const string FailedTestEnvironmentVerificationExceptionMessage = "This receipt is from the production environment, but it was sent to the test environment for verification.";
        private const string AuthorizeExceptionMessage = "This receipt could not be authorized. Treat this the same as if a purchase was never made.";
        private const string BaseAppPurchaseExceptionMessage = "There was an unspecified error during validating the receipt.";
        private const string ReceiptNotExistMessage = "Receipt does not exist.";
        private const string InvalidTransactionExceptionMessage = "Parameter {0} from request and from itunes are different.";
        private const string TransactionCancellationExceptionMessage = "Transaction was cancelled by Apple customer support. Cancellation date: {0}. Cancellation reason: {1}.";
        private const string UnknownErrorMessage = "Something went wrong during your request.";

        private readonly string _host;
       
        public IosPurchaseValidator(string host)
        {
            _host = host;
        }

        public async Task<IosPurchaseVerificationResponse> VerifyPaymentAsync(IosPurchaseVerificationRequest request)
        {
            var purchaseVerificationResponse = await PostRequest(request.Receipt);
            var iosPurchaseVerificationResponseModel = JsonConvert.DeserializeObject<IosPurchaseVerificationResponse>(purchaseVerificationResponse);
            if (iosPurchaseVerificationResponseModel.Status != (int) IosPurchaseStateEnum.Valid)
            {
                ThrowException(iosPurchaseVerificationResponseModel.Status);
            }
            else
            {
                if (iosPurchaseVerificationResponseModel.AppReceipt == null)
                {
                    throw new ReceiptNotFoundException(ReceiptNotExistMessage);
                }

                var inAppReceiptResponseModel = iosPurchaseVerificationResponseModel
                    .AppReceipt
                    .InAppReceiptResponses
                    .FirstOrDefault();

                if (inAppReceiptResponseModel?.TransactionId == null ||
                    inAppReceiptResponseModel.TransactionId != request.TransactionId)
                {
                    throw new InvalidTransactionException(string.Format(InvalidTransactionExceptionMessage, request.TransactionId));
                }

                if (inAppReceiptResponseModel.TransactionCancellationDate.HasValue &&
                    inAppReceiptResponseModel.TransactionCancellationReason != null)
                {
                    throw new TransactionCancellationException(string.Format(TransactionCancellationExceptionMessage, inAppReceiptResponseModel.TransactionCancellationDate, inAppReceiptResponseModel.TransactionCancellationReason));
                }
            }

            return iosPurchaseVerificationResponseModel;
        }

        private void ThrowException(int purchaseStatus)
        {
            switch (purchaseStatus)
            {
                case (int) IosPurchaseStateEnum.InvalidJson:
                    throw new InvalidJsonException(InvalidJsonExceptionMessage);
                case (int) IosPurchaseStateEnum.MissingData:
                    throw new MissingDataException(MissingDataExceptionMessage);
                case (int) IosPurchaseStateEnum.AuthenticationFailed:
                    throw new AuthenticationException(AuthenticationExceptionMessage);
                case (int) IosPurchaseStateEnum.InvalidSharedSecret:
                    throw new SharedSecretException(SharedSecretExceptionMessage);
                case (int) IosPurchaseStateEnum.ServerUnavailable:
                    throw new ServerUnavailableException(ServerUnavailableExceptionMessage);
                case (int) IosPurchaseStateEnum.SubscriptionExpired:
                    throw new SubscriptionExpiredException(SubscriptionExpiredExceptionMessage);
                case (int) IosPurchaseStateEnum.ProductionEnvironmentVerificationFailed:
                    throw new InvalidEnvironmentException(FailedProdEnvironmentVerificationExceptionMessage);
                case (int) IosPurchaseStateEnum.TestEnvironmentVerificationFailed:
                    throw new InvalidEnvironmentException(FailedTestEnvironmentVerificationExceptionMessage);
                case (int) IosPurchaseStateEnum.AuthorizeFailed:
                    throw new AuthorizeException(AuthorizeExceptionMessage);
                default:
                    throw new UnspecifiedPurchaseStatusException(BaseAppPurchaseExceptionMessage);
            }
        }

        private async Task<string> PostRequest(string receiptData)
        {
            try
            {
                string response;
                var json = new JObject(new JProperty(ReceiptDataName, receiptData)).ToString();
                var content = Encoding.UTF8.GetBytes(json);

                var httpClient = new HttpClient
                {
                    BaseAddress = new Uri(_host),
                    DefaultRequestHeaders =
                    {
                        { Utility.HttpHeaders.MethodHeaderName, PostActionName },
                        { Utility.HttpHeaders.ContentLengthName, content.Length.ToString() } 
                    }
                };

                httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue(MediaTypes.JsonContentType));
                var responseMessage = await httpClient.PostAsync(_host, new StringContent(json));
                
                using (var streamReader = new StreamReader(await responseMessage.Content.ReadAsStreamAsync()))
                {
                    response = streamReader.ReadToEnd().Trim();
                }

                return response;
            }
            catch (Exception ex)
            {
                throw new HttpRequestFailedException(UnknownErrorMessage, ex);
            }
        }
    }
}
