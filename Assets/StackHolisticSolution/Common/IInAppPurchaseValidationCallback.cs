using System.Diagnostics.CodeAnalysis;

namespace StackHolisticSolution
{
    [SuppressMessage("ReSharper", "InconsistentNaming")]
    public interface IInAppPurchaseValidationCallback
    {
        void InAppPurchaseValidationSuccessCallback(string json);

        void InAppPurchaseValidationFailureCallback(string error);
    }
}