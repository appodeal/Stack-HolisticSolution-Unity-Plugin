using StackHolisticSolution.Api;
using StackHolisticSolution.Common;
using UnityEngine;

namespace StackHolisticSolution.Platforms.Dummy
{
    public class Dummy : IHSAppodealConnector, IHSAppsflyerService, IHSFirebaseService, IHSAppConfig, IHSApp, IHSError, IHSLogger
    {
        private const string DummyMessage = "Not supported on this platform";
        
        public void withConnectors(HSAppodealConnector hsAppodealConnector)
        {
            Debug.Log(DummyMessage);
        }

        public void withServices(HSAppsflyerService appsflyerService, HSFirebaseService hsFirebaseService)
        {
            Debug.Log(DummyMessage);
        }

        public void setDebugEnabled(bool value)
        {
            Debug.Log(DummyMessage);
        }

        public void initialize(HSAppConfig appConfig, IHSAppInitializeListener hsAppInitializeListener)
        {
            Debug.Log(DummyMessage);
        }

        public void setEnabled(bool value)
        {
            Debug.Log(DummyMessage);
        }
    }
}