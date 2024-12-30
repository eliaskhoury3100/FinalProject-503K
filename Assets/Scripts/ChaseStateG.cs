using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChaseStateG : GuardBase
{
    //OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        base.OnStateEnter(animator, stateInfo, layerIndex);
        _guardMovement.StartChasing();
    }

    //OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        CheckForDeathTrigger(animator);

        _guardMovement.UpdatePlayerLocation();

        if(_guardMovement.ReachedPlayer())
            animator.SetBool(ATTACK_ANIM_PARAM, true);

        if(!_guardMovement.ChaseTriggered())
            animator.SetBool(CHASE_ANIM_PARAM, false);
    }

    //OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        _agent.isStopped = true;
        animator.SetBool(CHASE_ANIM_PARAM, false);
    }

    
}
