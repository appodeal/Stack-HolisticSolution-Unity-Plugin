using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using StackHolisticSolution.Api;
using StackHolisticSolution.Common;
using UnityEngine;

namespace StackHolisticSolution.Platforms.Android
{
    [SuppressMessage("ReSharper", "InconsistentNaming")]
    [SuppressMessage("ReSharper", "ClassNeverInstantiated.Global")]
    public class AndroidHSLogger : IHSLogger
    {
        private AndroidJavaClass HSLoggerClass;

        private AndroidJavaClass getHSLoggerClass()
        {
            return HSLoggerClass ?? (HSLoggerClass = new AndroidJavaClass("com.explorestack.hs.sdk.HSLogger"));
        }

        public void setEnabled(bool value)
        {
            getHSLoggerClass().CallStatic("setEnabled", value);
        }
    }

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
    }

    [SuppressMessage("ReSharper", "InconsistentNaming")]
    [SuppressMessage("ReSharper", "ClassNeverInstantiated.Global")]
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

            Debug.LogError(args.Length);

            AndroidJNI.CallObjectMethod(HSAppConfigInstance.GetRawObject(), eventMethod, args);

            var list = HSAppConfigInstance.Call<AndroidJavaObject>("getServices");
            int length = list.Call<int>("size");
            Debug.LogError($"length - {length}");
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
            Debug.LogError("HSAppInstance.CallStatic<bool>(isInitialized) - " +
                           HSAppInstance.CallStatic<bool>("isInitialized"));

            var androidHSAppConfig = (AndroidHSAppConfig) appConfig.getHSAppConfig();
            HSAppInstance.CallStatic("initialize", getActivity(),
                androidHSAppConfig.getHSAppConfigInstance(),
                new AndroidHSAppInitializeListener(hsAppInitializeListener));
        }
    }

    [SuppressMessage("ReSharper", "InconsistentNaming")]
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