using UnityEngine;

public class HidePanelUI : MonoBehaviour
{
    InputSetting input;
    public GameObject panel;
    public GameObject navi;
    bool panelState;
    bool naviState;

    void OnEnable() => input.Enable();
    void OnDisable() => input.Disable();
    void OnDestroy() => input.Disable();

    void Awake()
    {
        input = new InputSetting();
        input.Panel.HidePanel.performed += ctx => HideUI();

        panelState = true;
        naviState = false;
        HideUI();
    }

    void HideUI()
    {
        panelState = !panelState;
        naviState = !naviState;
        panel.SetActive(panelState);
        navi.SetActive(naviState);
    }
}
