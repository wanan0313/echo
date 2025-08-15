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
            // ���ݹ��ַ������Sliderֵ
            targetSlider.value += scroll * scrollSensitivity;

            // ȷ��ֵ�ںϷ���Χ��
            targetSlider.value = Mathf.Clamp(
                targetSlider.value,
                targetSlider.minValue,
                targetSlider.maxValue
            );
        }
    }
}