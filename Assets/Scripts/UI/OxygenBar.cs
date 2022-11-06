using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OxygenBar : MonoBehaviour
{
    public Slider slider; //Health bar slider
    public Gradient gradient; //����������ɫ����
    public Image fill;


    public void SetMaxOxygen(int oxygen) //ֱ���ڴ����п���slider�����ֵ
    {
        slider.maxValue = oxygen;
        slider.value = oxygen;

        fill.color = gradient.Evaluate(1f);
    }

    public void SetOxygen(int oxygen)  //ʹ����ֵ����slider��ֵ
    {
        slider.value = oxygen;

        fill.color = gradient.Evaluate(slider.normalizedValue);
    }
}
