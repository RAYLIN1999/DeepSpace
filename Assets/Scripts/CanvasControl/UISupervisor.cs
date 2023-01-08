using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class UISupervisor : MonoBehaviour
{
    public static UISupervisor Instance;
    void Awake()
    {
        Instance = this;
        DontDestroyOnLoad(transform.gameObject);
    }

    public enum TriggeredUI { Dialogue, Pickup, South, West };

    // States
    bool PauseMenuShowed = false;
    bool BagMenuShowed = false;
    bool TaskMenuShowed = false;
    bool ConversationButtonshowed = false;

    public bool InGameUIshowed = true;

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

    //UI controllers
    public HealthBar healthBar; //Reference script HealthBar.cs
    public OxygenBar oxygenBar; //Reference script OxygenBar.cs

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
        TaskMenu.Instance.UpdateMenu();                 //Update the content
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
    public void StartTalk()                             //start conversation, display dialogue interface
    {
        DialogueInterface.SetActive(true);              //Show dialogue interface
        HideInGameUI();                                 //Hide other interfaces
        HideStartTalkButton();
        DialogueTrigger.Instance.TriggerDialogue();     //Trigger conversation

    }
    public void ContinueTalk()                          //next sentence
    {
        DialogueManager.Instance.DisplayNextSentence(); //Switch to the next dialogue

    }
    public void EndTalk()                               //end conversation, hide dialogue interface
    {
        DialogueInterface.SetActive(false);             //Hide the dialogue interface
        ShowContinueTalkButton();
        HideCloseTalkButton();
        ShowInGameUI();
        DialogueManager.Instance.changeBool();
    }

    //Btns
    public void ShowInteractButton()   //display button
    {
        interactButton.SetActive(true);
    }

    public void HideInteractButton()   //hide button
    {
        interactButton.SetActive(false);
    }
    public void ShowStartTalkButton()   //display button
    {
        ConversationButtonshowed = true;
        startTalkButton.SetActive(true);
    }

    public void HideStartTalkButton()   //hide button
    {
        ConversationButtonshowed = false;
        startTalkButton.SetActive(false);
    }

    public void ShowContinueTalkButton()   //display button
    {
        continueTalkButton.SetActive(true);
    }

    public void HideContinueTalkButton()   //hide button
    {
        continueTalkButton.SetActive(false);
    }

    public void ShowCloseTalkButton()   //display button
    {
        closeTalkButton.SetActive(true);
    }

    public void HideCloseTalkButton()   //hide button
    {
        closeTalkButton.SetActive(false);
    }
    public void ShowPickUpButton()                      //display button
    {
        pickUpButton.SetActive(true);
    }

    public void HidePickUpButton()                      //hide button
    {
        pickUpButton.SetActive(false);
    }

    //
    public void TriggerElemOn(TriggeredUI _Type)
    {
        switch (_Type)
        {
            case TriggeredUI.Dialogue:
                ShowInteractButton();
                ShowStartTalkButton();
                break;
            case TriggeredUI.Pickup:
                ShowPickUpButton();
                break;
            case TriggeredUI.South:
                break;
            case TriggeredUI.West:
                break;
            default:
                break;
        }
    }
    public void TriggerElemOff(TriggeredUI _Type)
    {
        switch (_Type)
        {
            case TriggeredUI.Dialogue:
                HideInteractButton();
                HideStartTalkButton();
                break;
            case TriggeredUI.Pickup:
                HidePickUpButton();
                break;
            case TriggeredUI.South:
                break;
            case TriggeredUI.West:
                break;
            default:
                break;
        }
    }

    public void BackToMainMenu()   //turn to scene 'mainmenu'
    {
        HidePauseMenu();
        SceneManager.LoadScene(0);
        GameState.Reset();
        StoryLine.Instance.Restart();
    }

    public void ReplayGame()   //reload scene 'maingame'
    {
        HidePauseMenu();
        SceneManager.LoadScene(3);
        GameState.Reset();
        StoryLine.Instance.Restart();
    }

    private void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        //update HUD elements
        healthBar.SetMaxHealth((int)Player.Instance.MaxHP);
        healthBar.SetHealth((int)Player.Instance.CurrentHP);
        oxygenBar.SetMaxOxygen(Player.Instance.maxOxygen);
        oxygenBar.SetOxygen(Player.Instance.currentOxygen);
        HealthPoint.text = "" + Player.Instance.CurrentHP;
        OxygenPoint.text = "" + Player.Instance.currentOxygen;

        //process key events
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

        if (Input.GetKeyUp(KeyCode.F))                  //Shortcut keys to interact
        {
            var item = GameState.currInteractObj.GetComponent<ItemComp>();
            if (item != null)
            {
                //pickup
                GameState.ItemAmount[item.itemID] += 1;
                GameState.currInteractObj.SetActive(false);
                return;
            }
            var dia = GameState.currInteractObj.GetComponent<DialogueTrigger>();
            if (dia != null)
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
