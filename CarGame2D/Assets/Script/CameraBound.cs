using UnityEngine;

public class CameraBound : MonoBehaviour
{
    public Transform target;
    public float smoothTime = 0.3f;
    public Vector2 offset;
    public Vector2 minBounds;

    public bool followTargetXPosition = true;

    private Vector3 velocity = Vector3.zero;

    private void LateUpdate()
    {
        if (target == null)
            return;

        Vector3 targetPosition=target.position + (Vector3)offset;
        if(!followTargetXPosition) 
            targetPosition.x=transform.position.x;
        targetPosition.y=Mathf.Max(targetPosition.y, minBounds.y);
        targetPosition.z = transform.position.z;

        transform.position=Vector3.SmoothDamp(transform.position, targetPosition, ref velocity, smoothTime);
    }
}
