using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using StackHolisticSolution.Api;
using StackHolisticSolution.Common;
using UnityEngine;

[SuppressMessage("ReSharper", "InconsistentNaming")]
public class HolisticSolutionDemo : MonoBehaviour, IHSAppInitializeListener
{
    
    void Start()
    {
        HSLogger.setEnabled(true);
        HSAppodealConnector hsAppodealConnector = new HSAppodealConnector();
        HSAppsflyerService appsflyerService = new HSAppsflyerService("YOUR_APPSFLYER_DEV_KEY");
        HSFirebaseService firebaseService = new HSFirebaseService();
        HSFacebookService facebookService = new HSFacebookService();

        HSAppConfig appConfig = new HSAppConfig()
            .withServices(appsflyerService, firebaseService, facebookService)
            .withConnectors(hsAppodealConnector)
            .setDebugEnabled(true);

        HSApp.initialize(appConfig, this);
        
    }

    public void onAppInitialized(List<HSError> hsErrors)
    {
        Debug.Log("onAppInitialized");
    }
}