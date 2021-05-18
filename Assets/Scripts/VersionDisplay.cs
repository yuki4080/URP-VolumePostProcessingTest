using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class VersionDisplay : MonoBehaviour
{
    public string _ColorSpace;
    [SerializeField] TMP_Text msg;

#if UNITY_EDITOR
    void Start()
    {
        _ColorSpace = UnityEditor.PlayerSettings.colorSpace.ToString();
    }
#endif

    void Update()
    {
        msg.text = Application.platform + ", UnityVersion: " + Application.unityVersion + "\n" + SystemInfo.graphicsDeviceVersion + "\nColor Space: " + _ColorSpace;
    }
}
