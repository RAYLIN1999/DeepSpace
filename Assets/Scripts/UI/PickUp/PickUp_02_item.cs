using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUp_02_item : MonoBehaviour
{
    public static PickUp_02_item Instance; //Instantiating the PickUp_02_item.cs

    [SerializeField] public bool couldInteract = false;
    [SerializeField] private GameObject item_002;

    void Awake()
    {
        Instance = this;
    }
    public void OnTriggerEnter(Collider other)     //Show button when triggered

    {
        couldInteract = true;
        UIManager.Instance.ShowPickUpButton();
    }

    public void OnTriggerExit(Collider other) //Hide button when not triggered
    {
        couldInteract=false;
        UIManager.Instance.HidePickUpButton();
    }

    public void pickupOxygentank()
    {
        item_002.SetActive(false);
        couldInteract = false;
        UIManager.Instance.HidePickUpButton();
        GameManager.Instance.PickUp_02_Item();
    }
}
