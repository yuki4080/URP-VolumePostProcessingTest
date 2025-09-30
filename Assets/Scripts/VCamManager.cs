using System.Collections.Generic;
using UnityEngine;
using Unity.Cinemachine;

public class VCamManager : MonoBehaviour
{
    InputSetting input;
    public List<CinemachineCamera> vcamera;
    int lPriority = 10;     // Low priority value
    int hPriority = 11;     // High priority value

    public int vcamActive = 0;
    void OnEnable() => input.Enable();
    void OnDisable() => input.Disable();
    void OnDestroy() => input.Disable();

    void Awake()
    {
        input = new InputSetting();
        input.Camera.LeftSide.performed += ctx => vCamChange(false);
        input.Camera.RightSide.performed += ctx => vCamChange(true);
    }

    public void vCamChange(bool sw)
    {
        int vcamCount = vcamera.Count - 1;

        if (sw)
        {
            if (vcamActive ++ >= vcamCount)
                vcamActive = 0;
        }
        else
        {
            if (vcamActive -- <= 0)
                vcamActive = vcamCount;
        }

        // Assign a Priority to each virtual cameras
        for (int i = 0; i <= vcamCount; i ++)
            vcamera[i].Priority = i == vcamActive ? hPriority : lPriority;
    }
}
