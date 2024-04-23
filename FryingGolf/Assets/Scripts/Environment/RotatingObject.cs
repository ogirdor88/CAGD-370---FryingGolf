using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotatingObject : MonoBehaviour
{
    [SerializeField] private bool spinClockwise;
    [SerializeField] private float spinSpeed;


    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Clockwise();
        CounterClockwise();
    }

    private void Clockwise()
    {
        if (spinClockwise) 
        {
            transform.Rotate(Vector3.up * Time.deltaTime * spinSpeed);
        }
    }
    
    private void CounterClockwise()
    {
        if (!spinClockwise) 
        {
            transform.Rotate(Vector3.down * Time.deltaTime * spinSpeed);
        }
    }
}
