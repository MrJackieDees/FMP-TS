
using System;
using JetBrains.Annotations;
using UnityEngine;

public class EnemyRoam : MonoBehaviour
{
    public Timer WaitInPlaceTimer;

    public CircleCollider2D RoamArea;

    public EnemyShip enemyShip;

    void Awake()
    {
        WaitInPlaceTimer.WhenDoneCounting += ChooseNextRoamLocation;
    }

    private void ChooseNextRoamLocation()
    {
        float Angle = UnityEngine.Random.Range(0f, 360f);

        float distance = UnityEngine.Random.Range(0f, RoamArea.radius);

        Vector3 TargetRoamPosition =((Vector3)RoamArea.offset) + new Vector3 (Mathf.Cos(Angle) * distance, Mathf.Sin(Angle) * distance, 0);

        TargetRoamPosition = TargetRoamPosition + transform.position;

        enemyShip.setTargetRoamPosition(TargetRoamPosition);

        WaitInPlaceTimer.StartCounting();
    }

}
