// ReSharper disable All
using System.Diagnostics.CodeAnalysis;
using StackHolisticSolution.Api;
using StackHolisticSolution.Common;
using StackHolisticSolution.Platforms.Android;
using UnityEditor;

namespace StackHolisticSolution.Platforms
{
    [SuppressMessage("ReSharper", "InconsistentNaming")]
    public class HolisticSolutionClientFactory
    {
        internal static IHSAppodealConnector GetHSAppodealConnector()
        {
#if UNITY_ANDROID && !UNITY_EDITOR
			return new AndroidHSAppodealConnector();
#elif UNITY_IPHONE && !UNITY_EDITOR
            //return PlayerSettings.iOS.iOSHSAppodealConnector.Instance;
#else
            return new Dummy.Dummy();
#endif
        }
        
        internal static IHSAppsflyerService GetHSAppsflyerService(string key)
        {
#if UNITY_ANDROID && !UNITY_EDITOR
			return new AndroidHSAppsflyerService(key);
#elif UNITY_IPHONE && !UNITY_EDITOR
            //return new iOS.iOSHSAppsflyerService(key);
#else
            return new Dummy.Dummy();
#endif
        }
        
        internal static IHSFirebaseService GetHSFirebaseService()
        {
#if UNITY_ANDROID && !UNITY_EDITOR
			return new AndroidHSFirebaseService();
#elif UNITY_IPHONE && !UNITY_EDITOR
            return new iOS.iOSHSFirebaseService();
#else
            return new Dummy.Dummy();
#endif
        }
        
        internal static IHSFacebookService GetHSFacebookService()
        {
#if UNITY_ANDROID && !UNITY_EDITOR
			return new AndroidHSFacebookService();
#elif UNITY_IPHONE && !UNITY_EDITOR
            return new iOS.iOSHSFacebookService();
#else
            return new Dummy.Dummy();
#endif
        }
        
        internal static IHSAppConfig GetHSAppConfig()
        {
#if UNITY_ANDROID && !UNITY_EDITOR
			return new AndroidHSAppConfig();
#elif UNITY_IPHONE && !UNITY_EDITOR
            return new iOS.iOSHSAppConfig();
#else
            return new Dummy.Dummy();
#endif
        }
        
        internal static IHSApp GetHSApp()
        {
#if UNITY_ANDROID && !UNITY_EDITOR
			return new AndroidHSApp();
#elif UNITY_IPHONE && !UNITY_EDITOR
            return new iOS.iOSHSApp();
#else
            return new Dummy.Dummy();
#endif
        }
        
        internal static IHSLogger GetHSLogger()
        {
#if UNITY_ANDROID && !UNITY_EDITOR
			return new AndroidHSLogger();
#elif UNITY_IPHONE && !UNITY_EDITOR
            //return new iOS.iOSHSLogger();
#else
            return new Dummy.Dummy();
#endif
        }
    }
}