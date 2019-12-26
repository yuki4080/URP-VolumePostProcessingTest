using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using Cinemachine;

public class VCamManager : MonoBehaviour, InputActions.ICameraActions
{
    InputActions.CameraActions input;
    public List<CinemachineVirtualCamera> vcamera;

    public int vcamActive = 0;
    void OnEnable() => input.Enable();
    void OnDestroy() => input.Disable();

    void Awake()
    {
        input = new InputActions.CameraActions(new InputActions());
        input.SetCallbacks(this);
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

    public void OnLeftSide(InputAction.CallbackContext context)
    {
        if (context.started)
            vCamChange(false);
    }

    public void OnRightSide(InputAction.CallbackContext context)
    {
        if (context.started)
            vCamChange(false);
    }
}
