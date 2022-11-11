using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class MenuManager : MonoBehaviour
{
    public void StartGame() //Switch scene
    {
        Debug.Log("Start game");
        SceneManager.LoadScene(3);
    }

    public void LoadGame() //Switch scene
    {
        Debug.Log("Load game");
        SceneManager.LoadScene(2);
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
}
