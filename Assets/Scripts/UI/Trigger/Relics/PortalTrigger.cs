using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortalTrigger : MonoBehaviour
{
    public static PortalTrigger Instance; //Instantiating the PortalTrigger.cs

    [SerializeField] public bool couldInteract = false;

    void Awake()
    {
        Instance = this;
    }


    public void OnTriggerEnter(Collider other)     //Enter the range of this object

    {
        couldInteract = true; //Interaction can only take place when the player is in range
        UIManager.Instance.ShowCurrentStatusHint_Portal_Spaceship();
    }

    public void OnTriggerExit(Collider other) //Leave the range of this object
    {
        couldInteract = false;
        UIManager.Instance.HideCurrentStatusHint_Portal_Spaceship();
    }
}
