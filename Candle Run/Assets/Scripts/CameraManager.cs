using UnityEngine;

public class CameraManager : MonoBehaviour
{
    public Transform target;
    public float offsetZ = -3;

    public float smoothX;

    private void LateUpdate()
    {
        transform.position = new Vector3
           (Mathf.Lerp(transform.position.x, target.transform.position.x, smoothX * Time.deltaTime), transform.position.y, target.transform.position.z + offsetZ);
    }
}