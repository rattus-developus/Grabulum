using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] Transform target;

    void Update()
    {
        if(target == null) return;
        Vector3 targetPosition = new Vector3(target.position.x, target.position.y, -10f);
        transform.position = targetPosition;
    }
}