using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class BagManager : MonoBehaviour
{
    public static BagManager Instance; //Instantiating the BagManager.cs

    [SerializeField] private GameObject category_Healthy;    //Items in the Health category

    [SerializeField] private GameObject item_001_detail;    //details of item_001

    public void Show_Category_Healthy()     //Show items in the category Health
    {
        Debug.Log("Click button Healthy and show_Category_Healthy");
        category_Healthy.SetActive(true);
    }

    public void Hide_Category_Healthy()     //Hide items in category Health
    {
        Debug.Log("Hide_Category_Healthy");
        category_Healthy.SetActive(false);
    }

    public void Show_item_001_Detail()     //Show details of item_001
    {
        Debug.Log("Show details of item_001");
        item_001_detail.SetActive(true);
    }

    public void Hide_item_001_Detail()     //Hide details of item_001
    {
        Debug.Log("Hide details of item_001");
        item_001_detail.SetActive(false);
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
