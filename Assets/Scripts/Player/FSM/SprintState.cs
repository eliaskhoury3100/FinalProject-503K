using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SprintState : PlayerBase
{
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        base.OnStateEnter(animator, stateInfo, layerIndex);
    }

    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        CheckForDeathTrigger(animator);

        if (!SprintEnabled() || !Moving())
            animator.SetBool(SPRINT_ANIM_PARAM, false);

        CheckForAttackTrigger(animator);
    }

    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {

    }

}
