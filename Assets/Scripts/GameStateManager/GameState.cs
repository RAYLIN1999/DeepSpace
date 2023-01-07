using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

static public class GameState
{
    static public GameObject currInteractObj = null;
    static public bool GameEnd = false;

    static public void Reset()
    {
        currInteractObj = null;
        GameEnd = false;
    }
}
