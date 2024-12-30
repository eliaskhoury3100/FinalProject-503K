using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class GuardHealthSystem : MonoBehaviour
{
    [SerializeField] private float maxHealth = 100;
    [SerializeField] private float currentHealth;

    private NavMeshAgent _agent;

    private const float _countdownTillDestroyed = 5f;

    //public HealthBar healthBar;

    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;

        _agent = this.GetComponent<NavMeshAgent>();
    }

    public void TakeDamage(float damage)
    {
        currentHealth -= damage;
        //healthBar.SetMaxHealth(maxHealth);

        CheckForDeath();

    }


    public bool CheckForDeath()
    {
        if (currentHealth <= 0)
        {
            _agent.enabled = false;
            Destroy(this.gameObject, _countdownTillDestroyed);
            return true;
        }
        return false;

    }
}
