using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponControllerComponent : MonoBehaviour
{
    public float bulletSpeed;

    public GameObject objBullet;
    public GameObject bulletDummy;

    private GameObject objOwner;
    private WeaponStats weaponStats;

    void Start()
    {
        weaponStats = GetComponent<WeaponStats>();
    }

    public void SetOwner(GameObject owner)
    {
        objOwner = owner;
    }

    public void OnShoot()
    {
        GameObject newBullet = Instantiate(objBullet, bulletDummy.transform.position, bulletDummy.transform.rotation, transform.parent.parent);

        newBullet.GetComponent<Rigidbody>().velocity = newBullet.transform.forward * bulletSpeed;
        newBullet.GetComponent<BulletComponent>().SetOwner(objOwner);
    }
}
