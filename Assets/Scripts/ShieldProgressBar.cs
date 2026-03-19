using UnityEngine.UI;
using UnityEngine;
using System;

public class ShieldProgressBar : MonoBehaviour

{
    public float ChargePercent = 1.0f;

    public float CurrentProgress = 100f;

    public Image Overlay;

   public PlayerShield Shield;

    // Update is called once per frame
    void Update()
    {
        UpdateChargePercent();

        Overlay.fillAmount = ChargePercent;
    }

    private void UpdateChargePercent()
    {
        ChargePercent = Shield.CalculateShieldPercent();
    }
}
