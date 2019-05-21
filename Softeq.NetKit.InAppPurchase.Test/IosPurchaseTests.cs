// Developed by Softeq Development Corporation
// http://www.softeq.com

using System.Threading.Tasks;
using Softeq.NetKit.InAppPurchase;
using Softeq.NetKit.InAppPurchase.DTOs.Request;
using Softeq.NetKit.InAppPurchase.Exceptions;
using Xunit;

namespace Softeq.NoNetKit.InAppPurchase.Test
{
    public class IosPurchaseTests
    {
        private const string Host = "https://sandbox.itunes.apple.com/verifyReceipt";
        private IosPurchaseValidator _iosPurchase = new IosPurchaseValidator(Host);

        [Fact]
        public async Task MissingDataExceptionTest()
        {
            try
            {
                await _iosPurchase.VerifyPaymentAsync(new IosPurchaseVerificationRequest()
                {
                    ProductId = "com.ResianInnovations.FriendBuks.iOS.1.friendbuk",
                    TransactionId = "1000000378034117",
                    Receipt = "Test"
                });
            }
            catch (MissingDataException ex)
            {
                Assert.True(true, "Recieved MissingDataException");
            }
        }
    }
}
