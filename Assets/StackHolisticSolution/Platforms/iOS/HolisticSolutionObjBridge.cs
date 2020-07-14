#if UNITY_IOS
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Runtime.InteropServices;
using UnityEngine;

namespace StackHolisticSolution.Platforms.iOS
{
    [SuppressMessage("ReSharper", "InconsistentNaming")]
    public delegate void HSUSdkInitialisationCallback(string error);

    [SuppressMessage("ReSharper", "InconsistentNaming")]
    public delegate void HSUSdkInAppPurchaseValidationSuccessCallback(string json);

    [SuppressMessage("ReSharper", "InconsistentNaming")]
    public delegate void HSUSdkInAppPurchaseValidationFailureCallback(string error);

    [SuppressMessage("ReSharper", "InconsistentNaming")]
    internal class HSAppodealConnectorObjCBridge
    {
        private readonly IntPtr hSAppodealConnector;

        public HSAppodealConnectorObjCBridge()
        {
            hSAppodealConnector = GetHSAppodealConnector();
        }

        public IntPtr getIntPtr()
        {
            return hSAppodealConnector;
        }

        public void setEventsEnabled(bool value)
        {
            Debug.Log("Not supported");
        }

        [DllImport("__Internal")]
        private static extern IntPtr GetHSAppodealConnector();
    }

    [SuppressMessage("ReSharper", "InconsistentNaming")]
    internal class HSAppsflyerServiceObjCBridge
    {
        private readonly IntPtr hSAppsflyerService;

        public HSAppsflyerServiceObjCBridge(string devKey, string appId, string keys)
        {
            hSAppsflyerService = GetHSAppsflyerService(devKey, appId, keys);
        }

        public IntPtr getIntPtr()
        {
            return hSAppsflyerService;
        }

        public void setEventsEnabled(bool value)
        {
            Debug.Log("Not supported");
        }

        [DllImport("__Internal")]
        private static extern IntPtr GetHSAppsflyerService(string devKey, string appId, string keys);
    }

    [SuppressMessage("ReSharper", "InconsistentNaming")]
    internal class HSFirebaseServiceObjCBridge
    {
        private readonly IntPtr hSFirebaseService;

        public HSFirebaseServiceObjCBridge(string defaults, long expirationDuration)
        {
            hSFirebaseService = GetHSFirebaseService(defaults, expirationDuration);
        }

        public IntPtr getIntPtr()
        {
            return hSFirebaseService;
        }

        public void setEventsEnabled(bool value)
        {
            Debug.Log("Not supported");
        }

        [DllImport("__Internal")]
        private static extern IntPtr GetHSFirebaseService(string defaults, long expirationDuration);
    }

    [SuppressMessage("ReSharper", "InconsistentNaming")]
    internal class HSFacebookServiceObjCBridge
    {
        private readonly IntPtr hSFacebookService;


        public HSFacebookServiceObjCBridge()
        {
            hSFacebookService = GetHSFacebookService();
        }

        public IntPtr getIntPtr()
        {
            return hSFacebookService;
        }

        public void setEventsEnabled(bool value)
        {
            Debug.Log("Not supported");
        }

        [DllImport("__Internal")]
        private static extern IntPtr GetHSFacebookService();
    }

    [SuppressMessage("ReSharper", "InconsistentNaming")]
    internal class HSAppConfigObjCBridge
    {
        private readonly IntPtr hSAppConfig;

        public HSAppConfigObjCBridge()
        {
            hSAppConfig = GetHSAppConfig();
        }

        public IntPtr getIntPtr()
        {
            return hSAppConfig;
        }

        public void withConnectors(IntPtr hsAppodealConnector)
        {
            WithConnectors(hsAppodealConnector);
        }

        public void withServices(IntPtr[] services)
        {
            for (int i = 0; i < services.Length; i++)
            {
                WithService(services[i]);
            }
        }

        public void setDebugEnabled(bool value)
        {
            SetDebugEnabled(value);
        }

        [DllImport("__Internal")]
        private static extern IntPtr GetHSAppConfig();

        [DllImport("__Internal")]
        private static extern void SetDebugEnabled(bool value);

        [DllImport("__Internal")]
        private static extern void WithService(IntPtr services);

        [DllImport("__Internal")]
        private static extern void WithConnectors(IntPtr connector);
    }

    [SuppressMessage("ReSharper", "InconsistentNaming")]
    internal class HSAppObjCBridge
    {
        private readonly IntPtr hSApp;

        public HSAppObjCBridge()
        {
            hSApp = GetHSApp();
        }

        public IntPtr getIntPtr()
        {
            return hSApp;
        }

        public void initialize(IntPtr appConfig, HSUSdkInitialisationCallback onInitialize)
        {
            Initialize(appConfig, onInitialize);
        }

        public void logEvent(string key)
        {
           // LogEvent(key);
        }

        public void logEvent(string key, Dictionary<string, object> dictionary)
        {
            var defaultsString =
                dictionary.Aggregate("", (current, kvp) => current + (kvp.Key + "=" + kvp.Value + "\n"));
            LogEvent(key, defaultsString);
        }


        public void validateInAppPurchaseiOS(string productIdentifier, string price, string currency,
            string transactionId,
            string additionalParams, HSUSdkInAppPurchaseValidationSuccessCallback success,
            HSUSdkInAppPurchaseValidationFailureCallback failure)
        {
            ValidateInAppPurchase(productIdentifier, price, currency, transactionId, additionalParams, success,
                failure);
        }


        [DllImport("__Internal")]
        private static extern IntPtr GetHSApp();

        [DllImport("__Internal")]
        private static extern void ValidateInAppPurchase(string productIdentifier, string price, string currency,
            string transactionId,
            string additionalParams, HSUSdkInAppPurchaseValidationSuccessCallback success,
            HSUSdkInAppPurchaseValidationFailureCallback failure);



        [DllImport("__Internal")]
        private static extern void LogEvent(string key, string obj);

        [DllImport("__Internal")]
        private static extern void Initialize(IntPtr appConfig, HSUSdkInitialisationCallback onInitialize);
    }

    [SuppressMessage("ReSharper", "InconsistentNaming")]
    internal class HSErrorObjCBridge
    {
        private readonly IntPtr hSError;

        public HSErrorObjCBridge(IntPtr error)
        {
            hSError = GetHSError(error);
        }

        public IntPtr getIntPtr()
        {
            return hSError;
        }

        public string toString()
        {
            return ToStringError();
        }

        [DllImport("__Internal")]
        public static extern IntPtr GetHSError(IntPtr intPtr);

        [DllImport("__Internal")]
        public static extern string ToStringError();
    }

    [SuppressMessage("ReSharper", "InconsistentNaming")]
    internal class HSInAppPurchaseObjCBridge
    {
        private readonly IntPtr hSInAppPurchase;

        public HSInAppPurchaseObjCBridge()
        {
            hSInAppPurchase = GetHSInAppPurchase();
        }

        public HSInAppPurchaseObjCBridge(IntPtr inAppPurchase)
        {
            hSInAppPurchase = inAppPurchase;
        }

        public IntPtr getIntPtr()
        {
            return hSInAppPurchase;
        }

        public string getPublicKey()
        {
            return GetPublicKey();
        }

        public string getSignature()
        {
            return GetSignature();
        }

        public string getPurchaseData()
        {
            return GetPurchaseData();
        }

        public string getPrice()
        {
            return GetPrice();
        }

        public string getCurrency()
        {
            return GetCurrency();
        }

        public string getAdditionalParameters()
        {
            return GetAdditionalParameters();
        }

        [DllImport("__Internal")]
        private static extern IntPtr GetHSInAppPurchase();

        [DllImport("__Internal")]
        private static extern string GetPublicKey();

        [DllImport("__Internal")]
        private static extern string GetSignature();

        [DllImport("__Internal")]
        private static extern string GetPurchaseData();

        [DllImport("__Internal")]
        private static extern string GetPrice();

        [DllImport("__Internal")]
        private static extern string GetCurrency();

        [DllImport("__Internal")]
        private static extern string GetAdditionalParameters();
    }

    [SuppressMessage("ReSharper", "InconsistentNaming")]
    internal class HSInAppPurchaseBuilderObjCBridge
    {
        private readonly IntPtr hSInAppPurchaseBuilder;

        public HSInAppPurchaseBuilderObjCBridge()
        {
            hSInAppPurchaseBuilder = GetHSInAppPurchaseBuilder();
        }

        public IntPtr getIntPtr()
        {
            return hSInAppPurchaseBuilder;
        }

        public void withAdditionalParams(Dictionary<string, string> additionalParameters)
        {
            WithAdditionalParams(additionalParameters.ToString());
        }

        public void withCurrency(string currency)
        {
            WithCurrency(currency);
        }

        public void withPrice(string price)
        {
            WithPrice(price);
        }

        public void withPurchaseData(string purchaseData)
        {
            WithPurchaseData(purchaseData);
        }

        public void withSignature(string signature)
        {
            WithSignature(signature);
        }

        public void withPublicKey(string publicKey)
        {
            WithPublicKey(publicKey);
        }

        [DllImport("__Internal")]
        private static extern IntPtr GetHSInAppPurchaseBuilder();

        [DllImport("__Internal")]
        private static extern string WithAdditionalParams(string additionalParameters);

        [DllImport("__Internal")]
        private static extern string WithCurrency(string currency);

        [DllImport("__Internal")]
        private static extern string WithPrice(string price);

        [DllImport("__Internal")]
        private static extern string WithPurchaseData(string purchaseData);

        [DllImport("__Internal")]
        private static extern string WithSignature(string signature);

        [DllImport("__Internal")]
        private static extern string WithPublicKey(string publicKey);
    }
}
#endif