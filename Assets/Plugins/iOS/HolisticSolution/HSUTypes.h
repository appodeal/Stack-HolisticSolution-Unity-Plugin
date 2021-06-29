//
//  HSUTypes.h
//  Unity-iPhone
//
//  Created by Stas Kochkin on 13.07.2020.
//

typedef const void *HSUAppConfigurationRef;
typedef const void *HSUAppRef;

typedef void (HSUSdkInitialisationCallback)(const char *error);
typedef void (HSUSdkInAppPurchaseValidationSuccessCallback)(const char *data);
typedef void (HSUSdkInAppPurchaseValidationFailureCallback)(const char *error);
