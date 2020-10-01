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
    public class AndroidHSInAppPurchaseValidateListener
#if UNITY_ANDROID
        : UnityEngine.AndroidJavaProxy
    {
        private readonly IHSInAppPurchaseValidateListener listener;

        internal AndroidHSInAppPurchaseValidateListener(IHSInAppPurchaseValidateListener listener) : base(
            "com.explorestack.hs.sdk.HSInAppPurchaseValidateListener")
        {
            this.listener = listener;
        }

        private void onInAppPurchaseValidateSuccess(AndroidJavaObject purchase, AndroidJavaObject javaTypeList)
        {
            var csTypeList = new List<HSError>();
            var length = javaTypeList.Call<int>("size");
            for (var i = 0; i < length; i++)
            {
                var javaTypeHSError = javaTypeList.Call<AndroidJavaObject>("get", i);
                csTypeList.Add(new HSError(new AndroidHSError(javaTypeHSError)));
            }

            listener.onInAppPurchaseValidateSuccess(new HSInAppPurchase(new AndroidHSInAppPurchase(purchase)),
                csTypeList);
        }

        private void onInAppPurchaseValidateFail(AndroidJavaObject javaTypeList)
        {
            var csTypeList = new List<HSError>();
            var length = javaTypeList.Call<int>("size");
            for (var i = 0; i < length; i++)
            {
                var javaTypeHSError = javaTypeList.Call<AndroidJavaObject>("get", i);
                csTypeList.Add(new HSError(new AndroidHSError(javaTypeHSError)));
            }

            listener.onInAppPurchaseValidateFail(csTypeList);
        }
    }
#else
    {
        public AndroidHSInAppPurchaseValidateListener(IHSInAppPurchaseValidateListener listener)
        {

        }
    }
#endif
}