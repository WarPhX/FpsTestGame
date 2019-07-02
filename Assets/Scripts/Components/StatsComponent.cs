using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StatsComponent : MonoBehaviour {

    public float maxHp;
    private float curHp;

	void Start ()
    {
        curHp = maxHp;
        EventManager.Instance.AddListener<BulletHitEnemyEvent>(OnBulletHitEnemy);
	}

	public void OnBulletHitEnemy(BulletHitEnemyEvent e)
    {
        if (this.gameObject == e.targetHit)
        {
            curHp -= e.damage;
            Debug.Log("I've been shot " + this.gameObject.name + " , curent hp is " + curHp);
        }
    }

    void Update ()
    {
		if (curHp <= 0 )
        {
            Destroy(gameObject);
        }
	}
}
