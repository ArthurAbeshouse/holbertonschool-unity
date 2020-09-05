using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Improved_Jump : MonoBehaviour
{
    public float fallMultiplier = 2.5f;
    public float lowJumpMultiplier = 2f;
    public float gravityScale = 1f;
    private float globalGravity = -9.81f;

    Rigidbody rbdy;

    void Awake()
    {
        rbdy = GetComponent<Rigidbody>();
        rbdy.useGravity = false;
    }

    void Update()
    {
        Vector3 gravity = globalGravity * gravityScale * Vector3.up;
        if (rbdy.velocity.y < 0)
        {
            rbdy.AddForce(gravity * fallMultiplier, ForceMode.Acceleration);
        }
        else if (rbdy.velocity.y > 0 && !Input.GetButton("Jump"))
        {
            rbdy.AddForce(gravity * lowJumpMultiplier, ForceMode.Acceleration);
        }
        else
        {
            rbdy.AddForce(gravity, ForceMode.Acceleration);
        }
    }
}