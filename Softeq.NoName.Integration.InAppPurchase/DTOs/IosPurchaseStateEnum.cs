// Developed by Softeq Development Corporation
// http://www.softeq.com

namespace Softeq.NoName.Integration.InAppPurchase.DTOs
{
    public enum IosPurchaseStateEnum
    {
        Valid = 0,
        InvalidJson = 21000,
        MissingData = 21002,
        AuthenticationFailed = 21003,
        InvalidSharedSecret = 21004,
        ServerUnavailable = 21005,
        SubscriptionExpired = 21006,
        ProductionEnvironmentVerificationFailed = 21007,
        TestEnvironmentVerificationFailed = 21008,
        AuthorizeFailed = 21010
    }
}