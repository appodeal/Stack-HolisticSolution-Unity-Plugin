# About
Stack Holistic Solution SDK for Unity simplifies the collection and transfer of the necessary parameters from third-party services to the corresponding Stack SDKs to improve the performance of services such as Mediation and UA

## Integration Guide
- [Before integration started](#before-integration-started)
- [Import SDK](#import-sdk)
   - [Import Appodeal Holistic Solution plugin](#import-appodeal-holistic-solution-plugin)
   - [Android platform](#android-platform)
   - [iOS platform](#ios-platform)
   - [Setup required services](#setup-required-services)
		- [Facebook Service](#facebook-service)
		- [Firebase Service](#firebase-service)

## Before integration started

1. [Download hs unity plugin](https://appodeal-unity.s3.amazonaws.com/Appodeal-Unity-HS-Plugin-2.0.0-21.07.2021.unitypackage)

## Import SDK

### Import Appodeal Holistic Solution plugin

To import the Appodeal-Unity-HS-Plugin-2.0.0-21.07.2021.unitypackage, double-click on the Appodeal-Unity-HS-Plugin-2.0.0-21.07.2021.unitypackage, or go to Assets → Import Package → Custom Package. Keep all the files in the Importing Package window selected, and click Import .

### Android platform

1. Enable flag Custom Gradle Template for Unity 2017.4 - Unity 2019.2 versions or Custom Base Gradle Template for Unity 2019.3 or higher versions in Player Settings/Publishing Settings
2. Change classpath 'com.android.tools.build:gradle:3.4.0' to 'com.android.tools.build:gradle:3.4.3' in Custom Gradle Template file (path - Assets/Plugins/Android/mainTemplate.gradle) for Unity 2017.4 - Unity 2019.4 versions.
   Change classpath 'com.android.tools.build:gradle:3.6.0' to 'com.android.tools.build:gradle:3.6.4' in Custom Base Gradle Template file (path - Assets/Plugins/Android/baseProjectTemplate.gradle) for Unity 2020.1 or higher versions.
3. Appodeal Holistic Solution plugin includes External Dependency Manager package.  You need to complete these following steps to resolve Appodeal's dependencies:
   - After the import Appodeal Unity Plugin, in the Unity editor select File → Build Settings → Android.
   - Add flag Custom Gradle Template (Build Settings → Player Settings → Publishing settings).
   - Enable the setting "Patch mainTemplate.gradle" (Assets → External Dependency Manager → Android Resolver → Settings).
   - Enable the setting "Use Jetifier" (Assets → External Dependency Manager → Android Resolver → Settings).
   - Then run Assets → External Dependency Manager → Android Resolver and press Resolve or Force Resolve.
   - As a result, the modules, that are required for the Appodeal SDK support, will be imported to project's mainTemplate.gradle file.

### iOS platform 

Appodeal plugin includes Play Services Resolver package.  You need to complete these following steps to resolve Appodeal's dependencies:

 - After the import Appodeal Unity Plugin, in the Unity editor select File → Build Settings → iOS.
 - During build a project the modules, that are required for the Appodeal SDK support, will be imported to your project. You can edit them or add other modules in the Assets → Appodeal → Editor → AppodealDependencies.xml file.

### Setup required services

#### Facebook Service
> Note that HS Facebook Service will include only 'facebook-core' dependency independently

###### 1. Configure Your Facebook App

Please follow this [guide](https://developers.facebook.com/docs/unity/gettingstarted) to configure you Facebook app

#### Firebase Service
>Note that HS Firebase Service will include 'firebase-analytics' and 'firebase-config' dependencies independently

###### 1. Configure Your Firebase App

Please, follow this [guide](https://firebase.google.com/docs/android/setup#console) to configure you Firebase app


[initialize_sdk]: initialize_sdk
##  Initialize SDK

To initialize SDK add the line below to your script:

```c#
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
...
}
```
