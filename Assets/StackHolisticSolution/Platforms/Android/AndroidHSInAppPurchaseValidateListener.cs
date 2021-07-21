using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using UnityEngine;

namespace StackHolisticSolution
{
    [SuppressMessage("ReSharper", "InconsistentNaming")]
    [SuppressMessage("ReSharper", "UnusedMember.Local")]
    [SuppressMessage("ReSharper", "RedundantNameQualifier")]
    public class AndroidHSInAppPurchaseValidateListener
#if UNITY_ANDROID
        : UnityEngine.AndroidJavaProxy
    {
        private readonly IInAppPurchaseValidationCallback listener;

        internal AndroidHSInAppPurchaseValidateListener(IInAppPurchaseValidationCallback listener) : base(
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

            string responseError = null;
            string responsePurchase = null;

            var hsAndroidPurchase = new HSInAppPurchase(new AndroidHSInAppPurchase(purchase));

            if (string.IsNullOrEmpty(hsAndroidPurchase.getCurrency()))
            {
                responsePurchase = "/n" + "[HSInAppPurchase" + " " + "currency: " + hsAndroidPurchase.getCurrency();
            }
            else if (string.IsNullOrEmpty(hsAndroidPurchase.getPrice()))
            {
                responsePurchase += " " + "price: " + hsAndroidPurchase.getPrice();
            }
            else if (string.IsNullOrEmpty(hsAndroidPurchase.getSignature()))
            {
                responsePurchase += " " + "signature: " + hsAndroidPurchase.getSignature();
            }
            else if (string.IsNullOrEmpty(hsAndroidPurchase.getAdditionalParameters()))
            {
                responsePurchase += " " + "additional params: " + hsAndroidPurchase.getAdditionalParameters();
            }
            else if (string.IsNullOrEmpty(hsAndroidPurchase.getPublicKey()))
            {
                responsePurchase += " " + "public key: " + hsAndroidPurchase.getPublicKey();
            }
            else if (string.IsNullOrEmpty(hsAndroidPurchase.getPurchaseData()))
            {
                responsePurchase += " " + "purchase data: " + hsAndroidPurchase.getPurchaseData() + "]";
            }
            
            if (csTypeList.Count > 0 && !string.IsNullOrEmpty(responsePurchase))
            {
                foreach (var error in csTypeList)
                {
                    responseError = string.Join(", ", error.toString());
                }

                listener.InAppPurchaseValidationSuccessCallback(responsePurchase + "/n" + responseError);
            }
            else if (csTypeList.Count <= 0 && !string.IsNullOrEmpty(responsePurchase))
            {
                listener.InAppPurchaseValidationSuccessCallback(responsePurchase);
            }
            else if (csTypeList.Count > 0 && string.IsNullOrEmpty(responsePurchase))
            {
                foreach (var error in csTypeList)
                {
                    responseError = string.Join(", ", error.toString());
                }

                listener.InAppPurchaseValidationSuccessCallback(responseError);
            }
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

            string responseError = null;

            if (csTypeList.Count > 0)
            {
                foreach (var error in csTypeList)
                {
                    responseError = string.Join(", ", error.toString());
                }

                listener.InAppPurchaseValidationFailureCallback(responseError);
            }
            else
            {
                listener.InAppPurchaseValidationFailureCallback(null);
            }
        }
    }
#else
    {
        public AndroidHSInAppPurchaseValidateListener(IInAppPurchaseValidationCallback listener)
        {

        }
    }
#endif
}