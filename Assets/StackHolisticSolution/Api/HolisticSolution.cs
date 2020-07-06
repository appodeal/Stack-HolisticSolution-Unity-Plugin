using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using StackHolisticSolution.Common;
using StackHolisticSolution.Platforms;
using UnityEngine;


namespace StackHolisticSolution.Api
{
    [SuppressMessage("ReSharper", "InconsistentNaming")]
    public class HSAppodealConnector
    {
        private readonly IHSAppodealConnector nativeHSAppodealConnector;

        public IHSAppodealConnector getHSAppodealConnector()
        {
            return nativeHSAppodealConnector;
        }

        public HSAppodealConnector()
        {
            nativeHSAppodealConnector = HolisticSolutionClientFactory.GetHSAppodealConnector();
        }
    }

    [SuppressMessage("ReSharper", "InconsistentNaming")]
    public class HSAppsflyerService
    {
        private readonly IHSAppsflyerService nativeHSAppsflyerService;

        public IHSAppsflyerService getHSAppsflyerService()
        {
            return nativeHSAppsflyerService;
        }

        public HSAppsflyerService(string sellerId)
        {
            nativeHSAppsflyerService = HolisticSolutionClientFactory.GetHSAppsflyerService(sellerId);
        }
    }

    [SuppressMessage("ReSharper", "InconsistentNaming")]
    public class HSFirebaseService
    {
        private readonly IHSFirebaseService nativeHSFirebaseService;

        public IHSFirebaseService getHSFirebaseService()
        {
            return nativeHSFirebaseService;
        }

        public HSFirebaseService()
        {
            nativeHSFirebaseService = HolisticSolutionClientFactory.GetHSFirebaseService();
        }
    }

    [SuppressMessage("ReSharper", "InconsistentNaming")]
    public class HSAppConfig
    {
        private readonly IHSAppConfig nativeHSAppConfig;

        public IHSAppConfig getHSAppConfig()
        {
            return nativeHSAppConfig;
        }

        public HSAppConfig()
        {
            nativeHSAppConfig = HolisticSolutionClientFactory.GetHSAppConfig();
        }

        public HSAppConfig withConnectors(HSAppodealConnector connector)
        {
            nativeHSAppConfig.withConnectors(connector);
            return this;
        }

        public HSAppConfig withServices(HSAppsflyerService appsflyerService, HSFirebaseService firebaseService)
        {
            nativeHSAppConfig.withServices(appsflyerService, firebaseService);
            return this;
        }

        public HSAppConfig setDebugEnabled(bool value)
        {
            nativeHSAppConfig.setDebugEnabled(value);
            return this;
        }

    }

    [SuppressMessage("ReSharper", "InconsistentNaming")]
    public class HSApp
    {
        private static IHSApp nativeHsApp;

        private static IHSApp getInstance()
        {
            return nativeHsApp ?? (nativeHsApp = HolisticSolutionClientFactory.GetHSApp());
        }

        public static void initialize(HSAppConfig hsAppConfig, IHSAppInitializeListener hsAppInitializeListener)
        {
            getInstance().initialize(hsAppConfig, hsAppInitializeListener);
        }
        
    }

    [SuppressMessage("ReSharper", "InconsistentNaming")]
    public class HSLogger
    {
        private static IHSLogger nativeHSLogger;

        private static IHSLogger getInstance()
        {
            return nativeHSLogger ?? (nativeHSLogger = HolisticSolutionClientFactory.GetHSLogger());
        }

        public HSLogger()
        {
            nativeHSLogger = HolisticSolutionClientFactory.GetHSLogger();
        }

        public static void setEnabled(bool value)
        {
            getInstance().setEnabled(value);
        }
    }

    [SuppressMessage("ReSharper", "InconsistentNaming")]
    public class HSError
    {
        private readonly IHSError nativeHSError;

        private IHSError getHSError()
        {
            return nativeHSError;
        }

        public HSError()
        {
            nativeHSError = HolisticSolutionClientFactory.GetHSError();
        }
    }
}