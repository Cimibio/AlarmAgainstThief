using System;
using UnityEngine;

public class AlarmDetector : MonoBehaviour
{
    private Collider _houseCollider;

    public event Action ThiefEntered;
    public event Action ThiefExited;

    private void Start()
    {
        if (TryGetComponent(out Collider collider))
        {
            _houseCollider = collider;
            _houseCollider.isTrigger = true;
        }
    }

    private void OnTriggerEnter(Collider collider)
    {
        if (collider.TryGetComponent<Thief>(out _))
            ThiefEntered?.Invoke();
    }

    private void OnTriggerExit(Collider collider)
    {
        if (collider.TryGetComponent<Thief>(out _))
            ThiefExited?.Invoke();
    }
}
