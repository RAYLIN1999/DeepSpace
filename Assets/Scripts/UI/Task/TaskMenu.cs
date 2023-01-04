using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class TaskMenu : MonoBehaviour
{
    public static TaskMenu Instance; //Instantiating the TaskMenu.cs

    [SerializeField] public Button content_01_button;

    [SerializeField] public GameObject button_04;
    [SerializeField] public GameObject button_05;

    [SerializeField] public GameObject content_01;
    [SerializeField] public GameObject content_02;
    [SerializeField] public GameObject content_03;
    [SerializeField] public GameObject content_04;
    [SerializeField] public GameObject content_05;

    [SerializeField] private TMP_Text info_01;    //Text display of content_01
    [SerializeField] private TMP_Text info_02;    //Text display of content_02
    [SerializeField] private TMP_Text info_03;    //Text display of content_03
    [SerializeField] private TMP_Text info_04;    //Text display of content_04
    [SerializeField] private TMP_Text info_05;    //Text display of content_05


    void Awake()
    {
        Instance = this;
    }


    public void previous_01_content() //Page change in content 01
    {
        Debug.Log("content 01 _ previous page");
        //TO DO
    }

    public void next_01_content() //Page change in content 01
    {
        Debug.Log("content 01 _ next page");
        //TO DO
    }

    public void previous_02_content() //Page change in content 02
    {
        Debug.Log("content 02 _ previous page");
        //TO DO
    }

    public void next_02_content() //Page change in content 02
    {
        Debug.Log("content 02 _ next page");
        //TO DO
    }
    public void previous_03_content() //Page change in content 03
    {
        Debug.Log("content 03 _ previous page");
        //TO DO
    }

    public void next_03_content() //Page change in content 03
    {
        Debug.Log("content 03 _ next page");
        //TO DO
    }

    public void previous_04_content() //Page change in content 04
    {
        Debug.Log("content 04 _ previous page");
        //TO DO
    }

    public void next_04_content() //Page change in content 04
    {
        Debug.Log("content 04 _ next page");
        //TO DO
    }
    public void previous_05_content() //Page change in content 05
    {
        Debug.Log("content 05 _ previous page");
        //TO DO
    }

    public void next_05_content() //Page change in content 05
    {
        Debug.Log("content 05 _ next page");
        //TO DO
    }



    public void show_01_content() //Switch contents
    {
        Debug.Log("content 01");
        content_01.SetActive(true);    //show content 01
        content_02.SetActive(false);
        content_03.SetActive(false);
        content_04.SetActive(false);
        content_05.SetActive(false);
    }

    public void show_02_content() //Switch contents
    {
        Debug.Log("content 02");
        content_01.SetActive(false);
        content_02.SetActive(true);    //show content 02
        content_03.SetActive(false);
        content_04.SetActive(false);
        content_05.SetActive(false);
    }

    public void show_03_content() //Switch contents
    {
        Debug.Log("content 03");
        content_01.SetActive(false);
        content_02.SetActive(false);
        content_03.SetActive(true);    //show content 03
        content_04.SetActive(false);
        content_05.SetActive(false);
    }

    public void show_04_content() //Switch contents
    {
        Debug.Log("content 04");
        content_01.SetActive(false);
        content_02.SetActive(false);
        content_03.SetActive(false);
        content_04.SetActive(true);    //show content 04
        content_05.SetActive(false);
    }

    public void show_05_content() //Switch contents
    {
        Debug.Log("content 05");
        content_01.SetActive(false);
        content_02.SetActive(false);
        content_03.SetActive(false);
        content_04.SetActive(false);
        content_05.SetActive(true);    //show content 05
    }

    public void show_04_button() //show the button
    {
        Debug.Log("show the button 04");
        button_04.SetActive(true);    
    }
    public void hide_04_button() //hide the button
    {
        Debug.Log("hide the button 04");
        button_04.SetActive(false);
    }

    public void show_05_button() //show the button
    {
        Debug.Log("show the button 05");
        button_05.SetActive(true);
    }
    public void hide_05_button() //hide the button
    {
        Debug.Log("hide the button 05");
        button_05.SetActive(false);
    }

    void Start()
    {
        show_01_content();
        content_01_button.Select();

    }

    void Update()
    {

    }
}
