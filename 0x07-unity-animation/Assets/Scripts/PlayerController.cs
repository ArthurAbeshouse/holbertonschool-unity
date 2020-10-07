using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float velocity;
    public bool isGrounded = true;

    public float turnSmoothTime;
    float turnSmoothVelocity;

    public Transform cam;

    public float falldistance;
    private float jumpfalltrig;

    public float threshold;

    [Range(1, 10)]
    public float jumpSpeed;

    Rigidbody rbdy;

    Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        rbdy = GetComponent<Rigidbody>();
        animator = GetComponentInChildren<Animator>();
    }

    void PlayerMovement(float hori, float verti)
    {
        // makes the player move and adjusts the input direction
        // based on where the camera is pointing
        Vector3 targetDirection = new Vector3(hori, 0f, verti).normalized;
        if (targetDirection.magnitude >= 0.1f)
        {
            animator.SetFloat("IsMoving", targetDirection.magnitude);
            float targetAngle = Mathf.Atan2(targetDirection.x, targetDirection.z) * Mathf.Rad2Deg + cam.eulerAngles.y;
            float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref turnSmoothVelocity, turnSmoothTime);
            transform.rotation = Quaternion.Euler(0f, angle, 0f);
            animator.SetBool("IsRunning", true);
            if (isGrounded)
            {
                animator.SetBool("IsJumping", false);
            }
            Vector3 TurnedInputs = Quaternion.Euler(0, targetAngle, 0) * Vector3.forward;
            rbdy.MovePosition(transform.position + TurnedInputs * velocity * Time.deltaTime);

        }
        else
        {
            animator.SetBool("IsRunning", false);
            animator.SetFloat("IsMoving", 0f);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            isGrounded = false;
            animator.SetBool("IsGrounded", isGrounded);
            if (!isGrounded)
            {
                animator.SetBool("IsJumping", true);
            }
            rbdy.AddForce(Vector3.up * jumpSpeed, ForceMode.Impulse);
            // Measure how far the player has fallen to activate the falling animation
            jumpfalltrig = Time.time + falldistance;
        }
        if (transform.position.y < -2)
        {
            isGrounded = false;
            animator.SetBool("IsGrounded", isGrounded);
        }
        if (!isGrounded)
        {
            if (Time.time > jumpfalltrig)
            {
                animator.SetBool("IsFalling", true);
            }
            else
            {
                animator.SetBool("IsFalling", false);
            }
        }
    }
    void FixedUpdate()
    {
        float hori = Input.GetAxisRaw("Horizontal");
        float verti = Input.GetAxisRaw("Vertical");
        PlayerMovement(hori, verti);
        Respawn();
    }
    void Respawn()
    {
        //animator.SetBool("IsFalling", true);
        if (transform.position.y < threshold)
            transform.position = new Vector3(0, 8.117001f, 0);
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            isGrounded = true;
            animator.SetBool("IsGrounded", isGrounded);
            animator.SetBool("IsJumping", false);
            animator.SetBool("IsFalling", false);
        }
    }
}
