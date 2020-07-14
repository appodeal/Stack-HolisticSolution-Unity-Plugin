using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using StackHolisticSolution.Api;

namespace StackHolisticSolution.Common
{
    [SuppressMessage("ReSharper", "InconsistentNaming")]
    public interface IHSInAppPurchaseValidateListener
    {
        void onInAppPurchaseValidateSuccess(HSInAppPurchase purchase, IEnumerable<HSError> errors);

        void onInAppPurchaseValidateFail(IEnumerable<HSError> errors);
    }
}