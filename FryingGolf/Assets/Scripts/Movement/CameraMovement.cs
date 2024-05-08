using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Unity.Mathematics;
using UnityEngine;
using static UnityEngine.InputSystem.InputAction;

public class CameraMovement : MonoBehaviour
{
    //target is the golf ball
    [SerializeField]
    private Transform target;

    //variables for moveing the camera
    private PlayerControlls input;
    [SerializeField] private float movespeed;
    //private Vector3 currentPosition;

    //offset is the distance between the camera and the folg ball
    private Vector3 offset;

    [SerializeField]
    private float rotateSpeed;

    [SerializeField]
    private float heightSpeed;

    [SerializeField]
    private Camera followCam;

    public Camera mapCam;

    private void Awake()
    {
        //get the offset from the camera and the ball
        offset = target.position - transform.position;

        input = new PlayerControlls();
        input.CameraMove.Enable();

        followCam.enabled = true;
        mapCam.enabled = false;
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
        /*
         * first attempt at having the camera rotate with the mouse movement
         * {
            //get the x position of the mouse and rotate the golf ball
            float horizontal = Input.GetAxis("Mouse X") * rotateSpeed;
            target.Rotate(0, horizontal, 0);

            float vertical = Input.GetAxis("Mouse Y") * rotateSpeed;
            target.Rotate(vertical, 0, 0);

            //move the camer based on the current rotation of the target and the original offset
            float desiredYAngle = target.eulerAngles.y;

            float desiredXAngle = target.eulerAngles.x;

            Quaternion rotation = Quaternion.Euler(desiredXAngle, desiredYAngle, 0);

            transform.position = target.position - (rotation * offset);
        }*/

        //move the camera to follow the player with the offset
        transform.position = target.position - offset;
        //make the camera look at the player
        transform.LookAt(target);


        if (target.GetComponent<LineForce>()._isIdle == true)
        {
            MoveCam();
        }

        if (input.CameraMove.changeCam.triggered)
            SwitchCam();
    }

    public void MoveCam()
    {
        //rotate the camera with buttons
        float rotationDirection = input.CameraMove.move.ReadValue<float>();
        //Debug.Log(rotationDirection);

        float changeHeight = input.CameraMove.ChangeHeight.ReadValue<float>();

        transform.RotateAround(target.transform.position, new Vector3(0, 1, 0), rotationDirection * Time.deltaTime * rotateSpeed);

        if(transform.position.y >= target.transform.position.y)
            transform.position += new Vector3(0, changeHeight, 0) * Time.deltaTime * heightSpeed;

        if (transform.position.y < target.transform.position.y)
            transform.position += Vector3.up;


            offset = target.position - transform.position;
    }

    private void SwitchCam()
    {
        mapCam.enabled = !mapCam.enabled;
        followCam.enabled = !followCam.enabled; 
    }
}
