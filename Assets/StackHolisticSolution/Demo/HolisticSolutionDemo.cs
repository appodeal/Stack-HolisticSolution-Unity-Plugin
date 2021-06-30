using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using AppodealAds.Unity.Api;
using DefaultNamespace;
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
    void Start()
    {
        StartCoroutine(waitInitializeFirebase());

       


// #if UNITY_ANDROID

// #elif UNITY_IOS
//         HSApp.validateInAppPurchaseiOS("productIdentifier", "price", "currency", "transactionId",
//             "additionalParams", this);
// #endif
    }

    private IEnumerator waitInitializeFirebase()
    {
        yield return new WaitUntil(() => FirebaseController.IsInitialized);
        
        HolisticSolutionInitialize();
    }

    private void HolisticSolutionInitialize()
    {
        Appodeal.setTesting(true);
        Appodeal.setLogLevel(Appodeal.LogLevel.Verbose);

        var appConfig = new HSAppConfig()
            .setDebugEnabled(true)
            .setLoggingEnabled(true)
            .setAppKey(appKey)
            .setComponentInitializeTimeout(10000)
            .setAdType(Appodeal.INTERSTITIAL | Appodeal.REWARDED_VIDEO);

        HSApp.initialize(appConfig, this);
        
#if UNITY_ANDROID

        var firstPurchase = new HSInAppPurchase.Builder(PurchaseType.Subscription)
                .withPublicKey("YOUR_PUBLIC_KEY")
                .withSignature("YOUR_SIGNATURE") 
                .withPurchaseData("YOUR_PURCHASE_DATA")
                .withPrice("0.01")
                .withCurrency("0.02")
                .withAdditionalParams(new Dictionary<string, string>
                {
                    {
                        "key", "value"
                    }
                })
                .withPurchaseTimestamp(213123)
                .withPurchaseToken("token")
                .withSku("sku")
                .build();
            
        
        HSApp.validateInAppPurchaseAndroid(firstPurchase, this);
#endif
        
        // HSApp.validateInAppPurchaseiOS( 
        //     "productIdentifier",  
        //     "price",  
        //     "currency",
        //      "transactionId",
        //      "additionalParams", 
        //      iOSPurchaseType.consumable, 
        //     this);
        
        
        
    }

    #region HSAppInitializeListener

    public void onAppInitializeFailed(IEnumerable<HSError> hsErrors)
    {
        Debug.Log("onAppInitializeFailed");

        if (hsErrors == null) return;
        
        foreach (var error in hsErrors)
        {
            Debug.Log($"HSApp: [Error]: " + error.toString());
        }
    }

    public void onAppInitializeFailed(string error)
    {
        if (error != null)
        {
            Debug.Log($"onAppInitializeFailed - {error}");
        }
    }

    public void onAppInitialized()
    {
        Debug.Log("onAppInitialized");
        Debug.Log($"HSApp.isInitialized() - {HSApp.isInitialized()}");
        Debug.Log($"HSApp.getVersion() - {HSApp.getVersion()}");
    }

    #endregion
    
    #region HSInAppPurchaseValidateListener

    public void onInAppPurchaseValidateSuccess(HSInAppPurchase purchase, IEnumerable<HSError> errors)
    {
        Debug.Log("onInAppPurchaseValidateSuccess(HSInAppPurchase purchase, IEnumerable<HSError> errors)");

        foreach (var error in errors)
        {
            Debug.Log("Error - " + error.toString());
        }
    }

    public void onInAppPurchaseValidateFail(IEnumerable<HSError> errors)
    {
        Debug.Log("onInAppPurchaseValidateFail(IEnumerable<HSError> errors)");

        foreach (var error in errors)
        {
            Debug.Log("Error - " + error.toString());
        }
    }

    #endregion

    #region InAppPurchaseValidationiOSCallback

    public void InAppPurchaseValidationSuccessCallback(string json)
    {
        Debug.Log($"InAppPurchaseValidationSuccessCallback - {json}");
    }

    public void InAppPurchaseValidationFailureCallback(string error)
    {
        Debug.Log($"InAppPurchaseValidationFailureCallback - {error}");
    }

    #endregion
}