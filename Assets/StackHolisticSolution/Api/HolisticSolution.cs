using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using StackHolisticSolution.Common;
using StackHolisticSolution.Platforms;

namespace StackHolisticSolution.Api
{
    [SuppressMessage("ReSharper", "InconsistentNaming")]
    public class HSAppodealConnector
    {
        private readonly IHSAppodealConnector nativeHSAppodealConnector;

        public IHSAppodealConnector getHSAppodealConnector()
        {
            return nativeHSAppodealConnector;
        }

        public HSAppodealConnector()
        {
            nativeHSAppodealConnector = HolisticSolutionClientFactory.GetHSAppodealConnector();
        }

        public void setEventsEnabled(bool value)
        {
            getHSAppodealConnector().setEventsEnabled(value);
        }
    }

    [SuppressMessage("ReSharper", "InconsistentNaming")]
    public class HSAppsflyerService
    {
        private readonly IHSAppsflyerService nativeHSAppsflyerService;

        public IHSAppsflyerService getHSAppsflyerService()
        {
            return nativeHSAppsflyerService;
        }

        public HSAppsflyerService(string sellerId)
        {
            nativeHSAppsflyerService = HolisticSolutionClientFactory.GetHSAppsflyerService(sellerId);
        }

        public HSAppsflyerService(string devkey, string defaults, string[] keys)
        {
            nativeHSAppsflyerService =
                HolisticSolutionClientFactory.GetHSAppsflyerService(devkey, defaults, string.Join(",", keys));
        }

        public void setEventsEnabled(bool value)
        {
            nativeHSAppsflyerService.setEventsEnabled(value);
        }
    }

    [SuppressMessage("ReSharper", "InconsistentNaming")]
    public class HSFirebaseService
    {
        private readonly IHSFirebaseService nativeHSFirebaseService;

        public IHSFirebaseService getHSFirebaseService()
        {
            return nativeHSFirebaseService;
        }

        public HSFirebaseService()
        {
            nativeHSFirebaseService = HolisticSolutionClientFactory.GetHSFirebaseService();
        }

        public HSFirebaseService(Dictionary<string, string> defaults, long expirationDuration)
        {
            string defaultsString =
                defaults.Aggregate("", (current, kvp) => current + (kvp.Key + "=" + kvp.Value + "\n"));
            nativeHSFirebaseService =
                HolisticSolutionClientFactory.GetHSFirebaseService(defaultsString, expirationDuration);
        }

        public void setEventsEnabled(bool value)
        {
            nativeHSFirebaseService.setEventsEnabled(value);
        }
    }

    [SuppressMessage("ReSharper", "InconsistentNaming")]
    public class HSFacebookService
    {
        private readonly IHSFacebookService nativeHSFacebookService;

        public IHSFacebookService getHSFacebookService()
        {
            return nativeHSFacebookService;
        }

        public HSFacebookService()
        {
            nativeHSFacebookService = HolisticSolutionClientFactory.GetHSFacebookService();
        }

        public void setEventsEnabled(bool value)
        {
            nativeHSFacebookService.setEventsEnabled(value);
        }
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

        public HSAppConfig withConnectors(HSAppodealConnector connector)
        {
            nativeHSAppConfig.withConnectors(connector);
            return this;
        }

        public HSAppConfig withServices(params IHSService[] services)
        {
            nativeHSAppConfig.withServices(services);
            return this;
        }

        public HSAppConfig setDebugEnabled(bool value)
        {
            nativeHSAppConfig.setDebugEnabled(value);
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

        public static void logEvent(string key, Dictionary<string, object> dictionary)
        {
            getInstance().logEvent(key, dictionary);
        }

        public static void logEvent(string key)
        {
            getInstance().logEvent(key);
        }

        public static void validateInAppPurchaseAndroid(HSInAppPurchase purchase,
            IHSInAppPurchaseValidateListener hsInAppPurchaseValidateListener)
        {
            getInstance().validateInAppPurchaseAndroid(purchase, hsInAppPurchaseValidateListener);
        }

        public static void validateInAppPurchaseiOS(string productIdentifier, string price, string currency,
            string transactionId,
            string additionalParams, IInAppPurchaseValidationiOSCallback inAppPurchaseValidationiOSCallback)
        {
            getInstance().validateInAppPurchaseiOS(productIdentifier, price, currency, transactionId, additionalParams, inAppPurchaseValidationiOSCallback);
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

            public Builder()
            {
                nativeIHSInAppPurchaseBuilder =
                    HolisticSolutionClientFactory.GetInAppPurchaseBuilder();
            }

            public HSInAppPurchase build()
            {
                return new HSInAppPurchase(nativeIHSInAppPurchaseBuilder.build());
            }

            public Builder withAdditionalParams(Dictionary<string, string> additionalParameters)
            {
                nativeIHSInAppPurchaseBuilder.withAdditionalParams(additionalParameters);
                return this;
            }

            public Builder withCurrency(string currency)
            {
                nativeIHSInAppPurchaseBuilder.withCurrency(currency);
                return this;
            }

            public Builder withPrice(string price)
            {
                nativeIHSInAppPurchaseBuilder.withPrice(price);
                return this;
            }

            public Builder withPurchaseData(string purchaseData)
            {
                nativeIHSInAppPurchaseBuilder.withPurchaseData(purchaseData);
                return this;
            }

            public Builder withSignature(string signature)
            {
                nativeIHSInAppPurchaseBuilder.withSignature(signature);
                return this;
            }

            public Builder withPublicKey(string publicKey)
            {
                nativeIHSInAppPurchaseBuilder.withPublicKey(publicKey);
                return this;
            }
        }
    }
}