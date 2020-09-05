using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float velocity;
    public bool isGrounded = true;

    [Range(1, 10)]
    public float jumpSpeed;

    Rigidbody rbdy;

    // Start is called before the first frame update
    void Start()
    {
        rbdy = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(velocity * Input.GetAxis("Horizontal") * Time.deltaTime, 0f, velocity * Input.GetAxis("Vertical") * Time.deltaTime);
        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            rbdy.AddForce(Vector3.up * jumpSpeed, ForceMode.Impulse);
            isGrounded = false;
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            isGrounded = true;
        }
    }
}
