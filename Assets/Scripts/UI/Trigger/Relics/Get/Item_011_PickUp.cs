using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item_011_PickUp : MonoBehaviour
{
    public static Item_011_PickUp Instance; //Instantiating the Item_011_PickUp.cs

    [SerializeField] public bool couldInteract = false;
    //[SerializeField] public GameObject thisObject;

    void Awake()
    {
        Instance = this;
    }


    public void OnTriggerEnter(Collider other)     //Enter the range of this object

    {
        couldInteract = true; //Interaction can only take place when the player is in range
        UIManager.Instance.ShowPickUpButton(get_011_item);
    }

    public void OnTriggerExit(Collider other) //Leave the range of this object
    {
        couldInteract = false;
        UIManager.Instance.HidePickUpButton();
    }

    public void get_011_item()
    {
        Debug.Log("get item 011 - task item 2");
        GameState.ItemAmount[10]++;
        gameObject.SetActive(false);
    }
}
