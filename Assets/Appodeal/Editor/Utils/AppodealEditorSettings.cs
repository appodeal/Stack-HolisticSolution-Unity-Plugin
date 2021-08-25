#if UNITY_EDITOR
using UnityEditor;
using UnityEngine;
using AppodealAds.Unity.Editor.Checkers;

namespace AppodealAds.Unity.Editor.Utils
{
    public class AppodealEditorSettings : ScriptableObject
    {
        [MenuItem("Holistic Solution/Appodeal SDK Documentation")]
        public static void OpenAppodealDocumentation()
        {
            Application.OpenURL("http://www.appodeal.com/sdk/choose_framework?framework=2&full=1&platform=1");
        }
        
        [MenuItem("Holistic Solution/HS SDK Documentation")]
        public static void OpenHsDocumentation()
        {
            Application.OpenURL("https://github.com/appodeal/Stack-HolisticSolution-Unity-Plugin#readme");
        }

        [MenuItem("Holistic Solution/Appodeal Homepage")]
        public static void OpenAppodealHome()
        {
            Application.OpenURL("http://www.appodeal.com");
        }

        [MenuItem("Holistic Solution/Appodeal Settings")]
        public static void SetAdMobAppId()
        {
            AppodealInternalSettings.ShowAppodealInternalSettings();
        }

        [MenuItem("Holistic Solution/Remove plugin")]
        public static void RemoveAppodealPlugin()
        {
            RemoveHelper.RemovePlugin();
        }
    }
}
#endif