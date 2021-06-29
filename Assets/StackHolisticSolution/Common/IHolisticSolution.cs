using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;

namespace StackHolisticSolution
{
    
    [SuppressMessage("ReSharper", "InconsistentNaming")]
    public interface IHSAppConfig
    {
        void setComponentInitializeTimeout(long value);
        void setDebugEnabled(bool value);
        void setLoggingEnabled(bool value);
        void setAppKey(string appKey);
        void setAdType(int adType);
    }

    [SuppressMessage("ReSharper", "InconsistentNaming")]
    public interface IHSApp
    {
        void initialize(HSAppConfig appConfig, IHSAppInitializeListener hsAppInitializeListener);
        void logEvent(string key, Dictionary<string, object> dictionary);
        void logEvent(string key);
        string getVersion();
        bool isInitialized();
        void validateInAppPurchaseAndroid(HSInAppPurchase purchase, IHSInAppPurchaseValidateListener hsInAppPurchaseValidateListener);
        void validateInAppPurchaseiOS(string productIdentifier, string price, string currency, string transactionId ,string additionalParams, iOSPurchaseType type, IInAppPurchaseValidationiOSCallback inAppPurchaseValidationiOSCallback);
    }

    [SuppressMessage("ReSharper", "InconsistentNaming")]
    public interface IHSError
    {
        string toString();
    }

    [SuppressMessage("ReSharper", "InconsistentNaming")]
    public interface IHSInAppPurchase
    {
        PurchaseType getType();
        string getPublicKey();
        string getSignature();
        string getPurchaseData();
        string getPrice();
        string getCurrency();
        string getSku();
        string getOrderId();
        string getPurchaseToken();
        string getPurchaseTimestamp();
        string getAdditionalParameters();
    }

    [SuppressMessage("ReSharper", "InconsistentNaming")]
    public interface IHSInAppPurchaseBuilder
    {
        void withPublicKey(string publicKey);
        void withSignature(string signature);
        void withPurchaseData(string purchaseData);
        void withPrice(string price);
        void withCurrency(string currency);
        void withSku(string sku);
        void withOrderId(string orderId);
        void withPurchaseToken(string purchaseToken);
        void withPurchaseTimestamp(long purchaseTimestamp);
        void withAdditionalParams(Dictionary<string, string> additionalParameters);
        IHSInAppPurchase build();

    }
}