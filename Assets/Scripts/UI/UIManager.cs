using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;
using System;

public class UIManager : MonoBehaviour
{
    public static UIManager Instance; //Instantiating the MenuManager.cs

    void Awake()
    {
        Instance = this;
        DontDestroyOnLoad(transform.gameObject);
    }

    // Binded UI Objects
    [SerializeField] private GameObject InGameUI;                   //The normal interface display of the game running
    [SerializeField] private GameObject TasksMenu;                  //task menu interface
    [SerializeField] private GameObject PauseMenu;                  //pause menu interface
    [SerializeField] private GameObject BagMenu;                    //bag menu interface
    [SerializeField] private GameObject SettingMenu;                //setting menu interface

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

    [SerializeField] private GameObject CSH_Normal_Portal_Spaceship;//Current Status Hint text pop-ups triggered when approaching this object in Portal_Spaceship

    [SerializeField] private GameObject CSH_Normal_Relics_Door;     //Current Status Hint text pop-ups triggered when approaching this object in Relics_Door
    [SerializeField] private GameObject CSH_Disabled_Relics_Door;

    [SerializeField] private TMP_Text HealthPoint;                  //Text display of health value
    [SerializeField] private TMP_Text OxygenPoint;                  //Text display of oxygen value
    [SerializeField] private TMP_Text doorButtonText;               //open or close

    [SerializeField] private TMP_Text item_004_amount;

    //UI controllers
    public HealthBar healthBar;                                     //Reference script HealthBar.cs
    public OxygenBar oxygenBar;                                     //Reference script OxygenBar.cs

    [SerializeField] public bool InGameUIshowed = true;
    [SerializeField] public bool TaskMenuShowed = false;            //Determine if the interface is being displayed
    [SerializeField] public bool PauseMenuShowed = false;
    [SerializeField] public bool BagMenuShowed = false;
    [SerializeField] public bool GameEnd = false;                   //Whether the game wins or loses, the game is end
    [SerializeField] public bool ConversationStart;
    [SerializeField] public bool ConversationOver;
    [SerializeField] public bool ConversationButtonshowed = false;

    [SerializeField] public bool doorButtonshowed = false;          //Determine if the door button is displayed
    [SerializeField] public bool doorOpened = false;                //Determining whether a door is open or not

    [SerializeField] private GameObject Button_on;
    [SerializeField] private GameObject Button_off;

    private Action pickupFunc = null;



    public void ShowInGameUI()     //display in game interface, hide the menu
    {
        Debug.Log("Show InGameUI");
        InGameUIshowed = true;
        InGameUI.SetActive(true);
        Time.timeScale = 1;                           //Continue the game
        Cursor.lockState = CursorLockMode.Locked;     //Lock the cursor again
    }

    public void HideInGameUI()    //hide in game interface, show the menu
    {
        Debug.Log("Hide InGameUI");
        InGameUIshowed = false;
        InGameUI.SetActive(false);
        Time.timeScale = 0;                         //Pause the game
        Cursor.lockState = CursorLockMode.None;     //Allows button clicks with the cursor
    }

    public void ShowPauseMenu()   //display interface
    {
        Debug.Log("Show PauseMenu");
        HideInGameUI();
        PauseMenuShowed = true;
        PauseMenu.SetActive(true);
    }

    public void ShowTaskMenu()    //display interface
    {
        Debug.Log("Show TaskMenu");
        HideInGameUI();
        TaskMenuShowed = true;
        TasksMenu.SetActive(true);
        
    }

    public void HideTaskMenu()  //hide interface
    {
        Debug.Log("Hide TaskMenu");
        ShowInGameUI();
        TaskMenuShowed = false;
        TasksMenu.SetActive(false);
    }

    public void HidePauseMenu()   //hide interface
    {
        Debug.Log("Hide PauseMenu");
        ShowInGameUI();
        PauseMenuShowed = false;
        PauseMenu.SetActive(false);
        SettingMenu.SetActive(false);
    }


    public void ShowBagMenu()   //display interface
    {
        Debug.Log("Show BagMenu");
        HideInGameUI();
        BagMenuShowed = true;
        BagMenu.SetActive(true);
        BagManager.Instance.Initialise_BagMenu();
    }

    public void HideBagMenu()   //hide interface
    {
        Debug.Log("Hide BagMenu");
        ShowInGameUI();
        BagMenuShowed = false;
        BagMenu.SetActive(false);
        BagManager.Instance.Initialise_BagMenu();
    }

    public void Show_Facility_02_Panel()   //display interface
    {
        Debug.Log("Show Upgrade System Interface");
        HideInGameUI();

        Facility_02_Panel.SetActive(true);
        HideInteractButton();
        
    }

    public void Hide_Facility_02_Panel()   //hide interface
    {
        Debug.Log("Hide Upgrade System Interface");
        ShowInGameUI();
        Facility_02_Panel.SetActive(false);
        ShowInteractButton();
    }

    public void Show_Facility_03_Panel()   //display interface
    {
        Debug.Log("Show Energy System Interface");
        HideInGameUI();

        Facility_03_Panel.SetActive(true);
        HideInteractButton();

    }

    public void Hide_Facility_03_Panel()   //hide interface
    {
        Debug.Log("Hide Energy System Interface");
        ShowInGameUI();
        Facility_03_Panel.SetActive(false);
        ShowInteractButton();
    }
    public void Show_Facility_04_Panel()   //display interface
    {
        Debug.Log("Show SpaceAI Interface");
        HideInGameUI();

        Facility_04_Panel.SetActive(true);
        HideInteractButton();
    }

    public void Hide_Facility_04_Panel()   //hide interface
    {
        Debug.Log("Hide SpaceAI Interface");
        ShowInGameUI();
        Facility_04_Panel.SetActive(false);
        ShowInteractButton();
        SpaceShipAI.Instance.turn_to_01_page();
    }

    public void Show_Facility_05_Panel()   //display interface
    {
        Debug.Log("Show Portal Facility Interface");
        HideInGameUI();

        Facility_05_Panel.SetActive(true);
        HideInteractButton();
    }

    public void Hide_Facility_05_Panel()   //hide interface
    {
        Debug.Log("Hide Portal Facility Interface");
        ShowInGameUI();
        Facility_05_Panel.SetActive(false);
        ShowInteractButton();
    }

    public void Show_Fire_Stone_Panel()   //display interface
    {
        Debug.Log("Show Fire_Stone Interface");
        HideInGameUI();

        Fire_Stone_Panel.SetActive(true);
        HideInteractButton();
    }

    public void Hide_Fire_Stone_Panel()   //hide interface
    {
        Debug.Log("Hide Portal Facility Interface");
        ShowInGameUI();
        Fire_Stone_Panel.SetActive(false);
        ShowInteractButton();
    }

    public void Show_Wood_Stone_Panel()   //display interface
    {
        Debug.Log("Show Wood_Stone Interface");
        HideInGameUI();

        Wood_Stone_Panel.SetActive(true);
        HideInteractButton();
    }

    public void Hide_Wood_Stone_Panel()   //hide interface
    {
        Debug.Log("Hide Wood Stone Interface");
        ShowInGameUI();
        Wood_Stone_Panel.SetActive(false);
        ShowInteractButton();
    }

    public void ShowGameOverDead()   //display interface
    {
        Debug.Log("Show GameOverDead");
        HideInGameUI();
        GameEnd = true;
        GameOverDead.SetActive(true);
    }

    public void HideGameOverDead()   //hide interface
    {
        Debug.Log("Hide GameOverDead");
        ShowInGameUI();
        GameEnd = false;
        GameOverDead.SetActive(false);
    }

    public void ShowGameOverWin_Past()   //display interface
    {
        Debug.Log("Show GameOverWin_Past");
        HideInGameUI();
        GameEnd = true;
        GameOverWin_past.SetActive(true);
    }

    public void HideGameOverWin_Past()   //hide interface
    {
        Debug.Log("Hide GameOverLose");
        ShowInGameUI();
        GameEnd = false;
        GameOverWin_past.SetActive(false);
    }

    public void ShowGameOverWin_Earth()   //display interface
    {
        Debug.Log("Show GameOverWin_Earth");
        HideInGameUI();
        GameEnd = true;
        GameOverWin_earth.SetActive(true);
    }

    public void HideGameOverWin()   //hide interface
    {
        Debug.Log("Hide GameOverWin");
        ShowInGameUI();
        GameEnd = false;
        GameOverWin_earth.SetActive(false);
    }

    public void BackToMainMenu()   //turn to scene 'mainmenu'
    {
        Debug.Log("Back to Main Menu");
        HidePauseMenu();
        
        SceneManager.LoadScene(0);
    }

    public void ReplayGame()   //reload scene 'maingame'
    {
        Debug.Log("Replay Game");
        HidePauseMenu();
        SceneManager.LoadScene(3);
    }

    public void ShowInteractButton()   //display button
    {
        Debug.Log("Show Interact button");

        interactButton.SetActive(true);
    }

    public void HideInteractButton()   //hide button
    {
        Debug.Log("hide Interact button");

        interactButton.SetActive(false);
    }

    public void ShowPickUpButton(System.Action _PickupFunc)   //display button
    {
        Debug.Log("Show Pick Up button");
        pickupFunc = _PickupFunc;
        pickUpButton.SetActive(true);
    }

    public void HidePickUpButton()   //hide button
    {
        Debug.Log("hide Pick Up button");
        pickupFunc = null;
        pickUpButton.SetActive(false);
    }

    public void ShowStartTalkButton()   //display button
    {
        Debug.Log("Show  start talk button");

        ConversationButtonshowed = true;
        startTalkButton.SetActive(true);
    }

    public void HideStartTalkButton()   //hide button
    {
        Debug.Log("hide talk button");

        ConversationButtonshowed = false;
        startTalkButton.SetActive(false);
    }

    public void ShowContinueTalkButton()   //display button
    {
        Debug.Log("Show continue talk button");

        continueTalkButton.SetActive(true);
    }

    public void HideContinueTalkButton()   //hide button
    {
        Debug.Log("hide continue talk button");

        continueTalkButton.SetActive(false);
    }

    public void ShowCloseTalkButton()   //display button
    {
        Debug.Log("Show close talk button");

        closeTalkButton.SetActive(true);
    }

    public void HideCloseTalkButton()   //hide button
    {
        Debug.Log("hide close talk button");

        closeTalkButton.SetActive(false);
    }

    public void StartTalk()   //start conversation, display dialogue interface
    {
        Debug.Log("start Talk");
        DialogueInterface.SetActive(true);      //Show dialogue interface
        HideInGameUI();      //Hide other interfaces
        HideStartTalkButton();
        DialogueTrigger.Instance.TriggerDialogue();     //Trigger conversation
    }

    public void ContinueTalk()   //next sentence
    {
        Debug.Log("Continue to Talk");
        DialogueManager.Instance.DisplayNextSentence();     //Switch to the next dialogue

    }

    public void EndTalk()   //end conversation, hide dialogue interface
    {
        Debug.Log("end Talk");
        DialogueInterface.SetActive(false);      //Hide the dialogue interface
        ShowContinueTalkButton();
        HideCloseTalkButton();
        ShowInGameUI();
        DialogueManager.Instance.changeBool();
    }

    public void ShowDoorButton()   //display button
    {
        Debug.Log("Show door button");
        doorButtonshowed = true;
        doorButton.SetActive(true);
    }

    public void HideDoorButton()   //hide button
    {
        Debug.Log("hide door button");
        doorButtonshowed = false;
        doorButton.SetActive(false);
    }

    

    public void ShowCurrentStatusHint_Area_01_Trigger()   //show the current status hint of this game object
    {
        Debug.Log("Show the current status hint area 01");

        if(!GameState.StorageAreaUnlocked)CSH_Damage_Area_01.SetActive(true);

    }

    public void HideCurrentStatusHint_Area_01_Trigger()   //hide the current status hint of this game object
    {
        Debug.Log("hide the current status hint area 01");

        CSH_Damage_Area_01.SetActive(false);

    }

    public void ShowCurrentStatusHint_Area_02_Trigger()   //show the current status hint of this game object
    {
        Debug.Log("Show the current status hint area 02");

            if (!GameState.UpgradeAreaUnlocked )
            {
                    CSH_Damage_Area_02.SetActive(true);
                    CSH_Normal_Area_02.SetActive(false);                
            }
            else
            {
                    CSH_Damage_Area_02.SetActive(false);
                    CSH_Normal_Area_02.SetActive(true);
                    ShowInteractButton();           
            }
    }

    public void HideCurrentStatusHint_Area_02_Trigger()   //hide the current status hint of this game object
    {
        Debug.Log("hide the current status hint area 02");

        if (!GameState.UpgradeAreaUnlocked)
        {
            CSH_Damage_Area_02.SetActive(false);
            CSH_Normal_Area_02.SetActive(false);
        }
        else
        {
            CSH_Damage_Area_02.SetActive(false);
            CSH_Normal_Area_02.SetActive(false);
            HideInteractButton();
        }
    }

    public void ShowCurrentStatusHint_Area_03_Trigger()   //show the current status hint of this game object
    {
        Debug.Log("Show the current status hint area 03");

        if (!GameState.PowerAreaUnlocked)
        {
            CSH_Damage_Area_03.SetActive(true);
            CSH_Normal_Area_03.SetActive(false);
        }
        else
        {
            CSH_Damage_Area_03.SetActive(false);
            CSH_Normal_Area_03.SetActive(true);
            ShowInteractButton();
        }
    }

    public void HideCurrentStatusHint_Area_03_Trigger()   //hide the current status hint of this game object
    {
        Debug.Log("hide the current status hint area 03");

        if (!GameState.PowerAreaUnlocked)
        {
            CSH_Damage_Area_03.SetActive(false);
            CSH_Normal_Area_03.SetActive(false);
        }
        else
        {
            CSH_Damage_Area_03.SetActive(false);
            CSH_Normal_Area_03.SetActive(false);
            HideInteractButton();
        }
    }

    public void ShowCurrentStatusHint_Area_04_Trigger()   //show the current status hint of this game object
    {
        Debug.Log("Show the current status hint area 04");

        CSH_Normal_Area_04.SetActive(true);
        ShowInteractButton();

    }

    public void HideCurrentStatusHint_Area_04_Trigger()   //hide the current status hint of this game object
    {
        Debug.Log("hide the current status hint area 04");

        CSH_Normal_Area_04.SetActive(false);
        HideInteractButton();

    }

    public void ShowCurrentStatusHint_Area_05_Trigger()   //show the current status hint of this game object
    {
        Debug.Log("Show the current status hint area 05");

            CSH_Normal_Area_05.SetActive(true);
            ShowInteractButton();

    }

    public void HideCurrentStatusHint_Area_05_Trigger()   //hide the current status hint of this game object
    {
        Debug.Log("hide the current status hint area 05");

            CSH_Normal_Area_05.SetActive(false);
            HideInteractButton();

    }

    public void ShowCurrentStatusHint_Fire_Stone_Trigger()   //show the current status hint of this game object
    {
        Debug.Log("Show the current status hint Fire_Stone");

        //if (!GameManager.Instance.Fire_Stone_unlocked)
        //{
        //    CSH_Normal_Fire_Stone.SetActive(true);
        //}
        //else
        //{
            CSH_Normal_Fire_Stone.SetActive(true);
            ShowInteractButton();
        //}
    }

    public void HideCurrentStatusHint_Fire_Stone_Trigger()   //hide the current status hint of this game object
    {
        Debug.Log("hide the current status hint Fire_Stone");

        //if (!GameManager.Instance.Fire_Stone_unlocked)
        //{
        //    CSH_Normal_Fire_Stone.SetActive(false);
        //}
        //else
        //{
            CSH_Normal_Fire_Stone.SetActive(false);
            HideInteractButton();
        //}
    }

    public void ShowCurrentStatusHint_Wood_Stone_Trigger()   //show the current status hint of this game object
    {
        Debug.Log("Show the current status hint Wood_Stone");

        //if (!GameManager.Instance.Wood_Stone_unlocked)
        //{
        //    CSH_Normal_Wood_Stone.SetActive(true);
        //}
        //else
        //{
            CSH_Normal_Wood_Stone.SetActive(true);
            ShowInteractButton();
        //}
    }

    public void HideCurrentStatusHint_Wood_Stone_Trigger()   //hide the current status hint of this game object
    {
        Debug.Log("hide the current status hint Wood_Stone");

        //if (!GameManager.Instance.Wood_Stone_unlocked)
        //{
        //    CSH_Normal_Wood_Stone.SetActive(false);
        //}
        //else
        //{
            CSH_Normal_Wood_Stone.SetActive(false);
            HideInteractButton();
        //}
    }

    public void ShowCurrentStatusHint_Portal_Spaceship()   //show the current status hint of this game object
    {
        Debug.Log("Show the current status hint Portal_Spaceship");

        CSH_Normal_Portal_Spaceship.SetActive(true);
        ShowInteractButton();

    }

    public void HideCurrentStatusHint_Portal_Spaceship()   //hide the current status hint of this game object
    {
        Debug.Log("hide the current status hint Portal_Spaceship");

        CSH_Normal_Portal_Spaceship.SetActive(false);
        HideInteractButton();

    }

    public void ShowCurrentStatusHint_Door_Relics()   //show the current status hint of this game object
    {
        Debug.Log("Show the current status hint Door_Relics");

        if (!GameManager.Instance.Door_Wood_0_1_unlocked)
        {
            CSH_Disabled_Relics_Door.SetActive(true);
            CSH_Normal_Relics_Door.SetActive(false);
        }
        else
        {
            CSH_Disabled_Relics_Door.SetActive(false);
            CSH_Normal_Relics_Door.SetActive(true);
            ShowInteractButton();
        }
    }

    public void HideCurrentStatusHint_Door_Relics()   //hide the current status hint of this game object
    {
        Debug.Log("hide the current status hint Door_Relics");

        if (!GameManager.Instance.Door_Wood_0_1_unlocked)
        {
            CSH_Normal_Relics_Door.SetActive(false);
            CSH_Disabled_Relics_Door.SetActive(false);
        }
        else
        {
            CSH_Normal_Relics_Door.SetActive(false);
            CSH_Disabled_Relics_Door.SetActive(false);
            HideInteractButton();
        }
    }

    public void show_setting_menu_interface()
    {
        Debug.Log("show_setting_menu_interface");
        SettingMenu.SetActive(true);

    }
    public void hide_setting_menu_interface()
    {
        Debug.Log("hide_setting_menu_interface");
        SettingMenu.SetActive(false);

    }


    public void set_sound_value_Increase()
    {
        Debug.Log("sound value --> +");

        //TODO
    }

    public void set_sound_value_Decrease()
    {
        Debug.Log("sound value --> -");
        //TODO
    }

    public void set_background_music_ON()
    {
        Debug.Log("background music --> on");
        Button_on.SetActive(true);
        Button_off.SetActive(false);
        //TODO    turn on music
    }

    public void set_background_music_OFF()
    {
        Debug.Log("background music --> off");
        Button_on.SetActive(false);
        Button_off.SetActive(true);
        //TODO   turn off music
    }

    void Update()
    {
        //update HUD elements
        healthBar.SetMaxHealth((int)Player.Instance.MaxHP);
        healthBar.SetHealth((int)Player.Instance.CurrentHP);
        oxygenBar.SetMaxOxygen(Player.Instance.maxOxygen);
        oxygenBar.SetOxygen(Player.Instance.currentOxygen);
        HealthPoint.text = "" + Player.Instance.CurrentHP;
        OxygenPoint.text = "" + Player.Instance.currentOxygen;

       

        if (doorOpened)    //Modify the text of the door button
        {
            doorButtonText.text = "CLOSE";
        }
        else
        {
            doorButtonText.text = "OPEN";
        }


        if (Player.Instance.IsDead || Player.Instance.currentOxygen == 0)
        {
            GameEnd = true;
            ShowGameOverDead();
        }

        if (Input.GetKeyUp(KeyCode.P)) //Shortcut keys to control the display of the  pause menu interface
        {
            if (PauseMenuShowed && !InGameUIshowed)   //It can only be triggered when the  pause menu interface is displayed
            {
                HidePauseMenu();

            }
            else if (!PauseMenuShowed && InGameUIshowed)
            {
                ShowPauseMenu();
                
            }
        }


        if (Input.GetKeyUp(KeyCode.B))  //Shortcut keys to control the display of the bag menu interface
        {
            if (BagMenuShowed && !InGameUIshowed)  //It can only be triggered when the bag menu interface is displayed
            {
                HideBagMenu();
            }
            else if (!BagMenuShowed && InGameUIshowed)
            {
                ShowBagMenu();
            }
        }

        if (Input.GetKeyUp(KeyCode.T))  //Shortcut keys to control the display of the task menu interface
        {
            if (TaskMenuShowed && !InGameUIshowed)  //It can only be triggered when the task menu interface is displayed
            {
                HideTaskMenu();
            }
            else if (!TaskMenuShowed && InGameUIshowed)
            {
                ShowTaskMenu();
            }
        }


        if (Input.GetKeyUp(KeyCode.Y))   //Shortcut keys to turn to scene 'main menu'
        {
            if (PauseMenuShowed || GameEnd)      //It can only be triggered when the pause menu interface is displayed  
                                                 // or game end
            {
                BackToMainMenu();
            }

        }

        if (Input.GetKeyUp(KeyCode.R))   //Shortcut keys to reload scene 'main game'
        {
            if (PauseMenuShowed || GameEnd)      //It can only be triggered when the pause menu interface is displayed  
                                                 // or game end
            {
                ReplayGame();
            }

        }

        if (Input.GetKeyUp(KeyCode.F))   //Shortcut keys to interact with the facility
        {
            //if (PickUp_02_item.Instance.couldInteract)
            //{

            //    PickUp_02_item.Instance.pickupOxygentank();

            //}

            //pickup
            if (pickupFunc != null) { pickupFunc(); pickupFunc = null; }

            if (InGameUIshowed && Area_02_Trigger.Instance != null ? Area_02_Trigger.Instance.couldInteract : false)   //Allows players to interact with the facilities in Area 2
                                                                         //Interaction can only take place when the player is in range
            {
                if (GameState.UpgradeAreaUnlocked)
                {
                     Show_Facility_02_Panel();
                }         
            }

            if (InGameUIshowed && Area_03_Trigger.Instance != null ? Area_03_Trigger.Instance.couldInteract : false)   //Allows players to interact with the facilities in Area 3
                                                                            //Interaction can only take place when the player is in range
            {
                if (GameState.PowerAreaUnlocked)
                {
                    Show_Facility_03_Panel();
                }
            }

            if (InGameUIshowed && Area_04_Trigger.Instance != null ? Area_04_Trigger.Instance.couldInteract : false)   //Allows players to interact with the facilities in Area 4
                                                                            //Interaction can only take place when the player is in range
            {              
                    Show_Facility_04_Panel();
            }

            if (InGameUIshowed && Area_05_Trigger.Instance != null ? Area_05_Trigger.Instance.couldInteract : false)   //Allows players to interact with the facilities in Area 5
                                                                            //Interaction can only take place when the player is in range
            {
                    Show_Facility_05_Panel(); 
            }

            if (InGameUIshowed && Fire_Stone_Trigger.Instance != null ? Fire_Stone_Trigger.Instance.couldInteract : false)   //Allows players to interact with the facilities in Fire_Stone
                                                                            //Interaction can only take place when the player is in range
            {
                Show_Fire_Stone_Panel();
                GameState.FireAccessed = true;
            }

            if (InGameUIshowed && Wood_Stone_Trigger.Instance != null ? Wood_Stone_Trigger.Instance.couldInteract : false)   //Allows players to interact with the facilities in Wood_Stone
                                                                            //Interaction can only take place when the player is in range
            {
                Show_Wood_Stone_Panel();
                GameState.WoodAccessed = true;
            }

            if (InGameUIshowed && PortalTrigger.Instance != null ? PortalTrigger.Instance.couldInteract : false)   //Allows players to interact with the facilities in portal_backtoship
                                                                            //Interaction can only take place when the player is in range
            {
                Debug.Log("Back to spaceship");
                //MenuManager.Instance.LoadGame();    //switch to spaceship scene
            }

            if (InGameUIshowed && Fire_Tool_Trigger.Instance != null ? Fire_Tool_Trigger.Instance.couldInteract : false)   //Allows players to interact with the facilities in portal_backtoship
                                                                          //Interaction can only take place when the player is in range
            {
                Debug.Log("active fire tool");
                //Fire_Tool_Trigger.Instance.fire_tool_active();    //active fire tool
            }

            if (InGameUIshowed && Wood_Tool_Trigger.Instance != null ? Wood_Tool_Trigger.Instance.couldInteract : false)   //Allows players to interact with the facilities in portal_backtoship
                                                                              //Interaction can only take place when the player is in range
            {
                Debug.Log("active wood tool");
                //Wood_Tool_Trigger.Instance.fire_tool_active();    //active wood tool
            }

            if(InGameUIshowed && Get_fire_tool_Trigger.Instance != null ? Get_fire_tool_Trigger.Instance.couldInteract : false)   //Allows players to interact with the facilities in portal_backtoship
                                                                          //Interaction can only take place when the player is in range
            {
                Debug.Log("get fire tool");
                //Get_fire_tool_Trigger.Instance.get_fire_tool();    //get fire tool
            }

            if (InGameUIshowed && Get_wood_tool_Trigger.Instance != null ? Get_wood_tool_Trigger.Instance.couldInteract : false)   //Allows players to interact with the facilities in portal_backtoship
                                                                              //Interaction can only take place when the player is in range
            {
                Debug.Log("get wood tool");
                //Get_wood_tool_Trigger.Instance.get_wood_tool();    //get wood tool
            }

            if (InGameUIshowed && Item_010_PickUp.Instance != null ? Item_010_PickUp.Instance.couldInteract : false)   //Allows players to interact with the facilities in portal_backtoship
                                                                                  //Interaction can only take place when the player is in range
            {
                Debug.Log("get item 010");
                //Item_010_PickUp.Instance.get_010_item();    //get item 010
            }

            if (InGameUIshowed && Item_011_PickUp.Instance != null ? Item_011_PickUp.Instance.couldInteract : false)   //Allows players to interact with the facilities in portal_backtoship
                                                                            //Interaction can only take place when the player is in range
            {
                Debug.Log("get item 011");
                //Item_011_PickUp.Instance.get_011_item();    //get item 011
            }

            if (InGameUIshowed && Item_014_PickUp.Instance != null ? Item_014_PickUp.Instance.couldInteract : false)   //Allows players to interact with the facilities in portal_backtoship
                                                                            //Interaction can only take place when the player is in range
            {
                Debug.Log("get item 014");
                //Item_014_PickUp.Instance.get_014_item();    //get item 014
            }

            if (InGameUIshowed && Item_016_PickUp.Instance != null ? Item_016_PickUp.Instance.couldInteract : false)   //Allows players to interact with the facilities in portal_backtoship
                                                                            //Interaction can only take place when the player is in range
            {
                Debug.Log("get item 016");
                //Item_016_PickUp.Instance.get_016_item();    //get item 016
            }



            if (InGameUIshowed && Wood_0_1_Door_Trigger.Instance != null ? Wood_0_1_Door_Trigger.Instance.couldInteract : false)   //Allows players to interact with the facilities in portal_backtoship
                                                                              //Interaction can only take place when the player is in range
            {
                Debug.Log("wood ralics 0 --> 1");
                //SceneManager.LoadScene(2);                   //swtich scene
            }

            if (InGameUIshowed && Wood_1_2_Door_Trigger.Instance != null ? Wood_1_2_Door_Trigger.Instance.couldInteract : false)   //Allows players to interact with the facilities in portal_backtoship
                                                                                  //Interaction can only take place when the player is in range
            {
                Debug.Log("wood ralics 1 --> 2");
                //SceneManager.LoadScene(2);                   //swtich scene
            }

            if (InGameUIshowed && Wood_2_3_Door_Trigger.Instance != null ? Wood_2_3_Door_Trigger.Instance.couldInteract : false)   //Allows players to interact with the facilities in portal_backtoship
                                                                                  //Interaction can only take place when the player is in range
            {
                Debug.Log("wood ralics 2 --> 3");
                //SceneManager.LoadScene(2);                   //swtich scene
            }

            if (InGameUIshowed && Wood_3_0_Door_Trigger.Instance != null ? Wood_3_0_Door_Trigger.Instance.couldInteract : false)   //Allows players to interact with the facilities in portal_backtoship
                                                                                  //Interaction can only take place when the player is in range
            {
                Debug.Log("wood ralics 3 --> 0");
                //SceneManager.LoadScene(2);                   //swtich scene
            }

            if (InGameUIshowed && Fire_0_1_Door_Trigger.Instance != null ? Fire_0_1_Door_Trigger.Instance.couldInteract : false)   //Allows players to interact with the facilities in portal_backtoship
                                                                                  //Interaction can only take place when the player is in range
            {
                Debug.Log("Fire ralics 0 --> 1");
                //SceneManager.LoadScene(2);                   //swtich scene
            }

            if (InGameUIshowed && Fire_1_2_Door_Trigger.Instance != null ? Fire_1_2_Door_Trigger.Instance.couldInteract : false)   //Allows players to interact with the facilities in portal_backtoship
                                                                                  //Interaction can only take place when the player is in range
            {
                Debug.Log("Fire ralics 1 --> 2");
                //SceneManager.LoadScene(2);                   //swtich scene
            }

            if (InGameUIshowed && Fire_2_3_Door_Trigger.Instance != null ? Fire_2_3_Door_Trigger.Instance.couldInteract : false)   //Allows players to interact with the facilities in portal_backtoship
                                                                                  //Interaction can only take place when the player is in range
            {
                Debug.Log("Fire ralics 2 --> 3");
                //SceneManager.LoadScene(2);                   //swtich scene
            }

            if (InGameUIshowed && Fire_3_0_Door_Trigger.Instance != null ? Fire_3_0_Door_Trigger.Instance.couldInteract : false)   //Allows players to interact with the facilities in portal_backtoship
                                                                                  //Interaction can only take place when the player is in range
            {
                Debug.Log("Fire ralics 3 --> 0");
                //SceneManager.LoadScene(2);                   //swtich scene
            }

            if (DialogueTrigger.Instance != null ? DialogueTrigger.Instance.couldInteract : false)
            {
                if (InGameUIshowed && ConversationButtonshowed)    //If the Talk button is displayed, a conversation can be started
                {
                    StartTalk();

                }
                else if (!InGameUIshowed && DialogueManager.Instance.ConversationOver)  //If the conversation is over, then you can end it
                {
                    EndTalk();
                }
                else if (!InGameUIshowed && DialogueManager.Instance.ConversationStart) //If the conversation starts then the button can be used
                {
                    ContinueTalk();
                }
                return;
            }



        }



    }
}
