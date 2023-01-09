using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fire_Stone_Trigger : MonoBehaviour
{
    public static Fire_Stone_Trigger Instance; //Instantiating the Fire_Stone_Trigger.cs

    [SerializeField] public bool couldInteract = false;

    void Awake()
    {
        Instance = this;
    }
    public void OnTriggerEnter(Collider other)     //Enter the range of this object

    {
        couldInteract = true; //Interaction can only take place when the player is in range
        UIManager.Instance.ShowCurrentStatusHint_Fire_Stone_Trigger();
    }

    public void OnTriggerExit(Collider other) //Leave the range of this object
    {
        couldInteract = false;
        UIManager.Instance.HideCurrentStatusHint_Fire_Stone_Trigger();
    }
}