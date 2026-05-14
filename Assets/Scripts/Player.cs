using UnityEngine;

public class Player : MonoBehaviour
{
    private bool isRightSide = false;

    private void Awake()
    {
        isRightSide = false;
        Debug.Log(isRightSide ? 1 : -1);
    }

    private void OnEnable()
    {
        SwipeDetector.OnSwipeLeft += SwipeDetector_OnSwipeLeft;
        SwipeDetector.OnSwipeRight += SwipeDetector_OnSwipeRight;
    }

    private void SwipeDetector_OnSwipeRight()
    {
        if (!isRightSide)
            SetIsRightSide(true);
    }

    private void SwipeDetector_OnSwipeLeft()
    {
        if (isRightSide)
            SetIsRightSide(false);
    }

    private void SetIsRightSide(bool value)
    {
        isRightSide = value;
        Debug.Log(isRightSide ? 1 : -1);

        var prevPos = transform.position;
        transform.position = new Vector3(prevPos.x * -1, prevPos.y, prevPos.z);
    }

    private void OnDisable()
    {
        SwipeDetector.OnSwipeLeft -= SwipeDetector_OnSwipeLeft;
        SwipeDetector.OnSwipeRight -= SwipeDetector_OnSwipeRight;
    }
}
