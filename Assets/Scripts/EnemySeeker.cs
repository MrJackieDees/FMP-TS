using UnityEngine;

public class EnemySeeker : MonoBehaviour
{
    void Awake()
    {
        GameObject Enemy = GameObject.FindWithTag("EnemyShip");

        Vector3 vectorToEnemy = Enemy.transform.position - transform.position;

        float angleTowardsEnemy = Vector3.Angle(vectorToEnemy, transform.right) + 180f;

        if(vectorToEnemy.y <0f)
        {
            angleTowardsEnemy = Vector3.Angle(vectorToEnemy, -transform.right);
        }

        transform.Rotate(new Vector3 (0, 0, angleTowardsEnemy));
    }
}
