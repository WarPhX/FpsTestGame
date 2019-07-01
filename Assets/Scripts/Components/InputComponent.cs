using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// This bad boy will receive all the button events and send proper game events
/// </summary>
/// 
public class InputComponent : MonoBehaviour {


	
	// Update is called once per frame
	void Update () {

        // Weapon Change
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            ChangeWeaponEvent e = new ChangeWeaponEvent();
            e.weaponId = WeaponType.Pistol;
            EventManager.Instance.SendEvent(e);
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            ChangeWeaponEvent e = new ChangeWeaponEvent();
            e.weaponId = WeaponType.Rifle;
            EventManager.Instance.SendEvent(e);
        }

        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            ChangeWeaponEvent e = new ChangeWeaponEvent();
            e.weaponId = WeaponType.MachineGun;
            EventManager.Instance.SendEvent(e);
        }

        if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            ChangeWeaponEvent e = new ChangeWeaponEvent();
            e.weaponId = WeaponType.ChainGun;
            EventManager.Instance.SendEvent(e);
        }

        if (Input.GetKeyDown(KeyCode.Alpha5))
        {
            ChangeWeaponEvent e = new ChangeWeaponEvent();
            e.weaponId = WeaponType.Sniper;
            EventManager.Instance.SendEvent(e);
        }

        if (Input.GetKeyDown(KeyCode.Alpha6))
        {
            ChangeWeaponEvent e = new ChangeWeaponEvent();
            e.weaponId = WeaponType.PumpActionRifle;
            EventManager.Instance.SendEvent(e);
        }


        // Basic shoot stuff
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            ShootEvent e = new ShootEvent();
            e.shooter = GameObject.FindGameObjectsWithTag("Player")[0];
            EventManager.Instance.SendEvent(e);
        }
    }
}
