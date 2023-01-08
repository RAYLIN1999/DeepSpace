using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class BagManager : MonoBehaviour
{
    public static BagManager Instance; //Instantiating the BagManager.cs

    [SerializeField] private Button button_Healthy;  //button Healthy_button

    [SerializeField] private GameObject category_Healthy;    //Items in the Health category
    [SerializeField] private GameObject category_Material;    //Items in the Material category
    [SerializeField] private GameObject category_Tool;    //Items in the Tool category
    [SerializeField] private GameObject category_Task;    //Items in the Task category
    [SerializeField] private GameObject category_Collection;    //Items in the Collection category


    [SerializeField] private GameObject item_001_detail;    //details of item_001
    [SerializeField] private GameObject item_002_detail;    //details of item_002
    [SerializeField] private GameObject item_003_detail;    //details of item_003
    [SerializeField] private GameObject item_004_detail;    //details of item_004
    [SerializeField] private GameObject item_005_detail;    //details of item_005
    [SerializeField] private GameObject item_006_detail;    //details of item_006
    [SerializeField] private GameObject item_007_detail;    //details of item_007
    [SerializeField] private GameObject item_008_detail;    //details of item_008
    [SerializeField] private GameObject item_009_detail;    //details of item_009
    [SerializeField] private GameObject item_010_detail;    //details of item_010
    [SerializeField] private GameObject item_011_detail;    //details of item_011
    [SerializeField] private GameObject item_012_detail;    //details of item_012
    [SerializeField] private GameObject item_013_detail;    //details of item_013
    [SerializeField] private GameObject item_014_detail;    //details of item_014
    [SerializeField] private GameObject item_015_detail;    //details of item_015
    [SerializeField] private GameObject item_016_detail;    //details of item_016
    [SerializeField] private GameObject item_017_detail;    //details of item_017



    void Awake()
    {
        Instance = this;
    }

    public void Initialise_BagMenu()     //When showing or hiding the bag menu, change the initial page shown to the health category
    {
        Debug.Log("Initialise bag menu");
        button_Healthy.Select();
    }

//show or hide items in the categories
    public void Show_Category_Healthy()     //Show items in the category Health
    {
        Debug.Log("Click button Healthy and show_Category_Healthy");
        category_Healthy.SetActive(true);

        Hide_Category_Material();     //Hide other categories
        Hide_Category_Tool();
        Hide_Category_Task();
        Hide_Category_Collection();
    }

    public void Hide_Category_Healthy()     //Hide items in category Healthy
    {
        Debug.Log("Hide_Category_Healthy");
        category_Healthy.SetActive(false);

        Hide_item_001_Detail();   //Hide detail of items in category Healthy
        Hide_item_002_Detail();
    }

    public void Show_Category_Material()     //Show items in the category Material
    {
        Debug.Log("Click button Healthy and show_Category_Material");
        category_Material.SetActive(true);

        Hide_Category_Healthy();     //Hide other categories
        Hide_Category_Tool();
        Hide_Category_Task();
        Hide_Category_Collection();
    }

    public void Hide_Category_Material()     //Hide items in category Material
    {
        Debug.Log("Hide_Category_Material");
        category_Material.SetActive(false);

        Hide_item_003_Detail();   //Hide detail of items in category Material
        Hide_item_004_Detail();
        Hide_item_005_Detail();
        Hide_item_006_Detail();
    }

    public void Show_Category_Tool()     //Show items in the category Tool
    {
        Debug.Log("Click button Tool and show_Category_Tool");
        category_Tool.SetActive(true);

        Hide_Category_Healthy();     //Hide other categories
        Hide_Category_Material();
        Hide_Category_Task();
        Hide_Category_Collection();
    }

    public void Hide_Category_Tool()     //Hide items in category Tool
    {
        Debug.Log("Hide_Category_Tool");
        category_Tool.SetActive(false);

        Hide_item_007_Detail();   //Hide detail of items in category Tool
        Hide_item_008_Detail();
        Hide_item_009_Detail();
    }

    public void Show_Category_Task()     //Show items in the category Task
    {
        Debug.Log("Click button Task and show_Category_Task");
        category_Task.SetActive(true);

        Hide_Category_Healthy();     //Hide other categories
        Hide_Category_Material();
        Hide_Category_Tool();
        Hide_Category_Collection();
    }

    public void Hide_Category_Task()     //Hide items in category Task
    {
        Debug.Log("Hide_Category_Task");
        category_Task.SetActive(false);

        Hide_item_010_Detail();   //Hide detail of items in category Task
        Hide_item_011_Detail();
        Hide_item_012_Detail();
        Hide_item_013_Detail();
    }

    public void Show_Category_Collection()     //Show items in the category Collection
    {
        Debug.Log("Click button Collection and show_Category_Collection");
        category_Collection.SetActive(true);

        Hide_Category_Healthy();     //Hide other categories
        Hide_Category_Material();
        Hide_Category_Tool();
        Hide_Category_Task();
    }

    public void Hide_Category_Collection()     //Hide items in category Collection
    {
        Debug.Log("Hide_Category_Collection");
        category_Collection.SetActive(false);

        Hide_item_014_Detail();   //Hide detail of items in category Collection
        Hide_item_015_Detail();
        Hide_item_016_Detail();
        Hide_item_017_Detail();
    }


//Show or hide item detail

    public void Show_item_001_Detail()     //Show details of item_001
    {
        Debug.Log("Show details of item_001");
        item_001_detail.SetActive(true);

        Hide_item_002_Detail();  //Hide other items in the same category
    }

    public void Hide_item_001_Detail()     //Hide details of item_001
    {
        Debug.Log("Hide details of item_001");
        item_001_detail.SetActive(false);
    }

    public void Show_item_002_Detail()     //Show details of item_001
    {
        Debug.Log("Show details of item_002");
        item_002_detail.SetActive(true);

        Hide_item_001_Detail();  //Hide other items in the same category
    }

    public void Hide_item_002_Detail()     //Hide details of item_001
    {
        Debug.Log("Hide details of item_002");
        item_002_detail.SetActive(false);
    }

    public void Show_item_003_Detail()     //Show details of item_003
    {
        Debug.Log("Show details of item_003");
        item_003_detail.SetActive(true);

        Hide_item_004_Detail();  //Hide other items in the same category
        Hide_item_005_Detail();
        Hide_item_006_Detail();
    }

    public void Hide_item_003_Detail()     //Hide details of item_003
    {
        Debug.Log("Hide details of item_003");
        item_003_detail.SetActive(false);
    }

    public void Show_item_004_Detail()     //Show details of item_004
    {
        Debug.Log("Show details of item_004");
        item_004_detail.SetActive(true);

        Hide_item_003_Detail();  //Hide other items in the same category
        Hide_item_005_Detail();
        Hide_item_006_Detail();
    }

    public void Hide_item_004_Detail()     //Hide details of item_004
    {
        Debug.Log("Hide details of item_004");
        item_004_detail.SetActive(false);
    }

    public void Show_item_005_Detail()     //Show details of item_005
    {
        Debug.Log("Show details of item_005");
        item_005_detail.SetActive(true);

        Hide_item_003_Detail();  //Hide other items in the same category
        Hide_item_004_Detail();
        Hide_item_006_Detail();
    }

    public void Hide_item_005_Detail()     //Hide details of item_005
    {
        Debug.Log("Hide details of item_005");
        item_005_detail.SetActive(false);
    }

    public void Show_item_006_Detail()     //Show details of item_006
    {
        Debug.Log("Show details of item_006");
        item_006_detail.SetActive(true);

        Hide_item_004_Detail();  //Hide other items in the same category
        Hide_item_005_Detail();
        Hide_item_003_Detail();
    }

    public void Hide_item_006_Detail()     //Hide details of item_006
    {
        Debug.Log("Hide details of item_006");
        item_006_detail.SetActive(false);
    }

    public void Show_item_007_Detail()     //Show details of item_007
    {
        Debug.Log("Show details of item_007");
        item_007_detail.SetActive(true);

        Hide_item_008_Detail();  //Hide other items in the same category
        Hide_item_009_Detail();

    }

    public void Hide_item_007_Detail()     //Hide details of item_007
    {
        Debug.Log("Hide details of item_007");
        item_007_detail.SetActive(false);
    }

    public void Show_item_008_Detail()     //Show details of item_008
    {
        Debug.Log("Show details of item_008");
        item_008_detail.SetActive(true);

        Hide_item_007_Detail();  //Hide other items in the same category
        Hide_item_009_Detail();
    }

    public void Hide_item_008_Detail()     //Hide details of item_008
    {
        Debug.Log("Hide details of item_008");
        item_008_detail.SetActive(false);
    }

    public void Show_item_009_Detail()     //Show details of item_009
    {
        Debug.Log("Show details of item_009");
        item_009_detail.SetActive(true);

        Hide_item_007_Detail();  //Hide other items in the same category
        Hide_item_008_Detail();
    }

    public void Hide_item_009_Detail()     //Hide details of item_009
    {
        Debug.Log("Hide details of item_009");
        item_009_detail.SetActive(false);
    }

    public void Show_item_010_Detail()     //Show details of item_010
    {
        Debug.Log("Show details of item_010");
        item_010_detail.SetActive(true);

        Hide_item_011_Detail();  //Hide other items in the same category
        Hide_item_012_Detail();
        Hide_item_013_Detail();
    }

    public void Hide_item_010_Detail()     //Hide details of item_010
    {
        Debug.Log("Hide details of item_010");
        item_010_detail.SetActive(false);
    }

    public void Show_item_011_Detail()     //Show details of item_011
    {
        Debug.Log("Show details of item_011");
        item_011_detail.SetActive(true);

        Hide_item_010_Detail();  //Hide other items in the same category
        Hide_item_012_Detail();
        Hide_item_013_Detail();
    }

    public void Hide_item_011_Detail()     //Hide details of item_011
    {
        Debug.Log("Hide details of item_011");
        item_011_detail.SetActive(false);
    }

    public void Show_item_012_Detail()     //Show details of item_012
    {
        Debug.Log("Show details of item_012");
        item_012_detail.SetActive(true);

        Hide_item_010_Detail();  //Hide other items in the same category
        Hide_item_011_Detail();
        Hide_item_013_Detail();
    }

    public void Hide_item_012_Detail()     //Hide details of item_012
    {
        Debug.Log("Hide details of item_012");
        item_012_detail.SetActive(false);
    }

    public void Show_item_013_Detail()     //Show details of item_013
    {
        Debug.Log("Show details of item_013");
        item_013_detail.SetActive(true);

        Hide_item_011_Detail();  //Hide other items in the same category
        Hide_item_012_Detail();
        Hide_item_010_Detail();
    }

    public void Hide_item_013_Detail()     //Hide details of item_013
    {
        Debug.Log("Hide details of item_013");
        item_013_detail.SetActive(false);
    }

    public void Show_item_014_Detail()     //Show details of item_014
    {
        Debug.Log("Show details of item_014");
        item_014_detail.SetActive(true);

        Hide_item_015_Detail();  //Hide other items in the same category
        Hide_item_016_Detail();
        Hide_item_017_Detail();
    }

    public void Hide_item_014_Detail()     //Hide details of item_014
    {
        Debug.Log("Hide details of item_014");
        item_014_detail.SetActive(false);
    }

    public void Show_item_015_Detail()     //Show details of item_015
    {
        Debug.Log("Show details of item_015");
        item_015_detail.SetActive(true);

        Hide_item_014_Detail();  //Hide other items in the same category
        Hide_item_016_Detail();
        Hide_item_017_Detail();
    }

    public void Hide_item_015_Detail()     //Hide details of item_015
    {
        Debug.Log("Hide details of item_015");
        item_015_detail.SetActive(false);
    }

    public void Show_item_016_Detail()     //Show details of item_016
    {
        Debug.Log("Show details of item_016");
        item_016_detail.SetActive(true);

        Hide_item_014_Detail();  //Hide other items in the same category
        Hide_item_015_Detail();
        Hide_item_017_Detail();
    }

    public void Hide_item_016_Detail()     //Hide details of item_016
    {
        Debug.Log("Hide details of item_016");
        item_016_detail.SetActive(false);
    }

    public void Show_item_017_Detail()     //Show details of item_017
    {
        Debug.Log("Show details of item_017");
        item_017_detail.SetActive(true);

        Hide_item_015_Detail();  //Hide other items in the same category
        Hide_item_016_Detail();
        Hide_item_014_Detail();
    }

    public void Hide_item_017_Detail()     //Hide details of item_017
    {
        Debug.Log("Hide details of item_017");
        item_017_detail.SetActive(false);
    }


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        item_001_detail.transform.Find("Amount").GetChild(0).gameObject.GetComponent<TMP_Text>().text = GameState.ItemAmount[0].ToString();
        item_002_detail.transform.Find("Amount").GetChild(0).gameObject.GetComponent<TMP_Text>().text = GameState.ItemAmount[1].ToString();
        item_003_detail.transform.Find("Amount").GetChild(0).gameObject.GetComponent<TMP_Text>().text = GameState.ItemAmount[2].ToString();
        item_004_detail.transform.Find("Amount").GetChild(0).gameObject.GetComponent<TMP_Text>().text = GameState.ItemAmount[3].ToString();
        item_005_detail.transform.Find("Amount").GetChild(0).gameObject.GetComponent<TMP_Text>().text = GameState.ItemAmount[4].ToString();
        item_006_detail.transform.Find("Amount").GetChild(0).gameObject.GetComponent<TMP_Text>().text = GameState.ItemAmount[5].ToString();
        item_007_detail.transform.Find("Amount").GetChild(0).gameObject.GetComponent<TMP_Text>().text = GameState.ItemAmount[6].ToString();
        item_008_detail.transform.Find("Amount").GetChild(0).gameObject.GetComponent<TMP_Text>().text = GameState.ItemAmount[7].ToString();
        item_009_detail.transform.Find("Amount").GetChild(0).gameObject.GetComponent<TMP_Text>().text = GameState.ItemAmount[8].ToString();
        item_010_detail.transform.Find("Amount").GetChild(0).gameObject.GetComponent<TMP_Text>().text = GameState.ItemAmount[9].ToString();
        item_011_detail.transform.Find("Amount").GetChild(0).gameObject.GetComponent<TMP_Text>().text = GameState.ItemAmount[10].ToString();
        item_012_detail.transform.Find("Amount").GetChild(0).gameObject.GetComponent<TMP_Text>().text = GameState.ItemAmount[11].ToString();
        item_013_detail.transform.Find("Amount").GetChild(0).gameObject.GetComponent<TMP_Text>().text = GameState.ItemAmount[12].ToString();
        item_014_detail.transform.Find("Amount").GetChild(0).gameObject.GetComponent<TMP_Text>().text = GameState.ItemAmount[13].ToString();
        item_015_detail.transform.Find("Amount").GetChild(0).gameObject.GetComponent<TMP_Text>().text = GameState.ItemAmount[14].ToString();
        item_016_detail.transform.Find("Amount").GetChild(0).gameObject.GetComponent<TMP_Text>().text = GameState.ItemAmount[15].ToString();
        item_017_detail.transform.Find("Amount").GetChild(0).gameObject.GetComponent<TMP_Text>().text = GameState.ItemAmount[16].ToString();
    }
}
