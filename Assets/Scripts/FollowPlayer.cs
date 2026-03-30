using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    public Transform target;
    public Vector3 offset = new Vector3(0, -0.5f, 0);

    void LateUpdate()
    {
        transform.position = target.position + offset;
    }
}