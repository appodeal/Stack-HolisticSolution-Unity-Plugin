//
//  HSUSdkBridge.h
//  Unity-iPhone
//
//  Created by Stas Kochkin on 13.07.2020.
//

#import <Foundation/Foundation.h>
#import <HolisticSolutionSDK/HolisticSolutionSDK-Swift.h>


NS_ASSUME_NONNULL_BEGIN


FOUNDATION_EXPORT NSString *const kHSUFirebaseConnectorKey;
FOUNDATION_EXPORT NSString *const kHSUFacebookConnectorKey;
FOUNDATION_EXPORT NSString *const kHSUAppsFlyerConnectorKey;
FOUNDATION_EXPORT NSString *const kHSUAppodealConnectorKey;


@interface HSUSdkBridge : NSObject

@property (nonatomic, readonly) HSAppConfiguration *configuration;
@property (nonatomic, assign) BOOL debug;

+ (instancetype)shared;

- (void)setupAppodeal;
- (void)setupFacebook;
- (void)setupAppsFlyerWithAppId:(NSString *)appId
                         devKey:(NSString *)devKey
                 conversionKeys:(NSArray <NSString *> *)conversionKeys;
- (void)setupFirebaseWithDefaults:(NSDictionary <NSString *, id> *)defaults
                             keys:(NSArray <NSString *> *)keys
               expirationDuration:(long)expirationDuration;

- (id)connector:(NSString *)key;
- (void)setTrackingForService:(NSString *)key enabled:(BOOL)enabled;
- (void)registerService:(id)service;
- (void)registerConnector:(id)connector;

@end

NS_ASSUME_NONNULL_END
