using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponStats : MonoBehaviour {

    public string WeaponName;

  
    // this should go in a real stats system
    public float damage;
    public float delayBetweenShots;
    public float maxAmmo;
    public bool hasContinuousFireRate;

    private float ammo;

    public void Start()
    {
        ammo = maxAmmo;
    }

}
