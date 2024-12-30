using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCombatSystem : MonoBehaviour
{

    GameObject[] Guards;

    private Transform _closestGuardTransform;
    private GuardHealthSystem _closestGuardHealthSystem;
    private GameObject ClosestGuard;
    private float _closestDistance;
    private float _distanceToPlayer;

    [SerializeField] private float _attackDamage = 20f;
    private const float _attackRange = 3f;

    private bool _attackOngoing = false;

    private void Awake()
    {
        Guards = GameObject.FindGameObjectsWithTag("Guard"); // initialize array of all Guard gameObjects
    }

    private void Start()
    {
        InvokeRepeating("ResetAttackOngoingBool", 0f, 0.2f);
    }

    private GameObject GetClosestGuard()
    {
        _closestDistance = Mathf.Infinity; // initialize to infinity for accurate comparisons
        ClosestGuard = null;
        foreach (GameObject guard in Guards)
        {
            _distanceToPlayer = Vector3.Distance(this.transform.position, guard.transform.position);
            if (_distanceToPlayer < _closestDistance)
            {
                _closestDistance = _distanceToPlayer;
                ClosestGuard = guard;
            }
        }
        return ClosestGuard;
    }

    // triggered via Animation Event
    public void FindClosestGuardComponentsToAttack()
    {
        Debug.Log("FindClosestGuardComponentsToAttack method launched!");
        ClosestGuard = GetClosestGuard();
        _closestGuardTransform = ClosestGuard.transform;
        _closestGuardHealthSystem = ClosestGuard.GetComponent<GuardHealthSystem>();
        _attackOngoing = true;
        Debug.Log("_attackOngoing bool should be true now");
    }


    // triggered via Animation Event
    public void Attack()
    {
        Debug.Log("Attack method launched!");
        if (Vector3.Distance(this.transform.position, _closestGuardTransform.position) <= _attackRange)
        {
            this.transform.LookAt(_closestGuardTransform);
            _closestGuardHealthSystem.TakeDamage(_attackDamage);
        }
    }

    // triggered via Animation Event
    public bool AttackOngoing()
    {
        if (_attackOngoing)
            return true;
        else
            return false;
    }

    private void ResetAttackOngoingBool()
    {
        _attackOngoing = false;
        Debug.Log("_attackOnGoing bool should false now");
    }
}
