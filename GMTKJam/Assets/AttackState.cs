using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackState : BasePlayerState {
    public float durration;
    float currentDurration;

    public GameObject attackVolume;
    GameObject currentAV;
    public Vector2 attackPosition;
    public Vector2 attackPositionLeft;

    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        base.OnStateEnter(animator, stateInfo, layerIndex);

        currentAV = (GameObject)Instantiate(attackVolume, animator.gameObject.transform.position, Quaternion.identity, animator.gameObject.transform);

        if (localAnimator.GetBool("isFacingLeft"))
        {
            currentAV.transform.localPosition = attackPositionLeft;
            currentAV.SetActive(true);
        } else
        {
            currentAV.transform.localPosition = attackPosition;
            currentAV.SetActive(true);
        }
        currentDurration = 0f;
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        currentDurration += Time.deltaTime;
        if(currentDurration >= durration)
        {
            localAnimator.SetTrigger("state_AttackCooldown");
        }
    }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        base.OnStateExit(animator, stateInfo, layerIndex);
        Destroy(currentAV);
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
