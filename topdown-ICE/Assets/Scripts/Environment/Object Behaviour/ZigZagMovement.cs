using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZigZagMovement : MonoBehaviour
{
    private float  _frequency = 1.0f;
    private float _amplitude = 3.0f;
    private float _cyclespeed =  1.0f;

    private  Vector3 axis;
    private Vector3 pos;
    // Start is called before the first frame update
    void Start()
    {
        pos = transform.position;
        axis = transform.right;
    }

    internal void Movement()
    {
        pos += Vector3.down * Time.deltaTime * _cyclespeed;
        transform.position = pos  + axis * Mathf.Sin(Time.time* _frequency) * _amplitude;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
