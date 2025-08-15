using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.UI;


public class ScrollWheelSliderControl : MonoBehaviour
{
    public Slider targetSlider;
    public float scrollSensitivity = 3f;

    void Update()
    {
        float scroll = Input.GetAxis("Mouse ScrollWheel");

        if (scroll != 0 && targetSlider != null)
        {
            // 根据滚轮方向调整Slider值
            targetSlider.value += scroll * scrollSensitivity;

            // 确保值在合法范围内
            targetSlider.value = Mathf.Clamp(
                targetSlider.value,
                targetSlider.minValue,
                targetSlider.maxValue
            );
        }
    }
}