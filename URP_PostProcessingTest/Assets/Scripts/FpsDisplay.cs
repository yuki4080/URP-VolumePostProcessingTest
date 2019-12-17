using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class FpsDisplay : MonoBehaviour
{
    int frameCount;
    float prevTime;
    [SerializeField] TMP_Text fps;

    void Start()
    {
        frameCount = 0;
        prevTime = 0.0f;
        if (ReferenceEquals(fps, null))
        {
            fps = gameObject.GetComponent<TMP_Text>();
        }
    }

    void Update()
    {
        frameCount++;
        float time = Time.realtimeSinceStartup - prevTime;

        if (time >= 0.5f)
        {
            fps.text = (frameCount / time).ToString("00fps");

            frameCount = 0;
            prevTime = Time.realtimeSinceStartup;
        }
    }
}