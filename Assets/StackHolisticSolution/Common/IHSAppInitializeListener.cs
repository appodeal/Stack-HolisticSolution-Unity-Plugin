using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;

namespace StackHolisticSolution
{
    [SuppressMessage("ReSharper", "InconsistentNaming")]
    public interface IHSAppInitializeListener
    {
        void onAppInitialized(string error);
    }
}