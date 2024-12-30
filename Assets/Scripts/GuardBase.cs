using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class GuardBase : StateMachineBehaviour
{
    private GameObject Guard;

    protected GuardHealthSystem _guardHealthSystem;
    protected GuardCombatSystem _guardCombatSystem;
    protected GuardMovement _guardMovement;
    protected NavMeshAgent _agent;

    private GameObject Player;

    protected PlayerCombatSystem _playerCombatSytem;

    // STRING ANIMATOR PARAMETERS
    protected const string INVESTIGATE_ANIM_PARAM = "isInvestigating";
    protected const string PATROL_ANIM_PARAM = "isPatrolling";
    protected const string CHASE_ANIM_PARAM = "isChasing";
    protected const string SHIELD_ANIM_TRIGGER = "isShielding";
    protected const string ATTACK_ANIM_PARAM = "isAttacking";
    protected const string DIE_ANIM_TRIGGER = "isDead";

    protected bool _gameStart = true;

    //OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        Guard = animator.gameObject;

        _guardHealthSystem = Guard.GetComponent<GuardHealthSystem>();
        _guardCombatSystem = Guard.GetComponent<GuardCombatSystem>();
        _guardMovement = Guard.GetComponent<GuardMovement>();
        _agent = Guard.GetComponent<NavMeshAgent>();

        Player = GameObject.FindGameObjectWithTag("Player");

        _playerCombatSytem = Player.GetComponentInChildren<PlayerCombatSystem>();
    }

    protected void CheckForDeathTrigger(Animator animator)
    {
        if (_guardHealthSystem.CheckForDeath())
            animator.SetTrigger(DIE_ANIM_TRIGGER);
    }
}
