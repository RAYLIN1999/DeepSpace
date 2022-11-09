using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    public Slider slider; //Health bar slider
    public Gradient gradient; //The color gradient of the health bar         Ѫ������ɫ����
    public Image fill;


    public void SetMaxHealth(int health) //Control the maximum value of the slider directly in the script          ֱ���ڴ����п���slider�����ֵ
    {
        slider.maxValue = health;  
        slider.value = health;

        fill.color = gradient.Evaluate(1f);
    }

    public void SetHealth(int health)  //Make the health value equal to the slider's value                  ʹ����ֵ����slider��ֵ
    {
        slider.value = health;

        fill.color = gradient.Evaluate(slider.normalizedValue);
    }


}
