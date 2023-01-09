using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UseItem : MonoBehaviour
{
    static public UseItem Instance;

    private void Awake()
    {
        Instance = this;
        DontDestroyOnLoad(gameObject);
    }
    public void useItem01()
    {
        if (GameState.ItemAmount[0] <= 0) return;
        GameState.ItemAmount[0]--;
        BasicCombatant potion = new();
        CombatSystem.AddCombatAct(potion, Player.Instance.GetBasicCombatant(), new Healer { RawValue = 10 });
    }
    public void useItem02()
    {
        if (GameState.ItemAmount[1] <= 0) return;
        GameState.ItemAmount[1]--;
        Player.Instance.pickupOxygenTank();
    }

}
