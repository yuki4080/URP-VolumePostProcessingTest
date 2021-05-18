using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class VCamManager : MonoBehaviour
{
    InputSetting input;
    public List<CinemachineVirtualCamera> vcamera;

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

    void vCamChange(bool sw)
    {
        if (sw)
        {
            if (vcamActive ++ >= vcamera.Count - 1)
                vcamActive = 0;
        }
        else
        {
            if (vcamActive -- <= 0)
                vcamActive = vcamera.Count - 1;
        }

        for (int i = 0; i <= vcamera.Count; i ++)
        {
            if (i == vcamActive)
                vcamera[i].Priority = 11;
            else
                vcamera[i].Priority = 10;
        }
    }
}
