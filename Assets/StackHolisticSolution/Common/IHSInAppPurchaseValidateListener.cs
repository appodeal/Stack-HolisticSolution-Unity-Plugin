using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;

namespace StackHolisticSolution
{
    [SuppressMessage("ReSharper", "InconsistentNaming")]
    public interface IHSInAppPurchaseValidateListener
    {
        void onInAppPurchaseValidateSuccess(HSInAppPurchase purchase, IEnumerable<HSError> errors);

        void onInAppPurchaseValidateFail(IEnumerable<HSError> errors);
    }
}