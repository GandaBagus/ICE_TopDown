using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Moveable))]

public class MoveForward : MonoBehaviour
{

    private Moveable moveable;

    private ZigZagMovement zigzag;

    private void Awake() 
    {
        moveable = GetComponent<Moveable>();
        zigzag = GetComponent<ZigZagMovement>();  
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        moveable.setDirection(transform.up);
        zigzag.Movement();
    }
}
