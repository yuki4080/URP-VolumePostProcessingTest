using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.InputSystem;

public class HidePanelUI : MonoBehaviour
{
    public GameObject panel;
    public InputAction hidePanel;
    bool state;

    private void OnEnable()
    {
        hidePanel.Enable();
    }

    private void OnDisable()
    {
        hidePanel.Disable();
    }

    void Awake()
    {
        state = true;
        HideUI();
        hidePanel.performed += ctx => HideUI();
    }

    void HideUI()
    {
        state = !state;
        panel.SetActive(state);
    }
}
