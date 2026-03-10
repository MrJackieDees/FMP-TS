using UnityEngine;

public class Gun : MonoBehaviour
{

    public ShotgunBullet bullet;
    public void Shoot(GameObject BulletToShoot)
    {
        GameObject go = Instantiate(BulletToShoot, transform.position, Quaternion.identity);
    }

    public void shootdefault()
    {
        Shoot(bullet.gameObject);
    }
    
}
