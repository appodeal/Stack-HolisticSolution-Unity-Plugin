using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using StackHolisticSolution.Api;
using StackHolisticSolution.Common;
using UnityEngine;

[SuppressMessage("ReSharper", "InconsistentNaming")]
public class HolisticSolutionDemo : MonoBehaviour, IHSAppInitializeListener, IHSInAppPurchaseValidateListener
{
   void Start()
    {
        HSLogger.setEnabled(true);

        HSAppodealConnector hsAppodealConnector = new HSAppodealConnector();
        hsAppodealConnector.setEventsEnabled(true);

        HSAppsflyerService appsflyerService = new HSAppsflyerService("YOUR_APPSFLYER_DEV_KEY");
        appsflyerService.setEventsEnabled(true);

        HSFirebaseService firebaseService = new HSFirebaseService();
        firebaseService.setEventsEnabled(true);

        HSFacebookService facebookService = new HSFacebookService();
        facebookService.setEventsEnabled(true);

        HSAppConfig appConfig = new HSAppConfig()
            .setDebugEnabled(true)
            .withServices(appsflyerService.getHSAppsflyerService(), firebaseService.getHSFirebaseService(),
                facebookService.getHSFacebookService())
            .withConnectors(hsAppodealConnector);


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

        HSApp.initialize(appConfig, this);
        HSApp.logEvent("hs_sdk_example_test_event", dictionary);
        HSApp.logEvent("hs_sdk_example_test_event_1");

        HSInAppPurchase purchase = new HSInAppPurchase.Builder()
            .withPublicKey("YOUR_PUBLIC_KEY")
            .withAdditionalParams(additionalParams)
            .withSignature("Signature")
            .withPurchaseData("PurchaseData")
            .withPrice("Price")
            .withCurrency("Currency")
            .build();

        showInfoPurchase(purchase);
        
        HSApp.validateInAppPurchase(purchase, this);
    }

    public void onAppInitialized(IEnumerable<HSError> hsErrors)
    {
        Debug.Log("onAppInitialized");
        foreach (var error in hsErrors)
        {
            Debug.Log("Error - " + error.toString());
        }
    }

    private void showInfoPurchase(HSInAppPurchase hsInAppPurchase)
    {
        Debug.Log($"hsInAppPurchase.getCurrency() - {hsInAppPurchase.getCurrency()}");
        Debug.Log($"hsInAppPurchase.getPrice() - {hsInAppPurchase.getPrice()}");
        Debug.Log($"hsInAppPurchase.getSignature() - {hsInAppPurchase.getSignature()}");
        Debug.Log($"hsInAppPurchase.getPublicKey() - {hsInAppPurchase.getPublicKey()}");
        Debug.Log($"hsInAppPurchase.getPurchaseData() - {hsInAppPurchase.getPurchaseData()}");
        Debug.Log($"hsInAppPurchase.getAdditionalParameters() - {hsInAppPurchase.getAdditionalParameters()}");
    }

    public void onInAppPurchaseValidateSuccess(HSInAppPurchase purchase, List<HSError> errors)
    {
        Debug.Log("onInAppPurchaseValidateSuccess");
        
        foreach (var error in errors)
        {
            Debug.Log("Error - " + error.toString());
        }
    }

    public void onInAppPurchaseValidateFail(List<HSError> errors)
    {
        Debug.Log("onInAppPurchaseValidateSuccess");

        foreach (var error in errors)
        {
            Debug.Log("Error - " + error.toString());
        }
    }
}