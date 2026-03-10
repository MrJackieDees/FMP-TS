using System;
using Mono.Cecil.Cil;
using UnityEngine;

public class EnemyGun : Gun
{
    public ShotgunBullet shotgunBullet;

    public ShotgunBullet circleBullet;

    public void shotgun()
    {
        Shoot(shotgunBullet.gameObject);
    }

    public void circle()
    {
        Shoot(circleBullet.gameObject);
    }
}
