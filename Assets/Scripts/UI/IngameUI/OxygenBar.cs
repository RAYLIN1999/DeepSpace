using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OxygenBar : MonoBehaviour
{
    public Slider slider; //Health bar slider
    public Gradient gradient; ////The color gradient of the oxygen bar        ����������ɫ����
    public Image fill;


    public void SetMaxOxygen(int oxygen) //Control the maximum value of the slider directly in the script          ֱ���ڴ����п���slider�����ֵ
    {
        slider.maxValue = oxygen;
        slider.value = oxygen;

        fill.color = gradient.Evaluate(1f);
    }

    public void SetOxygen(int oxygen)  //Make the oxygen value equal to the slider's value                  ʹ����ֵ����slider��ֵ
    {
        slider.value = oxygen;

        fill.color = gradient.Evaluate(slider.normalizedValue);
    }
}
