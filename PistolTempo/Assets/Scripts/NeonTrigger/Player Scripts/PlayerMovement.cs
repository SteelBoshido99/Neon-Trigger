using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float speed = 5f;
    [SerializeField] private Rigidbody playerBody;

    private Vector3 moveIn;
    private Vector3 moveVel;
    private Camera topCamera;

    //DashFunction
    [SerializeField] private float DashTime;
    [SerializeField] private float DashSpeed;
    [SerializeField] private CharacterController pController;    

    public float getSpeed()
    {
        return speed;
    }
    public void setSpeed(float nSpeed)
    {
        speed = nSpeed;
    }

    void Start()
    {
        playerBody = GetComponent<Rigidbody>();
        topCamera = FindObjectOfType<Camera>();
    }

    // Update is called once per frame
    void Update()
    {
        //Uses the input presets in unity
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
