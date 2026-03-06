using UnityEngine.UI;
using UnityEngine;
using System;

public class HealthBar : MonoBehaviour

{
    public float HealthPercent = 1.0f;

    public float HealthTotal = 100f;

    public float CurrentHealth = 100f;

    public Image Overlay;

    public Ship Ship;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        UpdateHealthPercent();

        Overlay.fillAmount = HealthPercent;
    }

    public void takeDamage(float DamageAmount)
    {
        Debug.Log(CurrentHealth);
        CurrentHealth -= DamageAmount;

        TryDie();
    }

    private void TryDie()
    {
        if (CurrentHealth <= 0)
        {
            Die();

            CurrentHealth = 0;
        }
    }

    private void Die()
    {
        Ship.Die();
    }

    private void UpdateHealthPercent()
    {
        HealthPercent = CurrentHealth / HealthTotal;
    }
}
