
using System;
using JetBrains.Annotations;
using UnityEngine;

public class PickUpSpawner : MonoBehaviour
{
    public Timer PrepTimer;
    public Despawner PickUp;

    public CircleCollider2D SpawnBox;

    void Awake()
    {
        PrepTimer.WhenDoneCounting += SpawnPickUp;
    }

    private void SpawnPickUp()
    {
        float Angle = UnityEngine.Random.Range(0f, 360f);

        float distance = UnityEngine.Random.Range(0f, SpawnBox.radius);

        Vector3 spawnPositon =((Vector3)SpawnBox.offset) + new Vector3 (Mathf.Cos(Angle) * distance, Mathf.Sin(Angle) * distance, 0);

        spawnPositon = spawnPositon + transform.position;
        
        Despawner go = Instantiate(PickUp, spawnPositon, Quaternion.identity);

        go.WhenDespawned += prepareNextSpawn;
    }

    private void prepareNextSpawn(Despawner despawner)
    {
        despawner.WhenDespawned -= prepareNextSpawn;

        PrepTimer.StartCounting();
    }
}
