using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class GuardMovement : MonoBehaviour
{
    private GameObject Player;

    private NavMeshAgent _agent;
    private PlayerDetectionConeVision _playerDetection;

    [SerializeField] private Transform[] wayPoints;
    private int _currentDestinationPoint; // index for destination 

    [SerializeField] private float _patrolSpeed = 1.5f;
    [SerializeField] private float _chaseSpeed = 2.25f;
    [SerializeField] private float _wpStoppingDistance = 2f;
    private const float _playerAttackRange = 1.5f;

    private void Awake()
    {
        _agent = this.GetComponent<NavMeshAgent>();
        _playerDetection = GetComponentInChildren<PlayerDetectionConeVision>();
        Player = GameObject.FindGameObjectWithTag("Player");
    }

    // ----------------------------------- PATROLLING -----------------------------------

    public void StartPatrolling()
    {
        _agent.isStopped = false;
        GoToNextWayPoint();
    }

    private void GoToNextWayPoint()
    {
        if (wayPoints.Length == 0)
            return;

        _currentDestinationPoint = UnityEngine.Random.Range(0, wayPoints.Length);

        _agent.SetDestination(wayPoints[_currentDestinationPoint].position);
        _agent.speed = _patrolSpeed;
    }

    // Checks if Destination reached within range 
    public bool ReachedDestination()
    {
        if (_agent.remainingDistance <= _wpStoppingDistance)
        {
            return true;
        }
        else
            return false;
    }

    // ----------------------------------- CHASING -----------------------------------

    public bool ChaseTriggered()
    {
        if (_playerDetection.playerDetected)
        {
            return true;
        }
        else
            return false;
    }

    // Chase Player
    public void StartChasing()
    {
        _agent.isStopped = false;
        _agent.SetDestination(Player.transform.position);
        _agent.speed = _chaseSpeed;
    }

    public void UpdatePlayerLocation()
    {
        _agent.SetDestination(Player.transform.position);
    }

    // Checks if Player reached within range 
    public bool ReachedPlayer()
    {
        if (_agent.remainingDistance <= _playerAttackRange)
        {
            _agent.isStopped = true;
            return true;
        }
        else
            return false;
    }
}
