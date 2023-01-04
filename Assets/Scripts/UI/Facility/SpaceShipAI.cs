using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class SpaceShipAI : MonoBehaviour
{
    public static SpaceShipAI Instance; //Instantiating the SpaceShipAI.cs

    [SerializeField] public GameObject continueButton;

    [SerializeField] public GameObject page_01;
    [SerializeField] public GameObject page_02;

    [SerializeField] public Button content_01_button;

    [SerializeField] public GameObject content_01;
    [SerializeField] public GameObject content_02;
    [SerializeField] public GameObject content_03;
    [SerializeField] public GameObject content_04;
    [SerializeField] public GameObject content_05;

    [SerializeField] public int item_012_a;
    [SerializeField] public int item_013_a;


    void Awake()
    {
        Instance = this;
    }

    public void turn_to_01_page() //Switch page
    {
        Debug.Log("page 01");
        page_01.SetActive(true);
        page_02.SetActive(false);
    }

    public void turn_to_02_page() //Switch page
    {
        Debug.Log("page 02");
        page_01.SetActive(false);
        page_02.SetActive(true);
        show_01_content();
        content_01_button.Select();

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

    public void SAVE_03_content() //Page change in content 03
    {
        Debug.Log("content 03 _ SAVE");
        //TO DO
    }


    public void NEXT_04_content() //Page change in content 04
    {
        Debug.Log("content 04 _ NEXT");
        //TO DO
    }

    public void backTo_Past_05_content() //Page change in content 05
    {
        
        if(item_012_a >=1 && item_013_a >= 1)
        {
            Debug.Log("content 05 _ back to the past");
            GameManager.Instance.back_to_Past();
        } else
        {
            Debug.Log("cannot back to the past");
        }
    }

    public void backTo_Earth_05_content() //Page change in content 05
    {
        
        if (item_012_a >= 1 && item_013_a >= 1)
        {
            Debug.Log("content 05 _ back to the earth");
            GameManager.Instance.back_to_Earth();
        }
        else
        {
            Debug.Log("cannot back to the earth");
        }
    }



    public void show_01_content() //Switch contents in page 02
    {
        Debug.Log("page 02 - content 01");
        content_01.SetActive(true);    //show content 01
        content_02.SetActive(false);
        content_03.SetActive(false);
        content_04.SetActive(false);
        content_05.SetActive(false);
    }

    public void show_02_content() //Switch contents in page 02
    {
        Debug.Log("page 02 - content 02");
        content_01.SetActive(false);
        content_02.SetActive(true);    //show content 02
        content_03.SetActive(false);
        content_04.SetActive(false);
        content_05.SetActive(false);
    }

    public void show_03_content() //Switch contents in page 02
    {
        Debug.Log("page 02 - content 03");
        content_01.SetActive(false);
        content_02.SetActive(false);
        content_03.SetActive(true);    //show content 03
        content_04.SetActive(false);
        content_05.SetActive(false);
    }

    public void show_04_content() //Switch contents in page 02
    {
        Debug.Log("page 02 - content 04");
        content_01.SetActive(false);
        content_02.SetActive(false);
        content_03.SetActive(false);
        content_04.SetActive(true);    //show content 04
        content_05.SetActive(false);
    }

    public void show_05_content() //Switch contents in page 02
    {
        Debug.Log("page 02 - content 05");
        content_01.SetActive(false);
        content_02.SetActive(false);
        content_03.SetActive(false);
        content_04.SetActive(false);
        content_05.SetActive(true);    //show content 05
    }

    void Start()
    {
        turn_to_01_page();

    }

    void Update()
    {
        item_012_a = GameManager.Instance.item_012_amount;
        item_013_a = GameManager.Instance.item_013_amount;

    }
}
