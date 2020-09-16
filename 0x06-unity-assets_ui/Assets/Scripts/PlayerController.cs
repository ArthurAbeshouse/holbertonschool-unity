using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float velocity;
    public bool isGrounded = true;

    public float threshold;

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
        float hori = Input.GetAxis("Horizontal");
        float verti = Input.GetAxis("Vertical");
        PlayerMovement(hori, verti);
    }
    void PlayerMovement(float hori, float verti)
    {
        // makes the player move and adjusts the input direction
        // based on where the camera is pointing
        float facing = Camera.main.transform.eulerAngles.y;
        Vector3 targetDirection = new Vector3(hori, 0f, verti);
        Vector3 TurnedInputs = Quaternion.Euler(0, facing, 0) * targetDirection;
        rbdy.MovePosition(transform.position + TurnedInputs * velocity * Time.deltaTime);
        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            rbdy.AddForce(Vector3.up * jumpSpeed, ForceMode.Impulse);
            isGrounded = false;
        }
    }
    void FixedUpdate()
    {
        Respawn();
    }
    void Respawn()
    {
        if (transform.position.y < threshold)
            transform.position = new Vector3(0, 0.9899995f, 0);
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            isGrounded = true;
        }
    }
}
