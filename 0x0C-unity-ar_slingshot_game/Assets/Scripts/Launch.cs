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
    public Vector3 mousePressDownPos;
    public Vector3 mouseReleasePos;

    //public static Vector3 mousePosition;

    private Rigidbody rb;

    public bool isShoot;

    public float forceMultiplier;

    public float velocity;

    public float angle;

    public int resolution;

    public float g;

    float radianAngle;

    LineRenderer LineRen;

    void Awake()
    {
        LineRen = GetComponent<LineRenderer>();
        g = Mathf.Abs(Physics.gravity.y);
    }

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        //RenderArc();
        //LineRen = GetComponent<LineRenderer>();
    }

   /* void RenderArc()
    {
        LineRen.SetVertexCount(resolution + 1);
        LineRen.SetPositions(CalculateArcArray());
    }

    Vector3[] CalculateArcArray()
    {
        Vector3[] arcArray = new Vector3[resolution + 1];

        radianAngle = Mathf.Deg2Rad * angle;
        float maxDistance = (velocity * velocity * Mathf.Sin(2 * radianAngle)) / g;

        for (int i = 0; i <= resolution; i += 1)
        {
            float t = (float)i / (float)resolution;
            arcArray[i] = CalculateArPoint(t, maxDistance);
        }

        return arcArray;
    }

    Vector3 CalculateArPoint(float t, float maxDistance)
    {
        float x = t * maxDistance;
        float y = x * Mathf.Tan(radianAngle) - ((g * x * x) / (2 * velocity * velocity * Mathf.Cos(radianAngle) * Mathf.Cos(radianAngle)));
        return new Vector3(x, y);
    } */

    private void OnMouseDown()
    {
        mousePressDownPos = Input.mousePosition;
       // Debug.Log(mousePressDownPos);
        this.gameObject.GetComponent<DrawLine>().enabled = true;
        //DrawMovementLine();
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
        Ammo_spawner.Instance.NewSpawnRequest();
    }

    /* private void DrawMovementLine()
     {
         Debug.Log(LineRen.GetPosition(0));
         LineRen.SetPosition(0, rb);
         //LineRen.SetPosition((int)mouseReleasePos.x, mousePressDownPos);
     }*/
}
