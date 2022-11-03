using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    public Slider slider; //Health bar slider
    public Gradient gradient; //Ѫ������ɫ����
    public Image fill;
    

    public void SetMaxHealth(int health) //ֱ���ڴ����п���slider�����ֵ
    {
        slider.maxValue = health;  
        slider.value = health;

        fill.color = gradient.Evaluate(1f);
    }

    public void SetHealth(int health)  //ʹ����ֵ����slider��ֵ
    {
        slider.value = health;

        fill.color = gradient.Evaluate(slider.normalizedValue);
    }

}
