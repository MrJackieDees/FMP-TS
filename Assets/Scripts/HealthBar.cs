using UnityEngine.UI;
using UnityEngine;
using System;
using FMODUnity;
using FMOD.Studio;

public class HealthBar : MonoBehaviour

{
    public float HealthPercent = 1.0f;

    public float HealthTotal = 100f;

    public float CurrentHealth = 100f;

    public Image Overlay;

    public Ship Ship;

    public StudioEventEmitter emitter;

    public String OwnerName = "PlayerHealth";

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        GameObject obj = GameObject.Find("FMODListener"); 

        if (obj != null)
        {
            emitter = obj.GetComponent<StudioEventEmitter>();
        }
    }

    // Update is called once per frame
    void Update()
    {
        Overlay.fillAmount = HealthPercent;
    }

    public void takeDamage(float DamageAmount)
    {
        Debug.Log(CurrentHealth);
        CurrentHealth -= DamageAmount;

        CurrentHealth = Mathf.Max(CurrentHealth, 0f);

        RefreshHealth();

        TryDie();
    }

    private void RefreshHealth()
    {
        HealthPercent = (float)CurrentHealth / HealthTotal;

        if (emitter != null)
        {
            emitter.SetParameter(OwnerName, HealthPercent * 100f);

            Debug.Log("Setting FMOD param: " + HealthPercent * 100f);
        }
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
}
