using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wood_Tool_Trigger : MonoBehaviour
{
    public static Wood_Tool_Trigger Instance1; //Instantiating the Wood_Tool_Trigger.cs
    public static Wood_Tool_Trigger Instance2; //Instantiating the Wood_Tool_Trigger.cs

    [SerializeField] public bool couldInteract = false;

    void Awake()
    {
        if (Instance1 == null) Instance1 = this;
        else Instance2 = this;
    }


    public void OnTriggerEnter(Collider other)     //Enter the range of this object

    {
        couldInteract = true; //Interaction can only take place when the player is in range
        UIManager.Instance.ShowInteractButton();
    }

    public void OnTriggerExit(Collider other) //Leave the range of this object
    {
        couldInteract = false;
        UIManager.Instance.HideInteractButton();
    }

    public void wood_tool_active()
    {
        Debug.Log("wood_tool_active");
        if (GameState.ItemAmount[7]>0)gameObject.SetActive(false);
        UIManager.Instance.HideInteractButton();
    }
}
