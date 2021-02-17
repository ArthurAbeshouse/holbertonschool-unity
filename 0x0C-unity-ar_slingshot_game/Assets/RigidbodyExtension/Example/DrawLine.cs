using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Dweiss;
using UnityEngine.SceneManagement;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;

[ExecuteInEditMode]
[RequireComponent(typeof(LineRenderer), typeof(Rigidbody))]
public class DrawLine : MonoBehaviour {
    private LineRenderer _lr;
    private Rigidbody _rb;

    public Vector3 mousePressDownPos;
    public Vector3 mouseReleasePos;

   // Scene predictionScene;

  //  PhysicsScene p;

    Vector3 Force;

    Vector3 Velocity;

    public float timeBeteenStep = 1;
    public int stepCount = 30;

    //public float degrees;

    public bool isTouch;
    
    public Vector3 addedV, addedF;

    //Vector3 mp = Launch.mousePressDownPos;

    public KeyCode keyToActivate = KeyCode.Space;

    Camera cam;

    //float timeDelta = 1.0f / (transform.forward.magnitude * 5f);

    void Start() {
        _lr = GetComponent<LineRenderer>();
        _rb = GetComponent<Rigidbody>();
       // p = predictionScene.GetPhysicsScene();
        Debug.Log("Press " + keyToActivate + " to shooot ");
        cam = Camera.main;
    }

    /*private void AddPower()
    {
        Debug.LogWarning("Change V: " + addedV + " F: " + addedF);
        CalcTime();

        _rb.velocity += addedV;


        addedV = Vector3.zero;
        //_rb.AddForce(addedF, ForceMode.Force);
        addedF = Vector3.zero;
    }*/

    /*public void OnMouseDown()
    {
        addedF += Input.mousePosition;
        addedV += transform.forward;
        //DrawMovementLine();
    }

    public void OnMouseUp()
    {
        addedF = new Vector3(0, 0, 0);
        addedV = new Vector3(0, 0, 0);
    }*/


   /* private void CalcTime()
    {
        //float timeDelta = 1.0f / transform.forward.magnitude;
        Vector3[] t = _rb.CalculateTime(new Vector3(0, 0, 0),
            addedV, addedF);

        var timeT = new Vector3[]{
            new Vector3(Time.time + t[0].x, Time.time + t[0].y, Time.time + t[0].z),
            new Vector3(Time.time + t[1].x, Time.time + t[1].y, Time.time + t[1].z)
        };
        Debug.LogWarning(Time.time + ": assuming no drag touch in (0,0,0) occures in those 2 time stamps:  " + timeT[0] + ", " + timeT[1]);
    }*/

    private void DrawMovementLine()
    {

        //var res = _rb.CalculateMovement(stepCount, timeBeteenStep, addedV, addedF);
        var res = _rb.CalculateMovement(stepCount, timeBeteenStep, addedV, addedF);

        float timeDelta = 1.0f / transform.forward.magnitude;

        _lr.positionCount = stepCount + 1;
        _lr.SetPosition(0, transform.position);

        //Vector3 boob = transform.forward;

        //float timeDelta = 1.0f / transform.forward.magnitude;
        //float timeDelta = 1.0f / (transform.forward.magnitude * 5f);
        for (int i = 0; i < res.Length; ++i)
        {
            //Debug.Log(res[i]);
            _lr.SetPosition(i+1, res[i]);
            //p.Simulate(Time.fixedDeltaTime);
            //boob += addedV * timeDelta + 0.5f * Physics.gravity * timeDelta * timeDelta
            //addedV += Physics.gravity * timeDelta;
            //_lr.SetPosition(i+1, res[i] + new Vector3(10, 0, 0));
        }

    }
    public void OnMouseDown()
    {
        isTouch = true;
        mousePressDownPos = Input.mousePosition;
    }

    public void OnMouseUp()
    {
        isTouch = false;
        mouseReleasePos = Input.mousePosition;
    }

    public void OnMouseDrag()
    {
        
    }

    void Update () {
        //addedF = new Vector3(0, Input.mousePosition.y, 0);
        //addedV = new Vector3(Input.mousePosition.x, Input.mousePosition.y, 0);
        //float timeDelta = 1.0f / transform.forward.magnitude;

        //Force = (mouseReleasePos - mousePressDownPos);

        //Velocity = new Vector3(-Input.mousePosition.x / -15f, -Input.mousePosition.y, 0);
        DrawMovementLine();
        if (isTouch)
        {
            //Force = (mouseReleasePos - mousePressDownPos);
            //addedF = cam.ScreenToWorldPoint(Input.mousePosition);
            //addedF = new Vector3(0, -Input.mousePosition.y * 0.03f, 0);
            addedF = -Input.mousePosition * 0.03f;
            //addedV = (((Physics.gravity * timeDelta) * timeDelta + 0.5f * Physics.gravity * timeDelta * timeDelta) * -1f);
            addedV = new Vector3(-Input.mousePosition.x + 320f, -Input.mousePosition.y, -Input.mousePosition.y + 180f) * 0.03f;
            //addedV = new Vector3(Input.mousePosition.x + 320f, Input.mousePosition.y, 0) * 0.03f;
        }
        else
        {
            addedF = new Vector3(0, 0, 0);
            addedV = new Vector3(0, 0, 0);
        }

       // OnMouseDown();

       /* if (Input.GetKeyDown(keyToActivate))
        {
            AddPower();
        }*/
    }
}
