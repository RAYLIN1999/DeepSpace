using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

[System.Serializable]
public class Dialogue 
{
    public string name;   //���жԻ���npc������

    [TextArea(3,10)]
    public string[] sentences;     //����Ҫ���еĶԻ�
}
