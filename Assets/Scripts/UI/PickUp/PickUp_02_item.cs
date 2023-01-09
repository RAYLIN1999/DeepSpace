using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUp_02_item : MonoBehaviour
{
    public void OnTriggerEnter(Collider other)     //Show button when triggered
    {
        UIManager.Instance.ShowPickUpButton(pickupOxygentank);
    }

    public void OnTriggerExit(Collider other) //Hide button when not triggered
    {
        UIManager.Instance.HidePickUpButton();
    }

    public void pickupOxygentank()
    {
        UIManager.Instance.HidePickUpButton();
        GameState.ItemAmount[1]++;
        gameObject.SetActive(false);
    }
}
