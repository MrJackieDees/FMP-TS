using System;
using UnityEngine;

public class HurtBox : MonoBehaviour
{
  public HealthBar ConnectedHealth;

  public PlayerShield OptionalShield;

  public void TakeDamage(float DamageAmount)
  {
    if (TryBlockWithShield())
    {
      return;
    }
    ConnectedHealth.takeDamage(DamageAmount);
  }

  private bool TryBlockWithShield()
  {
    if (OptionalShield == null)
    {
      return false;
    }

    return OptionalShield.isActive;
  }
}
