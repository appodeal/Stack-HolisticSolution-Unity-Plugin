//
//  HSUTypes.h
//  Unity-iPhone
//
//  Created by Stas Kochkin on 13.07.2020.
//

typedef const void *HSUAppodealConnectorRef;
typedef const void *HSUAppsFlyerConnectorRef;
typedef const void *HSUFirebaseConnectorRef;
typedef const void *HSUFacebookConnectorRef;
typedef const void *HSUAppConfigurationRef;
typedef const void *HSUAppRef;

typedef void (HSUSdkInitialisationCallback)(const char *error);
typedef void (HSUSdkInAppPurchaseValidationSuccessCallback)(const char *data);
typedef void (HSUSdkInAppPurchaseValidationFailureCallback)(const char *error);
