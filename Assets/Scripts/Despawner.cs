using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;

public class Despawner : MonoBehaviour
{
    public float LifeTime = 3.0f;

    public UnityAction<Despawner> WhenDespawned;

    void Awake()
    {
        Destroy(gameObject, LifeTime);
    }

    void OnDestroy()
    {
        WhenDespawned?.Invoke(this);
    }


}
