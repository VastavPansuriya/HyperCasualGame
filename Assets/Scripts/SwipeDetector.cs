using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class SwipeDetector : MonoBehaviour
{
    public static event Action OnSwipeLeft;
    public static event Action OnSwipeRight;
    public static event Action OnSwipeUp;
    public static event Action OnSwipeDown;

    [Header("Swipe Settings")]
    [SerializeField] private float minSwipeDistance = 80f;
    [SerializeField] private float maxSwipeTime = 0.5f;

    private InputAction pointerPositionAction;
    private InputAction pointerPressAction;

    private Vector2 startPosition;
    private float startTime;
    private bool isTrackingSwipe;

    private void Awake()
    {
        pointerPositionAction = new InputAction(
            name: "Pointer Position",
            type: InputActionType.PassThrough,
            binding: "<Pointer>/position"
        );

        pointerPressAction = new InputAction(
            name: "Pointer Press",
            type: InputActionType.Button,
            binding: "<Pointer>/press"
        );
    }

    private void OnEnable()
    {
        pointerPositionAction.Enable();
        pointerPressAction.Enable();

        pointerPressAction.started += HandlePointerPressed;
        pointerPressAction.canceled += HandlePointerReleased;
    }

    private void OnDisable()
    {
        pointerPressAction.started -= HandlePointerPressed;
        pointerPressAction.canceled -= HandlePointerReleased;

        pointerPositionAction.Disable();
        pointerPressAction.Disable();
    }

    private void OnDestroy()
    {
        pointerPositionAction.Dispose();
        pointerPressAction.Dispose();
    }

    private void HandlePointerPressed(InputAction.CallbackContext context)
    {
        startPosition = pointerPositionAction.ReadValue<Vector2>();
        startTime = Time.unscaledTime;
        isTrackingSwipe = true;
    }

    private void HandlePointerReleased(InputAction.CallbackContext context)
    {
        if (!isTrackingSwipe)
            return;

        isTrackingSwipe = false;

        Vector2 endPosition = pointerPositionAction.ReadValue<Vector2>();
        float swipeTime = Time.unscaledTime - startTime;
        Vector2 swipeDelta = endPosition - startPosition;

        if (swipeTime > maxSwipeTime)
            return;

        if (swipeDelta.magnitude < minSwipeDistance)
            return;

        if (Mathf.Abs(swipeDelta.x) > Mathf.Abs(swipeDelta.y))
        {
            if (swipeDelta.x > 0f)
            {
                OnSwipeRight?.Invoke();
            }
            else
            {
                OnSwipeLeft?.Invoke();
            }
        }
        else
        {
            if (swipeDelta.y > 0f)
            {
                OnSwipeUp?.Invoke();
            }
            else
            {
                OnSwipeDown?.Invoke();
            }
        }
    }
}