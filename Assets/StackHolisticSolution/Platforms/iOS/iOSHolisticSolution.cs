#if UNITY_IOS
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using AOT;
using StackHolisticSolution.Api;
using StackHolisticSolution.Common;
using UnityEngine;

namespace StackHolisticSolution.Platforms.iOS
{
    
    [SuppressMessage("ReSharper", "InconsistentNaming")]
    public class iOSHSAppodealConnector : IHSAppodealConnector
    {
        private readonly HSAppodealConnectorObjCBridge hsAppodealConnectorObjCBridge;

        public iOSHSAppodealConnector()
        {
            hsAppodealConnectorObjCBridge = new HSAppodealConnectorObjCBridge();
        }
        
        public IntPtr getIntPtr()
        {
            return hsAppodealConnectorObjCBridge.getIntPtr();
        }

        public void setEventsEnabled(bool value)
        {
            hsAppodealConnectorObjCBridge.setEventsEnabled(value);
        }
    }

    [SuppressMessage("ReSharper", "InconsistentNaming")]
    [SuppressMessage("ReSharper", "UnusedType.Global")]
    public class iOSHSAppsflyerService : IHSAppsflyerService
    {
        private readonly HSAppsflyerServiceObjCBridge hsAppsflyerServiceObjCBridge;

        public iOSHSAppsflyerService(string devKey, string appId, string keys)
        {
            hsAppsflyerServiceObjCBridge = new HSAppsflyerServiceObjCBridge(devKey,  appId, keys);
        }
        
        public IntPtr GetIntPtr()
        {
            return hsAppsflyerServiceObjCBridge.getIntPtr();
        }
        
        public void setEventsEnabled(bool value)
        {
            hsAppsflyerServiceObjCBridge.setEventsEnabled(value);
        }

        public AndroidJavaObject GetAndroidInstance()
        {
            Debug.Log("Not supported");
            return null;
        }
    }
    
    [SuppressMessage("ReSharper", "InconsistentNaming")]
    [SuppressMessage("ReSharper", "UnusedType.Global")]
    public class iOSHSFirebaseService : IHSFirebaseService
    {
        private readonly HSFirebaseServiceObjCBridge hSFirebaseServiceObjCBridge;

        public iOSHSFirebaseService(string defaults, long expirationDuration)
        {
            hSFirebaseServiceObjCBridge = new HSFirebaseServiceObjCBridge(defaults, expirationDuration);
        }
        
        public IntPtr GetIntPtr()
        {
            return hSFirebaseServiceObjCBridge.getIntPtr();
        }
        
        public void setEventsEnabled(bool value)
        {
            hSFirebaseServiceObjCBridge.setEventsEnabled(value);
        }

        public AndroidJavaObject GetAndroidInstance()
        {
            Debug.Log("Not supported");
            return null;
        }
    }
    
    [SuppressMessage("ReSharper", "InconsistentNaming")]
    [SuppressMessage("ReSharper", "UnusedType.Global")]
    public class iOSHSFacebookService : IHSFacebookService
    {
        private readonly HSFacebookServiceObjCBridge hSFacebookServiceObjCBridge;

        public iOSHSFacebookService()
        {
            hSFacebookServiceObjCBridge = new HSFacebookServiceObjCBridge();
        }

        public IntPtr GetIntPtr()
        {
            return hSFacebookServiceObjCBridge.getIntPtr();
        }
        
        public void setEventsEnabled(bool value)
        {
            hSFacebookServiceObjCBridge.setEventsEnabled(value);
        }

        public AndroidJavaObject GetAndroidInstance()
        {
            Debug.Log("Not supported");
            return null;
        }
    }

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
        
        public void withConnectors(HSAppodealConnector hsAppodealConnector)
        {
            var iOSHSAppodealConnector = (iOSHSAppodealConnector) hsAppodealConnector.getHSAppodealConnector();
            hSAppConfigObjCBridge.withConnectors(iOSHSAppodealConnector.getIntPtr());
        }

        public void withServices(params IHSService[] services)
        {
            hSAppConfigObjCBridge.withServices(services.Select
                (service => service.GetIntPtr()).ToArray());
        }

        public void setDebugEnabled(bool value)
        {
            hSAppConfigObjCBridge.setDebugEnabled(value);
        }

        public void setComponentInitializeTimeout(long value)
        {
            hSAppConfigObjCBridge.setComponentInitializeTimeout(value);
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

        public void logEvent(string key, Dictionary<string, object> dictionary)
        {
            hsAppObjCBridge.logEvent(key, dictionary);
        }

        public void logEvent(string key)
        {
            hsAppObjCBridge.logEvent(key);
        }

        public void validateInAppPurchaseAndroid(HSInAppPurchase purchase, IHSInAppPurchaseValidateListener listener)
        {
            Debug.Log("Not supported");
        }

        public void validateInAppPurchaseiOS(string productIdentifier, string price, string currency, string transactionId,
            string additionalParams, IInAppPurchaseValidationiOSCallback inAppPurchaseValidationiOSCallback)
        {
            _inAppPurchaseValidationiOSCallback = inAppPurchaseValidationiOSCallback;
            hsAppObjCBridge.validateInAppPurchaseiOS(productIdentifier,price, currency, transactionId,
                additionalParams, onSuccess, onFailure);
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