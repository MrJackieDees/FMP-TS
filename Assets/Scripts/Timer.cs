using System;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;

public class Timer : MonoBehaviour
{
    public float Duration = 1.0f;

    [NonSerialized]

    public float currentValue = 0;

    public UnityAction WhenDoneCounting;

    [NonSerialized]

    public bool isCounting;

    public void StartCounting(float NewDuration)
    {
        Duration = NewDuration;

        StartCounting();
    }

    public void StartCounting()
    {
        enabled = true;

        isCounting = true;
    }

    private void FixedUpdate()
    {
        currentValue += Time.deltaTime;

        if(currentValue >= Duration)
        {
            currentValue = 0f;

            enabled = false;

            isCounting = false;

            WhenDoneCounting?.Invoke();
        }
    }
}
