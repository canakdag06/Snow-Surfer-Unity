using UnityEngine;

public class BackgroundCameraFollow : MonoBehaviour
{
    private void FixedUpdate()
    {
        transform.position = new Vector3(transform.position.x, Camera.main.transform.position.y, transform.position.z);
    }
}
