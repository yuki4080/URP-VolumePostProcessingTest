using UnityEngine;
using UnityEngine.InputSystem;

public class HidePanelUI : MonoBehaviour, InputActions.IPanelActions
{
    InputActions.PanelActions input;
    public GameObject panel;
    public GameObject navi;
    bool panelState;
    bool naviState;

    void OnEnable() => input.Enable();
    void OnDestroy() => input.Disable();

    void Awake()
    {
        panelState = true;
        naviState = false;
        HideUI();
        input = new InputActions.PanelActions(new InputActions());
        input.SetCallbacks(this);
    }

    void HideUI()
    {
        panelState = !panelState;
        naviState = !naviState;
        panel.SetActive(panelState);
        navi.SetActive(naviState);
    }

    public void OnHidePanel(InputAction.CallbackContext context)
    {
        if (context.started)
            HideUI();
    }
}
