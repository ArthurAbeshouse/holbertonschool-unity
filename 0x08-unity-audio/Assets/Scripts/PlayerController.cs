using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class PlayerController : MonoBehaviour
{
    public float velocity;
    public bool isGrounded = true;
    //public bool isMoving;
    public bool onGrass = true;
    public bool onRock;
    public bool wasGrounded;

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

    AudioSource Player_sounds;

    [SerializeField]
    AudioClip[] Player_snds_lib;

    public AudioMixer AudioMixer;
    public AudioMixerGroup AMGroup;
    public AudioMixerGroup AMGroup2;

    // Start is called before the first frame update
    void Start()
    {
        rbdy = GetComponent<Rigidbody>();
        animator = GetComponentInChildren<Animator>();
        Player_sounds = GetComponent<AudioSource>();
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
            //isMoving = true;
            if (isGrounded)
            {
                animator.SetBool("IsJumping", false);
                WalkSFX();
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

    void WalkSFX()
    {
        if (!Player_sounds.isPlaying)
        {
            Player_sounds.outputAudioMixerGroup = AMGroup;
            if (onGrass)
            {
                Player_sounds.clip = Player_snds_lib[0];
            }
            else if (onRock)
            {
                Player_sounds.clip = Player_snds_lib[1];
            }
            Player_sounds.Play();
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            isGrounded = false;
            onGrass = false;
            onRock = false;
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
            onGrass = false;
            onRock = false;
            
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
        if (!wasGrounded && isGrounded)
        {
            LandSFX();
        }
        wasGrounded = isGrounded;
    }

    void LandSFX()
    {
        if (!Player_sounds.isPlaying)
        {
            Player_sounds.outputAudioMixerGroup = AMGroup2;
            if (onGrass)
            {
                Player_sounds.clip = Player_snds_lib[2];
            }
            else if (onRock)
            {
                Player_sounds.clip = Player_snds_lib[3];
            }
            Player_sounds.Play();
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

        if (collision.gameObject.layer == 9)
        {
            onGrass = true;
        }

        if (collision.gameObject.layer == 10)
        {
            onRock = true;
        }
    }
}
