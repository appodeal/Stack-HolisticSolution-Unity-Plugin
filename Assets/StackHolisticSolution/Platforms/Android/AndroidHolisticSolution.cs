using System.Diagnostics.CodeAnalysis;
using StackHolisticSolution.Api;
using StackHolisticSolution.Common;
using UnityEngine;

namespace StackHolisticSolution.Platforms.Android
{
    [SuppressMessage("ReSharper", "InconsistentNaming")]
    [SuppressMessage("ReSharper", "UnusedType.Global")]
    [SuppressMessage("ReSharper", "NotAccessedField.Local")]
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

        public AndroidJavaObject getAndroidHSAppsflyerService()
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
    }

    [SuppressMessage("ReSharper", "InconsistentNaming")]
    [SuppressMessage("ReSharper", "UnusedType.Global")]
    [SuppressMessage("ReSharper", "ClassNeverInstantiated.Global")]
    public class AndroidHSAppConfig : IHSAppConfig
    {
        private readonly AndroidJavaObject HSAppConfigInstance;

        public AndroidHSAppConfig()
        {
            HSAppConfigInstance = new AndroidJavaObject(
                "com.explorestack.hs.sdk.HSAppConfig");
        }

        public AndroidJavaObject getHSAppConfig()
        {
            return HSAppConfigInstance;
        }

        public void withConnectors(HSAppodealConnector hsAppodealConnector)
        {
            var androidHSAppodealConnector = (AndroidHSAppodealConnector) hsAppodealConnector.getHSAppodealConnector();
            HSAppConfigInstance.CallStatic("withConnectors",
                androidHSAppodealConnector.getAndroidHSAppodealConnector());
        }

        public void withServices(HSAppsflyerService hsAppsflyerService)
        {
            var androidHSAppsflyerService = (AndroidHSAppsflyerService) hsAppsflyerService.getHSAppsflyerService();
            HSAppConfigInstance.CallStatic("withServices", androidHSAppsflyerService.getAndroidHSAppsflyerService());
        }

        public void withServices(HSFirebaseService hsFirebaseService)
        {
            var androidHSFirebaseService = (AndroidHSFirebaseService) hsFirebaseService.getHSFirebaseService();
            HSAppConfigInstance.CallStatic("withServices", androidHSFirebaseService.getAndroidHSFirebaseService());
        }

        public void withServices(HSFacebookService hsFacebookService)
        {
            var androidHSFacebookService = (AndroidHSFacebookService) hsFacebookService.getHSFacebookService();
            HSAppConfigInstance.CallStatic("withServices", androidHSFacebookService.getAndroidHSFacebookService());
        }

        public void withServices(HSFirebaseService hsFirebaseService, HSFacebookService hsFacebookService)
        {
            var androidHSFirebaseService = (AndroidHSFirebaseService) hsFirebaseService.getHSFirebaseService();
            var androidHSFacebookService = (AndroidHSFacebookService) hsFacebookService.getHSFacebookService();
            object[] objects = {androidHSFirebaseService.getAndroidHSFirebaseService(), androidHSFacebookService.getAndroidHSFacebookService()};
            HSAppConfigInstance.CallStatic("withServices", objects);
        }

        public void withServices(HSAppsflyerService hsAppsflyerService, HSFirebaseService hsFirebaseService,
            HSFacebookService hsFacebookService)
        {
            var androidHSAppsflyerService = (AndroidHSAppsflyerService) hsAppsflyerService.getHSAppsflyerService();
            var androidHSFirebaseService = (AndroidHSFirebaseService) hsFirebaseService.getHSFirebaseService();
            var androidHSFacebookService = (AndroidHSFacebookService) hsFacebookService.getHSFacebookService();
            object[] objects = {androidHSAppsflyerService.getAndroidHSAppsflyerService(), 
                androidHSFirebaseService.getAndroidHSFirebaseService(), androidHSFacebookService.getAndroidHSFacebookService()};
            HSAppConfigInstance.CallStatic("withServices", objects);
        }

        public void withServices(HSAppsflyerService hsAppsflyerService, HSFirebaseService hsFirebaseService)
        {
            var androidHSAppsflyerService = (AndroidHSAppsflyerService) hsAppsflyerService.getHSAppsflyerService();
            var androidHSFirebaseService = (AndroidHSFirebaseService) hsFirebaseService.getHSFirebaseService();
            object[] objects = {androidHSAppsflyerService.getAndroidHSAppsflyerService(), androidHSFirebaseService.getAndroidHSFirebaseService()};
            HSAppConfigInstance.CallStatic("withServices", objects);
        }

        public void withServices(HSAppsflyerService hsAppsflyerService, HSFacebookService hsFacebookService)
        {
            var androidHSAppsflyerService = (AndroidHSAppsflyerService) hsAppsflyerService.getHSAppsflyerService();
            var androidHSFacebookService = (AndroidHSFacebookService) hsFacebookService.getHSFacebookService();
            object[] objects = {androidHSAppsflyerService.getAndroidHSAppsflyerService(), androidHSFacebookService.getAndroidHSFacebookService()};
            HSAppConfigInstance.CallStatic("withServices", objects);
        }

        public void setDebugEnabled(bool value)
        {
            HSAppConfigInstance.CallStatic("setDebugEnabled", Helper.getJavaObject(value));
        }
    }

    [SuppressMessage("ReSharper", "InconsistentNaming")]
    [SuppressMessage("ReSharper", "UnusedMember.Local")]
    [SuppressMessage("ReSharper", "UnusedType.Global")]
    public class AndroidHSApp : IHSApp
    {
        private AndroidJavaClass HSAppClass;
        private AndroidJavaObject activity;

        private AndroidJavaClass getHSAppClass()
        {
            return HSAppClass ?? (HSAppClass = new AndroidJavaClass("com.explorestack.hs.sdk.HSApp"));
        }

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
            HSAppClass.CallStatic("initialize", getActivity(), androidHSAppConfig.getHSAppConfig(),
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

            if ((value is bool))
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