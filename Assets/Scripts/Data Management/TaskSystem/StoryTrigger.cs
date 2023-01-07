
using System;
using UnityEngine;

public class StoryTrigger : MonoBehaviour
{
    public bool IsTriggered { get; private set; } = false;
    public bool reuseable = false;
    private void OnTriggerEnter(Collider other)
    {
        if (other.name == "Player")
        {
            IsTriggered = true;
            if (!reuseable) gameObject.SetActive(false);
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.name == "Player")
            IsTriggered = false;
    }
}