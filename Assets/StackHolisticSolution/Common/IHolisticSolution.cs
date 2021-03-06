using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using StackHolisticSolution.Api;
using UnityEngine;

namespace StackHolisticSolution.Common
{
    [SuppressMessage("ReSharper", "InconsistentNaming")]
    public interface IHSAppodealConnector
    {
        void setEventsEnabled(bool value);
    }

    [SuppressMessage("ReSharper", "InconsistentNaming")]
    public interface IHSAppsflyerService : IHSService
    {
        void setEventsEnabled(bool value);
    }

    [SuppressMessage("ReSharper", "InconsistentNaming")]
    public interface IHSFirebaseService : IHSService
    {
        void setEventsEnabled(bool value);
    }

    [SuppressMessage("ReSharper", "InconsistentNaming")]
    public interface IHSFacebookService : IHSService
    {
        void setEventsEnabled(bool value);
    }

    [SuppressMessage("ReSharper", "InconsistentNaming")]
    public interface IHSService
    {
        AndroidJavaObject GetAndroidInstance();
        IntPtr GetIntPtr();
    }

    [SuppressMessage("ReSharper", "InconsistentNaming")]
    public interface IHSAppConfig
    {
        void withConnectors(HSAppodealConnector hsAppodealConnector);
        void withServices(params IHSService[] services);
        void setDebugEnabled(bool value);
        void setComponentInitializeTimeout(long value);
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