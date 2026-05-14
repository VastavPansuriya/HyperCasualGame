using UnityEngine;

public class Obstacle : MonoBehaviour
{
    [SerializeField] private float fallSpeed = 4f;
    [SerializeField] private float destroyYPosition = -6f;

    public void Initialize(float speed)
    {
        fallSpeed = speed;
    }

    private void Update()
    {
        if (GameManager.Instance != null && GameManager.Instance.IsGameOver)
        {
            return;
        }

        transform.position += Vector3.down * fallSpeed * Time.deltaTime;

        if (transform.position.y <= destroyYPosition)
        {
            Destroy(gameObject);
        }
    }
}
