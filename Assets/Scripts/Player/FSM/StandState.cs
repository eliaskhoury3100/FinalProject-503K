using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StandState : PlayerBase
{    

    //OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        base.OnStateEnter(animator, stateInfo, layerIndex);
    }

    //OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        CheckForDeathTrigger(animator);

        CheckForAttackTrigger(animator);

        CheckForMovementState(animator);
    }

    //OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {

    }

    private void CheckForMovementState(Animator animator)
    {
        if (Moving())
        {
            if (MovingForward())
                animator.SetBool(WALKFORWARD_ANIM_PARAM, true);
            else
                animator.SetBool(WALKBACKWARD_ANIM_PARAM, true);
        }
    }

}
