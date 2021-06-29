#if UNITY_IOS
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Runtime.InteropServices;

namespace StackHolisticSolution.Platforms.iOS
{
    [SuppressMessage("ReSharper", "InconsistentNaming")]
    public delegate void HSUSdkInitialisationCallback(string error);

    [SuppressMessage("ReSharper", "InconsistentNaming")]
    public delegate void HSUSdkInAppPurchaseValidationSuccessCallback(string json);

    [SuppressMessage("ReSharper", "InconsistentNaming")]
    public delegate void HSUSdkInAppPurchaseValidationFailureCallback(string error);

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
        
        public static void setLoggingEnabled(bool value)
        {
            SetLoggingEnabled(value);
        }

        public static void setAppKey(string appKey)
        {
            SetAppKey(appKey);
        }

        public static void setAdType(int adType)
        {
            SetAdType(adType);
        }

        public static void setDebugEnabled(bool value)
        {
            SetDebugEnabled(value);
        }

        public static void setComponentInitializeTimeout(long value)
        {
            SetComponentInitializeTimeout(value);
        }

        [DllImport("__Internal")]
        private static extern IntPtr GetHSAppConfig();

        [DllImport("__Internal")]
        private static extern void SetDebugEnabled(bool value);

        [DllImport("__Internal")]
        private static extern void SetComponentInitializeTimeout(long value);
        
        [DllImport("__Internal")]
        private static extern void SetLoggingEnabled(bool value);
        
        [DllImport("__Internal")]
        private static extern void SetAppKey(string appKey);

        [DllImport("__Internal")]
        private static extern void SetAdType(int adType);
        
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
            string additionalParams, 
            iOSPurchaseType type,
            
            HSUSdkInAppPurchaseValidationSuccessCallback success,
            HSUSdkInAppPurchaseValidationFailureCallback failure)
        {
            ValidateInAppPurchase(productIdentifier, price, currency, transactionId, additionalParams, (int) type, success,
                failure);
        }

        public string getVersion()
        {
            return GetVersion();
        }

        public bool isInitialized()
        {
            return IsInitialized();
        }

        [DllImport("__Internal")]
        private static extern IntPtr GetHSApp();

        [DllImport("__Internal")]
        private static extern void ValidateInAppPurchase(string productIdentifier, string price, string currency,
            string transactionId,
            string additionalParams,
            int type,
            HSUSdkInAppPurchaseValidationSuccessCallback success,
            HSUSdkInAppPurchaseValidationFailureCallback failure);

        [DllImport("__Internal")]
        private static extern bool IsInitialized();
        
        [DllImport("__Internal")]
        private static extern string GetVersion();

        [DllImport("__Internal")]
        private static extern void LogEvent(string key, string obj);

        [DllImport("__Internal")]
        private static extern void Initialize(IntPtr appConfig, HSUSdkInitialisationCallback onInitialize);
    }

}
#endif