using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class MenuManager : MonoBehaviour
{

    public static MenuManager Instance; //Instantiating the MenuManager.cs

    [SerializeField] public Button Button_easy;
    [SerializeField] public Button Button_normal;
    [SerializeField] public Button Button_hard;

    [SerializeField] private GameObject Button_on;
    [SerializeField] private GameObject Button_off;

    [SerializeField] public bool diff_easy = false;
    [SerializeField] public bool diff_normal = false;
    [SerializeField] public bool diff_hard = false;


    void Awake()
    {
        Instance = this;
    }


    public void StartGame() //Switch scene
    {
        Debug.Log("Start game");
        SceneManager.LoadScene(2);
    }

    public void LoadGame() //Switch scene
    {
        Debug.Log("Load game");
        //SceneManager.LoadScene(2);
    }

    public void OpenSettingMenu() //Switch scene
    {
        Debug.Log("Turn to Setting Menu");
        SceneManager.LoadScene(1);
    }


    public void QuitGame() //Switch scene
    {
        Debug.Log("Quit Game!");
        Application.Quit();
    }

    public void OpenMainMenu() //Switch scene
    {
        Debug.Log("Turn to Main Menu");
        SceneManager.LoadScene(0);
        //Cursor.lockState = CursorLockMode.None;

    }

    public void Set_easy() //set the difficulty of the game
    {
        Debug.Log("difficulty --> easy");
        diff_easy = true;
        diff_normal = false ;
        diff_hard = false;
        //GameManager.Instance.Set_Difficulty_Easy();

    }

    public void Set_normal() //set the difficulty of the game
    {
        Debug.Log("difficulty --> normal");
        diff_easy = false;
        diff_normal = true;
        diff_hard = false;
        //GameManager.Instance.Set_Difficulty_Normal();

    }

    public void Set_hard() //set the difficulty of the game
    {
        Debug.Log("difficulty --> hard");
        diff_easy = false;
        diff_normal = false;
        diff_hard = true;
        //GameManager.Instance.Set_Difficulty_Hard();

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
        Cursor.lockState = CursorLockMode.None;     //Allows button clicks with the cursor



        if (diff_easy)    //Show current difficulty
        {
            Button_easy.Select();
        }

        if (diff_normal)
        {
            Button_normal.Select();
        }

        if (diff_hard)
        {
            Button_hard.Select();
        }
    }
}
