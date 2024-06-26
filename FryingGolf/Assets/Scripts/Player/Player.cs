using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Unity.VisualScripting;
using UnityEngine;

//Author(s): Jackson, Katherine
//Updated: 04/24/24
//This script handles interactions with other objects and the attached GameObject.

public class Player : MonoBehaviour
{
    public GameObject fryingPan;
    public Transform golfBall;

    //Canvas control
    [SerializeField] private GameObject _playerCharacter;
    [SerializeField] private Canvas _playerCanvas;

    private bool isBallIdle;
    private bool isAiming;

    private Vector3 offset;
    private float _powerLimit;

    [SerializeField] public int eggCount;

    private void Awake()
    {
        isAiming = false;
        isBallIdle = true;
        offset = golfBall.position - fryingPan.transform.position;
    }

    private void Update()
    {
        //gets LineForce _isIdle bool state and sets isBallIdle equal to it
        isBallIdle = golfBall.GetComponent<LineForce>()._isIdle;

        //moves the fryingPan GameObject to the location of the golfBall transform at a distance, an offset
        fryingPan.transform.position = golfBall.position - offset;


        if (isBallIdle == false)
        {
            fryingPan.SetActive(false);
            isAiming = false;
        }
        
        if (isBallIdle == true) 
        {
            if(isAiming == true)
            {
                fryingPan.SetActive(true);
                Vector3? worldpoint = MouseRay();

                if (!worldpoint.HasValue)
                    return;

                panMouseMove(worldpoint.Value);
            }

            fryingPan.transform.LookAt(golfBall.position, Vector3.up);
        }

        if (_playerCharacter.GetComponentInChildren<CameraMovement>().mapCam.enabled == true)
            _playerCanvas.enabled = false;
        else
        {
            _playerCanvas.enabled = true;
        }
    }

    private void OnMouseDown()
    {
        //if the ball is idle while we click the mouse button down then set aiming to true
        if (isBallIdle)
        {
            isAiming = true;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Collectible"))
        {
            eggCount++;
            Destroy(other.gameObject);
        }
    }

    private Vector3? MouseRay()
    {
        Vector3 screenMousPositionFar = new Vector3(Input.mousePosition.x, Input.mousePosition.y, Camera.main.farClipPlane);
        Vector3 screenMousPositionNear = new Vector3(Input.mousePosition.x, Input.mousePosition.y, Camera.main.nearClipPlane);

        Vector3 WorldMousPositionFar = Camera.main.ScreenToWorldPoint(screenMousPositionFar);
        Vector3 WorldMousPositionNear = Camera.main.ScreenToWorldPoint(screenMousPositionNear);

        RaycastHit hit;


        if (Physics.Raycast(WorldMousPositionNear, WorldMousPositionFar - WorldMousPositionNear, out hit, float.PositiveInfinity))
            return hit.point;
        else
            return null;
    }

    private void panMouseMove(Vector3 worldpoint)
    {
        _powerLimit = golfBall.GetComponent<LineForce>().PowerLimit;

        Vector3[] positions =
        {
            transform.position,
            //PowerLimit (Removed from project due to incorrect snapping)
            //Vector3.MoveTowards(transform.position, new Vector3( worldpoint.x, gameObject.transform.position.y, worldpoint.z), _powerLimit)
            new Vector3( worldpoint.x, gameObject.transform.position.y, worldpoint.z)
        };
        fryingPan.transform.position = new Vector3 (worldpoint.x, gameObject.transform.position.y, worldpoint.z);

    }
}