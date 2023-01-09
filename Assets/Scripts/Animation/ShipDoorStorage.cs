using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipDoorStorage : MonoBehaviour
{
    Animator ator;

    void Start()
    {
        ator = gameObject.GetComponent<Animator>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (GameState.StorageAreaUnlocked)
        {
            gameObject.transform.Find("door_2_left").GetComponent<BoxCollider>().enabled = false;
            gameObject.transform.Find("door_2_right").GetComponent<BoxCollider>().enabled = false;
            ator.SetBool("character_nearby", true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        gameObject.transform.Find("door_2_left").GetComponent<BoxCollider>().enabled = true;
        gameObject.transform.Find("door_2_right").GetComponent<BoxCollider>().enabled = true;
        ator.SetBool("character_nearby", false);
    }
}
