#if UNITY_IOS
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using AOT;
using UnityEngine;

namespace StackHolisticSolution.Platforms.iOS
{
    [SuppressMessage("ReSharper", "InconsistentNaming")]
    public class iOSHSAppConfig : IHSAppConfig
    {
        private readonly HSAppConfigObjCBridge hSAppConfigObjCBridge;

        public iOSHSAppConfig()
        {
            hSAppConfigObjCBridge = new HSAppConfigObjCBridge();
        }

        public IntPtr getIntPtr()
        {
            return hSAppConfigObjCBridge.getIntPtr();
        }

        public void setDebugEnabled(bool value)
        {
            HSAppConfigObjCBridge.setDebugEnabled(value);
        }

        public void setLoggingEnabled(bool value)
        {
            HSAppConfigObjCBridge.setLoggingEnabled(value);
        }

        public void setAppKey(string appKey)
        {
            HSAppConfigObjCBridge.setAppKey(appKey);
        }

        public void setAdType(int adType)
        {
            HSAppConfigObjCBridge.setAdType(adType);
        }

        public void setComponentInitializeTimeout(long value)
        {
            HSAppConfigObjCBridge.setComponentInitializeTimeout(value);
        }
    }

    [SuppressMessage("ReSharper", "InconsistentNaming")]
    public class iOSHSApp : IHSApp
    {
        private readonly HSAppObjCBridge hsAppObjCBridge;
        private static IHSAppInitializeListener hsAppInitializeListener;
        private static IInAppPurchaseValidationiOSCallback _inAppPurchaseValidationiOSCallback;

        public iOSHSApp()
        {
            hsAppObjCBridge = new HSAppObjCBridge();
        }

        public void initialize(HSAppConfig appConfig, IHSAppInitializeListener listener)
        {
            hsAppInitializeListener = listener;
            var iOSAppConfig = (iOSHSAppConfig) appConfig.getHSAppConfig();
            hsAppObjCBridge.initialize(iOSAppConfig.getIntPtr(), onAppInitialized);
        }

        public void logEventiOS(string key, Dictionary<string, object> dictionary)
        {
            hsAppObjCBridge.logEvent(key, dictionary);
        }

        public void logEventAndroid(string key)
        {
            Debug.Log("Method void logEventAndroid(string key) not supported on iOS platform");
        }

        public string getVersion()
        {
           return hsAppObjCBridge.getVersion();
        }

        public bool isInitialized()
        {
            return hsAppObjCBridge.isInitialized();
        }

        public void validateInAppPurchaseAndroid(HSInAppPurchase purchase, IHSInAppPurchaseValidateListener listener)
        {
            Debug.Log("Method void validateInAppPurchaseAndroid(HSInAppPurchase purchase, IHSInAppPurchaseValidateListener listener) not supported on iOS platform");
        }

        public void validateInAppPurchaseiOS(string productIdentifier, string price, string currency,
            string transactionId,
            string additionalParams,iOSPurchaseType type, IInAppPurchaseValidationiOSCallback inAppPurchaseValidationiOSCallback)
        {
            _inAppPurchaseValidationiOSCallback = inAppPurchaseValidationiOSCallback;
            hsAppObjCBridge.validateInAppPurchaseiOS(productIdentifier, price, currency, transactionId,
                additionalParams, type, onSuccess, onFailure);
        }

        #region HSAppInitializeListener delegate

        [MonoPInvokeCallback(typeof(HSUSdkInitialisationCallback))]
        private static void onAppInitialized(string error)
        {
            hsAppInitializeListener?.onAppInitialized(error);
        }

        #endregion

        #region HSAppInitializeListeneriOS

        [MonoPInvokeCallback(typeof(HSUSdkInAppPurchaseValidationSuccessCallback))]
        private static void onSuccess(string json)
        {
            _inAppPurchaseValidationiOSCallback?.InAppPurchaseValidationSuccessCallback(json);
        }

        [MonoPInvokeCallback(typeof(HSUSdkInAppPurchaseValidationFailureCallback))]
        private static void onFailure(string error)
        {
            _inAppPurchaseValidationiOSCallback?.InAppPurchaseValidationFailureCallback(error);
        }

        #endregion
    }
}
#endif