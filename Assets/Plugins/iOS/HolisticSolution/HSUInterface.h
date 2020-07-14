//
//  HSSdkObjCBridge.h
//  Unity-iPhone
//
//  Created by Stas Kochkin on 13.07.2020.
//

#import <Foundation/Foundation.h>
#import "HSUTypes.h"


NS_ASSUME_NONNULL_BEGIN

FOUNDATION_EXPORT HSUAppodealConnectorRef GetHSAppodealConnector(void);

FOUNDATION_EXPORT HSUAppsFlyerConnectorRef GetHSAppsflyerService(const char *devKey,
                                                                 const char *appId,
                                                                 const char *keys);
FOUNDATION_EXPORT void SetHSAppsflyerServiceEventsEnabled(bool value);

FOUNDATION_EXPORT HSUFirebaseConnectorRef GetHSFirebaseService(const char *defaults, long expirationDuration);
FOUNDATION_EXPORT void SetHSFirebaseServiceEventsEnabled(bool value);

FOUNDATION_EXPORT HSUFacebookConnectorRef GetHSFacebookService(void);
FOUNDATION_EXPORT void SetHSFacebookServiceEventsEnabled(bool value);

FOUNDATION_EXPORT void WithService(const void *ptr);
FOUNDATION_EXPORT void WithConnectors(const void *ptr);
FOUNDATION_EXPORT void SetDebugEnabled(bool enabled);
FOUNDATION_EXPORT HSUAppConfigurationRef GetHSAppConfig(void);

FOUNDATION_EXPORT HSUAppRef GetHSApp(void);
FOUNDATION_EXPORT void Initialize(HSUAppConfigurationRef appConfig,
                                  HSUSdkInitialisationCallback callback);

FOUNDATION_EXPORT void LogEvent(const char *key,
                                const char *params);

FOUNDATION_EXPORT void ValidateInAppPurchase(const char *productIdentifier,
                                             const char *price,
                                             const char *currency,
                                             const char *transactionId,
                                             const char *additionalParams,
                                             HSUSdkInAppPurchaseValidationSuccessCallback success,
                                             HSUSdkInAppPurchaseValidationFailureCallback failure);

NS_ASSUME_NONNULL_END
