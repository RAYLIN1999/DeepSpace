using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

static public class GameState
{
    static public GameObject currInteractObj = null;
    static public bool WoodAccessed = false;
    static public bool FireAccessed = false;

    static public double PlayerHP = -1;
    static public int PlayerOx = -1;

    static public bool GameEnd = false;

    static public List<int> ItemAmount = new() { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };

    static public void Reset()
    {
        currInteractObj = null;
        WoodAccessed = false;
        FireAccessed = false;

        PlayerHP = -1;
        PlayerOx = -1;

        GameEnd = false;

        ItemAmount = new() { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };

    }
}
