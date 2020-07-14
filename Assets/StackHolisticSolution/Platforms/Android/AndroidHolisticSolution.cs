#if UNITY_ANDROID
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using StackHolisticSolution.Api;
using StackHolisticSolution.Common;
using UnityEngine;


namespace StackHolisticSolution.Platforms.Android
{

    [SuppressMessage("ReSharper", "InconsistentNaming")]
    [SuppressMessage("ReSharper", "UnusedType.Global")]
    [SuppressMessage("ReSharper", "NotAccessedField.Local")]
    [SuppressMessage("ReSharper", "ClassNeverInstantiated.Global")]
    public class AndroidHSAppodealConnector : IHSAppodealConnector
    {
        private readonly AndroidJavaObject HSAppodealConnectorInstance;

        public AndroidHSAppodealConnector()
        {
            HSAppodealConnectorInstance = new AndroidJavaObject(
                "com.explorestack.hs.sdk.connector.appodeal.HSAppodealConnector");
        }

        public AndroidJavaObject getAndroidHSAppodealConnector()
        {
            return HSAppodealConnectorInstance;
        }

        public void setEventsEnabled(bool value)
        {
            HSAppodealConnectorInstance.Call("setEventsEnabled", value);
        }
    }

    [SuppressMessage("ReSharper", "InconsistentNaming")]
    [SuppressMessage("ReSharper", "UnusedType.Global")]
    [SuppressMessage("ReSharper", "ClassNeverInstantiated.Global")]
    public class AndroidHSAppsflyerService : IHSAppsflyerService
    {
        private readonly AndroidJavaObject HSAppsflyerServiceInstance;

        public AndroidHSAppsflyerService(string key)
        {
            var androidJavaObject = new AndroidJavaObject("java.lang.String", key);
            HSAppsflyerServiceInstance = new AndroidJavaObject(
                "com.explorestack.hs.sdk.service.appsflyer.HSAppsflyerService",
                androidJavaObject);
        }

        public AndroidJavaObject getJavaObjectHSAppsflyerService()
        {
            return HSAppsflyerServiceInstance;
        }

        public AndroidJavaObject GetAndroidInstance()
        {
            return HSAppsflyerServiceInstance;
        }

        public IntPtr GetIntPtr()
        {
            return new IntPtr();
        }

        public void setEventsEnabled(bool value)
        {
            HSAppsflyerServiceInstance.Call("setEventsEnabled", value);
        }
    }

    [SuppressMessage("ReSharper", "InconsistentNaming")]
    [SuppressMessage("ReSharper", "UnusedType.Global")]
    [SuppressMessage("ReSharper", "ClassNeverInstantiated.Global")]
    public class AndroidHSFirebaseService : IHSFirebaseService
    {
        private readonly AndroidJavaObject HSFirebaseServiceInstance;

        public AndroidHSFirebaseService()
        {
            HSFirebaseServiceInstance = new AndroidJavaObject(
                "com.explorestack.hs.sdk.service.firebase.HSFirebaseService");
        }

        public AndroidJavaObject getAndroidHSFirebaseService()
        {
            return HSFirebaseServiceInstance;
        }

        public AndroidJavaObject GetAndroidInstance()
        {
            return HSFirebaseServiceInstance;
        }

        public IntPtr GetIntPtr()
        {
            return new IntPtr();
        }

        public void setEventsEnabled(bool value)
        {
            HSFirebaseServiceInstance.Call("setEventsEnabled", value);
        }
    }

    [SuppressMessage("ReSharper", "InconsistentNaming")]
    [SuppressMessage("ReSharper", "ClassNeverInstantiated.Global")]
    [SuppressMessage("ReSharper", "UnusedType.Global")]
    public class AndroidHSFacebookService : IHSFacebookService
    {
        private readonly AndroidJavaObject HSFacebookServiceInstance;

        public AndroidHSFacebookService()
        {
            HSFacebookServiceInstance = new AndroidJavaObject(
                "com.explorestack.hs.sdk.service.facebook.HSFacebookService");
        }

        public AndroidJavaObject getAndroidHSFacebookService()
        {
            return HSFacebookServiceInstance;
        }

        public AndroidJavaObject GetAndroidInstance()
        {
            return HSFacebookServiceInstance;
        }

        public IntPtr GetIntPtr()
        {
            return new IntPtr();
        }

        public void setEventsEnabled(bool value)
        {
            HSFacebookServiceInstance.Call("setEventsEnabled", value);
        }
    }

    [SuppressMessage("ReSharper", "InconsistentNaming")]
    [SuppressMessage("ReSharper", "UnusedType.Global")]
    [SuppressMessage("ReSharper", "ClassNeverInstantiated.Global")]
    public class AndroidHSAppConfig : IHSAppConfig
    {
        private AndroidJavaObject HSAppConfigInstance = new AndroidJavaObject("com.explorestack.hs.sdk.HSAppConfig");
        private AndroidJavaClass HSAppConfigClass;

        private AndroidJavaClass getHSAppConfigClass()
        {
            return HSAppConfigClass ?? (HSAppConfigClass = new AndroidJavaClass("com.explorestack.hs.sdk.HSAppConfig"));
        }

        public AndroidJavaObject getHSAppConfigInstance()
        {
            return HSAppConfigInstance;
        }

        public void setDebugEnabled(bool value)
        {
            HSAppConfigInstance.Call<AndroidJavaObject>("setDebugEnabled", value);
        }

        public void withConnectors(HSAppodealConnector hsAppodealConnector)
        {
            var androidHSAppodealConnector = (AndroidHSAppodealConnector) hsAppodealConnector.getHSAppodealConnector();
            AndroidJavaObject[] objects = {androidHSAppodealConnector.getAndroidHSAppodealConnector()};
            var eventMethod = AndroidJNI.GetMethodID(getHSAppConfigClass().GetRawClass(),
                "withConnectors", "([Lcom/explorestack/hs/sdk/HSConnector;)Lcom/explorestack/hs/sdk/HSAppConfig;");
            var args = AndroidJNIHelper.CreateJNIArgArray(new object[] {objects});
            AndroidJNI.CallObjectMethod(HSAppConfigInstance.GetRawObject(), eventMethod, args);
        }

        public void withServices(params IHSService[] services)
        {
            var eventMethod = AndroidJNI.GetMethodID(getHSAppConfigClass().GetRawClass(),
                "withServices", "([Lcom/explorestack/hs/sdk/HSService;)Lcom/explorestack/hs/sdk/HSAppConfig;");

            var androidJavaObjects =
                services.Select(e => e.GetAndroidInstance()).ToArray();

            var args = AndroidJNIHelper.CreateJNIArgArray(new object[]
            {
                javaArrayFromCS(androidJavaObjects,
                    "com.explorestack.hs.sdk.HSService")
            });

            AndroidJNI.CallObjectMethod(HSAppConfigInstance.GetRawObject(), eventMethod, args);
        }

        private static AndroidJavaObject javaArrayFromCS(IReadOnlyList<AndroidJavaObject> values, string classType)
        {
            var arrayClass = new AndroidJavaClass("java.lang.reflect.Array");
            var arrayObject = arrayClass.CallStatic<AndroidJavaObject>("newInstance",
                new AndroidJavaClass(classType),
                values.Count);
            for (var i = 0; i < values.Count; ++i)
            {
                arrayClass.CallStatic("set", arrayObject, i, values[i]);
            }

            return arrayObject;
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

        public void logEvent(string key, Dictionary<string, object> dictionary)
        {
            var map = new AndroidJavaObject("java.util.HashMap");
            foreach (var entry in dictionary)
            {
                map.Call<AndroidJavaObject>("put", entry.Key, Helper.getJavaObject(entry.Value));
            }

            HSAppInstance.CallStatic("logEvent", Helper.getJavaObject(key), map);
        }

        public void logEvent(string key)
        {
            HSAppInstance.CallStatic("logEvent", Helper.getJavaObject(key));
        }

        public void validateInAppPurchaseAndroid(HSInAppPurchase purchase,
            IHSInAppPurchaseValidateListener hsInAppPurchaseValidateListener)
        {
            var androidHSInAppPurchase = (AndroidHSInAppPurchase) purchase.getNativeHSInAppPurchase();
            HSAppInstance.CallStatic("validateInAppPurchase", androidHSInAppPurchase.getHSInAppPurchase(),
                new AndroidHSInAppPurchaseValidateListener(hsInAppPurchaseValidateListener));
        }

        public void validateInAppPurchaseiOS(string productIdentifier, string price, string currency,
            string transactionId,
            string additionalParams, IInAppPurchaseValidationiOSCallback inAppPurchaseValidationiOSCallback)
        {
            Debug.Log("Not support");
        }
    }

    [SuppressMessage("ReSharper", "InconsistentNaming")]
    [SuppressMessage("ReSharper", "UnusedType.Global")]
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

        public AndroidHSInAppPurchaseBuilder()
        {
            HSInAppPurchaseBuilder =
                new AndroidJavaClass("com.explorestack.hs.sdk.HSInAppPurchase").CallStatic<AndroidJavaObject>(
                    "newBuilder");
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
            getBuilder().Call<AndroidJavaObject>("withPublicKey", Helper.getJavaObject(publicKey));
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
            getBuilder().Call<AndroidJavaObject>("withCurrency", Helper.getJavaObject(currency));
        }

        public void withPrice(string price)
        {
            getBuilder().Call<AndroidJavaObject>("withPrice", Helper.getJavaObject(price));
        }

        public void withPurchaseData(string purchaseData)
        {
            getBuilder().Call<AndroidJavaObject>("withPurchaseData", Helper.getJavaObject(purchaseData));
        }

        public void withSignature(string signature)
        {
            getBuilder().Call<AndroidJavaObject>("withSignature", Helper.getJavaObject(signature));
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

        public string getAdditionalParameters()
        {
            return HSInAppPurchase.Call<AndroidJavaObject>("getAdditionalParameters").Call<string>("toString");
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