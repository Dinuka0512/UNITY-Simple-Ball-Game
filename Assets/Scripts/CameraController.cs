using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform target;

    private void FixedUpdate()
    {
        transform.LookAt(target);
    }
}
