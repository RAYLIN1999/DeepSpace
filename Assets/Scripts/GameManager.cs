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

    [SerializeField] public bool Area_01_unlocked = false;
    [SerializeField] public bool Area_02_unlocked = false;
    [SerializeField] public bool Area_03_unlocked = false;

    [SerializeField] public bool Equipment_01_Upgrades = false;
    [SerializeField] public bool Equipment_02_Upgrades = false;
    [SerializeField] public bool Equipment_03_Upgrades = false;

    // Start is called before the first frame update
    void Start()
    {
        DontDestroyOnLoad(gameObject);
    }

    public void Upgrade_1_2_Equipment()     //Perform equipment upgrades - oxygen+
    {
        Debug.Log("upgrades 1+2 successfully ");
        
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



}
