typedef const void *HSUAppConfigurationRef;
typedef const void *HSUAppRef;

typedef void (HSUSdkInitialisationCallback)(const char *error);
typedef void (HSUSdkInAppPurchaseValidationSuccessCallback)(const char *data);
typedef void (HSUSdkInAppPurchaseValidationFailureCallback)(const char *error);
