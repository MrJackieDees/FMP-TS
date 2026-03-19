using UnityEngine;

public abstract class Ship : MonoBehaviour
{
    public GameObject explosion;

    protected float moveSpeed = 14;

    public void Die()
    {
        Destroy(gameObject);
    
        GameObject go = Instantiate(explosion.gameObject, transform.position, Quaternion.identity);
    }
     protected void moveShipAround(Vector2 moveInput)
    {
        var moveAmount = moveSpeed * moveInput * Time.fixedDeltaTime;

        transform.position = new Vector3 (transform.position.x + moveAmount.x, transform.position.y + moveAmount.y, transform.position.z); 
    }
}

