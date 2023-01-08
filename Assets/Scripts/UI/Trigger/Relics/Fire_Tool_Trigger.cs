using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fire_Tool_Trigger : MonoBehaviour
{
    public static Fire_Tool_Trigger Instance; //Instantiating the Fire_Tool_Trigger.cs

    [SerializeField] public bool couldInteract = false;

    void Awake()
    {
        Instance = this;
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

    public void fire_tool_active()
    {
        Debug.Log("fire_tool_active");
        //
    }
}
