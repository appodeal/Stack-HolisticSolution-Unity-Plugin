#import <Foundation/Foundation.h>
#import "HSUTypes.h"


NS_ASSUME_NONNULL_BEGIN

FOUNDATION_EXPORT void SetDebugEnabled(bool enabled);
FOUNDATION_EXPORT void SetComponentInitializeTimeout(long value);
FOUNDATION_EXPORT void SetLoggingEnabled(bool enabled);
FOUNDATION_EXPORT void SetAppKey(const char *key);
FOUNDATION_EXPORT void SetAdType(int adType);

FOUNDATION_EXPORT HSUAppConfigurationRef GetHSAppConfig(void);

FOUNDATION_EXPORT HSUAppRef GetHSApp(void);
FOUNDATION_EXPORT void Initialize(HSUAppConfigurationRef appConfig,
                                  HSUSdkInitialisationCallback callback);

FOUNDATION_EXPORT void LogEvent(const char *key);

FOUNDATION_EXPORT void ValidateInAppPurchase(const char *productIdentifier,
                                             const char *price,
                                             const char *currency,
                                             const char *transactionId,
                                             const char *additionalParams,
                                             int type,
                                             HSUSdkInAppPurchaseValidationSuccessCallback success,
                                             HSUSdkInAppPurchaseValidationFailureCallback failure);

NS_ASSUME_NONNULL_END
