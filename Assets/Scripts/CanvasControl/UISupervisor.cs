using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class UISupervisor : MonoBehaviour
{
    void Awake()
    {
        DontDestroyOnLoad(transform.gameObject);
    }

    // States
    bool PauseMenuShowed = false;
    bool BagMenuShowed = false;
    bool TaskMenuShowed = false;

    bool InGameUIshowed = true;

    // Binded UI Objects
    [SerializeField] private GameObject InGameUI;                   //The normal interface display of the game running
    [SerializeField] private GameObject TasksMenu;                  //task menu interface
    [SerializeField] private GameObject PauseMenu;                  //pause menu interface
    [SerializeField] private GameObject BagMenu;                    //bag menu interface

    [SerializeField] private GameObject Facility_02_Panel;          //Upgrade System Interface
    [SerializeField] private GameObject Facility_03_Panel;          //Energy System Interface
    [SerializeField] private GameObject Facility_04_Panel;          //Spaceship AI Interface
    [SerializeField] private GameObject Facility_05_Panel;          //Portal Facility Interface
    [SerializeField] private GameObject Fire_Stone_Panel;           //fire stone tablet Interface
    [SerializeField] private GameObject Wood_Stone_Panel;           //wood stone tablet Interface

    [SerializeField] private GameObject GameOverDead;               //game over interface, Player dies , with zero health or oxygen
    [SerializeField] private GameObject GameOverWin_past;           //game over interface, Player win the game, back to the past
    [SerializeField] private GameObject GameOverWin_earth;          //game over interface, Player win the game, back to the earth

    [SerializeField] private GameObject DialogueInterface;          //dialogue interface
    [SerializeField] private GameObject startTalkButton;            //Start a conversation
    [SerializeField] private GameObject continueTalkButton;         //Switch to the next conversation
    [SerializeField] private GameObject closeTalkButton;            //Close the conversation
    [SerializeField] private GameObject interactButton;             //click button to interact with the object
    [SerializeField] private GameObject pickUpButton;               //click button to pick up the object


    [SerializeField] private GameObject doorButton;                 //Button for opening and closing the door

    [SerializeField] private GameObject CSH_Damage_Area_01;         //Current Status Hint text pop-ups triggered when approaching this object in area 01
    [SerializeField] private GameObject Door_area_01;

    [SerializeField] private GameObject CSH_Damage_Area_02;         //Current Status Hint text pop-ups triggered when approaching this object in area 02
    [SerializeField] private GameObject CSH_Normal_Area_02;

    [SerializeField] private GameObject CSH_Damage_Area_03;         //Current Status Hint text pop-ups triggered when approaching this object in area 03
    [SerializeField] private GameObject CSH_Normal_Area_03;

    [SerializeField] private GameObject CSH_Normal_Area_04;         //Current Status Hint text pop-ups triggered when approaching this object in area 05

    [SerializeField] private GameObject CSH_Normal_Area_05;         //Current Status Hint text pop-ups triggered when approaching this object in area 05

    [SerializeField] private GameObject CSH_Normal_Fire_Stone;      //Current Status Hint text pop-ups triggered when approaching this object in Fire_Stone

    [SerializeField] private GameObject CSH_Normal_Wood_Stone;      //Current Status Hint text pop-ups triggered when approaching this object in Wood_Stone


    [SerializeField] private TMP_Text HealthPoint;                  //Text display of health value
    [SerializeField] private TMP_Text OxygenPoint;                  //Text display of oxygen value
    [SerializeField] private TMP_Text doorButtonText;               //open or close

    [SerializeField] private TMP_Text item_004_amount;

    // UI Control Functions
    void ShowInGameUI()                                 //display HUD, hide the menu
    {
        InGameUIshowed = true;
        InGameUI.SetActive(true);
        Time.timeScale = 1;                             //Continue the game
        Cursor.lockState = CursorLockMode.Locked;       //Lock the cursor again
    }

    void HideInGameUI()                                 //hide HUD, show the menu
    {
        InGameUIshowed = false;
        InGameUI.SetActive(false);
        Time.timeScale = 0;                             //Pause the game
        Cursor.lockState = CursorLockMode.None;         //Allows button clicks with the cursor
    }

    public void ShowPauseMenu()                         //display pause menu
    {
        HideInGameUI();
        PauseMenuShowed = true;
        PauseMenu.SetActive(PauseMenuShowed);
    }
    public void HidePauseMenu()                         //hide pause menu
    {
        ShowInGameUI();
        PauseMenuShowed = false;
        PauseMenu.SetActive(PauseMenuShowed);
    }

    public void ShowTaskMenu()                          //display task menu
    {
        HideInGameUI();                                 //Hide HUD for better visual
        TaskMenuShowed = true;
        TasksMenu.SetActive(true);
    }

    public void HideTaskMenu()                          //hide task menu
    {
        ShowInGameUI();
        TaskMenuShowed = false;
        TasksMenu.SetActive(false);
    }
    public void ShowBagMenu()                           //display bag menu
    {
        Debug.Log("Show BagMenu");
        HideInGameUI();
        BagMenuShowed = true;
        BagMenu.SetActive(true);
        BagManager.Instance.Initialise_BagMenu();
    }

    public void HideBagMenu()                           //hide bag menu
    {
        Debug.Log("Hide BagMenu");
        ShowInGameUI();
        BagMenuShowed = false;
        BagMenu.SetActive(false);
        BagManager.Instance.Initialise_BagMenu();
    }
    void BackToMainMenu()
    {

    }void ReplayGame()
    {

    }


    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyUp(KeyCode.P))                  //Shortcut keys to control the display of the  pause menu interface
        {
            if (PauseMenuShowed && !InGameUIshowed)     //It can only be triggered when the  pause menu interface is displayed
            {
                HidePauseMenu();
            }
            else if (!PauseMenuShowed && InGameUIshowed)
            {
                ShowPauseMenu();
            }
        }


        if (Input.GetKeyUp(KeyCode.B))                  //Shortcut keys to control the display of the bag menu interface
        {
            if (BagMenuShowed && !InGameUIshowed)       //It can only be triggered when the bag menu interface is displayed
            {
                HideBagMenu();
            }
            else if (!BagMenuShowed && InGameUIshowed)
            {
                ShowBagMenu();
            }
        }

        if (Input.GetKeyUp(KeyCode.T))                  //Shortcut keys to control the display of the task menu interface
        {
            if (TaskMenuShowed && !InGameUIshowed)      //It can only be triggered when the task menu interface is displayed
            {
                HideTaskMenu();
            }
            else if (!TaskMenuShowed && InGameUIshowed)
            {
                ShowTaskMenu();
            }
        }


        if (Input.GetKeyUp(KeyCode.Y))                  //Shortcut keys to turn to scene 'main menu'
        {
            if (PauseMenuShowed || GameState.GameEnd)   //It can only be triggered when the pause menu interface is displayed  
            {                                           // or game end
                BackToMainMenu();
            }

        }

        if (Input.GetKeyUp(KeyCode.R))                  //Shortcut keys to reload scene 'main game'
        {
            if (PauseMenuShowed || GameState.GameEnd)   //It can only be triggered when the pause menu interface is displayed  
            {                                           // or game end
                ReplayGame();
            }

        }

        if (Input.GetKeyUp(KeyCode.F))                  //Shortcut keys to interact with the facility
        {

        }
    }
}
