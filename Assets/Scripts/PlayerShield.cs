using System;
using UnityEngine;

public class PlayerShield : MonoBehaviour
{
    public GameObject ShieldSprite;

    public Collider2D ShieldHitBox;

    public Timer CooldownTimer;

    public Timer ShieldDurationTimer;

    public bool isActive;

    void Awake()
    {
        ShieldDurationTimer.WhenDoneCounting += DeactivateShield;
    }

    private void DeactivateShield()
    {
        ShieldSprite.SetActive(false);

        ShieldHitBox.enabled = false;

        CooldownTimer.StartCounting();

        isActive = false;
    }

    public void Update()
    {
        if (Input.GetKey(KeyCode.E))
        {
            TryActivateShield();
        }
    }

    private void TryActivateShield()
    {
        if (ShieldNotOnCooldown())
        {
            ActivateShield();
        }
    }

    private void ActivateShield()
    {
        isActive = true;

        ShieldSprite.SetActive(true);

        ShieldHitBox.enabled = true;

        ShieldDurationTimer.StartCounting();
    }

    private bool ShieldNotOnCooldown()
    {
        return CooldownTimer.currentValue == 0;
    }

    internal float CalculateShieldPercent()
    {
        if (isActive)
        {
            return CalculateShieldDurationPercent();
        }

        if (!CooldownTimer.isCounting)
        {
            return 1f;
        }

        float ShieldPercent = CooldownTimer.currentValue / CooldownTimer.Duration;

        return ShieldPercent;


    }

    private float CalculateShieldDurationPercent()
    {
        return 1.0f - ShieldDurationTimer.currentValue / ShieldDurationTimer.Duration;
    }
}
