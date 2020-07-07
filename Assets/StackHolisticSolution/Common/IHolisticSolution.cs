using System.Diagnostics.CodeAnalysis;
using StackHolisticSolution.Api;

namespace StackHolisticSolution.Common
{
    [SuppressMessage("ReSharper", "InconsistentNaming")]
    public interface IHSAppodealConnector
    {
    }

    [SuppressMessage("ReSharper", "InconsistentNaming")]
    public interface IHSAppsflyerService
    {
    }

    [SuppressMessage("ReSharper", "InconsistentNaming")]
    public interface IHSFirebaseService
    {
    }

    [SuppressMessage("ReSharper", "InconsistentNaming")]
    public interface IHSFacebookService
    {
    }

    [SuppressMessage("ReSharper", "InconsistentNaming")]
    public interface IHSAppConfig
    {
        void withConnectors(HSAppodealConnector hsAppodealConnector);
        void withServices(HSAppsflyerService appsflyerService);
        void withServices(HSFirebaseService hsFirebaseService);
        void withServices(HSFacebookService facebookService);
        void withServices(HSAppsflyerService appsflyerService, HSFirebaseService hsFirebaseService);
        void withServices(HSAppsflyerService appsflyerService, HSFacebookService facebookService);
        void withServices(HSFirebaseService hsFirebaseService, HSFacebookService facebookService);
        void withServices(HSAppsflyerService appsflyerService, HSFirebaseService hsFirebaseService,
            HSFacebookService facebookService);
        void setDebugEnabled(bool value);
    }

    [SuppressMessage("ReSharper", "InconsistentNaming")]
    public interface IHSApp
    {
        void initialize(HSAppConfig appConfig, IHSAppInitializeListener hsAppInitializeListener);
    }

    [SuppressMessage("ReSharper", "InconsistentNaming")]
    public interface IHSError
    {
    }

    [SuppressMessage("ReSharper", "InconsistentNaming")]
    public interface IHSLogger
    {
        void setEnabled(bool value);
    }
}