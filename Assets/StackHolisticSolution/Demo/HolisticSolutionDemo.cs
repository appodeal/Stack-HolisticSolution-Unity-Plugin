using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using StackHolisticSolution.Api;
using StackHolisticSolution.Common;
using UnityEngine;

[SuppressMessage("ReSharper", "InconsistentNaming")]
public class HolisticSolutionDemo : MonoBehaviour, IHSAppInitializeListener, IHSInAppPurchaseValidateListener,
    IInAppPurchaseValidationiOSCallback
{
    #region SampleDictionaries

    Dictionary<string, object> dictionary = new Dictionary<string, object>
    {
        {"example_param_1", "Param1 value"},
        {"example_param_2", 123},
        {"example_param_3", true},
        {"example_param_4", 1.2f}
    };

    Dictionary<string, string> additionalParams = new Dictionary<string, string>()
    {
        {"1.KeY", "value.1"},
        {"2.KeY", "value.2"},
        {"3.KeY", "value.2"}
    };
    
    Dictionary<string, string> defaults = new Dictionary<string, string>()
    {
        {"key", "value"}
    };

    #endregion

    void Start()
    {
#if UNITY_ANDROID
        HSAppodealConnector hsAppodealConnector = new HSAppodealConnector();
        hsAppodealConnector.setEventsEnabled(true);
        
        HSAppsflyerService appsflyerService = new HSAppsflyerService("YOUR_APPSFLYER_DEV_KEY");
        appsflyerService.setEventsEnabled(true);
        
        HSFirebaseService firebaseService = new HSFirebaseService();
        firebaseService.setEventsEnabled(true);
        
        HSFacebookService facebookService = new HSFacebookService();
        facebookService.setEventsEnabled(true);
#elif UNITY_IOS
        HSAppodealConnector hsAppodealConnector = new HSAppodealConnector();
        HSAppsflyerService appsflyerService = new HSAppsflyerService("DEV_KEY", "APP_ID", new[] {"KEYS"});
        HSFirebaseService firebaseService = new HSFirebaseService(defaults, long.MaxValue);
        HSFacebookService facebookService = new HSFacebookService();
#endif

        HSAppConfig appConfig = new HSAppConfig()
            .setDebugEnabled(true)
            .withServices(appsflyerService.getHSAppsflyerService(), firebaseService.getHSFirebaseService(),
                facebookService.getHSFacebookService())
            .withConnectors(hsAppodealConnector);

        HSApp.initialize(appConfig, this);
        HSApp.logEvent("hs_sdk_example_test_event_1");
        
#if UNITY_ANDROID
            HSInAppPurchase purchase = new HSInAppPurchase.Builder()
            .withPublicKey("YOUR_PUBLIC_KEY")
            .withAdditionalParams(additionalParams)
            .withSignature("Signature")
            .withPurchaseData("PurchaseData")
            .withPrice("Price")
            .withCurrency("Currency")
            .build();

            HSApp.validateInAppPurchaseAndroid(purchase, this);
#elif UNITY_IOS
        HSApp.validateInAppPurchaseiOS("productIdentifier", "price", "currency", "transactionId",
            "additionalParams", this);
#endif
    }

    #region HSAppInitializeListener

    public void onAppInitialized(IEnumerable<HSError> hsErrors)
    {
        Debug.Log("onAppInitialized");
        foreach (var error in hsErrors)
        {
            Debug.Log("Error - " + error.toString());
        }
    }

    public void onAppInitialized(string error)
    {
        Debug.Log($"onAppInitialized - {error}");
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