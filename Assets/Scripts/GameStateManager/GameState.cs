using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

/// <summary>
/// Contains Game States to be shared amoung components and storeed by archive
/// </summary>
static public class GameState
{
    static public GameObject currInteractObj = null;

    //AccessControl
    static public bool WoodAccessed = false;
    static public bool FireAccessed = false;

    static public bool AIUnlocked = false;
    static public bool StorageAreaUnlocked = false;
    static public bool UpgradeAreaUnlocked = true;
    static public bool PowerAreaUnlocked = true;

    //PlayerState
    static public double PlayerHP = -1;
    static public int PlayerOx = -1;
    static public List<int> ItemAmount = new() { 0, 0, 0, 10, 10, 10, 1, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0 };

    //GameState
    static public bool GameEnd = false;
    static public bool BGM = true;
    static public int Difficulty = 0;   //0,1,2 easy, normal, hard


    static public void Reset()
    {
        currInteractObj = null;
        WoodAccessed = false;
        FireAccessed = false;
        
        AIUnlocked = false;
        StorageAreaUnlocked = false;
        UpgradeAreaUnlocked = true;
        PowerAreaUnlocked = true;

        PlayerHP = -1;
        PlayerOx = -1;
        ItemAmount = new() { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };

        GameEnd = false;
        BGM = true;

    }
}
