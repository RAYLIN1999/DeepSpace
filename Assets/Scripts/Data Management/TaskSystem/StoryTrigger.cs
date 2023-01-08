
using System;
using UnityEngine;

public class StoryTrigger : MonoBehaviour
{
    public bool IsTriggered { get; private set; } = false;
    private void OnTriggerEnter(Collider other)
    {
        if (other.name == "Player")
        {
            IsTriggered = true;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.name == "Player")
            IsTriggered = false;
    }
}