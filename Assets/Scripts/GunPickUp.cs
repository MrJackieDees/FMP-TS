using UnityEngine;

public class GunPickUp : MonoBehaviour

{
    public GameObject HeatSeekerShot;
    void OnTriggerEnter2D(Collider2D other)
    {
        Destroy(gameObject);

        GameObject go = Instantiate(HeatSeekerShot, transform.position, Quaternion.identity);
    }

    void Awake()
    {
        Destroy(gameObject, 2.0f);
    }

}
