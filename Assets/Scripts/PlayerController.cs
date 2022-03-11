using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PlayerController : MonoBehaviour
{
    public int speed=5;
    public int rlspeed=3;

    // Start is called before the first frame update
    void Start()
    {

    }
    // Update is called once per frame
    void FixedUpdate()
    {   
        if( Input.GetKey("w"))
        {
            transform.Translate(Vector3.forward *speed* Time.deltaTime);
        }
        if( Input.GetKey("s"))
        {
            transform.Translate(-Vector3.forward *speed* Time.deltaTime);
        }   
        if( Input.GetKey("a"))
        {
            transform.Translate(Vector3.left *rlspeed* Time.deltaTime);
        }
        if( Input.GetKey("d"))
        {
            transform.Translate(Vector3.right *rlspeed* Time.deltaTime); 
        } 
    }
    
    
}
