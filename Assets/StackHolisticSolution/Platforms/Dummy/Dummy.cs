// ReSharper disable All

using System;
using System.Collections.Generic;
using UnityEngine;

namespace StackHolisticSolution.Platforms.Dummy
{
    public class Dummy :
        IHSAppConfig, IHSApp, IHSError, IHSInAppPurchaseBuilder
    {
        private const string DummyMessage = "To test advertising, install your application on the Android/iOS device.";
        
        public void setComponentInitializeTimeout(long value)
        {
            Debug.Log("Call to setComponentInitializeTimeout on not supported platform." + DummyMessage);
        }

        public void setDebugEnabled(bool value)
        {
            Debug.Log("Call to setDebugEnabled on not supported platform." + DummyMessage);
        }

        public void setLoggingEnabled(bool value)
        {
            Debug.Log("Call to setLoggingEnabled on not supported platform." + DummyMessage);
        }

        public void setAppKey(string appKey)
        {
            Debug.Log("Call to setAppKey on not supported platform." + DummyMessage);
        }

        public void setAdType(int adType)
        {
            Debug.Log("Call to setAdType on not supported platform." + DummyMessage);
        }

        public void initialize(HSAppConfig appConfig, IHSAppInitializeListener hsAppInitializeListener)
        {
            Debug.Log("Call to initialize on not supported platform." + DummyMessage);
        }

        public void logEvent(string key)
        {
            Debug.Log("Call to logEvent on not supported platform." + DummyMessage);
        }

        public string getVersion()
        {
            Debug.Log("Call to getVersion on not supported platform." + DummyMessage);
            return string.Empty;
        }

        public bool isInitialized()
        {
            Debug.Log("Call to isInitialized on not supported platform." + DummyMessage);
            return false;
        }

        public void validateInAppPurchaseAndroid(HSInAppPurchase purchase,
            IHSInAppPurchaseValidateListener hsInAppPurchaseValidateListener)
        {
            Debug.Log("Call to validateInAppPurchaseAndroid on not supported platform." + DummyMessage);
        }

        public void validateInAppPurchaseiOS(string productIdentifier, string price, string currency,
            string transactionId,
            string additionalParams, iOSPurchaseType type,
            IInAppPurchaseValidationiOSCallback inAppPurchaseValidationiOSCallback)
        {
            Debug.Log("Call to validateInAppPurchaseiOS on not supported platform." + DummyMessage);
        }
        
        public string toString()
        {
            Debug.Log("Call to toString on not supported platform." + DummyMessage);
            return string.Empty;
        }

        public void withPublicKey(string publicKey)
        {
            Debug.Log("Call to withPublicKey on not supported platform." + DummyMessage);
        }

        public void withSignature(string signature)
        {
            Debug.Log("Call to withSignature on not supported platform." + DummyMessage);
        }

        public void withPurchaseData(string purchaseData)
        {
            Debug.Log("Call to withPurchaseData on not supported platform." + DummyMessage);
        }

        public void withPrice(string price)
        {
            Debug.Log("Call to withPrice on not supported platform." + DummyMessage);
        }

        public void withCurrency(string currency)
        {
            Debug.Log("Call to withCurrency on not supported platform." + DummyMessage);
        }

        public void withSku(string sku)
        {
            Debug.Log("Call to withSku on not supported platform." + DummyMessage);
        }

        public void withOrderId(string orderId)
        {
            Debug.Log("Call to withOrderId on not supported platform." + DummyMessage);
        }

        public void withPurchaseToken(string purchaseToken)
        {
            Debug.Log("Call to withPurchaseToken on not supported platform." + DummyMessage);
        }

        public void withPurchaseTimestamp(long purchaseTimestamp)
        {
            Debug.Log("Call to withPurchaseTimestamp on not supported platform." + DummyMessage);
        }

        public void withAdditionalParams(Dictionary<string, string> additionalParameters)
        {
            Debug.Log("Call to withAdditionalParams on not supported platform." + DummyMessage);
        }

        public IHSInAppPurchase build()
        {
            Debug.Log("Call to withAdditionalParams on not supported platform." + DummyMessage);
            return null;
        }
    }
}