using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 5f;
    public Rigidbody pb;

    private Vector3 moveIn;
    private Vector3 moveVel;

    private Camera topCamera;

    //DashFunction
    public float dashDistance = 10f;

    public const float maxDashTime = 1.0f;
    public float DashSpeed = 6;

    void Start()
    {
        pb = GetComponent<Rigidbody>();
        topCamera = FindObjectOfType<Camera>();
    }

    // Update is called once per frame
    void Update()
    {
        moveIn = new Vector3(Input.GetAxisRaw("Horizontal"), 0f, Input.GetAxisRaw("Vertical"));
        moveVel = moveIn * speed;

        //Look at mouse
        Ray cameraRay = topCamera.ScreenPointToRay(Input.mousePosition);
        Plane ground = new Plane(Vector3.up, Vector3.zero);
        
        // how far from the camera to the gorund
        float rayLength;
        if(ground.Raycast(cameraRay, out rayLength))
        {
            Vector3 lookPoint = cameraRay.GetPoint(rayLength);
            //Testing
            //Debug.DrawLine(cameraRay.origin, lookPoint, Color.red);

            transform.LookAt(new Vector3(lookPoint.x, transform.position.y, lookPoint.z)) ;
        }

    }

    void FixedUpdate()
    {
        pb.velocity = moveVel;
    }

    void Dash()
    {

    }


}
