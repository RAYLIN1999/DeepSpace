using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;

public class TaskMenu : MonoBehaviour
{
    public static TaskMenu Instance;               //Instantiating the TaskMenu.cs

    // Related objects
    [SerializeField] public GameObject button_f;
    [SerializeField] public GameObject button_w;

    [SerializeField] public GameObject content_tt; //panel toturial
    [SerializeField] public GameObject content_m;  //panel main
    [SerializeField] public GameObject content_f;  //panel fire
    [SerializeField] public GameObject content_w;  //panel wood

    [SerializeField] private TMP_Text ttText;      //Text display of toturial content
    [SerializeField] private TMP_Text mainText;    //Text display of main quest content
    [SerializeField] private TMP_Text fireText;    //Text display of fire quest content
    [SerializeField] private TMP_Text woodText;    //Text display of wood quest content

    [SerializeField] private TMP_Text mainTitle;   //Text display of main quest title

    [SerializeField] private TMP_Text tip;         //Short text on HUD
    [SerializeField] private string tipText;       //Short text cache

    // Task menu states
    public int currMaxMain = 0;                    //the latest main quest number
    public int currMaxFire = 0;                    //the latest fire quest number
    public int currMaxWood = 0;                    //the latest wood quest number
    int currMain = 0;                              //currently watching main quest number
    int currFire = 0;                              //currently watching main quest number
    int currWood = 0;                              //currently watching main quest number

    int currTask = 0;                              // 0 for tutorial, 1 for main, 2 for fire, 3 for wood

    // Task Text Data
    List<Tuple<string, string>> MainText =         //Text of Main quests
        new()
        {
            new("1","2"),
            new("1","2"),
            new("1","2"),
            new("1","2"),
        };

    List<Tuple<string, string>> FireText =         //Text of Fire quests
        new()
        {
            new("1","2"),
        };

    List<Tuple<string, string>> WoodText =         //Text of Wood quests
        new()
        {
            new("1","Collect the item 016 and item 017. Then interact with the stone tablet to repair it"),
            new("1","Enter the Wood Country Relic"),
            new("1","Collect the item 016 and item 017. Then interact with the stone tablet to repair it"),
        };

    void Awake()
    {
        Instance = this;
        DontDestroyOnLoad(transform.gameObject);
    }
    private void Start()
    {
        ShowTutorial();
        UpdateMenu();
    }
    public void Restart()
    {
        currTask = 0;
        SetFireProgress(0);
        SetWoodProgress(0);
        SetMainProgress(0);
        SetTutorialText("");
        SetTutorialTextDetail("");
    }
    public void UpdateTip()
    {
        switch (currTask)
        {
            case 0:
                tip.text = tipText;
                break;
            case 1:
                tip.text = MainText[currMain].Item1;
                break;
            case 2:
                tip.text = FireText[currFire].Item1;
                break;
            case 3:
                tip.text = WoodText[currWood].Item1;
                break;
        }
    }
    public void UpdateMenu()
    {
        if (GameState.WoodAccessed == true)
            button_w.SetActive(true);
        else
            button_w.SetActive(false);

        if (GameState.FireAccessed == true)
            button_f.SetActive(true);
        else
            button_f.SetActive(false);

        mainTitle.text = MainText[currMain].Item1;
        mainText.text = MainText[currMain].Item2;

        fireText.text = FireText[currFire].Item2;

        woodText.text = WoodText[currWood].Item2;

        
        // Toturial text is managed by task system
    }
    /// <summary>
    /// Show the task panel of toturial
    /// </summary>
    public void ShowTutorial()
    {
        currTask = 0;
        content_tt.SetActive(true);
        content_m.SetActive(false);
        content_f.SetActive(false);
        content_w.SetActive(false);
        UpdateTip();
    }
    /// <summary>
    /// Show the task panel of Main quests
    /// </summary>
    public void ShowMain()
    {
        currTask = 1;
        content_tt.SetActive(false);
        content_m.SetActive(true);
        content_f.SetActive(false);
        content_w.SetActive(false);
        UpdateMenu();
        UpdateTip();
    }
    /// <summary>
    /// Show the task panel of Kingdom of Fire quests
    /// </summary>
    public void ShowFire()
    {
        currTask = 2;
        content_tt.SetActive(false);
        content_m.SetActive(false);
        content_f.SetActive(false);
        content_w.SetActive(true);
        UpdateMenu();
        UpdateTip();
    }
    /// <summary>
    /// Show the task panel of Kingdom of Wood quests
    /// </summary>
    public void ShowWood()
    {
        currTask = 3;
        content_tt.SetActive(false);
        content_m.SetActive(false);
        content_f.SetActive(true);
        content_w.SetActive(false);
        UpdateMenu();
        UpdateTip();
    }
    /// <summary>
    /// Tutorial is a simple task that will not be documented.
    /// Thus we let the task system to change the text.
    /// </summary>
    /// <param name="_Content">The text</param>
    public void SetTutorialText(string _Content)
    {
        tipText = _Content;
        UpdateTip();
    }
    /// <summary>
    /// Tutorial is a simple task that will not be documented.
    /// Thus we let the task system to change the text.
    /// </summary>
    /// <param name="_Content">The text</param>
    public void SetTutorialTextDetail(string _Content)
    {
        ttText.text = _Content;
    }
    /// <summary>
    /// Set the last progress of main quests, allowing the UI to retrieve to the latest
    /// </summary>
    /// <param name="_Prog">Current prog number</param>
    public void SetMainProgress(int _Prog)
    {
        currMaxMain = _Prog;
    }
    /// <summary>
    /// Set the last progress of fire quests, allowing the UI to retrieve to the latest
    /// </summary>
    /// <param name="_Prog">Current prog number</param>
    public void SetFireProgress(int _Prog)
    {
        currMaxFire = _Prog;
    }
    /// <summary>
    /// Set the last progress of wood quests, allowing the UI to retrieve to the latest
    /// </summary>
    /// <param name="_Prog">Current prog number</param>
    public void SetWoodProgress(int _Prog)
    {
        currMaxWood = _Prog;
    }
    /// <summary>
    /// Invoked when prev btn is pressed
    /// </summary>
    public void PrevBtn()
    {
        switch (currTask)
        {
            case 0:
                break;
            case 1:
                currMain--;
                if (currMain < 0) currMain = 0;
                break;
            case 2:
                currFire--;
                if (currFire < 0) currFire = 0;
                break;
            case 3:
                currWood--;
                if (currWood < 0) currWood = 0;
                break;
        }
        UpdateMenu();
    }
    /// <summary>
    /// Invoked when next btn is pressed
    /// </summary>
    public void NextBtn()
    {
        switch (currTask)
        {
            case 0:
                break;
            case 1:
                currMain++;
                if (currMain > currMaxMain) currMain = 0;
                break;
            case 2:
                currFire++;
                if (currFire > currMaxFire) currFire = 0;
                break;
            case 3:
                currWood++;
                if (currWood > currMaxWood) currWood = 0;
                break;
        }
        UpdateMenu();
    }
}
