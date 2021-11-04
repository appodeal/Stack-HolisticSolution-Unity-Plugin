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
@property (nonatomic, assign) long timeout;
@property (nonatomic, assign) BOOL logging;
@property (nonatomic, copy) NSString *appKey;
@property (nonatomic, assign) int adType;

+ (instancetype)shared;

@end

NS_ASSUME_NONNULL_END
