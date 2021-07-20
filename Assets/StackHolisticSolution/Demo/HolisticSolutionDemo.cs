using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using AppodealAds.Unity.Api;
using StackHolisticSolution;
using UnityEngine;

[SuppressMessage("ReSharper", "InconsistentNaming")]
[SuppressMessage("ReSharper", "ArrangeTypeMemberModifiers")]
[SuppressMessage("ReSharper", "FieldCanBeMadeReadOnly.Local")]
public class HolisticSolutionDemo : MonoBehaviour, IHSAppInitializeListener, IHSInAppPurchaseValidateListener,
    IInAppPurchaseValidationiOSCallback
{
    #region Application keys

#if UNITY_EDITOR && !UNITY_ANDROID && !UNITY_IPHONE
        public static string appKey = "";
#elif UNITY_ANDROID
    public static string appKey = "c05de97de46bf68a9ede523a580bef97e42692848736ecad";
#elif UNITY_IPHONE
    public static string appKey = "ae8558d35fbf2175d3e23ff61df138e27d3cd8efe1e789c4";
#else
	public static string appKey = "";
#endif

    #endregion

    public void ShowBanner()
    {
        if (Appodeal.canShow(Appodeal.BANNER_BOTTOM))
        {
            Appodeal.show(Appodeal.BANNER_BOTTOM);
        }
        else
        {
            Debug.Log("Appodeal.canShow(Appodeal.BANNER_BOTTOM) - " + Appodeal.canShow(Appodeal.BANNER_BOTTOM));
        }
    }

    public void HieBanner()
    {
        Appodeal.hide(Appodeal.BANNER_BOTTOM);
    }

    public void ShowInterstitial()
    {
        if (Appodeal.canShow(Appodeal.INTERSTITIAL))
        {
            Appodeal.show(Appodeal.INTERSTITIAL);
        }
        else
        {
            Debug.Log("Appodeal.canShow(Appodeal.INTERSTITIAL) - " + Appodeal.canShow(Appodeal.INTERSTITIAL));
        }
    }

    public void ShowRewardedVideo()
    {
        if (Appodeal.canShow(Appodeal.REWARDED_VIDEO))
        {
            Appodeal.show(Appodeal.REWARDED_VIDEO);
        }
        else
        {
            Debug.Log("Appodeal.canShow(Appodeal.REWARDED_VIDEO) - " + Appodeal.canShow(Appodeal.REWARDED_VIDEO));
        }
    }

    public void HolisticSolutionInitialize()
    {
        var appConfig = new HSAppConfig()
            .setDebugEnabled(true)
            .setAppKey(appKey)
            .setComponentInitializeTimeout(10000)
            .setAdType(Appodeal.INTERSTITIAL | Appodeal.REWARDED_VIDEO | Appodeal.BANNER);

        HSApp.initialize(appConfig, this);
        HSApp.logEvent("hs_sdk_example_test_event");
        
    }

    private void PurchaseTest()
    {
        
#if UNITY_ANDROID
        HSInAppPurchase purchase = new HSInAppPurchase.Builder(PurchaseType.SUBS)
            .withPublicKey("YOUR_PUBLIC_KEY")
            .withAdditionalParams(new Dictionary<string, string>
            {
                {"test_key", "test_value"},
            })
            .withSignature("Signature")
            .withPurchaseData("PurchaseData")
            .withPrice("Price")
            .withCurrency("Currency")
            .build();


        HSApp.validateInAppPurchaseAndroid(purchase, this);
#elif UNITY_IOS
        HSApp.validateInAppPurchaseiOS("productIdentifier", "price", "currency", "transactionId",
            "additionalParams", iOSPurchaseType.consumable, this);

#endif
    }

    #region HSAppInitializeListener

    public void onAppInitialized(string error)
    {
        if (!string.IsNullOrEmpty(error))
        {
            Debug.Log($"onAppInitializeFailed - {error}");
        }

        Debug.Log("Holistic Solution Initialize - " + HSApp.isInitialized());

        PurchaseTest();
    }

    #endregion

    #region HSInAppPurchaseValidateListener

    public void onInAppPurchaseValidateSuccess(HSInAppPurchase purchase, IEnumerable<HSError> errors)
    {
        Debug.Log("onInAppPurchaseValidateSuccess");

        var hsErrors = errors as HSError[] ?? errors.ToArray();
        if (!hsErrors.ToList().Any()) return;
        foreach (var error in hsErrors)
        {
            Debug.Log("Error - " + error.toString());
        }
    }

    public void onInAppPurchaseValidateFail(IEnumerable<HSError> errors)
    {
        Debug.Log("onInAppPurchaseValidateFail");

        if (errors == null) return;

        foreach (var error in errors)
        {
            Debug.Log("Error - " + error.toString());
        }
    }

    #endregion

    #region InAppPurchaseValidationiOSCallback

    public void InAppPurchaseValidationSuccessCallback(string json)
    {
        if (string.IsNullOrEmpty(json)) return;
        Debug.Log($"InAppPurchaseValidationSuccessCallback - {json}");
    }

    public void InAppPurchaseValidationFailureCallback(string error)
    {
        if (string.IsNullOrEmpty(error)) return;
        Debug.Log($"InAppPurchaseValidationFailureCallback - {error}");
    }

    #endregion
}