using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletComponent : MonoBehaviour {

    private GameObject shooter;

    public void SetOwner(GameObject owner)
    {
        shooter = owner;
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.transform.parent.gameObject.tag == "Enemy")
        {
            BulletHitEnemyEvent e = new BulletHitEnemyEvent();
            e.targetHit = collision.gameObject.transform.parent.gameObject;
            e.shooter = shooter;
            EventManager.Instance.SendEvent(e);
        }

        Destroy(this.gameObject);
    }
}
