using UnityEngine;

public class Bullet : MonoBehaviour
{

    public Vector2 direction = new Vector2(1, 0);
    public float speed = 22;

    public Vector2 velocity;

    public float Damage;

    float deltaAngle;

    public float BulletLife = 2.0f;

    void OnTriggerEnter2D(Collider2D other)
    {
        var HurtBox = other.GetComponent<HurtBox>();

        if(HurtBox != null)
        {
            HurtBox.TakeDamage(Damage);
        }
    } 

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Destroy(gameObject, BulletLife);
    }

    // Update is called once per frame
    void Update()
    {
        velocity = -gameObject.transform.right * speed;
    }

    private void FixedUpdate()
    {
        Vector2 pos = transform.position;

        pos += velocity * Time.fixedDeltaTime;

        transform.position = pos;
    }
}
