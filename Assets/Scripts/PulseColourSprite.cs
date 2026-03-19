using System;
using UnityEngine;

public class PulseColourSprite : MonoBehaviour
{
    public float MinOpacity = 0f;

    public float MaxOpacity = 1.0f;

    public Timer SinglePulseTimer;

    public float PulseTime;

    public SpriteRenderer ShieldSprite;

    private void Start()
    {
        SinglePulseTimer.WhenDoneCounting += restartTimer;

        restartTimer();
    }

    private void restartTimer()
    {
        StartTimer();
    }

    private void StartTimer()
    {
        SinglePulseTimer.StartCounting(PulseTime);
    }

    void Update()
    {
        float opactity = CalcOpacity();

        ShieldSprite.color = new Color(93.0f / 255.0f, 206.0f / 255.0f, 252.0f / 255.0f, opactity);

    }

    private float CalcOpacity()
    {
        float x = SinglePulseTimer.currentValue / PulseTime * Mathf.PI * 2;

        float y = (Mathf.Cos(x) + 1) / 2;

        return Mathf.Lerp(MinOpacity, MaxOpacity, y);
    }
}
