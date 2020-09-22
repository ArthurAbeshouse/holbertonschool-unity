using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControl : MonoBehaviour
{

    public Transform player;

    private Vector3 offset;

    public float turnSpeed;

    public static int invert;

    public bool isInverted = false;

    // Start is called before the first frame update
    void Start()
    {
        offset = transform.position - player.position;
        invert = OptionsMenu.invert;
        if (PlayerPrefs.HasKey("isInverted"))
            isInverted = PlayerPrefs.GetInt("isInverted") == 0 ? false : true;
    }

    void LateUpdate()
    {
        offset = Quaternion.AngleAxis(Input.GetAxis("Mouse X") * turnSpeed, Vector3.up) * Quaternion.AngleAxis(Input.GetAxis("Mouse Y") * invert * turnSpeed, Vector3.left) * offset;
        transform.position = player.position + offset * Time.timeScale;
        transform.LookAt(player.position);
    }
}
