using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using StackHolisticSolution.Platforms;

namespace StackHolisticSolution
{
    public static class HolisticSolution
    {
        public const string HolisticSolutionPluginVersion = "2.0.0";
    }

    [SuppressMessage("ReSharper", "InconsistentNaming")]
    public class HSAppConfig
    {
        private readonly IHSAppConfig nativeHSAppConfig;

        public IHSAppConfig getHSAppConfig()
        {
            return nativeHSAppConfig;
        }

        public HSAppConfig()
        {
            nativeHSAppConfig = HolisticSolutionClientFactory.GetHSAppConfig();
        }

        public HSAppConfig setDebugEnabled(bool value)
        {
            nativeHSAppConfig.setDebugEnabled(value);
            return this;
        }

        public HSAppConfig setAppKey(string appKey)
        {
            nativeHSAppConfig.setAppKey(appKey);
            return this;
        }

        public HSAppConfig setAdType(int adType)
        {
            nativeHSAppConfig.setAdType(adType);
            return this;
        }

        public HSAppConfig setComponentInitializeTimeout(long value)
        {
            nativeHSAppConfig.setComponentInitializeTimeout(value);
            return this;
        }
        
    }

    [SuppressMessage("ReSharper", "InconsistentNaming")]
    public static class HSApp
    {
        private static IHSApp nativeHsApp;

        private static IHSApp getInstance()
        {
            return nativeHsApp ?? (nativeHsApp = HolisticSolutionClientFactory.GetHSApp());
        }

        public static void initialize(HSAppConfig hsAppConfig, IHSAppInitializeListener hsAppInitializeListener)
        {
            getInstance().initialize(hsAppConfig, hsAppInitializeListener);
        }

        public static void logEvent(string key)
        {
            getInstance().logEvent(key);
        }

        public static string getVersion()
        {
           return getInstance().getVersion();
        }

        public static bool isInitialized()
        {
            return getInstance().isInitialized();
        }

        public static void validateInAppPurchaseAndroid(HSInAppPurchase purchase,
            IInAppPurchaseValidationCallback hsInAppPurchaseValidateListener)
        {
            getInstance().validateInAppPurchaseAndroid(purchase, hsInAppPurchaseValidateListener);
        }

        public static void validateInAppPurchaseiOS(string productIdentifier, string price, string currency,
            string transactionId,
            string additionalParams, 
            iOSPurchaseType type, 
            IInAppPurchaseValidationCallback inAppPurchaseValidationiOSCallback)
        {
            getInstance().validateInAppPurchaseiOS(productIdentifier, price, currency, transactionId, additionalParams, type, inAppPurchaseValidationiOSCallback);
        }
    }

    [SuppressMessage("ReSharper", "InconsistentNaming")]
    [SuppressMessage("ReSharper", "UnusedMember.Local")]
    public class HSError
    {
        private readonly IHSError nativeHSError;

        private IHSError getHSError()
        {
            return nativeHSError;
        }

        public HSError(IHSError getHsError)
        {
            nativeHSError = getHsError;
        }

        public string toString()
        {
            return nativeHSError.toString();
        }
    }

    [SuppressMessage("ReSharper", "InconsistentNaming")]
    public enum PurchaseType
    {
        SUBS,
        INAPP
    }
    
    [SuppressMessage("ReSharper", "InconsistentNaming")]
    public enum iOSPurchaseType{
     consumable = 0,
     nonConsumable = 1,
     autoRenewableSubscription = 2,
     nonRenewingSubscription = 3
    }

    [Serializable]
    [SuppressMessage("ReSharper", "InconsistentNaming")]
    public class HSInAppPurchase
    {
        private readonly IHSInAppPurchase nativeHSInAppPurchase;

        public HSInAppPurchase(IHSInAppPurchase builder)
        {
            nativeHSInAppPurchase = builder;
        }

        public IHSInAppPurchase getNativeHSInAppPurchase()
        {
            return nativeHSInAppPurchase;
        }

        public string getPublicKey()
        {
            return nativeHSInAppPurchase.getPublicKey();
        }

        public string getSignature()
        {
            return nativeHSInAppPurchase.getSignature();
        }

        public string getPurchaseData()
        {
            return nativeHSInAppPurchase.getPurchaseData();
        }

        public string getPrice()
        {
            return nativeHSInAppPurchase.getPrice();
        }

        public string getCurrency()
        {
            return nativeHSInAppPurchase.getCurrency();
        }

        public string getAdditionalParameters()
        {
            return nativeHSInAppPurchase.getAdditionalParameters();
        }

        public class Builder
        {
            private readonly IHSInAppPurchaseBuilder nativeIHSInAppPurchaseBuilder;

            public Builder(PurchaseType purchaseType)
            {
                 nativeIHSInAppPurchaseBuilder =
                     HolisticSolutionClientFactory.GetInAppPurchaseBuilder(purchaseType);
            }

            public HSInAppPurchase build()
            {
                return new HSInAppPurchase(nativeIHSInAppPurchaseBuilder.build());
            }
            
            public Builder withPublicKey(string publicKey)
            {
                nativeIHSInAppPurchaseBuilder.withPublicKey(publicKey);
                return this;
            }
            
            public Builder withSignature(string signature)
            {
                nativeIHSInAppPurchaseBuilder.withSignature(signature);
                return this;
            }
            
            public Builder withPurchaseData(string purchaseData)
            {
                nativeIHSInAppPurchaseBuilder.withPurchaseData(purchaseData);
                return this;
            }

            public Builder withPrice(string price)
            {
                nativeIHSInAppPurchaseBuilder.withPrice(price);
                return this;
            }

            public Builder withCurrency(string currency)
            {
                nativeIHSInAppPurchaseBuilder.withCurrency(currency);
                return this;
            }
            
            public Builder withSku(string sku)
            {
                nativeIHSInAppPurchaseBuilder.withSku(sku);
                return this;
            }
            
            public Builder withOrderId(string orderId)
            {
                nativeIHSInAppPurchaseBuilder.withOrderId(orderId);
                return this;
            }
            
            public Builder withPurchaseToken(string purchaseToken)
            {
                nativeIHSInAppPurchaseBuilder.withPurchaseToken(purchaseToken);
                return this;
            }
            
            public Builder withPurchaseTimestamp(long purchaseTimestamp)
            {
                nativeIHSInAppPurchaseBuilder.withPurchaseTimestamp(purchaseTimestamp);
                return this;
            }

            
            public Builder withAdditionalParams(Dictionary<string, string> additionalParameters)
            {
                nativeIHSInAppPurchaseBuilder.withAdditionalParams(additionalParameters);
                return this;
            }
    
        }
    }
}