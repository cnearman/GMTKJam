using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpState : MovementState {
    public float JumpForce;
    public float floatForce;
    public float chargeTime;
    public float currentChargeTime;
    Rigidbody2D rigidbody;
    public bool held;

	 // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
	override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
        base.OnStateEnter(animator, stateInfo, layerIndex);
        rigidbody = animator.gameObject.GetComponent<Rigidbody2D>();
        rigidbody.AddForce(Vector3.up * JumpForce);
        Debug.Log("Entered Jump State");
        currentChargeTime = 0;
        held = true;
        EventManager.StartListening("Jump_" + PlayerNumber + "Released", StopJump);
        EventManager.StartListening("Attack_" + PlayerNumber + "Pressed", Attack);
    }

	// OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
	override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
        base.OnStateUpdate(animator, stateInfo, layerIndex);
        currentChargeTime += Time.deltaTime;
        if(currentChargeTime < chargeTime)
        {
            if (held)
            {
                rigidbody.AddForce(Vector3.up * floatForce * Time.deltaTime);
            }
        } else
        {
            animator.SetBool("hasJumped", true);
        }

        if(rigidbody.velocity.y < 0)
        {
            animator.SetBool("hasJumped", false);
            animator.SetTrigger("state_falling");
        } else if (rigidbody.velocity.y == 0 && animator.GetBool("isGrounded") && animator.GetBool("hasJumped"))
        {
            animator.SetBool("hasJumped", false);
            animator.SetTrigger("state_Landing");
        }
	}

	// OnStateExit is called when a transition ends and the state machine finishes evaluating this state
	override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
        base.OnStateExit(animator, stateInfo, layerIndex);
        EventManager.StopListening("Jump_" + PlayerNumber + "Released", StopJump);
        EventManager.StopListening("Attack_" + PlayerNumber + "Pressed", Attack);
    }

    void StopJump(EventBody eb)
    {
        held = false;
    }

    private void Attack(EventBody eb)
    {
        localAnimator.SetTrigger("state_AttackWarmUp");
    }

    // OnStateMove is called right after Animator.OnAnimatorMove(). Code that processes and affects root motion should be implemented here
    //override public void OnStateMove(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
    //
    //}

    // OnStateIK is called right after Animator.OnAnimatorIK(). Code that sets up animation IK (inverse kinematics) should be implemented here.
    //override public void OnStateIK(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
    //
    //}
}
