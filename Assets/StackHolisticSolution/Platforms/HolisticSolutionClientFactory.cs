// ReSharper disable All

using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;


namespace StackHolisticSolution.Platforms
{
    [SuppressMessage("ReSharper", "InconsistentNaming")]
    public class HolisticSolutionClientFactory
    {

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