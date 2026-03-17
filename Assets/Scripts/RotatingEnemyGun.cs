using System;
using Unity.Mathematics;
using UnityEngine;

public class RotatingEnemyGun : EnemyGun
{
    public float rotationspeed;

    private float RotatingTimer = 0f;

    public float RotatingTimerDuration = 3.0f;

    private float VolleyTimer = 0f;

    public float VolleyTimerDuration = 3.0f;

    public void shootvolley()
    {
        transform.rotation = Quaternion.identity;

        VolleyTimer = 0;

        enabled = true;
    }

     public override void Shoot(GameObject BulletToShoot)
    
    {
        GameObject go = Instantiate(BulletToShoot, transform.position, transform.rotation);
    }

    void FixedUpdate()
    {
        Rotate();

        RotatingTimer += Time.deltaTime;
        
        VolleyTimer += Time.deltaTime;

        if(RotatingTimer >= RotatingTimerDuration)
        {
            Shoot(bullet.gameObject);

            RotatingTimer = 0f;
        }

         if(VolleyTimer >= VolleyTimerDuration)
        {
            enabled = false;
        }
    }

    private void Rotate()
    {
        Vector3 deltaRotation = new Vector3 (0, 0, rotationspeed) * Time.deltaTime;

        transform.Rotate(deltaRotation);
    }
}
