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
        GameObject Info = GameObject.FindGameObjectWithTag("Info");
        if (Info == null)
            return;
        Info.GetComponent<VersionDisplay>()._ColorSpace = PlayerSettings.colorSpace.ToString();
    }

    public int callbackOrder { get { return 0; } }
}
