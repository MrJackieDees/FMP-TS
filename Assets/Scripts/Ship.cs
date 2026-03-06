using UnityEngine;

public abstract class Ship : MonoBehaviour
{
    public GameObject explosion;

    public void Die()
    {
        Destroy(gameObject);
    
        GameObject go = Instantiate(explosion.gameObject, transform.position, Quaternion.identity);
    }
}

