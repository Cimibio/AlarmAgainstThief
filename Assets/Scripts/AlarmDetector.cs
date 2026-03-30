using System;
using UnityEngine;

public class AlarmDetector : MonoBehaviour
{
    public event Action ThiefEntered;
    public event Action ThiefExited;

    private void OnCollisionEnter(Collision collision)
    {
        if (!collision.gameObject.TryGetComponent<Thief>(out _))
            return;

        ThiefEntered?.Invoke();
    }

    private void OnCollisionExit(Collision collision)
    {
        if (!collision.gameObject.TryGetComponent<Thief>(out _))
            return;

        ThiefExited?.Invoke();
    }
}
