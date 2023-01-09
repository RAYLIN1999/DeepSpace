using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;
using Unity.VisualScripting;

public class UpgradeSystem : MonoBehaviour
{

    public static UpgradeSystem Instance; //Instantiating the UpgradeSystem.cs

    [SerializeField] private GameObject category_1_2;          //Content of the category oxygen+
    [SerializeField] private GameObject category_1_3;          //Content of the category health+
    [SerializeField] private GameObject category_2_3;          //Content of the category Ammunition+

    [SerializeField] private GameObject button_1_2;          //upgrade button of the category oxygen+
    [SerializeField] private GameObject button_1_3;          //upgrade button of the category health+
    [SerializeField] private GameObject button_2_3;          //upgrade button of the category Ammunition+

    [SerializeField] private int item_004_a;
    [SerializeField] private int item_005_a;
    [SerializeField] private int item_006_a;

    [SerializeField] private Button button_Oxygen;  //button oxygen_button

    void Awake()
    {
        Instance = this;
    }

    public void Initialise_UpgradeSystem()     //When showing or hiding the Upgrade System, change the initial page shown to the oxygen+ category
    {
        Debug.Log("Initialise Upgrade System");
        button_Oxygen.Select();
        Show_1_2_Category();
    }

    public void Upgrade_1_2_Equipment()     //Perform equipment upgrades - oxygen+
    {
        if(item_004_a >= 1 && item_005_a >= 1)
        {
            Debug.Log("upgrades - oxygen+");
            GameManager.Instance.Upgrade_1_2_Equipment();
        } else
        {
            Debug.Log("cannot upgrade");
        }
        
    }

    public void Upgrade_1_3_Equipment()     //Perform equipment upgrades - health+
    {
        if (item_004_a >= 1 && item_006_a >= 1)
        {
            Debug.Log("upgrades - health+");
            GameManager.Instance.Upgrade_1_3_Equipment();
        }
        else
        {
            Debug.Log("cannot upgrade");
        }
    }

    public void Upgrade_2_3_Equipment()     //Perform equipment upgrades - Ammunition+
    {
        if (item_005_a >= 1 && item_006_a >= 1)
        {
            Debug.Log("upgrades - Ammunition+");
            GameManager.Instance.Upgrade_2_3_Equipment();
        }
        else
        {
            Debug.Log("cannot upgrade");
        }
    }


    public void Show_1_2_Category()     //shown the oxygen+ category page
    {
        Debug.Log("show oxygen+");

        category_1_2.SetActive(true);
        category_1_3.SetActive(false);
        category_2_3.SetActive(false);
    }

    public void Show_1_3_Category()     //shown the health+ category page
    {
        Debug.Log("show health+");

        category_1_3.SetActive(true);
        category_1_2.SetActive(false);
        category_2_3.SetActive(false);
    }

    public void Show_2_3_Category()     //shown the Ammunition+ category page
    {
        Debug.Log("show Ammunition+");

        category_2_3.SetActive(true);
        category_1_2.SetActive(false);
        category_1_3.SetActive(false);
    }



    // Update is called once per frame
    void Start()
    {
        Initialise_UpgradeSystem();
    }

    void Update()
    {
        item_004_a = GameState.ItemAmount[3];       //get value from gamemanager.cs
        item_005_a = GameState.ItemAmount[4];
        item_006_a = GameState.ItemAmount[5];

        if (GameManager.Instance.Equipment_01_Upgrades) //If the equipment has not been upgraded, the button is displayed
        {
            button_1_2.SetActive(false);        //hide the button
        } else
        {
            button_1_2.SetActive(true);         //show the button
        }

        if (GameManager.Instance.Equipment_02_Upgrades) //If the equipment has not been upgraded, the button is displayed
        {
            button_1_3.SetActive(false);        //hide the button
        }
        else
        {
            button_1_3.SetActive(true);         //show the button
        }

        if (GameManager.Instance.Equipment_03_Upgrades) //If the equipment has not been upgraded, the button is displayed
        {
            button_2_3.SetActive(false);        //hide the button
        }
        else
        {
            button_2_3.SetActive(true);         //show the button
        }
    }
}
