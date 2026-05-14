using UnityEngine;

public class ObstacleMover : MonoBehaviour
{
    [Header("Movement")]
    [SerializeField] private float moveSpeed = 4f;

    [Header("Destroy Settings")]
    [SerializeField] private float destroyYPosition = -7f;

    private void Update()
    {
        transform.position += Vector3.down * moveSpeed * Time.deltaTime;

        if (transform.position.y <= destroyYPosition)
        {
            Destroy(gameObject);
        }
    }
}