//
//  HSSdkObjCBridge.m
//  Unity-iPhone
//
//  Created by Stas Kochkin on 13.07.2020.
//

#import "HSUInterface.h"
#import "HSUSdkBridge.h"
#import <HolisticSolutionSDK/HolisticSolutionSDK-Swift.h>
#import <Appodeal/Appodeal.h>


#pragma mark - Helpers

static NSString *HSUStringFromUTF8String(const char *bytes) {
    return bytes ? @(bytes) : nil;
}

static NSDictionary <NSString *, NSString *> *HSUDictionaryFromUTF8String(const char *bytes) {
    NSString *string = HSUStringFromUTF8String(bytes);
    NSArray *pairs = [string componentsSeparatedByString:@","];
    NSMutableDictionary <NSString *, NSString *> *dict = [NSMutableDictionary dictionaryWithCapacity:pairs.count];
    [pairs enumerateObjectsUsingBlock:^(NSString *pair, NSUInteger idx, BOOL *stop) {
        NSArray <NSString *> *splited = [pair componentsSeparatedByString:@"="];
        NSString *key = splited.firstObject;
        NSString *value = splited.lastObject;
        if (key) {
            dict[key] = value;
        }
    }];
    return dict;
}

#pragma mark - Bridging

void SetDebugEnabled(bool enabled) {
    HSUSdkBridge.shared.debug = enabled;
}

void SetComponentInitializeTimeout(long value) {
    HSUSdkBridge.shared.timeout = value;
}

void SetAdtype(int adType){
    HSUSdkBridge.shared.adType = adType;
}

void SetAppKey(const char *appKey){
    HSUSdkBridge.shared.appKey = appKey;
}

HSUAppConfigurationRef GetHSAppConfig(void) {
    return (__bridge_retained HSUAppConfigurationRef)HSUSdkBridge.shared;
}

#pragma mark - API

HSUAppRef GetHSApp(void) {
    return (__bridge HSUAppRef)(HSApp.class);
}

void Initialize(HSUAppConfigurationRef appConfig, HSUSdkInitialisationCallback callback) {
    HSUSdkBridge *config = (__bridge_transfer HSUSdkBridge *)appConfig;
    if ([config isKindOfClass:HSUSdkBridge.class]) {
        [Appodeal.hs initializeWithApplication:UIApplication.sharedApplication
                                 launchOptions:@{}
                                 configuration:config.configuration
                                    completion:^(NSError *error) {
            
        }];
//    configureWithConfiguration:config.configuration completion:^(NSError *error) {
//            callback ? callback(error.localizedDescription.UTF8String) : nil;
//        }];
    } else {
        callback ? callback("Invalid configuration was sent from Unity") : nil;
    }
}

void LogEvent(const char *key, const char *params) {
    NSDictionary *paramsDict = HSUDictionaryFromUTF8String(params);
    [Appodeal.hs trackEvent:HSUStringFromUTF8String(key)
     customParameters:paramsDict];
}

void ValidateInAppPurchase(const char *productIdentifier,
                           const char *price,
                           const char *currency,
                           const char *transactionId,
                           const char *additionalParams,
                           int type,
                           HSUSdkInAppPurchaseValidationSuccessCallback success,
                           HSUSdkInAppPurchaseValidationFailureCallback failure) {
    NSString *productIdString = HSUStringFromUTF8String(productIdentifier);
    NSString *priceString = HSUStringFromUTF8String(price);
    NSString *currencyString = HSUStringFromUTF8String(currency);
    NSString *transactionIdString = HSUStringFromUTF8String(transactionId);
    NSDictionary *additionalParamsDict = HSUDictionaryFromUTF8String(additionalParams);
    
    NSString *purchaseType =HSUStringFromUTF8String(type);
    

    
    [Appodeal.hs validateAndTrackInAppPurchaseWithProductId:productIdString
                                                       type:(HSPurchaseType)type
                                                      price:priceString
                                                   currency:currencyString
                                              transactionId:transactionIdString
                                       additionalParameters:additionalParamsDict
                                                    success:^(NSDictionary *data) {
        NSData *jsonData;
        NSError *jsonError;
        jsonData = [NSJSONSerialization dataWithJSONObject:data
                                                   options:0
                                                     error:&jsonError];
        if (jsonError) {
            failure ? failure("Invalid response") : nil;
        } else {
            NSString *JSONString = [[NSString alloc] initWithBytes:jsonData.bytes
                                                            length:jsonData.length
                                                          encoding:NSUTF8StringEncoding];
            success ? success(JSONString.UTF8String) : nil;
            
        }
    }
                                              failure:^(NSError *error, id response) {
        NSString *errorString = (!error) ? @"unknown" : [NSString stringWithFormat:@"error: %@", error.localizedDescription];
        if ([response isKindOfClass:NSDictionary.class]) {
            if ([response objectForKey:@"error"] != nil) {
                errorString = response[@"error"];
            } else if ([response objectForKey:@"status"] != nil) {
                errorString = [NSString stringWithFormat:@"Error code = %@", response[@"status"]];
            }
        }
        else if ([response isKindOfClass:NSData.class]) {
            errorString = [[NSString alloc] initWithData:response
                                                encoding:NSUTF8StringEncoding];
        } else if ([response isKindOfClass:NSString.class]) {
            errorString = response;
        }
        
        failure ? failure(errorString.UTF8String) : nil;
    }];
}
