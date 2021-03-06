﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementState : BasePlayerState {
    Rigidbody2D rb;
    float accelerationX = 50;
    float maxSpeedX = 5;
    SpriteRenderer rend;

	 // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
	override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
        base.OnStateEnter(animator, stateInfo, layerIndex);
        rb = animator.gameObject.GetComponent<Rigidbody2D>();
        maxSpeedX = animator.gameObject.GetComponent<LittleGuy>().Statistics.GetAttribute(AttributeTypes.Speed).CurrentValue;
        EventManager.StartListening("Move_" + PlayerNumber, Move);
        rend = animator.gameObject.GetComponent<SpriteRenderer>();
    }

	// OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
	override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
        if(rb == null)
        {
            rb = animator.gameObject.GetComponent<Rigidbody2D>();
        }
        animator.SetFloat("velocity_x", rb.velocity.x); 
        if (rb.velocity.x == 0)
        {
            animator.SetTrigger("state_Idle");
        }
	}

	// OnStateExit is called when a transition ends and the state machine finishes evaluating this state
	override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
        base.OnStateExit(animator, stateInfo, layerIndex);
        EventManager.StopListening("Move_" + PlayerNumber, Move);
    }

	// OnStateMove is called right after Animator.OnAnimatorMove(). Code that processes and affects root motion should be implemented here
	//override public void OnStateMove(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
	//
	//}

	// OnStateIK is called right after Animator.OnAnimatorIK(). Code that sets up animation IK (inverse kinematics) should be implemented here.
	//override public void OnStateIK(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
	//
	//}

    private void Move(EventBody eb)
    {
        var xInput = ((AxisEB)eb).value;
        if (xInput < 0)
        {
            float targetSpeed = maxSpeedX * xInput;
            if (rb.velocity.x > targetSpeed)
            {
                rb.AddForce(Vector2.left * accelerationX);
            }

            localAnimator.SetBool("isFacingLeft", true);
            rend.flipX = true;
            //rb.AddForce(Vector2.left * 6);
        }
        else if (xInput > 0)
        {
            float targetSpeed = maxSpeedX * xInput;
            if (rb.velocity.x < targetSpeed)
            {
                rb.AddForce(Vector2.right * accelerationX);
            }

            localAnimator.SetBool("isFacingLeft", false);
            rend.flipX = false;
            //rb.AddForce(Vector2.right * 6);
        } // If 0 Then face same direction

    }
}
