using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;

[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(Collider))]
public class Launch : MonoBehaviour
{
    private Vector3 mousePressDownPos;
    private Vector3 mouseReleasePos;

    //public static Vector3 porsh;

    //public static Vector3 mousePosition;

    private Rigidbody rb;

    public bool isShoot;

    public bool isTouch;

    public float forceMultiplier;

    private LineRenderer LineRen;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        LineRen = GetComponent<LineRenderer>();
    }

    private void OnMouseDown()
    {
        mousePressDownPos = Input.mousePosition;
        LineRen.enabled = true;
        /*if (isTouch)
            return;

        if (!isShoot && Input.touchCount > 0)
        {
            isTouch = true;
            if (isTouch)
            {
                mousePressDownPos = Input.mousePosition;
                //this.gameObject.GetComponent<DrawLine>().enabled = true;
                porsh = mousePressDownPos;
            }
        }*/
       // Debug.Log(mousePressDownPos);
        //this.gameObject.GetComponent<DrawLine>().enabled = true;
        //DrawMovementLine();
    }

    public void FixedUpdate()
    {
        UpdateTrajectory(transform.position, transform.forward, Input.mousePosition);
        //OnMouseDown();
    } 

    private void OnMouseUp()
    {
        mouseReleasePos = Input.mousePosition;
       //Debug.Log(mouseReleasePos);
        Shoot(mouseReleasePos - mousePressDownPos);
    }

    void Shoot(Vector3 Force)
    {
        if (isShoot)
            return;

        rb.isKinematic = false;

        rb.AddForce(new Vector3(Force.x, Force.y, Force.y) * forceMultiplier);
        //rb.velocity = new Vector3(Force.x, Force.y, Force.y) * forceMultiplier;
        isShoot = true;
        if (isShoot)
            LineRen.enabled = false;
        Ammo_spawner.Instance.NewSpawnRequest();
    }

    void UpdateTrajectory(Vector3 initialPosition, Vector3 initialVelocity, Vector3 gravity)
    {
        int numSteps = 20; // for example
        float timeDelta = 1.0f / initialVelocity.magnitude; // for example
    
        LineRenderer lineRenderer = GetComponent<LineRenderer>();
        lineRenderer.SetVertexCount(numSteps);
    
        Vector3 position = initialPosition;
        Vector3 velocity = initialVelocity;
        for (int i = 0; i < numSteps; ++i)
        {
            lineRenderer.SetPosition(i, position);
    
            position += velocity * timeDelta + 0.5f * gravity * timeDelta * timeDelta;
            velocity += gravity * timeDelta;
        }
    }

    /* private void DrawMovementLine()
     {
         Debug.Log(LineRen.GetPosition(0));
         LineRen.SetPosition(0, rb);
         //LineRen.SetPosition((int)mouseReleasePos.x, mousePressDownPos);
     }*/
}
