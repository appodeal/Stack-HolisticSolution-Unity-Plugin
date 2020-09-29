// ReSharper disable All
using System;
using System.Collections.Generic;
using StackHolisticSolution.Api;
using StackHolisticSolution.Common;
using StackHolisticSolution.Platforms.Android;
using UnityEngine;

namespace StackHolisticSolution.Platforms.Dummy
{
    public class Dummy : IHSAppodealConnector, IHSAppsflyerService, IHSFirebaseService,
        IHSAppConfig, IHSApp, IHSError, IHSFacebookService, IHSInAppPurchaseBuilder, IHSLogger
    {
        private const string DummyMessage = "Not supported on this platform";
        
        void IHSAppodealConnector.setEventsEnabled(bool value)
        {
            Debug.Log(DummyMessage);
        }

        public AndroidJavaObject GetAndroidInstance()
        {
            Debug.Log(DummyMessage);
            return null;
        }

        public IntPtr GetIntPtr()
        {
            Debug.Log(DummyMessage);
            return new IntPtr();
        }

        void IHSFacebookService.setEventsEnabled(bool value)
        {
            Debug.Log(DummyMessage);
        }

        void IHSFirebaseService.setEventsEnabled(bool value)
        {
            Debug.Log(DummyMessage);
        }

        void IHSAppsflyerService.setEventsEnabled(bool value)
        {
            Debug.Log(DummyMessage);
        }

        public void withConnectors(HSAppodealConnector hsAppodealConnector)
        {
            Debug.Log(DummyMessage);
        }

        public void withServices(params IHSService[] services)
        {
            Debug.Log(DummyMessage);
        }

        public void setDebugEnabled(bool value)
        {
            Debug.Log(DummyMessage);
        }

        public void setComponentInitializeTimeout(long value)
        {
            Debug.Log(DummyMessage);
        }

        public void initialize(HSAppConfig appConfig, IHSAppInitializeListener hsAppInitializeListener)
        {
            Debug.Log(DummyMessage);
        }

        public void logEvent(string key, Dictionary<string, object> dictionary)
        {
            Debug.Log(DummyMessage);
        }

        public void logEvent(string key)
        {
            Debug.Log(DummyMessage);
        }

        public void validateInAppPurchaseAndroid(HSInAppPurchase purchase,
            IHSInAppPurchaseValidateListener hsInAppPurchaseValidateListener)
        {
            Debug.Log(DummyMessage);
        }

        public void validateInAppPurchaseiOS(string productIdentifier, string price, string currency, string transactionId,
            string additionalParams, IInAppPurchaseValidationiOSCallback inAppPurchaseValidationiOSCallback)
        {
            Debug.Log(DummyMessage);
        }

        public void validateInAppPurchaseiOS(string productIdentifier, string price, string currency, string transactionId,
            string additionalParams)
        {
            Debug.Log(DummyMessage);
        }

        public string toString()
        {
            Debug.Log(DummyMessage);
            return string.Empty;
        }

        public IHSInAppPurchase build()
        {
            Debug.Log(DummyMessage);
            return null;
        }

        public void withAdditionalParams(Dictionary<string, string> additionalParameters)
        {
            Debug.Log(DummyMessage);
        }

        public void withCurrency(string currency)
        {
            Debug.Log(DummyMessage);
        }

        public void withPrice(string price)
        {
            Debug.Log(DummyMessage);
        }

        public void withPurchaseData(string purchaseData)
        {
            Debug.Log(DummyMessage);
        }

        public void withSignature(string signature)
        {
            Debug.Log(DummyMessage);
        }

        public void withPublicKey(string publicKey)
        {
            Debug.Log(DummyMessage);
        }

        public void setEnabled(bool value)
        {
            Debug.Log(DummyMessage);
        }
    }
}