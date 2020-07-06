using System.Diagnostics.CodeAnalysis;
using StackHolisticSolution.Api;
using StackHolisticSolution.Platforms.Android;

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
    public interface IHSAppConfig
    {
        void withConnectors(HSAppodealConnector hsAppodealConnector);
        void withServices(HSAppsflyerService appsflyerService, HSFirebaseService hsFirebaseService);
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