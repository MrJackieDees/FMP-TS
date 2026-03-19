

using System;
using UnityEngine;

public class EnemyShip : Ship
{
    private float Timer = 0f;

    public float TimerDuration = 3.0f;

    public EnemyGun gun;

    public RotatingEnemyGun rotatinggun;

    private Vector3 _targetRoamPosition;

    public float CloseEnoughThresh = 0.0001f;


    void Awake()
    {
        setTargetRoamPosition(transform.position);
    }

    void FixedUpdate()
    {
        Timer += Time.deltaTime;

        if (Timer >= TimerDuration)
        {
            shoot();
        }

        MoveTowardTargetPosition();

    }

    private void MoveTowardTargetPosition()
    {
        var VectorTowardsTarget = _targetRoamPosition - gameObject.transform.position;

        if(isCloseEnough(VectorTowardsTarget))
        {
            return;
        }

        var moveInput = VectorTowardsTarget.normalized;

        moveShipAround(moveInput);
    }

    private bool isCloseEnough(Vector3 vectorTowardsTarget)
    {
        return vectorTowardsTarget.magnitude < CloseEnoughThresh;
    }

    private void shoot()
    {
        gun.shootdefault();

        gun.shotgun();

        gun.circle();

        rotatinggun.shootvolley();

        Timer = 0f;
    }

    internal void setTargetRoamPosition(Vector3 newPosition)
    {
        _targetRoamPosition = newPosition;
    }

}
