//
//  HSUSdkBridge.m
//  Unity-iPhone
//
//  Created by Stas Kochkin on 13.07.2020.
//

#import "HSUSdkBridge.h"


NSString *const kHSUFirebaseConnectorKey = @"HSUFirebaseConnector";
NSString *const kHSUFacebookConnectorKey = @"HSUFacebookConnector";
NSString *const kHSUAppodealConnectorKey = @"HSUAppodealConnector";
NSString *const kHSUAppsFlyerConnectorKey = @"HSUAppsFlyerConnector";


@interface HSUSdkBridge ()

@property (nonatomic, strong) NSMapTable <NSString *, id> *connectors;
@property (nonatomic, strong) NSHashTable<id<HSService>> *registeredServices;
@property (nonatomic, strong) NSHashTable<id<HSAdvertising>> *registeredAdvertising;

@end

@implementation HSUSdkBridge

+ (instancetype)shared {
    static HSUSdkBridge *_bridge;
    static dispatch_once_t onceToken;
    dispatch_once(&onceToken, ^{
        _bridge = [HSUSdkBridge new];
    });
    return _bridge;
}

#pragma mark - Lazy

- (NSMapTable<NSString *,id> *)connectors {
    if (!_connectors) {
        _connectors = [NSMapTable strongToStrongObjectsMapTable];
    }
    return _connectors;
}

- (NSHashTable<id<HSService>> *)registeredServices {
    if (!_registeredServices) {
        _registeredServices = [NSHashTable weakObjectsHashTable];
    }
    return _registeredServices;
}

- (NSHashTable<id<HSAdvertising>> *)registeredAdvertising {
    if (!_registeredAdvertising) {
        _registeredAdvertising = [NSHashTable weakObjectsHashTable];
    }
    return _registeredAdvertising;
}

#pragma mark - Public

- (id)connector:(NSString *)key {
    return [self.connectors objectForKey:key];
}

- (void)setupAppodeal {
    HSAppodealConnector *appodeal = [[HSAppodealConnector alloc] init];
    [self.connectors setObject:appodeal forKey:kHSUAppodealConnectorKey];
}

- (void)setupAppsFlyerWithAppId:(NSString *)appId
                         devKey:(NSString *)devKey
                 conversionKeys:(NSArray<NSString *> *)conversionKeys {
    HSAppsFlyerConnector *appsFlyer = [[HSAppsFlyerConnector alloc] initWithDevKey:devKey
                                                                             appId:appId
                                                                              keys:conversionKeys];
    [self.connectors setObject:appsFlyer forKey:kHSUAppsFlyerConnectorKey];
}

- (void)setupFirebaseWithDefaults:(NSDictionary<NSString *,id> *)defaults
                             keys:(NSArray<NSString *> *)keys
               expirationDuration:(long)expirationDuration {
    HSFirebaseConnector *firebase = [[HSFirebaseConnector alloc] initWithKeys:keys
                                                                     defaults:defaults
                                                           expirationDuration:expirationDuration];
    [self.connectors setObject:firebase forKey:kHSUFirebaseConnectorKey];
}

- (void)setupFacebook {
    HSFacebookConnector *facebook = [[HSFacebookConnector alloc] init];
    [self.connectors setObject:facebook forKey:kHSUFacebookConnectorKey];
}

- (void)registerService:(id)service {
    if ([service conformsToProtocol:@protocol(HSService)]) {
        [self.registeredServices addObject:service];
    }
}

- (void)registerConnector:(id)connector {
    if ([connector conformsToProtocol:@protocol(HSAdvertising)]) {
        [self.registeredAdvertising addObject:connector];
    }
}

- (HSAppConfiguration *)configuration {
    Debug debug = self.debug ? DebugEnabled : DebugDisabled;
    double timeout = (self.timeout != 0) ? (self.timeout / 1000) : 30.0;
    return [[HSAppConfiguration alloc] initWithServices:self.registeredServices.allObjects
                                             connectors:self.registeredAdvertising.allObjects
                                                timeout:timeout
                                                  debug:debug];;
}

@end
