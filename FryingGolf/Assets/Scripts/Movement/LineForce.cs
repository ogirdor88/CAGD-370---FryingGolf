using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Experimental.AI;

public class LineForce : MonoBehaviour
{

    [SerializeField]private LineRenderer lineRenderer;
    [SerializeField]private float stopVelocity = .05f;
    [SerializeField]private float shotPower;
    [SerializeField]private GameObject SpawnPoint;

    //Updating strokeCount in function Shootball to be used in UIManager script.
    public int strokeCount;

    private bool _isIdle;
    private bool _isAiming;
    private Color _color;

    private Rigidbody _rigidbody;

    private void Awake()
    {
        _color = GetComponent<Renderer>().material.color;
        //set the rigidbody
        _rigidbody = GetComponent<Rigidbody>();

        //set aiming to false and turn off the line render
        _isAiming = false;
        lineRenderer.enabled = false;
        _isIdle = true;
    }

    private void FixedUpdate()
    {
        //if the ball is moving slower that the stopping speed make the ball stop
        if(_rigidbody.velocity.magnitude < stopVelocity)
        {
            StopBall();
        }
        Aiming();
    }

    public void StopBall()
    {
        //set the velocity of the ball to 0
        _rigidbody.velocity = Vector3.zero;
        _rigidbody.angularVelocity = Vector3.zero;
        this.GetComponent<Renderer>().material.color = Color.green;

        //the ball is idle
        _isIdle = true;

        Debug.Log("STOPPED");
        SpawnPoint.transform.position = this.transform.position;    
    }


    private void OnMouseDown()
    {
        //if the ball is idle while we click the mouse button down then set aiming to true
        if(_isIdle)
        {
            _isAiming = true;
        }
    }

    private void Aiming()
    {
        //if we are not aiming or not idle return
        if(!_isAiming || !_isIdle) 
        {
            return;
        }

        //if we are idle draw a line to aim
        Vector3? worldpoint = MouseRay();

        if (!worldpoint.HasValue)
        {
            return;
        }

        DrawLine(worldpoint.Value);

        if(Input.GetMouseButtonUp(0)) 
        {
            ShootBall(worldpoint.Value);
        }
    }

    private void ShootBall(Vector3 wp)
    {
        
        _isAiming = false;
        lineRenderer.enabled=false;
        GetComponent<Renderer>().material.color = _color;

        Vector3 horizontalWorldPoint = new Vector3(wp.x, transform.position.y, wp.z);

        Vector3 direction = -(horizontalWorldPoint - transform.position).normalized;
        float strength = Vector3.Distance(transform.position, horizontalWorldPoint);

        _rigidbody.AddForce( direction *  strength * shotPower);
        _isIdle = false;

        strokeCount++;
    }

    private void DrawLine(Vector3 worldpoint)
    {
        Vector3[] positions =
        {
            transform.position,
            worldpoint
        };
        lineRenderer.SetPositions(positions);
        lineRenderer.enabled = true;

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

    private void OnCollisionStay(Collision collision)
    {
        if(collision.gameObject.tag == "Platform" && _isIdle)
        {
            transform.position = new Vector3(collision.transform.position.x, transform.position.y, collision.transform.position.z);
        }
    }
}
