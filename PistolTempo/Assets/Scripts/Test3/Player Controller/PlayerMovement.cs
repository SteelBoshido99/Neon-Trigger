using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 5f;
    public Rigidbody playerBody;

    private Vector3 moveIn;
    private Vector3 moveVel;

    private Camera topCamera;

    //DashFunction
    public float DashTime;
    public float DashSpeed;

    public CharacterController pController;

    void Start()
    {
        playerBody = GetComponent<Rigidbody>();
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

        if(Input.GetKeyDown(KeyCode.LeftShift)){
            StartCoroutine(Dash());
        }

    }

    void FixedUpdate()
    {
        playerBody.velocity = moveVel;
    }

    IEnumerator Dash()
    {
        float startTime = Time.time;

        while(Time.time< startTime + DashTime)
        {
            pController.Move(moveIn * DashSpeed * Time.deltaTime);

            yield return null;
        }

    }


}
