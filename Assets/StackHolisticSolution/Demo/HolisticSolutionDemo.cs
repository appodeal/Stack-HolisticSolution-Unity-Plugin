using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using StackHolisticSolution.Api;
using StackHolisticSolution.Common;
using UnityEngine;

[SuppressMessage("ReSharper", "InconsistentNaming")]
public class HolisticSolutionDemo : MonoBehaviour, IHSAppInitializeListener
{
    public const string YOUR_APPSFLYER_DEV_KEY = "";

    void Start()
    {
        HSAppodealConnector hsAppodealConnector = new HSAppodealConnector();

        HSAppsflyerService appsflyerService = new HSAppsflyerService(YOUR_APPSFLYER_DEV_KEY);

        //Create service for Firebase
        HSFirebaseService firebaseService = new HSFirebaseService();

        //Create HSApp configuration
        HSAppConfig appConfig = new HSAppConfig()
            .withServices(appsflyerService, firebaseService)
            .withConnectors(hsAppodealConnector)
            .setDebugEnabled(true);

        HSApp.initialize(appConfig, this);

        HSLogger.setEnabled(true);
        
    }

    // Update is called once per frame
    void Update()
    {
    }

    public void onAppInitialized()
    {
        Debug.Log("onAppInitialized");
    }

    public void onAppInitializationFailed(HSError hsError)
    {
        Debug.Log("onAppInitializationFailed");
    }
}