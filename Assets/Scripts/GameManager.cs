using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance; //Instantiating the GameManager.cs


    void Awake()
    {
        Instance = this;
    }


    [SerializeField] public bool Area_01_unlocked = false;    //Determine if the area is unlocked
    [SerializeField] public bool Area_02_unlocked = false;
    [SerializeField] public bool Area_03_unlocked = false;

    [SerializeField] public bool Fire_Stone_unlocked = false;  //Determine if the stone is unlocked
    [SerializeField] public bool Wood_Stone_unlocked = false;

    [SerializeField] public bool Equipment_01_Upgrades = false;   //Determine if the equipment is upgraded
    [SerializeField] public bool Equipment_02_Upgrades = false;
    [SerializeField] public bool Equipment_03_Upgrades = false;

    [SerializeField] public bool EnergryRefilled = false;    //Determine if the energy is refilled

    [SerializeField] public bool Trigger_Area_01 = false;    //Determine if this trigger is in range
    [SerializeField] public bool Trigger_Area_02 = false;
    [SerializeField] public bool Trigger_Area_03 = false;
    [SerializeField] public bool Trigger_Area_05 = false;

    [SerializeField] public bool Difficulty_easy = false;     //Judging the difficulty of the game
    [SerializeField] public bool Difficulty_normal = false;
    [SerializeField] public bool Difficulty_hard = false;


    [SerializeField] public int item_001_amount;     //Amount of the items
    [SerializeField] public int item_002_amount; 
    [SerializeField] public int item_003_amount;
    [SerializeField] public int item_004_amount;
    [SerializeField] public int item_005_amount;
    [SerializeField] public int item_006_amount;
    [SerializeField] public int item_007_amount;
    [SerializeField] public int item_008_amount;
    [SerializeField] public int item_009_amount;
    [SerializeField] public int item_010_amount;
    [SerializeField] public int item_011_amount;
    [SerializeField] public int item_012_amount;
    [SerializeField] public int item_013_amount;
    [SerializeField] public int item_014_amount;
    [SerializeField] public int item_015_amount;
    [SerializeField] public int item_016_amount;
    [SerializeField] public int item_017_amount;



    // Start is called before the first frame update
    void Start()
    {
        //DontDestroyOnLoad(gameObject);
    }

    public void Set_Difficulty_Easy()     //set the difficulty of the game
    {
        Debug.Log("defficult --> Easy");
        Difficulty_easy = true;
        Difficulty_normal = false;
        Difficulty_hard = false;
    }

    public void Set_Difficulty_Normal()     //set the difficulty of the game
    {
        Debug.Log("defficult --> Normal");
        Difficulty_easy = false;
        Difficulty_normal = true;
        Difficulty_hard = false;
    }

    public void Set_Difficulty_Hard()     //set the difficulty of the game
    {
        Debug.Log("defficult --> Hard");
        Difficulty_easy = false;
        Difficulty_normal = false;
        Difficulty_hard = true;
    }


    public void Area_01_unlock()     //unlock the area 01
    {
        Debug.Log("unlock the area 01");
        Area_01_unlocked = true;
    }

    public void Area_02_unlock()     //unlock the area 02
    {
        Debug.Log("unlock the area 02");
        Area_02_unlocked = true;
    }

    public void Area_03_unlock()     //unlock the area 03
    {
        Debug.Log("unlock the area 03");
        Area_03_unlocked = true;
    }

    public void Upgrade_1_2_Equipment()     //Perform equipment upgrades - oxygen+
    {
        Debug.Log("upgrades 1+2 successfully ");
        item_004_amount -= item_004_amount;
        item_005_amount -= item_005_amount;
        Equipment_01_Upgrades = true;
    }

    public void Upgrade_1_3_Equipment()     //Perform equipment upgrades - health+
    {
        Debug.Log("upgrades 1+3 successfully ");

        Equipment_02_Upgrades = true;
    }

    public void Upgrade_2_3_Equipment()     //Perform equipment upgrades - Ammunition+
    {
        Debug.Log("upgrades 1+2 successfully ");

        Equipment_03_Upgrades = true;
    }

    public void RefillEnergy()     //refill the energy of the spaceship
    {
        Debug.Log("refill the energy of the spaceship successfully ");
        item_012_amount -= item_012_amount;
        item_013_amount -= item_013_amount;
        EnergryRefilled = true;
    }

    public void PickUp_01_Item()     //pick up item 001
    {
        Debug.Log("pick up a halth potion");
        item_001_amount += item_001_amount;
    }

    public void PickUp_02_Item()     //pick up item 002
    {
        Debug.Log("pick up an oxygen tank");
        item_002_amount += item_002_amount;
    }

    public void back_to_Past()     //back to the past
    {
        Debug.Log("back to the past");
        UIManager.Instance.ShowGameOverWin_Past();
    }

    public void back_to_Earth()     //back to the earth
    {
        Debug.Log("back to the earth");
        UIManager.Instance.ShowGameOverWin_Earth();

    }


    void Update()
    {
        Trigger_Area_02 = Area_02_Trigger.Instance.couldInteract;
        Trigger_Area_03 = Area_03_Trigger.Instance.couldInteract;
        Trigger_Area_05 = Area_05_Trigger.Instance.couldInteract;

    }

}
