using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item_016_PickUp : MonoBehaviour
{
    public static Item_016_PickUp Instance; //Instantiating the Item_016_PickUp.cs

    [SerializeField] public bool couldInteract = false;
    //[SerializeField] public GameObject thisObject;

    void Awake()
    {
        Instance = this;
    }


    public void OnTriggerEnter(Collider other)     //Enter the range of this object

    {
        couldInteract = true; //Interaction can only take place when the player is in range
        UIManager.Instance.ShowPickUpButton(get_016_item);
    }

    public void OnTriggerExit(Collider other) //Leave the range of this object
    {
        couldInteract = false;
        UIManager.Instance.HidePickUpButton();
    }

    public void get_016_item()
    {
        Debug.Log("get item 016 - piece item");
        GameState.ItemAmount[15]++;
        gameObject.SetActive(false);
    }
}
