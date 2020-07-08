using System.Diagnostics.CodeAnalysis;
using StackHolisticSolution.Api;
using StackHolisticSolution.Platforms.Android;
using UnityEngine;

namespace StackHolisticSolution.Common
{
    [SuppressMessage("ReSharper", "InconsistentNaming")]
    public interface IHSAppodealConnector
    {
    }

    [SuppressMessage("ReSharper", "InconsistentNaming")]
    public interface IHSAppsflyerService : IHSService
    {
        
    }

    [SuppressMessage("ReSharper", "InconsistentNaming")]
    public interface IHSFirebaseService : IHSService
    {
    }

    [SuppressMessage("ReSharper", "InconsistentNaming")]
    public interface IHSFacebookService : IHSService
    {
    }

    public interface IHSService
    {
        AndroidJavaObject GetAndroidInstance();
    }

    [SuppressMessage("ReSharper", "InconsistentNaming")]
    public interface IHSAppConfig
    {
        
        void withConnectors(HSAppodealConnector hsAppodealConnector);
        void withServices(params IHSService[] services);
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
        string toString();
    }

    [SuppressMessage("ReSharper", "InconsistentNaming")]
    public interface IHSLogger
    {
        void setEnabled(bool value);
    }
}