using System.Diagnostics.CodeAnalysis;
using StackHolisticSolution.Common;
using StackHolisticSolution.Platforms;

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
    public class HSFacebookService
    {
        private readonly IHSFacebookService nativeHSFacebookService;

        public IHSFacebookService getHSFacebookService()
        {
            return nativeHSFacebookService;
        }

        public HSFacebookService()
        {
            nativeHSFacebookService = HolisticSolutionClientFactory.GetHSFacebookService();
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
        
        public HSAppConfig withServices(HSFacebookService hsFacebookService)
        {
            nativeHSAppConfig.withServices(hsFacebookService);
            return this;
        }
        
        public HSAppConfig withServices(HSFirebaseService hsFirebaseService)
        {
            nativeHSAppConfig.withServices(hsFirebaseService);
            return this;
        }
        
        public HSAppConfig withServices(HSAppsflyerService hsAppsflyerService)
        {
            nativeHSAppConfig.withServices(hsAppsflyerService);
            return this;
        }
        
        public HSAppConfig withServices(HSAppsflyerService hsAppsflyerService, HSFirebaseService hsFirebaseService)
        {
            nativeHSAppConfig.withServices(hsAppsflyerService, hsFirebaseService);
            return this;
        }
       
        public HSAppConfig withServices(HSAppsflyerService hsAppsflyerService, HSFacebookService hsFacebookService)
        {
            nativeHSAppConfig.withServices(hsAppsflyerService, hsFacebookService);
            return this;
        }

        public HSAppConfig withServices(HSAppsflyerService hsAppsflyerService, HSFirebaseService hsFirebaseService, HSFacebookService hsFacebookService)
        {
            nativeHSAppConfig.withServices(hsAppsflyerService, hsFirebaseService, hsFacebookService);
            return this;
        }
        
        public HSAppConfig withServices(HSFirebaseService hsFirebaseService, HSFacebookService hsFacebookService)
        {
            nativeHSAppConfig.withServices(hsFirebaseService, hsFacebookService);
            return this;
        }
        

        public HSAppConfig setDebugEnabled(bool value)
        {
            nativeHSAppConfig.setDebugEnabled(value);
            return this;
        }

    }

    [SuppressMessage("ReSharper", "InconsistentNaming")]
    public static class HSApp
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
    [SuppressMessage("ReSharper", "ClassNeverInstantiated.Global")]
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
    [SuppressMessage("ReSharper", "UnusedMember.Local")]
    public class HSError
    {
        private readonly IHSError nativeHSError;

        private IHSError getHSError()
        {
            return nativeHSError;
        }

        public HSError(IHSError getHsError)
        {
            nativeHSError = getHsError;
        }

        public IHSError getHSErr()
        {
            return HolisticSolutionClientFactory.GetHSError();
        }
    }
}