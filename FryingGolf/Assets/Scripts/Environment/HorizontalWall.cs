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
        LeftAndRight();
    }

    private void LeftAndRight()
    {
        //get the position of the obstical
        Vector3 currPos = transform.position;

        //if the obstical is moving left and is on the right side of the left most point move it left
        if(goLeft && currPos.x > LeftPoint.transform.position.x)
        {
            currPos += Vector3.left * movespeed * Time.deltaTime;
            transform.position = currPos;
            //if the obstical reaches the left most point stop going left 
            if (currPos.x <= LeftPoint.transform.position.x)
            {
                goLeft = false;
            }
        }

        //if the obstical is not going left and is on the left side of the right most point move it right
        if(!goLeft && currPos.x < RightPoint.transform.position.x)
        {
            currPos += Vector3.right * movespeed * Time.deltaTime;
            transform.position = currPos;
            //if the obstical reaches the right most point change it to go left;
            if (currPos.x >= RightPoint.transform.position.x)
            {
                goLeft = true;
            }
        }

    }

}
