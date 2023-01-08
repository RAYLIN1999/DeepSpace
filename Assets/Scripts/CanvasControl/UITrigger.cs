using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UITrigger : MonoBehaviour
{
    public UISupervisor.TriggeredUI type;
    private void OnTriggerEnter(Collider other)
    {
        if (other.name == "Player")
        {
            UISupervisor.Instance.TriggerElemOn(type);
            GameState.currInteractObj = gameObject;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.name == "Player")
        {
            UISupervisor.Instance.TriggerElemOff(type);
            if (GameState.currInteractObj == gameObject)
                GameState.currInteractObj = null;
        }
    }
}
