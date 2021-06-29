// ReSharper disable All
using System;
using System.Collections.Generic;
using UnityEngine;

namespace StackHolisticSolution.Platforms.Dummy
{
    public class Dummy : 
        IHSAppConfig, IHSApp, IHSError, IHSInAppPurchaseBuilder
    {
        private const string DummyMessage = "Not supported on this platform";


        public void setComponentInitializeTimeout(long value)
        {
            throw new NotImplementedException();
        }

        public void setDebugEnabled(bool value)
        {
            throw new NotImplementedException();
        }

        public void setLoggingEnabled(bool value)
        {
            throw new NotImplementedException();
        }

        public void setAppKey(string appKey)
        {
            throw new NotImplementedException();
        }

        public void setAdType(int adType)
        {
            throw new NotImplementedException();
        }

        public void initialize(HSAppConfig appConfig, IHSAppInitializeListener hsAppInitializeListener)
        {
            throw new NotImplementedException();
        }

        public void logEvent(string key, Dictionary<string, object> dictionary)
        {
            throw new NotImplementedException();
        }

        public void logEvent(string key)
        {
            throw new NotImplementedException();
        }

        public string getVersion()
        {
            throw new NotImplementedException();
        }

        public bool isInitialized()
        {
            throw new NotImplementedException();
        }

        public void validateInAppPurchaseAndroid(HSInAppPurchase purchase,
            IHSInAppPurchaseValidateListener hsInAppPurchaseValidateListener)
        {
            throw new NotImplementedException();
        }

        public void validateInAppPurchaseiOS(string productIdentifier, string price, string currency, string transactionId,
            string additionalParams, iOSPurchaseType type,
            IInAppPurchaseValidationiOSCallback inAppPurchaseValidationiOSCallback)
        {
            throw new NotImplementedException();
        }


        public string toString()
        {
            throw new NotImplementedException();
        }

        public void withPublicKey(string publicKey)
        {
            throw new NotImplementedException();
        }

        public void withSignature(string signature)
        {
            throw new NotImplementedException();
        }

        public void withPurchaseData(string purchaseData)
        {
            throw new NotImplementedException();
        }

        public void withPrice(string price)
        {
            throw new NotImplementedException();
        }

        public void withCurrency(string currency)
        {
            throw new NotImplementedException();
        }

        public void withSku(string sku)
        {
            throw new NotImplementedException();
        }

        public void withOrderId(string orderId)
        {
            throw new NotImplementedException();
        }

        public void withPurchaseToken(string purchaseToken)
        {
            throw new NotImplementedException();
        }

        public void withPurchaseTimestamp(long purchaseTimestamp)
        {
            throw new NotImplementedException();
        }

        public void withAdditionalParams(Dictionary<string, string> additionalParameters)
        {
            throw new NotImplementedException();
        }

        public IHSInAppPurchase build()
        {
            throw new NotImplementedException();
        }
    }
}