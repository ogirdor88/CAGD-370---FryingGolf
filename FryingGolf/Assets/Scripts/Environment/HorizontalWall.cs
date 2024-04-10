using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HorizontalWall : MonoBehaviour
{
    [SerializeField] private GameObject LeftPoint;
    [SerializeField] private GameObject RightPoint;
    [SerializeField] protected float movespeed;

    private bool goLeft;


    // Start is called before the first frame update
    void Start()
    {
        movespeed = 10f;
        goLeft = true;
    }

    // Update is called once per frame
    void Update()
    {
        //LeftAndRightX();
        MoveBetween();
    }

    /// <summary>
    /// move an object back and forth along the x axis
    /// </summary>
    private void LeftAndRightX()
    {
        //get the position of the obstacle
        Vector3 currPos = transform.position;

        //if the obstacle is moving left and is on the right side of the left most point move it left
        if (goLeft && currPos.x > LeftPoint.transform.position.x)
        {
            currPos += Vector3.left * movespeed * Time.deltaTime;
            transform.position = currPos;
            //if the obstacle reaches the left most point stop going left 
            if (currPos.x <= LeftPoint.transform.position.x)
            {
                goLeft = false;
            }
        }

        //if the obstacle is not going left and is on the left side of the right most point move it right
        if (!goLeft && currPos.x < RightPoint.transform.position.x)
        {
            currPos += Vector3.right * movespeed * Time.deltaTime;
            transform.position = currPos;
            //if the obstacle reaches the right most point change it to go left;
            if (currPos.x >= RightPoint.transform.position.x)
            {
                goLeft = true;
            }
        }

    }

    /// <summary>
    /// move an object between two points no matter the orientation
    /// </summary>
    private void MoveBetween()
    {
        if(goLeft)
        {
            transform.position = Vector3.MoveTowards(transform.position, LeftPoint.transform.position, Time.deltaTime * movespeed);
            if(transform.position == LeftPoint.transform.position)
            {
                goLeft = false;
            }
        }

        if (!goLeft)
        {
            transform.position = Vector3.MoveTowards(transform.position, RightPoint.transform.position, Time.deltaTime * movespeed);
            if (transform.position == RightPoint.transform.position)
            {
                goLeft = true;
            }
        }
    }

}
