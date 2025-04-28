using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public float moveSmoothness;
    public float rotateSmoothness;

    public Vector3 moveOffest;
    public Vector3 rotationOffest;

    public Transform carTarget;

    private void LateUpdate()
    {
        FollowTarget();
    }

    void FollowTarget()
    {
        HandleMovement();
        HandleRotation();
    }

    void HandleMovement()
    {
        Vector3 targetPos = new Vector3();
        targetPos = carTarget.TransformPoint(moveOffest);

        transform.position = Vector3.Lerp(transform.position, targetPos, moveSmoothness * Time.deltaTime);
    }

    void HandleRotation()
    {
        var direction = carTarget.position - transform.position;
        var rotation = new Quaternion();

        rotation = Quaternion.LookRotation(direction + rotationOffest, Vector3.up);

        transform.rotation = Quaternion.Slerp(transform.rotation, rotation, rotateSmoothness * Time.deltaTime);
    }
}
