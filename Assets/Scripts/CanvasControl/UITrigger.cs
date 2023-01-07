using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UITrigger : MonoBehaviour
{
    public GameObject UIElement = null;
    private void OnTriggerEnter(Collider other)
    {
        if (other.name == "Player")
        {
            UIElement.SetActive(true);
            GameState.currInteractObj = gameObject;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.name == "Player")
        {
            UIElement.SetActive(false);
            if (GameState.currInteractObj == gameObject)
                GameState.currInteractObj = null;
        }
    }
}
