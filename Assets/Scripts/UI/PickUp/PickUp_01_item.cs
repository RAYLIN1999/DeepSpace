using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUp_01_item : MonoBehaviour
{
    public static PickUp_01_item Instance; //Instantiating the PickUp_01_item.cs

    [SerializeField] public bool couldInteract = false;
    [SerializeField] private GameObject item_001;

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
        couldInteract = false;
        UIManager.Instance.HidePickUpButton();
    }

    public void pickupOxygentank()
    {
        item_001.SetActive(false);
        couldInteract = false;
        UIManager.Instance.HidePickUpButton();
        GameManager.Instance.PickUp_01_Item();
    }
}
