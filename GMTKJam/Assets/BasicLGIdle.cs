using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicLGIdle : MovementState {
    Rigidbody2D rb;

	//  OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
	override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
        base.OnStateEnter(animator, stateInfo, layerIndex);
        Debug.Log("Entered Idle State.");
        EventManager.StartListening("Jump_" + PlayerNumber + "Pressed", Jump);
        localAnimator = animator;
	}

	// OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
        base.OnStateUpdate(animator, stateInfo, layerIndex);
        if (animator.GetFloat("velocity_x") != 0)
        {
            animator.SetTrigger("state_Walking");
        }
	}

	// OnStateExit is called when a transition ends and the state machine finishes evaluating this state
	override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
        base.OnStateExit(animator, stateInfo, layerIndex);
        EventManager.StopListening("Jump_" + PlayerNumber + "Pressed", Jump);
    }

    private void Jump(EventBody eb)
    {
        Debug.Log("Jump Event processed by BasicLGIdle.");
        localAnimator.SetTrigger("state_JumpWarmUp");
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
