using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class destoryaftertutorial : MonoBehaviour
{

    // Update is called once per frame
    void Update()
    {
        if (GameState.AIUnlocked == true) gameObject.SetActive(false);
    }
}
