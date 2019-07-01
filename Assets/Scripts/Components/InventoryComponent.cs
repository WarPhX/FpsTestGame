using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum WeaponType
{
    Pistol = 0,
    Rifle = 1,
    MachineGun = 2,
    ChainGun = 3,
    Sniper = 4,
    PumpActionRifle = 5
}

public class InventoryComponent : MonoBehaviour {

    public List<GameObject> weaponList;
    public GameObject DummyLeft;
    public GameObject DummyRight;

    private GameObject curWeaponLeft;   // not used curently
    private GameObject curWeaponRight;
    private WeaponControllerComponent curWeaponControllerRight;

    private WeaponType currentWeaponIdx;


    private void Start()
    {
        curWeaponRight = Instantiate(weaponList[0], DummyRight.transform.position, DummyRight.transform.rotation, transform);
        currentWeaponIdx = 0;
        curWeaponControllerRight = curWeaponRight.GetComponent<WeaponControllerComponent>();
        if (curWeaponControllerRight)
        {
            curWeaponControllerRight.SetOwner(gameObject);
        }

        EventManager.Instance.AddListener<ChangeWeaponEvent>(OnChangeWeapon);
        EventManager.Instance.AddListener<ShootEvent>(OnShoot);
    }

    private void OnChangeWeapon(ChangeWeaponEvent e)
    {
        if (currentWeaponIdx != e.weaponId)
        {
            Destroy(curWeaponRight.gameObject);
            curWeaponRight = Instantiate(weaponList[(int)e.weaponId], DummyRight.transform.position, DummyRight.transform.rotation, transform);
            curWeaponControllerRight = curWeaponRight.GetComponent<WeaponControllerComponent>();
            if (curWeaponControllerRight)
            {
                curWeaponControllerRight.SetOwner(gameObject);
            }
            currentWeaponIdx = e.weaponId;
        }
    }


    public void OnShoot(ShootEvent e)
    {
        curWeaponControllerRight.OnShoot();
    }

}
