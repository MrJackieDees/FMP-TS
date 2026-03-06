using UnityEngine;

public class HurtBox : MonoBehaviour
{
  public HealthBar ConnectedHealth;

  public void TakeDamage(float DamageAmount)
    {
        ConnectedHealth.takeDamage(DamageAmount);
    }

}
