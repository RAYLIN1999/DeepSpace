using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Area_05_Trigger : MonoBehaviour
{
    public static Area_05_Trigger Instance; //Instantiating the Area_05_Trigger.cs

    [SerializeField] public bool couldInteract = false;

    void Awake()
    {
        Instance = this;
    }


    public void OnTriggerEnter(Collider other)     //Enter the range of this object

    {
        couldInteract = true; //Interaction can only take place when the player is in range
        UIManager.Instance.ShowCurrentStatusHint_Area_05_Trigger();
    }

    public void OnTriggerExit(Collider other) //Leave the range of this object
    {
        couldInteract = false;
        UIManager.Instance.HideCurrentStatusHint_Area_05_Trigger();
    }
}
