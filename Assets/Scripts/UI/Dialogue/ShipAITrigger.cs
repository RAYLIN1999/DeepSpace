using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class ShipAITrigger : MonoBehaviour
{
    public static ShipAITrigger Instance; //Instantiating the ShipAITrigger.cs

    [SerializeField] public bool couldInteract = false;

    void Awake()
    {
        Instance = this;
    }


    public void OnTriggerEnter(Collider other)     //Show hint interface and button when triggered

    {
        couldInteract = true;      //Interaction can only take place when the player is in range
        UIManager.Instance.ShowCurrentStatusHint();
    }

    public void OnTriggerExit(Collider other) //Hide hint interface and button when not triggered
    {
        couldInteract = false;
        UIManager.Instance.HideCurrentStatusHint();
    }


}
