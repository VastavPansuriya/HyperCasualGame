using UnityEngine;

#if ENABLE_INPUT_SYSTEM
using UnityEngine.InputSystem;
#endif

public class PlayerController : MonoBehaviour
{
    [Header("Movement")]
    [SerializeField] private float moveSpeed = 8f;
    [SerializeField] private float horizontalPadding = 0.4f;

    private Camera mainCamera;
    private float inputX;

    private void Awake()
    {
        mainCamera = Camera.main;
    }

    private void Update()
    {
        if (GameManager.Instance != null && GameManager.Instance.IsGameOver)
        {
            return;
        }

        ReadInput();
        MovePlayer();
        ClampToScreen();
    }

    private void ReadInput()
    {
        inputX = 0f;

#if ENABLE_INPUT_SYSTEM
        if (Keyboard.current != null)
        {
            if (Keyboard.current.aKey.isPressed || Keyboard.current.leftArrowKey.isPressed)
            {
                inputX -= 1f;
            }

            if (Keyboard.current.dKey.isPressed || Keyboard.current.rightArrowKey.isPressed)
            {
                inputX += 1f;
            }
        }
#else
        inputX = Input.GetAxisRaw("Horizontal");
#endif
    }

    private void MovePlayer()
    {
        Vector3 movement = new Vector3(inputX, 0f, 0f);
        transform.position += movement * moveSpeed * Time.deltaTime;
    }

    private void ClampToScreen()
    {
        if (mainCamera == null)
        {
            return;
        }

        Vector3 leftEdge = mainCamera.ViewportToWorldPoint(new Vector3(0f, 0f, 0f));
        Vector3 rightEdge = mainCamera.ViewportToWorldPoint(new Vector3(1f, 0f, 0f));

        Vector3 position = transform.position;
        position.x = Mathf.Clamp(position.x, leftEdge.x + horizontalPadding, rightEdge.x - horizontalPadding);
        transform.position = position;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Obstacle"))
        {
            if (GameManager.Instance != null)
            {
                GameManager.Instance.GameOver();
            }
        }
    }
}
