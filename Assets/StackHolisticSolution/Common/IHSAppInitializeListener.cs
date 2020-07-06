using System.Diagnostics.CodeAnalysis;
using StackHolisticSolution.Api;

namespace StackHolisticSolution.Common
{
    [SuppressMessage("ReSharper", "InconsistentNaming")]
    public interface IHSAppInitializeListener
    {
        void onAppInitialized();
        void onAppInitializationFailed(HSError hsError);
    }
}