using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

//Rodrigo Lopez-Patino

public class VerticalPlatform : MonoBehaviour
{
    [SerializeField] private GameObject topPoint;
    [SerializeField] private GameObject BottomPoint;
    [SerializeField] protected float movespeed;
    [SerializeField] protected float WaitTime;

    private bool goUp;
    private bool waiting;


    // Start is called before the first frame update
    void Start()
    {
        goUp = true;
        waiting = false;
    }

    // Update is called once per frame
    void Update()
    {
        UpAndDown();
    }

    private void UpAndDown()
    {
        //if goUp is true check if the platform is at a lower level than the top most point
        //if it is then move the platform up
        //if it is at the top most point or higher, the platform stops for a bit then goUp changes to false
        if (goUp)
        {
            if (gameObject.transform.position.y < topPoint.transform.position.y)
            {
                if (!waiting)
                    transform.position += Vector3.up * Time.deltaTime * movespeed;
            }
            else
            {
                StartCoroutine(PlatformPause());
                goUp = false;
            }
        }

        //if goUp is false check to see if the platform is at a higher level than the bottom most point
        //if it is then move the plaform down
        //if the platform reaches or gets lower than the bottom most point, the platform stops for a bit then goUp changes to true
        if(!goUp)
        {
            if(gameObject.transform.position.y > BottomPoint.transform.position.y )
            {
                if(!waiting)
                    transform.position += Vector3.down * Time.deltaTime * movespeed;
            }
            else
            {
                StartCoroutine(PlatformPause());
                goUp = true;
            }    
        }
    }

    private IEnumerator PlatformPause()
    {
        waiting = true;
        yield return new WaitForSeconds(WaitTime);
        waiting = false;
    }
}
