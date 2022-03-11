using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationControler : MonoBehaviour
{
    
    public enum animationsStates {idle,run,backrun,jump,runjump};
    public animationsStates myState;

    Animator playerAnimator;
    // Start is called before the first frame update
    void Start()
    {
        playerAnimator=GetComponent<Animator>();
    }
    // Update is called once per frame
    void FixedUpdate()
    {   
        if( Input.GetKey("w"))
        {
            if(myState!=animationsStates.run)
            {
                myState=animationsStates.run; 
                playerAnimator.SetTrigger("run");
            }
        }
        else if( Input.GetKey("space"))
        {
            if(myState!=animationsStates.jump)
            {
                myState=animationsStates.jump;
                playerAnimator.SetTrigger("jump"); 
            }
        }
        else if( Input.GetKey("s"))
        {
            if(myState!=animationsStates.backrun)
            {
                myState=animationsStates.backrun;
                playerAnimator.SetTrigger("backrun");
            }
        }
        else
        {
            if(myState!=animationsStates.idle)
            {
                myState=animationsStates.idle;
                playerAnimator.SetTrigger("idle");
            }
        }    
        if( Input.GetKey("a"))
        {
            return;
        }
        if( Input.GetKey("d"))
        {
            return;
        }   
    }
    
    
}
