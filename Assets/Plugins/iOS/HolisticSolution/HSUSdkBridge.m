//
//  HSUSdkBridge.m
//  Unity-iPhone
//
//  Created by Stas Kochkin on 13.07.2020.
//

#import "HSUSdkBridge.h"
#import <Appodeal/Appodeal.h>


@implementation HSUSdkBridge

+ (instancetype)shared {
    static HSUSdkBridge *_bridge;
    static dispatch_once_t onceToken;
    dispatch_once(&onceToken, ^{
        _bridge = [HSUSdkBridge new];
    });
    return _bridge;
}

#pragma mark - Public

- (HSAppConfiguration *)configuration {
    HSAppConfigurationDebug debug = self.debug ? HSAppConfigurationDebugEnabled : HSAppConfigurationDebugDisabled;

    double timeout = (self.timeout != 0) ? (self.timeout / 1000) : 30.0;
    return [[HSAppConfiguration alloc] initWithAppKey:@""
                                              timeout:timeout
                                                debug:debug
                                              adTypes:self.adType];
}

@end
