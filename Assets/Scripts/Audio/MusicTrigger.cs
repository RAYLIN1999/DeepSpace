using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicTrigger : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        AudioManager.instance.Play("collect");
    }
}
