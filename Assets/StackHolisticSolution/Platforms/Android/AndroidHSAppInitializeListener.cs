using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using StackHolisticSolution.Api;
using StackHolisticSolution.Common;
using UnityEngine;

namespace StackHolisticSolution.Platforms.Android
{
    [SuppressMessage("ReSharper", "InconsistentNaming")]
    [SuppressMessage("ReSharper", "UnusedMember.Local")]
    [SuppressMessage("ReSharper", "RedundantNameQualifier")]
    public class AndroidHSAppInitializeListener
#if UNITY_ANDROID
        : UnityEngine.AndroidJavaProxy
    {
        private readonly IHSAppInitializeListener listener;

        internal AndroidHSAppInitializeListener(IHSAppInitializeListener listener) : base(
            "com.explorestack.hs.sdk.HSAppInitializeListener")
        {
            this.listener = listener;
        }

        private void onAppInitialized(AndroidJavaObject javaTypeList)
        {
            Debug.Log("onAppInitialized" + HSAppodealConnector.HolisticSolutionPluginVersion);
            
            if (javaTypeList!=null)
            {
                var csTypeList = new List<HSError>();
                var length = javaTypeList.Call<int>("size");
                for (var i = 0; i < length; i++)
                {
                    var javaTypeHSError = javaTypeList.Call<AndroidJavaObject>("get", i);
                    csTypeList.Add(new HSError(new AndroidHSError(javaTypeHSError)));
                }
                listener.onAppInitialized(csTypeList);
            }
            else
            {
                listener.onAppInitialized("true");
            }
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