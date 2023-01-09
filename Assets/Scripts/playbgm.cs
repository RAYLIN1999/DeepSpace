using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playbgm : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        if (GameState.BGM)
            AudioManager.instance.Play("environment1");
    }
}
