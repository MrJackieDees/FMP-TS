using UnityEngine;

public class Gun : MonoBehaviour
{

    public Bullet bullet;
    public void Shoot()
    {
        GameObject go = Instantiate(bullet.gameObject, transform.position, Quaternion.identity);
    }
}
