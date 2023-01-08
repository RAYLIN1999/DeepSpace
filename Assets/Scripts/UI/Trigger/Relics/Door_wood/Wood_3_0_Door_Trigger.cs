using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wood_3_0_Door_Trigger : MonoBehaviour
{
    public static Wood_3_0_Door_Trigger Instance; //Instantiating the Wood_3_0_Door_Trigger.cs

    [SerializeField] public bool couldInteract = false;

    void Awake()
    {
        Instance = this;
    }


    public void OnTriggerEnter(Collider other)     //Enter the range of this object

    {
        couldInteract = true; //Interaction can only take place when the player is in range
        UIManager.Instance.ShowCurrentStatusHint_Door_Relics();
    }

    public void OnTriggerExit(Collider other) //Leave the range of this object
    {
        couldInteract = false;
        UIManager.Instance.HideCurrentStatusHint_Door_Relics();
    }
}
