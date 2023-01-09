using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item_010_PickUp : MonoBehaviour
{
    public static Item_010_PickUp Instance; //Instantiating the Item_010_PickUp.cs

    [SerializeField] public bool couldInteract = false;
    //[SerializeField] public GameObject thisObject;

    void Awake()
    {
        Instance = this;
    }


    public void OnTriggerEnter(Collider other)     //Enter the range of this object

    {
        couldInteract = true; //Interaction can only take place when the player is in range
        UIManager.Instance.ShowInteractButton();
    }

    public void OnTriggerExit(Collider other) //Leave the range of this object
    {
        couldInteract = false;
        UIManager.Instance.HideInteractButton();
    }

    public void get_010_item()
    {
        Debug.Log("get item 010 - task item 1");
        GameState.ItemAmount[9]++;
        gameObject.SetActive(false);
    }
}
