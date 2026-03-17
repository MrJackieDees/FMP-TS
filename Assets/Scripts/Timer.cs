using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;

public class Timer : MonoBehaviour
{
    float Duration = 1.0f;

    float currentValue = 0;

    public UnityAction WhenDoneCounting;

    public void StartCounting()
    {
        enabled = true;
    }

    private void FixedUpdate()
    {
        currentValue += Time.deltaTime;

        if(currentValue >= Duration)
        {
            currentValue = 0f;

            WhenDoneCounting?.Invoke();

            enabled = false;
        }
    }

}
