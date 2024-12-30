using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackStateG : GuardBase
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

        _guardCombatSystem.FacePlayer();

        if (!_guardCombatSystem.PlayerWithinAttackRange() || !_guardMovement.ChaseTriggered())
            animator.SetBool(ATTACK_ANIM_PARAM, false);

        if (_playerCombatSytem.AttackOngoing())
            animator.SetTrigger(SHIELD_ANIM_TRIGGER);
    }

    //OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        
    }

}
