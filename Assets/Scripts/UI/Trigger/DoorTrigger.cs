using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorTrigger : MonoBehaviour
{
    public static DoorTrigger Instance; //Instantiating the DoorTrigger.cs


    void Awake()
    {
        Instance = this;
    }
    public void OnTriggerEnter(Collider other)     //Enter the range of this object

    {
        Debug.Log("DOOR OPEN");
        //TODO
        
    }

    public void OnTriggerExit(Collider other) //Leave the range of this object
    {
        Debug.Log("DOOR CLOSE");
        //TODO
    }
}
