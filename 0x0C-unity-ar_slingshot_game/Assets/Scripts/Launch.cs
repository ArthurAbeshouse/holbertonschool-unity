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

    LineRenderer LineRen;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        LineRen = GetComponent<LineRenderer>();
    }

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

        rb.AddForce(new Vector3(Force.x, Force.y, Force.y) * forceMultiplier);
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
