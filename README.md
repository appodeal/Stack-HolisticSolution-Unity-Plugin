# explorestack-hs-unity-plugin
# About

Stack Holistic Solution SDK for Android simplifies the collection and transfer of the necessary parameters from third-party services to the corresponding Stack SDKs to improve the performance of services such as Mediation and UA

## Import SDK

#### Import Appodeal Holistic Solution plugin

Android

1. Import Appodeal holistic solution plugin to your project. Assets → Import Package → Custom package.
2. After the import Appodeal Unity Plugin, in the Unity editor select choose platform File → Build Settings → Android.
3. Add flag "Use Jetifier" in External Dependency Manger.  Assets → External Dependency Manager → Android Resolver  → Settings.
4. Then run Assets → External Dependency Manger → Android Resolver and press Resolve or Force Resolve.

iOS 

1. Import Appodeal holistic solution plugin to your project. Assets → Import Package → Custom package.


[initialize_sdk]: initialize_sdk
##  Initialize SDK

To initialize SDK add the line below to your script:

```c#
public class HolisticSolutionDemo : MonoBehaviour,IHSAppInitializeListener, IHSInAppPurchaseValidateListener
{
    ...
    void Start()
        {
    #if UNITY_ANDROID
            //Create connector for Appodeal
            HSAppodealConnector hsAppodealConnector = new HSAppodealConnector();
            hsAppodealConnector.setEventsEnabled(true);
            
            //Create Appsflyer Service
            HSAppsflyerService appsflyerService = new HSAppsflyerService("YOUR_APPSFLYER_DEV_KEY");
            appsflyerService.setEventsEnabled(true);
            
            //Create FirebaseService Service
            HSFirebaseService firebaseService = new HSFirebaseService();
            firebaseService.setEventsEnabled(true);
            
            //Create FacebookService Service
            HSFacebookService facebookService = new HSFacebookService();
            facebookService.setEventsEnabled(true);
            
    #elif UNITY_IOS
            //Create connector for Appodeal
            HSAppodealConnector hsAppodealConnector = new HSAppodealConnector();
            hsAppodealConnector.setEventsEnabled(true);
            
            //Create Appsflyer Service
            HSAppsflyerService appsflyerService = new HSAppsflyerService("DEV_KEY", "APP_ID", new[] {"KEYS"});
            appsflyerService.setEventsEnabled(true);
            
            //Create FirebaseService Service
            HSFirebaseService firebaseService = new HSFirebaseService("KEYS", "DEFAULTS", new[] {"KEYS"});
            firebaseService.setEventsEnabled(true);
            
            //Create FacebookService Service
            HSFacebookService facebookService = new HSFacebookService();
            facebookService.setEventsEnabled(true);
    #endif
    
    //Create HSApp Config 
    HSAppConfig appConfig = new HSAppConfig()
        .setDebugEnabled(true)
        .withServices(appsflyerService.getHSAppsflyerService(), firebaseService.getHSFirebaseService(),
            facebookService.getHSFacebookService())
        .withConnectors(hsAppodealConnector);
    
    //Initialize HSApp
    HSApp.initialize(appConfig, this);
    HSApp.logEvent("hs_sdk_example_test_event", dictionary);
    HSApp.logEvent("hs_sdk_example_test_event_1");

    //Create purchase
    HSInAppPurchase purchase = new HSInAppPurchase.Builder()
        .withPublicKey("YOUR_PUBLIC_KEY")
        .withAdditionalParams(additionalParams)
        .withSignature("Signature")
        .withPurchaseData("PurchaseData")
        .withPrice("Price")
        .withCurrency("Currency")
        .build();
        
    //Validate HSApp InApp Purchase    
    HSApp.validateInAppPurchase(purchase, this);


#region HSAppInitializeListener
   
   public void onAppInitialized(IEnumerable<HSError> hsErrors)
   {
       Debug.Log("onAppInitialized");
       foreach (var error in hsErrors)
       {
           Debug.Log("Error - " + error.toString());
       }
   }
   #endregion

   #region HSInAppPurchaseValidateListener

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

   #endregion
    
    ...
}
```
