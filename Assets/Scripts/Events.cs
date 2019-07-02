using UnityEngine;

public class ChangeWeaponEvent : Message , IGameEvent
{
    public override string Type { get { return "ChangeWeaponEvent"; } }
    public WeaponType weaponId;
}

public class ShootEvent : Message , IGameEvent
{
    public override string Type { get { return "ShootEvent"; } }
    public GameObject shooter;
}

public class BulletHitEnemyEvent : Message, IGameEvent
{
    public override string Type { get { return "BulletHitEnemyEvent"; } }
    public GameObject targetHit;
    public GameObject shooter;
    public float damage;
}
