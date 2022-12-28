using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(BasicCombatant))]
public class WeaponControl : MonoBehaviour
{
    public Transform shootPoint;
    public int bulletsMag = 30;//Number of rounds in a magazine             一个弹匣的子弹数量
    public int range = 100;//Shooting range                                 射程
    public int bulletLeft = 300;//Back-up bullets                           备弹
    public int currentBullet;//Current bullet count                         当前子弹数

    private bool gunShootInput;

    public float fireRate = 0.1f;//Rate of fire                 射速
    private float fireTime;//Timer                              计时器
    private BasicCombatant myComb;

    [Header("KeySet")]
    [SerializeField] private KeyCode reloadInputName;

    [Header("UI")]
    public Text AmmoTextUI;
    public Image CrossPoint;

    // Start is called before the first frame update
    void Start()
    {
        myComb=GetComponent<BasicCombatant>();
        reloadInputName = KeyCode.R;
        currentBullet = bulletsMag;
        UpdateAmmoUI();
    }

    // Update is called once per frame
    void Update()
    {
        gunShootInput = Input.GetMouseButton(0);//Detects if the left mouse button is pressed               检测鼠标左键是否按下
        if (gunShootInput)
        {
            GunFire();
        }

        if (fireTime < fireRate)
        {
            fireTime += Time.deltaTime;
        }

        if (Input.GetKeyDown(reloadInputName) && currentBullet < bulletsMag && bulletLeft > 0)
        {
            Reload();
        }
    }

    /// <summary>
    /// 射击 shoot
    /// </summary>
    public void GunFire()
    {
        //控制射速，如果计时器比射速还小，跳出方法（不射击
        //每帧减少射线执行的次数，从而降低射速
        //子弹为0时退出射击。

        //control the rate of fire, if the timer is smaller than the rate of fire, jump out of the method (no shooting)
        //reduce the number of times the shot is executed per frame, thus reducing the rate of fire
        //quit firing when the bullet is 0
        if (fireTime < fireRate || currentBullet <= 0)
        {
            return;
        }

        //shoot                                 射击
        RaycastHit hit;
        Vector3 shootDirection = shootPoint.forward;//Shooting direction forward                射击方向向前
        if (Physics.Raycast(shootPoint.position, shootDirection, out hit, range))//Range of 100 yards (range), if it hits an object, the information is stored in the hit       100码（range）的射程，如果击中物体，则会将信息存放到 hit 中
        {
            var comb = hit.collider.gameObject.GetComponent<BasicCombatant>();
            if (comb != null)// hit combatants only
            {
                CombatSystem.AddCombatAct(myComb, comb, new DamageDealer { RawValue = 5 }, "");
                Debug.Log(hit.transform.name + "Hit");
            }
        }

        currentBullet--;//Less one bullet per shot                      每次射击子弹减一
        UpdateAmmoUI();

        fireTime = 0;
    }

    /// <summary>
    /// Bullet UI                           子弹UI
    /// </summary>
    public void UpdateAmmoUI()
    {
        AmmoTextUI.text = currentBullet + "/" + bulletLeft;
    }

    /// <summary>
    /// Bullet exchange                     换子弹
    /// </summary>
    public void Reload()
    {
        if (bulletLeft <= 0) return;

        int bulletNeed = bulletsMag - currentBullet;//Number of munitions to be filled                  所需填装的弹药数量

        //int bullectReduce = (bulletLeft >= bulletNeed) ? bulletNeed : bulletLeft;


        if (bulletLeft >= bulletNeed)
        {
            bulletLeft = bulletLeft - bulletNeed;
        }
        else
        {
            bulletLeft = 0;
            bulletsMag = currentBullet + bulletLeft;
        }

        //bulletLeft -= bullectReduce;//Reduced bullet preparation                              减少的备弹
        currentBullet += bulletNeed;//Current bullet count                                      当前子弹数
        UpdateAmmoUI();
    }
}