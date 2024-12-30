using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealthSystem : MonoBehaviour
{

    [SerializeField] private float maxHealth = 100;
    [SerializeField] private float currentHealth;

    private PlayerMovement _playerMovement;

    //public HealthBar healthBar;

    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;

        _playerMovement = this.gameObject.transform.parent.gameObject.GetComponent<PlayerMovement>();
    }

    public void TakeDamage(float damage)
    {
        currentHealth -= damage;
        //healthBar.SetMaxHealth(maxHealth);

        CheckForDeath();

    }

    public void Heal(float regen)
    {
        currentHealth += regen;
        if (currentHealth > maxHealth)
            currentHealth = maxHealth;
        // healthBar.SetHealth(currentHealth);
    }



    public bool CheckForDeath()
    {
        if (currentHealth <= 0)
        {
            _playerMovement.enabled = false;
            this.enabled = false;
            return true;
        }
        return false;

    }
}
