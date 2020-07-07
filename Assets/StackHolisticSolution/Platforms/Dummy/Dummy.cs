using StackHolisticSolution.Api;
using StackHolisticSolution.Common;
using UnityEngine;

namespace StackHolisticSolution.Platforms.Dummy
{
    public class Dummy : IHSAppodealConnector, IHSAppsflyerService, IHSFirebaseService,
        IHSAppConfig, IHSApp, IHSError, IHSLogger, IHSFacebookService
    {
        private const string DummyMessage = "Not supported on this platform";


        public void withConnectors(HSAppodealConnector hsAppodealConnector)
        {
            Debug.LogError(DummyMessage);
        }

        public void withServices(HSAppsflyerService appsflyerService)
        {
            Debug.LogError(DummyMessage);
        }

        public void withServices(HSFirebaseService hsFirebaseService)
        {
            Debug.LogError(DummyMessage);
        }

        public void withServices(HSFacebookService facebookService)
        {
            Debug.LogError(DummyMessage);
        }

        public void withServices(HSAppsflyerService appsflyerService, HSFirebaseService hsFirebaseService)
        {
            Debug.LogError(DummyMessage);
        }

        public void withServices(HSAppsflyerService appsflyerService, HSFacebookService facebookService)
        {
            Debug.LogError(DummyMessage);
        }

        public void withServices(HSFirebaseService hsFirebaseService, HSFacebookService facebookService)
        {
            Debug.LogError(DummyMessage);
        }

        public void withServices(HSAppsflyerService appsflyerService, HSFirebaseService hsFirebaseService,
            HSFacebookService facebookService)
        {
            Debug.LogError(DummyMessage);
        }

        public void setDebugEnabled(bool value)
        {
            Debug.LogError(DummyMessage);
        }

        public void initialize(HSAppConfig appConfig, IHSAppInitializeListener hsAppInitializeListener)
        {
            Debug.LogError(DummyMessage);
        }

        public void setEnabled(bool value)
        {
            Debug.LogError(DummyMessage);
        }
    }
}