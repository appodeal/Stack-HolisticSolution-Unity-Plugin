// ReSharper disable All

using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using StackHolisticSolution.Common;
using StackHolisticSolution.Platforms.Android;


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
            return new iOS.iOSHSAppodealConnector();
#else
            return new Dummy.Dummy();
#endif
        }
        
        internal static IHSAppsflyerService GetHSAppsflyerService(string key)
        {
#if UNITY_ANDROID && !UNITY_EDITOR
			return new AndroidHSAppsflyerService(key);
#elif UNITY_IPHONE && !UNITY_EDITOR
            return null;
#else
            return new Dummy.Dummy();
#endif
        }
        
        internal static IHSAppsflyerService GetHSAppsflyerService(string devKey, string appId, string keys)
        {
#if UNITY_ANDROID && !UNITY_EDITOR
			return null;
#elif UNITY_IPHONE && !UNITY_EDITOR
            return new iOS.iOSHSAppsflyerService(devKey, appId, keys);
#else
            return new Dummy.Dummy();
#endif
        }
        
        internal static IHSFirebaseService GetHSFirebaseService(string defaults, long expirationDuration)
        {
#if UNITY_ANDROID && !UNITY_EDITOR
			return null;
#elif UNITY_IPHONE && !UNITY_EDITOR
            return new iOS.iOSHSFirebaseService(defaults, expirationDuration);
#else
            return new Dummy.Dummy();
#endif
        }
        
        internal static IHSFirebaseService GetHSFirebaseService()
        {
#if UNITY_ANDROID && !UNITY_EDITOR
			return new AndroidHSFirebaseService();
#elif UNITY_IPHONE && !UNITY_EDITOR
            return null;
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

        internal static IHSInAppPurchaseBuilder GetInAppPurchaseBuilder()
        {
#if UNITY_ANDROID && !UNITY_EDITOR
			return new AndroidHSInAppPurchaseBuilder();
#elif UNITY_IPHONE && !UNITY_EDITOR
            return null;
#else
            return new Dummy.Dummy();
#endif
        }
        
    }
}