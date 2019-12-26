using UnityEngine;
using UnityEngine.InputSystem;

public class HidePanelUI : MonoBehaviour, InputActions.IPanelActions
{
    InputActions.PanelActions input;
    public GameObject panel;
    bool state;

    void OnEnable() => input.Enable();
    void OnDestroy() => input.Disable();

    void Awake()
    {
        state = true;
        HideUI();
        input = new InputActions.PanelActions(new InputActions());
        input.SetCallbacks(this);
    }

    void HideUI()
    {
        state = !state;
        panel.SetActive(state);
    }

    public void OnHidePanel(InputAction.CallbackContext context)
    {
        if (context.started)
            HideUI();
    }
}
