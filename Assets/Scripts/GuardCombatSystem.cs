using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GuardCombatSystem : MonoBehaviour
{

    private Transform _playerTransform;
    private PlayerHealthSystem _playerHealthSystem;

    private const float _attackRange = 2f;
    [SerializeField] private float _damageAmount = 20f;

    private void Awake()
    {
        _playerTransform = GameObject.FindGameObjectWithTag("Player").transform;
        _playerHealthSystem = GameObject.FindGameObjectWithTag("Player").GetComponentInChildren<PlayerHealthSystem>();
    }


    public void FacePlayer()
    {
        this.transform.LookAt(_playerTransform.position);
    }

    public bool PlayerWithinAttackRange()
    {
        if (Vector3.Distance(this.transform.position, _playerTransform.position) <= _attackRange)
            return true;
        else
            return false;
    }

    // triggered via Animation Event
    public void Attack()
    {
        _playerHealthSystem.TakeDamage(_damageAmount);
        Debug.Log("GOTCHA WITH " + _damageAmount + " DAMAGE, OLIVIA!");
    }
}
