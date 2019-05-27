
# Softeq.NetKit.InAppPurchase

Softeq.NetKit.InAppPurchase component simplifies the process of verifying purchases using App Store (for IOS devices) and Google Play (for Android devices).
Also you can see programming guide for:
1. [IOS](https://developer.apple.com/library/archive/releasenotes/General/ValidateAppStoreReceipt/Chapters/ValidateRemotely.html#//apple_ref/doc/uid/TP40010573-CH104-SW1)
2. [Android](https://developers.google.com/android-publisher/api-ref/purchases/products/get)

# Getting Started

## Install 
1. Check-out master branch from repository;
2. Add a reference to Softeq.NetKit.InAppPurchase into target project.

## Obtain the P12 key (for Android)

Grab your the P12 key from the [Google Cloud Console](https://console.developers.google.com/).

Open the project, go to ```APIs & auth``` > ```Credentials```

Click on ```Create new Client ID```, and select ```Service account``` and ```P12 key```. Then click on ```Create Client ID``` to download it.

Insert the P12 key into Softeq.NetKit.InAppPurchase.

## Setup configuration

Add PurchaseValidation settings to your ```appsettings.json``` file:
```json
    "PurchaseValidation": {
        "Ios": {
          "Host":"HOST_URL"
        },
        "Android": {
          "IsPlayStoreSupported": "TRUE_OR_FALSE",
          "GooglePlayConsoleAccountEmail":"YOUR_EMAIL",
          "GooglePlayConsoleAccountPassword":"YOUR_PASSWORD",
          "CertificateFileName":"CERTIFICATE_FILE_NAME",
          "GoogleApiAuthUrl":"https://www.googleapis.com/auth/androidpublisher"
        }
    },
```

In the test environment, use ```https://sandbox.itunes.apple.com/verifyReceipt``` as HOST_URL. 
In production, use ```https://buy.itunes.apple.com/verifyReceipt``` as HOST_URL.

## Configure DI Container

Softeq.NetKit.InAppPurchase comes with Autofac Module to register its dependencies. 
If different IoC container is used or manual registration is required, the following registrations need to be performed:
1. Set up and register ```IosPurchaseValidator``` in your DI container
```csharp
    builder.Register(x =>
            {
                var configuration = context.Resolve<IConfiguration>();
                var iosPurchaseValidator = new IosPurchaseValidator(configuration["PurchaseValidation:Ios:Host"]);
                return iosPurchaseValidator;
            })
            .As<IIosPurchaseValidator>();
```

2. Register ```IAndroidPurchaseValidator``` implementation
```csharp
    builder.Register(x =>
            {
                var configuration = context.Resolve<IConfiguration>();

                var androidPurchaseValidator = new AndroidPurchaseValidator(
                    configuration["PurchaseValidation:Android:IsPlayStoreSupported"],
                    configuration["PurchaseValidation:Android:GooglePlayConsoleAccountEmail"],
                    configuration["PurchaseValidation:Android:GooglePlayConsoleAccountPassword"],
                    configuration["PurchaseValidation:Android:GoogleApiAuthUrl"],
                    configuration["PurchaseValidation:Android:CertificateFileName"]);
                    return androidPurchaseValidator;
                })
                .As<IAndroidPurchaseValidator>();
```

## Use

Inject ```IIosPurchaseValidator``` into your service to validate payments using the following action:
```csharp
    Task VerifyPaymentAsync(AndroidPurchaseVerificationRequest request);
```
Inject ```IAndroidPurchaseValidator``` into your service to validate payments using the following action:
```csharp
    Task<IosPurchaseVerificationResponse> VerifyPaymentAsync(IosPurchaseVerificationRequest request);
```

## About

This project is maintained by Softeq Development Corp.

We specialize in .NET core applications.

## Contributing

We welcome any contributions.

## License

The NetKit.InAppPurchase project is available for free use, as described by the [LICENSE](/LICENSE) (MIT).
