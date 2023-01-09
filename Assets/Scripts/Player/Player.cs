using Newtonsoft.Json.Linq;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;


[RequireComponent(typeof(BasicCombatant))]
public class Player : MonoBehaviour
{
    static public Player Instance = null;
    public bool IsDead { get => myComb.HitPoint == 0; }

    public double CurrentHP => myComb.HitPoint;
    public double MaxHP => myComb.MaxHitPoint;

    public int maxOxygen = 10;     //Maximum Oxygen value
    public int currentOxygen;      //Current Oxygen value


    private BasicCombatant myComb;

    void Awake()
    {
        Instance = this;
        myComb = GetComponent<BasicCombatant>();
    }

    // Start is called before the first frame update
    void Start()
    {
        if (GameState.PlayerHP > 0) myComb.SetHP(GameState.PlayerHP);
        currentOxygen = maxOxygen - 1;
        if (GameState.PlayerOx > 0) currentOxygen = (GameState.PlayerOx);
    }

    // Update is called once per frame
    void Update()
    {
        GameState.PlayerHP = CurrentHP;
        GameState.PlayerOx = currentOxygen;

        if (Input.GetKeyDown(KeyCode.K))  //Cheat button for testing, and reduce health values
        {
            TakeDamage(10);
        }

        if (Input.GetKeyDown(KeyCode.L)) //Cheat button for testing, and reduce oxygen values
        {
            LoseOxygen(1);
        }

    }

    void TakeDamage(int damage)
    {
        CombatSystem.AddCombatAct(myComb, myComb, new DamageDealer { RawValue = damage });
        //UIManager.Instance.SetHealth((int)myComb.HitPoint);   //Synchronised bar values
        AudioManager.instance.Play("damage");
    }

    void LoseOxygen(int lose)
    {
        currentOxygen -= lose;   //reduce oxygen values

        if (currentOxygen < 0)    //Avoid reducing to a negative number
        {
            currentOxygen = 0;
        }
    }

    void addOxygen(int add)
    {
        currentOxygen += add;   //add oxygen values

        if (currentOxygen > 10)    //Avoid above 10
        {
            currentOxygen = 10;
        }
    }

    public void pickupOxygenTank()
    {
        addOxygen(1);
        AudioManager.instance.Play("collect");
    }

    public BasicCombatant GetBasicCombatant()
    {
        return myComb;
    }
}
