#if UNITY_ANDROID
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using AppodealAds.Unity.Android;
using UnityEngine;

namespace StackHolisticSolution
{
    [SuppressMessage("ReSharper", "InconsistentNaming")]
    [SuppressMessage("ReSharper", "UnusedType.Global")]
    [SuppressMessage("ReSharper", "ClassNeverInstantiated.Global")]
    public class AndroidHSAppConfig : IHSAppConfig
    {
        private readonly AndroidJavaObject HSAppConfigInstance =
            new AndroidJavaObject("com.explorestack.hs.sdk.HSAppConfig");
        
        public AndroidJavaObject getHSAppConfigInstance()
        {
            return HSAppConfigInstance;
        }

        public void setDebugEnabled(bool value)
        {
            HSAppConfigInstance.Call<AndroidJavaObject>("setDebugEnabled", value);
        }

        public void setLoggingEnabled(bool value)
        {
            HSAppConfigInstance.Call<AndroidJavaObject>("setLoggingEnabled", value);
        }

        public void setAppKey(string appKey)
        {
            HSAppConfigInstance.Call<AndroidJavaObject>("setAppKey", appKey);
        }

        public void setAdType(int adType)
        {
            HSAppConfigInstance.Call<AndroidJavaObject>("setAdType",
                Helper.getJavaObject(AndroidAppodealClient.nativeAdTypesForType(adType)));
        }

        public void setComponentInitializeTimeout(long value)
        {
            HSAppConfigInstance.Call<AndroidJavaObject>("setComponentInitializeTimeout", value);
        }
    }

    [SuppressMessage("ReSharper", "InconsistentNaming")]
    [SuppressMessage("ReSharper", "UnusedMember.Local")]
    [SuppressMessage("ReSharper", "UnusedType.Global")]
    public class AndroidHSApp : IHSApp
    {
        private readonly AndroidJavaObject HSAppInstance = new AndroidJavaObject("com.explorestack.hs.sdk.HSApp");
        private AndroidJavaObject activity;

        private AndroidJavaObject getActivity()
        {
            if (activity != null) return activity;
            var playerClass = new AndroidJavaClass("com.unity3d.player.UnityPlayer");
            activity = playerClass.GetStatic<AndroidJavaObject>("currentActivity");

            return activity;
        }

        public void initialize(HSAppConfig appConfig, IHSAppInitializeListener hsAppInitializeListener)
        {
            var androidHSAppConfig = (AndroidHSAppConfig) appConfig.getHSAppConfig();
            HSAppInstance.CallStatic("initialize", getActivity(),
                androidHSAppConfig.getHSAppConfigInstance(),
                new AndroidHSAppInitializeListener(hsAppInitializeListener));
        }

        public void logEvent(string key, Dictionary<string, string> eventParams)
        {
            var map = new AndroidJavaObject("java.util.HashMap");
            
            foreach (var entry in eventParams)
            {
                map.Call<AndroidJavaObject>("put", entry.Key, Helper.getJavaObject(entry.Value));
            }

            HSAppInstance.CallStatic("logEvent", Helper.getJavaObject(key), map);
        }

        public void logEvent(string key)
        {
            HSAppInstance.CallStatic("logEvent", Helper.getJavaObject(key));
        }

        public string getVersion()
        {
            return HSAppInstance.CallStatic<string>("getVersion");
        }

        public bool isInitialized()
        {
            return HSAppInstance.CallStatic<bool>("isInitialized");
        }

        public void validateInAppPurchaseAndroid(HSInAppPurchase purchase,
            IInAppPurchaseValidationCallback hsInAppPurchaseValidateListener)
        {
            var androidHSInAppPurchase = (AndroidHSInAppPurchase) purchase.getNativeHSInAppPurchase();
            HSAppInstance.CallStatic("validateInAppPurchase", androidHSInAppPurchase.getHSInAppPurchase(),
                new AndroidHSInAppPurchaseValidateListener(hsInAppPurchaseValidateListener));
        }

        public void validateInAppPurchaseiOS(string productIdentifier, string price, string currency, string transactionId,
            string additionalParams, iOSPurchaseType type,
            IInAppPurchaseValidationCallback inAppPurchaseValidationiOSCallback)
        {
            Debug.Log("Not support");
        }
    }

    [SuppressMessage("ReSharper", "InconsistentNaming")]
    [SuppressMessage("ReSharper", "UnusedType.Global")]
    [SuppressMessage("ReSharper", "UnusedMember.Global")]
    public class AndroidHSError : IHSError
    {
        private readonly AndroidJavaObject HSErrorInstance;

        public AndroidHSError(AndroidJavaObject hsErrorInstance)
        {
            HSErrorInstance = hsErrorInstance;
        }

        public AndroidJavaObject getHSError()
        {
            return HSErrorInstance;
        }

        public string toString()
        {
            return HSErrorInstance.Call<string>("toString");
        }
    }

    [SuppressMessage("ReSharper", "InconsistentNaming")]
    [SuppressMessage("ReSharper", "UnusedType.Global")]
    public class AndroidHSInAppPurchaseBuilder : IHSInAppPurchaseBuilder
    {
        private readonly AndroidJavaObject HSInAppPurchaseBuilder;
        private AndroidJavaObject HSInAppPurchase;

        public AndroidHSInAppPurchaseBuilder(PurchaseType purchaseType)
        {
            switch (purchaseType)
            {
                case PurchaseType.SUBS:
                    HSInAppPurchaseBuilder =
                        new AndroidJavaClass("com.explorestack.hs.sdk.HSInAppPurchase").CallStatic<AndroidJavaObject>(
                            "newBuilder", new AndroidJavaClass("com.explorestack.hs.sdk.HSInAppPurchase$PurchaseType")
                                .GetStatic<AndroidJavaObject>(
                                    "SUBS"));
                    break;
                case PurchaseType.INAPP:
                    HSInAppPurchaseBuilder =
                        new AndroidJavaClass("com.explorestack.hs.sdk.HSInAppPurchase").CallStatic<AndroidJavaObject>(
                            "newBuilder", new AndroidJavaClass("com.explorestack.hs.sdk.HSInAppPurchase$PurchaseType")
                                .GetStatic<AndroidJavaObject>(
                                    "INAPP"));
                    break;
            }
        }

        private AndroidJavaObject getBuilder()
        {
            return HSInAppPurchaseBuilder;
        }

        public IHSInAppPurchase build()
        {
            HSInAppPurchase = new AndroidJavaObject("com.explorestack.hs.sdk.HSInAppPurchase");
            HSInAppPurchase = getBuilder().Call<AndroidJavaObject>("build");
            return new AndroidHSInAppPurchase(HSInAppPurchase);
        }

        public void withPublicKey(string publicKey)
        {
            getBuilder().Call<AndroidJavaObject>("withPublicKey", publicKey);
        }

        public void withPurchaseTimestamp(long purchaseTimestamp)
        {
            getBuilder().Call<AndroidJavaObject>("withPurchaseTimestamp", purchaseTimestamp);
        }

        public void withAdditionalParams(Dictionary<string, string> additionalParameters)
        {
            var map = new AndroidJavaObject("java.util.HashMap");
            foreach (var entry in additionalParameters)
            {
                map.Call<AndroidJavaObject>("put", entry.Key, Helper.getJavaObject(entry.Value));
            }

            getBuilder().Call<AndroidJavaObject>("withAdditionalParams", map);
        }

        public void withCurrency(string currency)
        {
            getBuilder().Call<AndroidJavaObject>("withCurrency", currency);
        }

        public void withSku(string sku)
        {
            getBuilder().Call<AndroidJavaObject>("withSku", sku);
        }

        public void withOrderId(string orderId)
        {
            getBuilder().Call<AndroidJavaObject>("withOrderId", orderId);
        }

        public void withPurchaseToken(string purchaseToken)
        {
            getBuilder().Call<AndroidJavaObject>("withPurchaseToken", purchaseToken);
        }

        public void withPrice(string price)
        {
            getBuilder().Call<AndroidJavaObject>("withPrice", price);
        }

        public void withPurchaseData(string purchaseData)
        {
            getBuilder().Call<AndroidJavaObject>("withPurchaseData", purchaseData);
        }

        public void withSignature(string signature)
        {
            getBuilder().Call<AndroidJavaObject>("withSignature", signature);
        }

        public void withDeveloperPayload(string developerPayload) 
        {
            getBuilder().Call<AndroidJavaObject>("withDeveloperPayload", developerPayload);
        }
    }

    [SuppressMessage("ReSharper", "InconsistentNaming")]
    public class AndroidHSInAppPurchase : IHSInAppPurchase
    {
        private readonly AndroidJavaObject HSInAppPurchase;

        public AndroidHSInAppPurchase(AndroidJavaObject hSInAppPurchase)
        {
            HSInAppPurchase = hSInAppPurchase;
        }

        public AndroidJavaObject getHSInAppPurchase()
        {
            return HSInAppPurchase;
        }

        public PurchaseType getType()
        {
            var purchaseType = PurchaseType.SUBS;
            var type = HSInAppPurchase.Call<AndroidJavaObject>("getType").Call<string>("toString");
            switch (type)
            {
                case "SUBS":
                    purchaseType = PurchaseType.SUBS;
                    break;
                case "INAPP":
                    purchaseType = PurchaseType.INAPP;
                    break;
            }

            return purchaseType;
        }

        public string getPublicKey()
        {
            return HSInAppPurchase.Call<string>("getPublicKey");
        }

        public string getSignature()
        {
            return HSInAppPurchase.Call<string>("getSignature");
        }

        public string getPurchaseData()
        {
            return HSInAppPurchase.Call<string>("getPurchaseData");
        }

        public string getPrice()
        {
            return HSInAppPurchase.Call<string>("getPrice");
        }

        public string getCurrency()
        {
            return HSInAppPurchase.Call<string>("getCurrency");
        }

        public string getSku()
        {
            return HSInAppPurchase.Call<string>("getSku");
        }

        public string getOrderId()
        {
            return HSInAppPurchase.Call<string>("getOrderId");
        }

        public string getPurchaseToken()
        {
            return HSInAppPurchase.Call<string>("getPurchaseToken");
        }

        public long getPurchaseTimestamp()
        {
            return HSInAppPurchase.Call<long>("getPurchaseTimestamp");
        }

        public string getAdditionalParameters()
        {
            return HSInAppPurchase.Call<AndroidJavaObject>("getAdditionalParameters").Call<string>("toString");
        }

        public string getDeveloperPayload()
        {
            return HSInAppPurchase.Call<string>("getDeveloperPayload");
        }
    }

    [SuppressMessage("ReSharper", "InconsistentNaming")]
    [SuppressMessage("ReSharper", "ConstantNullCoalescingCondition")]
    public static class Helper
    {
        public static object getJavaObject(object value)
        {
            if (value is string)
            {
                return value;
            }

            if (value is char)
            {
                return new AndroidJavaObject("java.lang.Character", value);
            }

            if (value is bool)
            {
                return new AndroidJavaObject("java.lang.Boolean", value);
            }

            if (value is int)
            {
                return new AndroidJavaObject("java.lang.Integer", value);
            }

            if (value is long)
            {
                return new AndroidJavaObject("java.lang.Long", value);
            }

            if (value is float)
            {
                return new AndroidJavaObject("java.lang.Float", value);
            }

            if (value is double)
            {
                return new AndroidJavaObject("java.lang.Float", value);
            }

            return value ?? null;
        }
    }
}
#endif