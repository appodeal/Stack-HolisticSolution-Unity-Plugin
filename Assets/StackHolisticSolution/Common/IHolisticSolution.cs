using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using UnityEngine;

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
        void validateInAppPurchaseAndroid(HSInAppPurchase purchase, IHSInAppPurchaseValidateListener hsInAppPurchaseValidateListener);
        void validateInAppPurchaseiOS(string productIdentifier, string price, string currency, string transactionId ,string additionalParams, IInAppPurchaseValidationiOSCallback inAppPurchaseValidationiOSCallback);
    }

    [SuppressMessage("ReSharper", "InconsistentNaming")]
    public interface IHSError
    {
        string toString();
    }

    [SuppressMessage("ReSharper", "InconsistentNaming")]
    public interface IHSInAppPurchase
    {
        string getPublicKey();
        string getSignature();
        string getPurchaseData();
        string getPrice();
        string getCurrency();
        string getAdditionalParameters();
    }

    [SuppressMessage("ReSharper", "InconsistentNaming")]
    public interface IHSInAppPurchaseBuilder
    {
        IHSInAppPurchase build();
        void withAdditionalParams(Dictionary<string, string> additionalParameters);
        void withCurrency(string currency);
        void withPrice(string price);
        void withPurchaseData(string purchaseData);
        void withSignature(string signature);
        void withPublicKey(string publicKey);
    }

    [SuppressMessage("ReSharper", "InconsistentNaming")]
    public interface IHSLogger
    {
        void setEnabled(bool value);
    }
}