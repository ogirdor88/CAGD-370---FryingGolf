using System.Collections;
using System.Collections.Generic;
using System.Net.Security;
using Unity.VisualScripting;
using UnityEngine;

public class LineForce : MonoBehaviour
{
    public LineRenderer lineRenderer;
    [SerializeField] private float stopVelocity = .05f;
    [SerializeField] private float shotPower;
    //PowerLimit removed due to incorrect snapping
    public float PowerLimit;
    public GameObject SpawnPoint;

    //Updating strokeCount in function Shootball to be used in UIManager script.
    public int strokeCount;

    public bool _isIdle;
    private bool _isAiming;
    private Color _color;

    private bool _isWaterColliding;
    private float oriShotPower;
    private float oriDrag;

    private Rigidbody _rigidbody;

    private Vector3 initialVelocity;
    private Vector3 lastFrameVelocity;
    [SerializeField] private float minVelocity = 1f;

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
        if (_rigidbody.velocity.magnitude < stopVelocity)
        {
            StopBall();
        }
        Aiming();
        lastFrameVelocity = _rigidbody.velocity;
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Water")
        {
            _isWaterColliding = true;
        }

        if (other.gameObject.tag == "Sand")
        {
            oriShotPower = shotPower;
            shotPower = shotPower / 3;
            oriDrag = this.gameObject.GetComponent<Rigidbody>().drag;
            this.gameObject.GetComponent<Rigidbody>().drag = 1.5f;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        //if (other.gameObject.tag == "Water")
        //Debug.Log("Oiuk");
        if (other.gameObject.tag == "Water" && _isIdle)
        {
            _isWaterColliding = false;
            //new Vector3 that holds the location of the oldSpawn point
            //new Vector3 oldSpawn = ;
        }

        if (other.gameObject.tag == "Sand")
        {
            shotPower = oriShotPower;
            this.gameObject.GetComponent<Rigidbody>().drag = oriDrag;
        }
    }

    public void StopBall()
    {
        //set the velocity of the ball to 0
        _rigidbody.velocity = new Vector3(0f, _rigidbody.velocity.y, 0f);
        _rigidbody.angularVelocity = new Vector3(0f, _rigidbody.velocity.y, 0f);
        this.GetComponent<Renderer>().material.color = Color.green;

        //the ball is idle
        _isIdle = true;

        //Debug.Log("STOPPED");
        if (_isWaterColliding != true)
        {
            SpawnPoint.transform.position = this.transform.position;
        }
    }


    private void OnMouseDown()
    {
        //if the ball is idle while we click the mouse button down then set aiming to true
        if (_isIdle)
        {
            _isAiming = true;
        }
    }

    private void Aiming()
    {
        //if we are not aiming or not idle return
        if (!_isAiming || !_isIdle)
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

        if (Input.GetMouseButtonUp(0))
        {
            ShootBall(worldpoint.Value);
        }
    }

    private void ShootBall(Vector3 wp)
    {

        _isAiming = false;
        lineRenderer.enabled = false;
        GetComponent<Renderer>().material.color = _color;

        Vector3 horizontalWorldPoint = new Vector3(wp.x, transform.position.y, wp.z);

        Vector3 direction = -(horizontalWorldPoint - transform.position).normalized;
        float strength = Vector3.Distance(transform.position, horizontalWorldPoint);

        _rigidbody.AddForce(direction * strength * shotPower);
        _isIdle = false;

        strokeCount++;
    }

    private void DrawLine(Vector3 worldpoint)
    {
        Vector3[] positions =
        {
            transform.position,
            new Vector3( worldpoint.x, gameObject.transform.position.y, worldpoint.z)
            //PowerLimit removed due to incorrect snapping
            //Vector3.MoveTowards(transform.position, new Vector3( worldpoint.x, gameObject.transform.position.y, worldpoint.z), PowerLimit)
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
        if (collision.gameObject.tag == "Platform" && _isIdle)
        {
            transform.position = new Vector3(collision.transform.position.x, transform.position.y, collision.transform.position.z);
        }

        if (collision.gameObject.tag == "Momentum")
        {
            _isIdle = false;
            var direction = Vector3.Reflect(lastFrameVelocity.normalized, new Vector3(collision.transform.position.x, collision.transform.position.y, collision.transform.position.z));
            _rigidbody.velocity = direction * Mathf.Max(10f, 10f);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag != "NoBounce")
        {
            Bounce(collision.contacts[0].normal);
        }

        if (collision.gameObject.tag == "Momentum")
        {
            _isIdle = false;
            var direction = Vector3.Reflect(lastFrameVelocity.normalized, new Vector3(collision.transform.position.x, collision.transform.position.y, collision.transform.position.z));
            _rigidbody.velocity = direction * Mathf.Max(10f, 10f);
        }
    }

    private void Bounce(Vector3 collisionNormal)
    {
        //get the speed of the ball then it hits something 
        var speed = lastFrameVelocity.magnitude;
        //reflect the ball off of the object hit
        var direction = Vector3.Reflect(lastFrameVelocity.normalized, collisionNormal);

        //make the ball bounce off the object that was hit.
        _rigidbody.velocity = direction * Mathf.Max(speed, minVelocity);
    }
}
