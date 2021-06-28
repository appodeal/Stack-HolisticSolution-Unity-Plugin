using System.Diagnostics.CodeAnalysis;

namespace StackHolisticSolution
{
    [SuppressMessage("ReSharper", "InconsistentNaming")]
    public interface IInAppPurchaseValidationiOSCallback
    {
        void InAppPurchaseValidationSuccessCallback(string json);

        void InAppPurchaseValidationFailureCallback(string error);
    }
}