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
- [Initialize SDK](#initialize-sdk)
- [Features](#features)
  * [Events](#events)
  * [In-App purchase validation](#in-app-purchase-validation)

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

Holistic Solution SDK will automatically initialize all components and sync all required data to connectors (e.g - Appodeal).

To initialize SDK add the line below to your script:

```c#
public class HolisticSolutionDemo : MonoBehaviour, IHSAppInitializeListener
    
{
    
    void Start()
    {
    
   	 HSAppConfig appConfig = new HSAppConfig()
            .setDebugEnabled(true)
            .setAppKey("YOUR_APP_KEY)
            .setComponentInitializeTimeout(10000)
            .setAdType(Appodeal.INTERSTITIAL | Appodeal.REWARDED_VIDEO | Appodeal.BANNER);

   	 HSApp.initialize(appConfig, this);
    
    }

    public void onAppInitialized(string error)
    {
        if (!string.IsNullOrEmpty(error))
        {
            Debug.Log($"onAppInitializeFailed - {error}");
        }
	
        Debug.Log("Holistic Solution Initialize - " + HSApp.isInitialized());

	//HSApp initialization finished, now you can initialize required SDK
	
    }
...
}
```
| Parameter            | Description                                                                                                        		               |
|----------------------|-------------------------------------------------------------------------------------------------------------------------------------------|
| appKey               | [Appodeal application key](https://app.appodeal.com/apps).							                                                       |
| adType               | Appodeal ad types (e.g - `Appodeal.INTERSTITIAL`).                                   	           	                        			   |
| debug                | Enable sdk, services and connectors debug logic if possible.                        				                             		   |
| timeout              | In this case is timeout for **one** operation: starting attribution service or fetching remote config. By default the value is **30 sec**.|

[Code example](https://github.com/appodeal/Stack-HolisticSolution-Unity-Plugin/blob/master/Assets/StackHolisticSolution/Demo/HolisticSolutionDemo.cs#L68)

## Features

### Events

Holistic Solution SDK allows you to send events to analytic services such as Firebase, AppsFlyer and Facebook using a single method:

> Event parameters can only be strings and numbers

[Code example](https://github.com/appodeal/Stack-HolisticSolution-Unity-Plugin/blob/master/Assets/StackHolisticSolution/Demo/HolisticSolutionDemo.cs#L77)


### Purchase validation
Holistic Solution SDK allows you to unify purchase validation using a single method:
```c#
public class HolisticSolutionDemo : MonoBehaviour, IInAppPurchaseValidationCallback
    
{
    
    void Start()
    {
   	 PurchaseTest();
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

    #region InAppPurchaseValidationCallback

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
    
    
...
}
```

| Parameter            | Description                                                                                                        |
|----------------------|--------------------------------------------------------------------------------------------------------------------|
| purchaseType         | Purchase type. Must be one of [PurchaseType](https://github.com/appodeal/Stack-HolisticSolution-Unity-Plugin/blob/master/Assets/StackHolisticSolution/Api/HolisticSolution.cs#L123).   |
| publicKey            | [Public key from Google Developer Console](https://support.google.com/googleplay/android-developer/answer/186113). |
| signature            | Transaction signature (returned from Google API when the purchase is completed).                                   |
| purchaseData         | Product purchased in JSON format (returned from Google API when the purchase is completed).                        |
| purchaseToken        | Product purchased token (returned from Google API when the purchase is completed).                        	        |
| purchaseTimestamp    | Product purchased timestamp (returned from Google API when the purchase is completed).                        	    |
| orderId              | Product purchased unique order id for the transaction (returned from Google API when the purchase is completed).   |
| sku                  | Stock keeping unit id.											                                                    |
| price                | Purchase revenue.                                                                                                  |
| currency             | Purchase currency.                                                                                                 |
| additionalParameters | Additional parameters of the purchase event.                                                                       |

> In-App purchase validation runs by FIFO queue in a single thread

[Code example](https://github.com/appodeal/Stack-HolisticSolution-Unity-Plugin/blob/master/Assets/StackHolisticSolution/Demo/HolisticSolutionDemo.cs#L81)
