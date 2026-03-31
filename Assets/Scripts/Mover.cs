using UnityEngine;

public class Mover : MonoBehaviour
{
    [SerializeField] private Vector3 _moveDirection;

    private void Update()
    {
        transform.Translate(_moveDirection);
    }
}