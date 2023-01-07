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
        DontDestroyOnLoad(transform.gameObject);
    }

    
}
