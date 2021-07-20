using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using UnityEngine;

namespace StackHolisticSolution
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
            if (javaTypeList == null) return;
            
            var csTypeList = new List<HSError>();
            var length = javaTypeList.Call<int>("size");
            for (var i = 0; i < length; i++)
            {
                var javaTypeHSError = javaTypeList.Call<AndroidJavaObject>("get", i);
                csTypeList.Add(new HSError(new AndroidHSError(javaTypeHSError)));
            }

            string responseError = null;

            if (csTypeList.Count > 0)
            {
                foreach (var error in csTypeList)
                {
                    responseError = string.Join(", ", error.toString());
                }
                listener.onAppInitialized(responseError);
            }
            else
            {
                listener.onAppInitialized(null);
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