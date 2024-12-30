using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBase : StateMachineBehaviour
{

    protected GameObject characterGraphics;
    protected GameObject ThirdPersonPlayer;
    protected PlayerMovement _playerMovement;
    private PlayerHealthSystem _playerHealthSystem;

    // STRING ANIMATOR PARAMETERS
    protected string WALKFORWARD_ANIM_PARAM = "isWalkingForward";
    protected string WALKBACKWARD_ANIM_PARAM = "isWalkingBackward";
    protected string SPRINT_ANIM_PARAM = "isSprinting";
    protected string ATTACK_ANIM_TRIGGER = "isAttacking";
    protected string DIE_ANIM_TRIGGER = "isDead";

    //OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        characterGraphics = animator.gameObject; 
        ThirdPersonPlayer = characterGraphics.transform.parent.gameObject; // parent contains scripts

        _playerMovement = ThirdPersonPlayer.GetComponent<PlayerMovement>();
        _playerHealthSystem = characterGraphics.GetComponent<PlayerHealthSystem>();
    } 

    protected bool Moving()
    {
        if (Input.GetAxis("Vertical") != 0)
            return true;
        else
            return false;
    }

    protected bool MovingForward()
    {
        if (Input.GetAxis("Vertical") > 0)
            return true;
        else
            return false;
    }

    protected bool SprintEnabled()
    {
        if (Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.RightShift))
            return true;
        else
            return false;
    }

    // attack is triggered using space bar press once
    protected void CheckForAttackTrigger(Animator animator)
    {
        if (Input.GetKeyDown(KeyCode.Space))
            animator.SetTrigger(ATTACK_ANIM_TRIGGER);
    }

    protected void CheckForDeathTrigger(Animator animator)
    {
        if (_playerHealthSystem.CheckForDeath())
            animator.SetTrigger(DIE_ANIM_TRIGGER);
    }
}
