using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InvestigateStateG : GuardBase
{
    private float _idleTime;
    private const float _idleTimeThreshold = 4;

    //OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        base.OnStateEnter(animator, stateInfo, layerIndex);
        _agent.isStopped = true;
        _idleTime = 0;
    }

    //OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (_gameStart)
        {
            _gameStart = false;
            animator.SetBool(PATROL_ANIM_PARAM, true);
        }

        CheckForDeathTrigger(animator);

        if (_guardMovement.ChaseTriggered())
            animator.SetBool(CHASE_ANIM_PARAM, true);

        _idleTime += Time.deltaTime;
        if (_idleTime >= _idleTimeThreshold)
            animator.SetBool(PATROL_ANIM_PARAM, true);

    }

    //OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (animator.GetBool(CHASE_ANIM_PARAM))
            animator.SetBool(PATROL_ANIM_PARAM, false);
    }

}
