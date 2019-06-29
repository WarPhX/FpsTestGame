using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryComponent : MonoBehaviour {

    public List<GameObject> weaponList;
    public GameObject DummyLeft;
    public GameObject DummyRight;

    private GameObject currentWeaponLeft;
    private GameObject currentWeaponRight;

    private void Start()
    {
        currentWeaponLeft = Instantiate(weaponList[0], DummyLeft.transform,false);
        //currentWeaponLeft.transform.parent = this.gameObject.transform;
        
        currentWeaponRight = Instantiate(weaponList[1], DummyRight.transform, false);
        //currentWeaponRight.transform.parent = this.gameObject.transform;
    }
}
