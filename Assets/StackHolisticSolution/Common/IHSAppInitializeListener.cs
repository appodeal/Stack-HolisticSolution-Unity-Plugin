using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;

namespace StackHolisticSolution
{
    [SuppressMessage("ReSharper", "InconsistentNaming")]
    public interface IHSAppInitializeListener
    {
        void onAppInitializeFailed(IEnumerable<HSError> hsErrors);
        void onAppInitializeFailed(string error);
        void onAppInitialized();
    }
}