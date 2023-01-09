using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class switchtofire1 : MonoBehaviour
{
    // Start is called before the first frame update

    double t0 = 0;
    void Start()
    {
        t0 = Time.timeAsDouble;
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.timeAsDouble > t0 + 5)
            SceneManager.LoadScene(8);
    }
}
