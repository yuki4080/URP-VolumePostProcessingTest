using UnityEngine;
using UnityEngine.UIElements;

public class HidePanelUI : MonoBehaviour
{
    public bool panelState;
    public bool naviState;
    InputSetting input;
    VisualElement element;
    PostProcessingManager manager;
    VCamManager vCam;

    public UIDocument MobileInputPanel;
    Button left;
    Button right;

    void OnEnable() => input.Enable();
    void OnDisable() => input.Disable();
    void OnDestroy() => input.Disable();

    void Awake()
    {
        manager = gameObject.GetComponent<PostProcessingManager>();
        vCam = GameObject.FindGameObjectWithTag("vCam").GetComponent<VCamManager>();

        element = MobileInputPanel.rootVisualElement;
        left = element.Q<Button>("LeftInput");
        right = element.Q<Button>("RightInput");
        left.clickable.clickedWithEventInfo += (Event) => vCam.vCamChange(false);
        right.clickable.clickedWithEventInfo += (Event) => vCam.vCamChange(true);
        element.style.display = DisplayStyle.None;

        input = new InputSetting();
        input.Panel.HidePanel.performed += ctx => HideUI();

        panelState = true;
        naviState = false;
    }

    public void HideUI()
    {
        panelState = !panelState;
        naviState = !naviState;
        manager.ShowUI(panelState);
        element.style.display = naviState ? DisplayStyle.Flex : DisplayStyle.None;
    }
}
