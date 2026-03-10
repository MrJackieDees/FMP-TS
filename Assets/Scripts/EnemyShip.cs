

using UnityEngine;

public class EnemyShip : Ship
{
    private float Timer = 0f;

    public float TimerDuration = 3.0f;

    public EnemyGun gun;


    void FixedUpdate()
    {
        Timer += Time.deltaTime;

        if(Timer >= TimerDuration)
        {
            shoot();
        }
    }

    private void shoot()
    {
        gun.shootdefault();

        gun.shotgun();

        gun.circle();

        Timer = 0f;
    }
}
