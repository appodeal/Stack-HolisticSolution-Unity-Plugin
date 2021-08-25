#if UNITY_IOS
using System;
using System.Diagnostics.CodeAnalysis;
using AOT;
using AppodealAds.Unity.Api;
using UnityEngine;

namespace StackHolisticSolution.Platforms.iOS
{
    [SuppressMessage("ReSharper", "InconsistentNaming")]
    public class iOSHSAppConfig : IHSAppConfig
    {
        private readonly HSAppConfigObjCBridge hSAppConfigObjCBridge;
        
        private const int AppodealAdTypeInterstitial = 1 << 0;
        private const int AppodealAdTypeBanner = 1 << 2;
        private const int AppodealAdTypeRewardedVideo = 1 << 4;
        private const int AppodealAdTypeMrec = 1 << 5;
        private const int AppodealAdTypeNonSkippableVideo = 1 << 6;

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

        public void setAppKey(string appKey)
        {
            HSAppConfigObjCBridge.setAppKey(appKey);
        }

        public void setAdType(int adType)
        {
            HSAppConfigObjCBridge.setAdType(nativeAdTypesForType(adType));
        }

        public void setComponentInitializeTimeout(long value)
        {
            HSAppConfigObjCBridge.setComponentInitializeTimeout(value);
        }
        
        private static int nativeAdTypesForType(int adTypes)
        {
            var nativeAdTypes = 0;

            if ((adTypes & Appodeal.INTERSTITIAL) > 0)
            {
                nativeAdTypes |= AppodealAdTypeInterstitial;
            }

            if ((adTypes & Appodeal.BANNER) > 0 ||
                (adTypes & Appodeal.BANNER_VIEW) > 0 ||
                (adTypes & Appodeal.BANNER_TOP) > 0 ||
                (adTypes & Appodeal.BANNER_LEFT) > 0 ||
                (adTypes & Appodeal.BANNER_RIGHT) > 0 ||
                (adTypes & Appodeal.BANNER_BOTTOM) > 0)
            {
                nativeAdTypes |= AppodealAdTypeBanner;
            }

            if ((adTypes & Appodeal.MREC) > 0)
            {
                nativeAdTypes |= AppodealAdTypeMrec;
            }

            if ((adTypes & Appodeal.REWARDED_VIDEO) > 0)
            {
                nativeAdTypes |= AppodealAdTypeRewardedVideo;
            }

            if ((adTypes & Appodeal.NON_SKIPPABLE_VIDEO) > 0)
            {
                nativeAdTypes |= AppodealAdTypeNonSkippableVideo;
            }

            return nativeAdTypes;
        }

    }

    [SuppressMessage("ReSharper", "InconsistentNaming")]
    public class iOSHSApp : IHSApp
    {
        private readonly HSAppObjCBridge hsAppObjCBridge;
        private static IHSAppInitializeListener hsAppInitializeListener;
        private static IInAppPurchaseValidationCallback _inAppPurchaseValidationiOSCallback;

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

        public void logEvent(string key)
        {
            hsAppObjCBridge.logEvent(key);
        }

        public string getVersion()
        {
           return hsAppObjCBridge.getVersion();
        }

        public bool isInitialized()
        {
            return hsAppObjCBridge.isInitialized();
        }

        public void validateInAppPurchaseAndroid(HSInAppPurchase purchase, IInAppPurchaseValidationCallback listener)
        {
            Debug.Log("Method void validateInAppPurchaseAndroid(HSInAppPurchase purchase, IHSInAppPurchaseValidateListener listener) not supported on iOS platform");
        }

        public void validateInAppPurchaseiOS(string productIdentifier, string price, string currency,
            string transactionId,
            string additionalParams,iOSPurchaseType type, IInAppPurchaseValidationCallback inAppPurchaseValidationiOSCallback)
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