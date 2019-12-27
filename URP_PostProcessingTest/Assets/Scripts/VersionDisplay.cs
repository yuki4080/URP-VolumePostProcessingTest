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
        msg.text = Application.platform + ", Version Number: " + Application.unityVersion + ", " + SystemInfo.graphicsDeviceVersion + ", Color Space: " + _ColorSpace;
    }
}
