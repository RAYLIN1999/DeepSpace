using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipDoor : MonoBehaviour
{
    Animator ator;

    void Start()
    {
        ator = gameObject.GetComponent<Animator>();
    }

    private void OnTriggerEnter(Collider other)
    {
        ator.SetBool("character_nearby", true);
    }

    private void OnTriggerExit(Collider other)
    {
        ator.SetBool("character_nearby", false);
    }
}
