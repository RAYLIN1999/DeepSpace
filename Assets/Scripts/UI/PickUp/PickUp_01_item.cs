using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUp_01_item : MonoBehaviour
{
    public void OnTriggerEnter(Collider other)     //Show button when triggered
    {
        UIManager.Instance.ShowPickUpButton(pickupHealthtank);
    }

    public void OnTriggerExit(Collider other) //Hide button when not triggered
    {
        UIManager.Instance.HidePickUpButton();
    }

    public void pickupHealthtank()
    {
        UIManager.Instance.HidePickUpButton();
        GameState.ItemAmount[0]++;
        gameObject.SetActive(false);
    }
}
