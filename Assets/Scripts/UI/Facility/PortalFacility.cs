using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PortalFacility : MonoBehaviour
{
    public static PortalFacility Instance; //Instantiating the PortalFacility.cs

    void Awake()
    {
        Instance = this;
    }

    public void GoTo_fire_country() //Switch scene
    {
        Debug.Log("fire country");
        //SceneManager.LoadScene(2);
    }

    public void GoTo_wood_country() //Switch scene
    {
        Debug.Log("wood country");
        //SceneManager.LoadScene(1);
    }
}
