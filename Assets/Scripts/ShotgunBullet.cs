using System;
using System.Collections.Generic;
using UnityEngine;

public class ShotgunBullet : MonoBehaviour
{

public List <Bullet> bullets = new List<Bullet>();


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {
        var children = GetComponentsInChildren<Bullet>();

        for(int i = 0; i <children.Length; i ++)
        {
           var childBullet = children[i];

           bullets.Add(childBullet);
        } 

        var maxBulletLifeSpan = FindMaxLifeSpan(bullets);

        Destroy(gameObject, maxBulletLifeSpan);
    }

    private float FindMaxLifeSpan(List<Bullet> bullets)
    {
        float MaxLifeFound = 0;

        foreach(Bullet bullet in bullets)
        {
            if(bullet.BulletLife > MaxLifeFound)
            {
                MaxLifeFound = bullet.BulletLife;
            }
        }

        return MaxLifeFound;
    
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
