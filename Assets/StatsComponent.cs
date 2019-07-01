using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StatsComponent : MonoBehaviour {

    public float maxHp;
    private float curHp;
    public float damage;

	void Start ()
    {
        curHp = maxHp;
        EventManager.Instance.AddListener<BulletHitEnemyEvent>(OnBulletHitEnemy);
	}

	public void OnBulletHitEnemy(BulletHitEnemyEvent e)
    {
        if (this.gameObject == e.targetHit)
        {
            curHp -= e.shooter.GetComponent<StatsComponent>().damage;
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
