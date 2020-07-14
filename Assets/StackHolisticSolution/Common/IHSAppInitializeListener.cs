using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using StackHolisticSolution.Api;

namespace StackHolisticSolution.Common
{
    [SuppressMessage("ReSharper", "InconsistentNaming")]
    public interface IHSAppInitializeListener
    {
        void onAppInitialized(IEnumerable<HSError> hsErrors);
        void onAppInitialized(string error);
    }
}