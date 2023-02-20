using UnityEngine;
using UnityEngine.InputSystem.EnhancedTouch;
using Touch = UnityEngine.InputSystem.EnhancedTouch.Touch;
using TouchPhase = UnityEngine.InputSystem.TouchPhase;

public class ShowMenuPanelTouch : MonoBehaviour
{
    public HidePanelUI panelUI;
    float lastDistance;

    void Update()
    {
        if (Touch.activeTouches.Count < 2) return;

        var touch0 = Touch.activeTouches[0];
        var touch1 = Touch.activeTouches[1];

        if (touch1.phase == TouchPhase.Began)
        {
            lastDistance = Vector2.Distance(touch0.screenPosition, touch1.screenPosition);
        }

        if (!(touch0.phase == TouchPhase.Moved) && !(touch1.phase == TouchPhase.Moved))
        {
            return;
        }

        float distance = Vector2.Distance(touch0.screenPosition, touch1.screenPosition);

        OnPinch(distance - lastDistance);
        lastDistance = distance;
    }
    void OnPinch(float delta)
    {
        if (panelUI.panelState) return;
        if (delta >= 10f)
        {
            panelUI.HideUI();
        }
    }

    void OnEnable() => EnhancedTouchSupport.Enable();
    void OnDisable() => EnhancedTouchSupport.Disable();
}
