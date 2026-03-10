using System;
using Mono.Cecil.Cil;
using UnityEngine;

public class EnemyGun : Gun
{
    public ShotgunBullet shotgunBullet;

    internal void shotgun()
    {
        Shoot(shotgunBullet.gameObject);
    }
}
