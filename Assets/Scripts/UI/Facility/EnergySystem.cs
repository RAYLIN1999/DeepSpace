using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnergySystem : MonoBehaviour
{
    public static EnergySystem Instance; //Instantiating the EnergySystem.cs

    [SerializeField] private GameObject button_refill;

    [SerializeField] private int item_012_a;
    [SerializeField] private int item_013_a;


    void Awake()
    {
        Instance = this;
    }

    public void Refill_Energy()     //refill the energy
    {
        if (item_012_a >= 1 && item_013_a >= 1)
        {
            Debug.Log("refill the energy");
            GameManager.Instance.RefillEnergy();
        }
        else
        {
            Debug.Log("cannot refill");
        }
    }

    void Update()
    {
        item_012_a = GameManager.Instance.item_012_amount;       //get value from gamemanager.cs
        item_013_a = GameManager.Instance.item_013_amount;

        if (GameManager.Instance.EnergryRefilled) //If the energy has not been refilled, the button is displayed
        {
            button_refill.SetActive(false);        //hide the button
        }
        else
        {
            button_refill.SetActive(true);         //show the button
        }
    }
}
