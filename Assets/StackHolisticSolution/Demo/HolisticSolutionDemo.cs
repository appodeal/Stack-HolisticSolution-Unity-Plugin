using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using AppodealAds.Unity.Api;
using StackHolisticSolution;
using UnityEngine;

[SuppressMessage("ReSharper", "InconsistentNaming")]
[SuppressMessage("ReSharper", "ArrangeTypeMemberModifiers")]
[SuppressMessage("ReSharper", "FieldCanBeMadeReadOnly.Local")]
public class HolisticSolutionDemo : MonoBehaviour, IHSAppInitializeListener,
    IInAppPurchaseValidationCallback
{
    #region Application keys

#if UNITY_EDITOR && !UNITY_ANDROID && !UNITY_IPHONE
        public static string appKey = "";
#elif UNITY_ANDROID
    public static string appKey = "c05de97de46bf68a9ede523a580bef97e42692848736ecad";
#elif UNITY_IPHONE
    public static string appKey = "466de0d625e01e8811c588588a42a55970bc7c132649eede";
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
        
        HSApp.logEvent("logEventWithParams",
            new Dictionary<string, string>
            {
                { "testKey1", "testParam1" },
                { "testKey2", "testParam2" },
                { "testKey3", "testParam3" }
            });
    }

    private void PurchaseTest()
    {
#if UNITY_ANDROID
        var purchase = new HSInAppPurchase.Builder(PurchaseType.SUBS)
            .withPublicKey("YOUR_PUBLIC_KEY")
            .withAdditionalParams(new Dictionary<string, string>
            {
                { "test_key", "test_value" },
            })
            .withSignature("Signature")
            .withPurchaseData("PurchaseData")
            .withPrice("Price")
            .withCurrency("Currency")
            .withSku("Sku")
            .withOrderId("OrderId")
            .withPurchaseToken("Purchase token")
            .withPurchaseTimestamp(123)
            .withDeveloperPayload("DeveloperPayload")
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


    #region InAppPurchaseValidationCallback

    public void InAppPurchaseValidationSuccessCallback(string json)
    {        
        Debug.Log($"InAppPurchaseValidationSuccessCallback");
        if (string.IsNullOrEmpty(json)) return;
        Debug.Log($"InAppPurchaseValidationSuccessCallback - {json}");
    }

    public void InAppPurchaseValidationFailureCallback(string error)
    {
        Debug.Log($"InAppPurchaseValidationFailureCallback");
        if (string.IsNullOrEmpty(error)) return;
        Debug.Log($"InAppPurchaseValidationFailureCallback - {error}");
    }

    #endregion
}