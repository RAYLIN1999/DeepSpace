using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class UIManager : MonoBehaviour
{
    public static UIManager Instance; //Instantiating the MenuManager.cs

    [SerializeField] private GameObject InGameUI;    //The normal interface display of the game running
    [SerializeField] private GameObject TaskMenu;    //task menu interface
    [SerializeField] private GameObject PauseMenu;   //pause menu interface
    [SerializeField] private GameObject BagMenu;     //bag menu interface

    [SerializeField] private GameObject GameOverDead;  //game over interface, Player dies , with zero health or oxygen
    [SerializeField] private GameObject GameOverLose;  //game over interface, Player lose the game
    [SerializeField] private GameObject GameOverWin;  //game over interface, Player win the game

    [SerializeField] private GameObject DialogueInterface;  //dialogue interface
    [SerializeField] private GameObject startTalkButton;    //Start a conversation
    [SerializeField] private GameObject continueTalkButton;  //Switch to the next conversation
    [SerializeField] private GameObject closeTalkButton;   //Close the conversation


    [SerializeField] private GameObject doorButton; //Button for opening and closing the door

    [SerializeField] private GameObject repairInfo; //Text pop-ups for red facilities
    [SerializeField] private GameObject backInfo; //Text pop-ups for white facilities

    [SerializeField] private GameObject pickUpOXYGENInfo; //Text pop-ups for oxygen tank
    [SerializeField] private GameObject pickUp001Info; //Text pop-ups for Material 001
    [SerializeField] private GameObject pickUp002Info; //Text pop-ups for Material 002

    [SerializeField] private GameObject bag001Info; 
    [SerializeField] private GameObject bag002Info; 

    [SerializeField] private GameObject task9item; 
    [SerializeField] private GameObject task10item; 
    [SerializeField] private GameObject redFacility;
    [SerializeField] private GameObject fixbutton;
    [SerializeField] private GameObject backFacility;


    [SerializeField] private TMP_Text HealthPoint;    //Text display of health value
    [SerializeField] private TMP_Text OxygenPoint;    //Text display of oxygen value
    [SerializeField] private TMP_Text doorButtonText;    //open or close


    public HealthBar healthBar; //Reference script HealthBar.cs
    [SerializeField] public int currentHealth;
    [SerializeField] public int currentOxygen;

    [SerializeField] public bool InGameUIshowed = true;
    [SerializeField] public bool TaskMenuShowed = false;    //Determine if the interface is being displayed
    [SerializeField] public bool PauseMenuShowed = false;
    [SerializeField] public bool BagMenuShowed = false;
    [SerializeField] public bool GameEnd = false;          //Whether the game wins or loses, the game is end
    [SerializeField] public bool ConversationStart;
    [SerializeField] public bool ConversationOver;
    [SerializeField] public bool ConversationButtonshowed = false;

    [SerializeField] public bool doorButtonshowed = false;   //Determine if the door button is displayed
    [SerializeField] public bool doorOpened = false;   //Determining whether a door is open or not

    [SerializeField] public bool pickUp001 = false;
    [SerializeField] public bool pickUp002 = false;
    [SerializeField] public bool pickUpox = false;

    [SerializeField] public bool facilityFixed = false;
    [SerializeField] public bool couldBack = false;


    public void ShowInGameUI()     //display interface
    {
        Debug.Log("Show InGameUI");
        InGameUIshowed = true;
        InGameUI.SetActive(true);
    }

    public void HideInGameUI()    //hide interface
    {
        Debug.Log("Hide InGameUI");
        InGameUIshowed = false;
        InGameUI.SetActive(false);
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
        TaskMenu.SetActive(true);
    }

    public void HideTaskMenu()  //hide interface
    {
        Debug.Log("Hide TaskMenu");
        ShowInGameUI();
        TaskMenuShowed = false;
        TaskMenu.SetActive(false);
    }

    public void HidePauseMenu()   //hide interface
    {
        Debug.Log("Hide PauseMenu");
        ShowInGameUI();
        PauseMenuShowed = false;
        PauseMenu.SetActive(false);
    }


    public void ShowBagMenu()   //display interface
    {
        Debug.Log("Show BagMenu");
        HideInGameUI();
        BagMenuShowed = true;
        BagMenu.SetActive(true);
    }

    public void HideBagMenu()   //hide interface
    {
        Debug.Log("Hide BagMenu");
        ShowInGameUI();
        BagMenuShowed = false;
        BagMenu.SetActive(false);
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

    public void ShowGameOverLose()   //display interface
    {
        Debug.Log("Show GameOverLose");
        HideInGameUI();
        GameEnd = true;
        GameOverLose.SetActive(true);
    }

    public void HideGameOverLose()   //hide interface
    {
        Debug.Log("Hide GameOverLose");
        ShowInGameUI();
        GameEnd = false;
        GameOverLose.SetActive(false);
    }

    public void ShowGameOverWin()   //display interface
    {
        Debug.Log("Show GameOverWin");
        HideInGameUI();
        GameEnd = true;
        GameOverWin.SetActive(true);
    }

    public void HideGameOverWin()   //hide interface
    {
        Debug.Log("Hide GameOverWin");
        ShowInGameUI();
        GameEnd = false;
        GameOverWin.SetActive(false);
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

        TaskTrigger.Instance.TriggerTask(); //Trigger task

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

    public void DoorOpen()   //open the door
    {
        Debug.Log("open the door");
        doorOpened = true;
        Door.Instance.hideDoor1();
    }

    public void DoorClose()   //close the door
    {
        Debug.Log("close the door");
        doorOpened = false;
        Door.Instance.showDoor1();
    }

    public void ShowRepairInfo()   //display info
    {
        Debug.Log("Show repair information");

        repairInfo.SetActive(true);
    }

    public void HideRepairInfo()   //hide info
    {
        Debug.Log("hide repair information");

        repairInfo.SetActive(false);
    }

    public void FixRedFacility()   //fix the red facility
    {
        Debug.Log("fix the red facility");

        redFacility.SetActive(false);
        repairInfo.SetActive(false) ;
    }

    public void ShowBackInfo()   //display info
    {
        Debug.Log("Show back information");

        backInfo.SetActive(true);
    }

    public void HideBackInfo()   //hide info
    {
        Debug.Log("hide back information");

        backInfo.SetActive(false);
    }

    public void ShowpickUpOXYGENInfo()   //display info
    {
        Debug.Log("Show pickUpOXYGEN information");

        pickUpOXYGENInfo.SetActive(true);
    }

    public void HidepickUpOXYGENInfo()   //hide info
    {
        Debug.Log("hide pickUpOXYGEN information");

        pickUpOXYGENInfo.SetActive(false);
    }

    public void pickUpOXYGEN()   //pick up item
    {
        Debug.Log("pickUp OXYGEN ");
        pickUpoXYGEN.Instance.pickupOxygentank();
        pickUpox = true;
        pickUpOXYGENInfo.SetActive(false);
    }

    public void ShowpickUp001Info()   //display info
    {
        Debug.Log("Show pickUp001 information");

        pickUp001Info.SetActive(true);
    }

    public void HidepickUp001Info()   //hide info
    {
        Debug.Log("hide pickUp001 information");

        pickUp001Info.SetActive(false);
    }

    public void pickUpitem001()   //pick up item
    {
        Debug.Log("pickUp item 001 ");
        pickUpone.Instance.pickupitem001();
        pickUp001 = true;
        pickUp001Info.SetActive(false);
        bag001Info.SetActive(true);
    }

    public void ShowpickUp002Info()   //display info
    {
        Debug.Log("Show pickUp002 information");

        pickUp002Info.SetActive(true);
    }

    public void HidepickUp002Info()   //hide info
    {
        Debug.Log("hide pickUp002 information");

        pickUp002Info.SetActive(false);
    }

    public void pickUpitem002()   //pick up item
    {
        Debug.Log("pickUp item 002 ");
        pickUptwo.Instance.pickupitem002();
        pickUp002 = true;
        pickUp002Info.SetActive(false);
        bag002Info.SetActive(true);
    }



    void Awake()
    {
        Instance = this;
    }
    private void Start()
    {
        healthBar.SetMaxHealth((int)Player.Instance.MaxHP);
    }
    void Update()
    {
        currentHealth = (int)Player.Instance.CurrentHP;      //Synchronize the data of the script Player.cs
        currentOxygen = Player.Instance.currentOxygen;

        HealthPoint.text = "" + currentHealth;       //Synchronize the text of value
        OxygenPoint.text = "" + currentOxygen;

        healthBar.SetHealth(currentHealth);

        ConversationOver = DialogueManager.Instance.ConversationOver;
        if (ConversationOver)     //If the conversation is over, then the close conversation button is displayed
        {
            HideContinueTalkButton();    //hide continue button
            ShowCloseTalkButton();       //show close button
        }
        ConversationStart = DialogueManager.Instance.ConversationStart;

        if (doorOpened)    //Modify the text of the door button
        {
            doorButtonText.text = "CLOSE";
        }
        else
        {
            doorButtonText.text = "OPEN";
        }

        if (pickUp001 && pickUp002)
        {
            task9item.SetActive(true);
            task10item.SetActive(true);
            backFacility.SetActive(true);
            fixbutton.SetActive(true);
        }

        if (Player.Instance.IsDead || currentOxygen == 0)
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

        if (Input.GetKeyUp(KeyCode.F))   //Shortcut keys to start conversation or finish conversation
        {
            if (InGameUIshowed&&ConversationButtonshowed)    //If the Talk button is displayed, a conversation can be started
            {
                StartTalk();

            }
            else if (!InGameUIshowed && ConversationOver)  //If the conversation is over, then you can end it
            {
                EndTalk();
            }



        }

        if (Input.GetKeyUp(KeyCode.C))   //Shortcut keys to Switch to the next dialogue
        {
            if (!InGameUIshowed && ConversationStart) //If the conversation starts then the button can be used
            {
                ContinueTalk();
            }

        }

        if (Input.GetKeyUp(KeyCode.G))   //Shortcut keys to open or close the door
        {
            if (doorButtonshowed) //If the door button is displayed then it can be triggered
            {
                if (doorOpened)
                {
                    DoorClose();
                }
                else
                {
                    DoorOpen();
                }
            }

        }

        if (Input.GetKeyUp(KeyCode.I))   //Shortcut keys to pick up oxygen tank
        {
            if (!pickUpox) //
            {
                pickUpOXYGEN();
            }

        }

        if (Input.GetKeyUp(KeyCode.U))   //Shortcut keys to pick up ITEM 001
        {
            if (!pickUp001) //
            {
                pickUpitem001();
            }

        }

        if (Input.GetKeyUp(KeyCode.H))   //Shortcut keys to pick up item 002
        {
            if (!pickUp002) //
            {
                pickUpitem002();
            }

        }

        if (Input.GetKeyUp(KeyCode.Z))   //Shortcut keys to pick up oxygen tank
        {
            if (!facilityFixed) //
            {
                FixRedFacility();
                facilityFixed = true;
                couldBack = true;
            }

        }

        if (Input.GetKeyUp(KeyCode.X))   //Shortcut keys to pick up oxygen tank
        {
            if (couldBack) //
            {
                ShowGameOverWin();
            }
            else
            {
                ShowGameOverLose();
            }

        }
    }
}
