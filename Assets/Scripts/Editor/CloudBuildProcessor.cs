using UnityEngine;
using UnityEditor;
using UnityEditor.Build;
using UnityEditor.Build.Reporting;
using UnityEngine.SceneManagement;

public class CloudBuildProcessor : IPreprocessBuildWithReport, IProcessSceneWithReport
{
    public void OnPreprocessBuild(BuildReport report)
    {
#if CLOUD_BUILD_GAMMA
        PlayerSettings.colorSpace = ColorSpace.Gamma;
#endif
    }

    public void OnProcessScene(Scene scene, BuildReport report)
    {
#if !UNITY_EDITOR
        GameObject Info = GameObject.FindGameObjectWithTag("Info");
        Info.GetComponent<VersionDisplay>()._ColorSpace = PlayerSettings.colorSpace.ToString();
#endif
    }

    public int callbackOrder { get { return 0; } }
}
