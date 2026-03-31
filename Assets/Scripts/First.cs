using UnityEngine;

public class First : MonoBehaviour
{
    [SerializeField] private float _transformZmax = 5f;
    [SerializeField] private float _transformZreturn = 0f;

    private void Update()
    {
        if (transform.position.z > _transformZmax)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, _transformZreturn);
        }
    }
}
