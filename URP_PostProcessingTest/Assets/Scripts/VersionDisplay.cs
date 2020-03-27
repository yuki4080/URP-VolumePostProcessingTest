using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class VersionDisplay : MonoBehaviour
{
    public string _ColorSpace;
    [SerializeField] TMP_Text msg;

    void Update()
    {
        msg.text = Application.platform + ", UnityVersion: " + Application.unityVersion + "\n" + SystemInfo.graphicsDeviceVersion + "\nColor Space: " + _ColorSpace;
    }
}
