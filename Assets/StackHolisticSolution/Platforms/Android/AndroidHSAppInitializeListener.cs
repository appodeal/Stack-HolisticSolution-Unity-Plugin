using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using StackHolisticSolution.Api;
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

            private void onAppInitialized(IEnumerable<AndroidJavaObject> javaObjects)
            {
                var errors = new List<HSError>();

                foreach (var javaObject in javaObjects)
                {
                    var androidHsError = new AndroidHSError(javaObject);
                    errors.Add(new HSError(androidHsError));
                }
                
                listener.onAppInitialized(errors);
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