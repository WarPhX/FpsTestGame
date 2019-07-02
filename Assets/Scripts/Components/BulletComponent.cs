using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletComponent : MonoBehaviour {

    private GameObject shooter;
    private float damage;

    public void SetOwner(GameObject owner)
    {
        shooter = owner;
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.transform.parent.gameObject.tag == "Enemy")
        {

        }

        Destroy(this.gameObject);
    }
}
