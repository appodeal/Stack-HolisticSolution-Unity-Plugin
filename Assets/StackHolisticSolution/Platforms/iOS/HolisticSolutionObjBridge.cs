using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.InteropServices;

namespace StackHolisticSolution.Platforms.iOS
{
    [SuppressMessage("ReSharper", "InconsistentNaming")]
    public delegate void HSAppInitializeListener(IntPtr error);
    public delegate void InAppPurchaseValidateSuccess(IntPtr purchase, IntPtr error );
    public delegate void InAppPurchaseValidateFail(IntPtr error);
    
    [SuppressMessage("ReSharper", "InconsistentNaming")]
    internal class HSLoggerObjCBridge
    {
        private readonly IntPtr hSLogger;

        public HSLoggerObjCBridge()
        {
            hSLogger = GetHSLogger();
        }

        public IntPtr getIntPtr()
        {
            return hSLogger;
        }

        public void setEnabled(bool value)
        {
            SetEnabled(value);
        }
        
        [DllImport("__Internal")]
        private static extern IntPtr GetHSLogger();
        
        [DllImport("__Internal")]
        private static extern void SetEnabled(bool value);
    }

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
            SetEventsEnabled(value);
        }
        
        [DllImport("__Internal")]
        private static extern IntPtr GetHSAppodealConnector();
        
        [DllImport("__Internal")]
        private static extern void SetEventsEnabled(bool value);
        
    }
    
    [SuppressMessage("ReSharper", "InconsistentNaming")]
    internal class HSAppsflyerServiceObjCBridge
    {
        private readonly IntPtr hSAppsflyerService;
        
        public HSAppsflyerServiceObjCBridge(string key)
        {
            hSAppsflyerService = GetHSAppsflyerService(key);
        }

        public IntPtr getIntPtr()
        {
            return hSAppsflyerService;
        }
        
        public void setEventsEnabled(bool value)
        {
            SetEventsEnabled(value);
        }
        
        [DllImport("__Internal")]
        private static extern IntPtr GetHSAppsflyerService(string key);
        
        [DllImport("__Internal")]
        private static extern void SetEventsEnabled(bool value);
        
    }
    
    [SuppressMessage("ReSharper", "InconsistentNaming")]
    internal class HSFirebaseServiceObjCBridge
    {
        private readonly IntPtr hSFirebaseService;
        
        public HSFirebaseServiceObjCBridge()
        {
            hSFirebaseService = GetHSFirebaseService();
        }

        public IntPtr getIntPtr()
        {
            return hSFirebaseService;
        }
        
        public void setEventsEnabled(bool value)
        {
            SetEventsEnabled(value);
        }
        
        [DllImport("__Internal")]
        private static extern IntPtr GetHSFirebaseService();
        
        [DllImport("__Internal")]
        private static extern void SetEventsEnabled(bool value);
        
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
            SetEventsEnabled(value);
        }
        
        [DllImport("__Internal")]
        private static extern IntPtr GetHSFacebookService();
        
        [DllImport("__Internal")]
        private static extern void SetEventsEnabled(bool value);
        
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
            WithServices(services);
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
        private static extern void WithServices(IntPtr[] services);
        
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
        
        public void initialize(IntPtr appConfig, HSAppInitializeListener onAppInitialized)
        {
            Initialize(appConfig, onAppInitialized);
        }

        public void logEvent(string key)
        {
            LogEvent(key);
        }

        public void logEvent(string key, Dictionary<string, object> dictionary)
        {
            LogEvent(key, dictionary.ToString());
        }

        public void validateInAppPurchase(IntPtr purchase, InAppPurchaseValidateSuccess onInAppPurchaseValidateSuccess,
            InAppPurchaseValidateFail onInAppPurchaseValidateFail)
        {
          ValidateInAppPurchase(purchase, onInAppPurchaseValidateSuccess, onInAppPurchaseValidateFail);
        }
        
        [DllImport("__Internal")]
        private static extern IntPtr GetHSApp();
        
        [DllImport("__Internal")]
        private static extern void ValidateInAppPurchase(IntPtr purchase, InAppPurchaseValidateSuccess onInAppPurchaseValidateSuccess,
            InAppPurchaseValidateFail onInAppPurchaseValidateFail);
        
        [DllImport("__Internal")]
        private static extern void LogEvent(string key);
        
        [DllImport("__Internal")]
        private static extern void LogEvent(string key, string obj);
        
        [DllImport("__Internal")]
        private static extern void Initialize(IntPtr appConfig, HSAppInitializeListener onAppInitialized);
    }

    [SuppressMessage("ReSharper", "InconsistentNaming")]
    internal class HSErrorObjCBridge
    {
        private readonly IntPtr hSError;
        
        public HSErrorObjCBridge(IntPtr error)
        {
            hSError = error;
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

        public HSInAppPurchaseObjCBridge(IntPtr vendorIntPtr)
        {
            hSInAppPurchase = vendorIntPtr;
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