using System.Diagnostics.CodeAnalysis;
using StackHolisticSolution.Common;
using UnityEngine;

namespace StackHolisticSolution.Platforms.Android
{
    [SuppressMessage("ReSharper", "InconsistentNaming")]
        [SuppressMessage("ReSharper", "UnusedMember.Local")]
        public class AndroidHSAppInitializeListener
#if UNITY_ANDROID
            : UnityEngine.AndroidJavaProxy
        {
            private readonly IHSAppInitializeListener listener;

            internal AndroidHSAppInitializeListener(IHSAppInitializeListener listener) : base(
                "io.bidmachine.app_event.BMAdManagerAppEventListener")
            {
                this.listener = listener;
            }

            private void onAppInitialized()
            {
                listener.onAppInitialized();
            }

            private void onAppInitializationFailed(AndroidJavaObject javaObject)
            {
                //var consentManagerException = new HSError(new AndroidConsentManagerException(exception));
               // listener.onAppInitializationFailed();
            }
            
        }
#else
    {
        public AndroidHSAppInitializeListener(IHSAppInitializeListener listener)
        {

        }
    }
#endif
    
}