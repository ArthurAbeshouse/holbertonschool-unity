using UnityEngine;

public class CameraControl : MonoBehaviour
{

    public Transform player;

    private Vector3 offset;

    public float turnSpeed;

    // Start is called before the first frame update
    void Start()
    {
        offset = transform.position - player.position;
    }

    // Update is called once per frame
    void LateUpdate()
    {
        offset = Quaternion.AngleAxis(Input.GetAxis("Mouse X") * turnSpeed, Vector3.up) * Quaternion.AngleAxis(Input.GetAxis("Mouse Y") * turnSpeed, Vector3.left) * offset;
        transform.position = player.position + offset;
        transform.LookAt(player.position);
    }
}
