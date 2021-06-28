using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using StackHolisticSolution;
using UnityEngine;

[SuppressMessage("ReSharper", "InconsistentNaming")]
[SuppressMessage("ReSharper", "ArrangeTypeMemberModifiers")]
[SuppressMessage("ReSharper", "FieldCanBeMadeReadOnly.Local")]
public class HolisticSolutionDemo : MonoBehaviour, IHSAppInitializeListener, IHSInAppPurchaseValidateListener,
    IInAppPurchaseValidationiOSCallback
{
    void Start()
    {
        HSAppConfig appConfig = new HSAppConfig()
            .setDebugEnabled(true)
            .setLoggingEnabled(true)
            .setAppKey("")
            .setComponentInitializeTimeout(10000)
            .setAdType(2);
        
        
        
        HSApp.initialize(appConfig, this );
        HSApp.logEvent("hs_sdk_example_test_event_1");


// #if UNITY_ANDROID
//         HSInAppPurchase purchase = new HSInAppPurchase.Builder()
//             .withPublicKey("YOUR_PUBLIC_KEY")
//             .withAdditionalParams(additionalParams)
//             .withSignature("Signature")
//             .withPurchaseData("PurchaseData")
//             .withPrice("Price")
//             .withCurrency("Currency")
//             .build();
//
//         HSApp.validateInAppPurchaseAndroid(purchase, this);
// #elif UNITY_IOS
//         HSApp.validateInAppPurchaseiOS("productIdentifier", "price", "currency", "transactionId",
//             "additionalParams", this);
// #endif
    }
    
    #region HSAppInitializeListener
    
    public void onAppInitializeFailed(IEnumerable<HSError> hsErrors)
    {
        Debug.Log("onAppInitialized");
        if (hsErrors!=null)
        {
            foreach (var error in hsErrors)
            {
                Debug.LogError($"HSApp: [Error]: " + error.toString());
            }
        }
    }

    public void onAppInitializeFailed(string error)
    {
        Debug.Log($"onAppInitializeFailed - {error}");
    }

    public void onAppInitialized()
    {
        
    }

    #endregion



    #region HSInAppPurchaseValidateListener

    public void onInAppPurchaseValidateSuccess(HSInAppPurchase purchase, IEnumerable<HSError> errors)
    {
        Debug.Log("onInAppPurchaseValidateSuccess");

        foreach (var error in errors)
        {
            Debug.Log("Error - " + error.toString());
        }
    }

    public void onInAppPurchaseValidateFail(IEnumerable<HSError> errors)
    {
        Debug.Log("onInAppPurchaseValidateSuccess");

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