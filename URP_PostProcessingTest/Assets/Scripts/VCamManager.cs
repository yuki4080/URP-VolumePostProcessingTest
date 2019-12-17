using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using Cinemachine;

public class VCamManager : MonoBehaviour
{
    public InputAction leftShoulder;
    public InputAction rightShoulder;
    public List<CinemachineVirtualCamera> vcamera;

    public int vcamActive = 0;

    private void OnEnable()
    {
        leftShoulder.Enable();
        rightShoulder.Enable();
    }

    private void OnDisable()
    {
        leftShoulder.Disable();
        rightShoulder.Disable();
    }

    void Awake()
    {
        leftShoulder.performed += ctx => vCamChange(false);
        rightShoulder.performed += ctx => vCamChange(true);
    }

    void vCamChange(bool sw)
    {
        if (sw)
        {
            if (vcamActive ++ >= vcamera.Count - 1)
            {
                vcamActive = 0;
            }
        }
        else
        {
            if (vcamActive -- <= 0)
            {
                vcamActive = vcamera.Count - 1;
            }
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
