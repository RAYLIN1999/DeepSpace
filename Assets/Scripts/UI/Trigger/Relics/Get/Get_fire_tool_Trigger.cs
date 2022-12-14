using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Get_fire_tool_Trigger : MonoBehaviour
{
    public static Get_fire_tool_Trigger Instance; //Instantiating the Get_fire_tool_Trigger.cs

    [SerializeField] public bool couldInteract = false;
    //[SerializeField] public GameObject thisObject;

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

    public void get_fire_tool()
    {
        Debug.Log("get item 007 - fire tool");
        GameState.ItemAmount[6]++;
        gameObject.SetActive(false);
    }
}
