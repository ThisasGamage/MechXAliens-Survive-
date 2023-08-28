using System.Collections;
using System.Collections.Generic;
using System.Runtime.Serialization;
using UnityEngine;

public class CharacterStats : MonoBehaviour
{
    [SerializeField] protected int initialHealth = 0;
    [SerializeField] protected int initialMaxHealth = 0;

    [SerializeField] protected int health;
    [SerializeField] protected int maxHealth;

    [SerializeField] protected bool isDead;

    private void Start()
    { 
        InitVariable();
    }

    public virtual void CheckHealth()
    {
        if (health <= 0)
        {
            health = 0;
            Die();
        }
        if (health >= maxHealth)
        {
            health = maxHealth;
        }
    }

    public virtual void Die()
    {
        isDead = true;
    }

    public bool IsDead()
    {
        return isDead;
    }

    public void SetHealthTo(int healthToSetTo)
    {
        health = healthToSetTo;
        CheckHealth();
    }

    public void TakeDamage(int damage)
    {
        int healthAfterDamage = health - damage;
        SetHealthTo(healthAfterDamage);
    }

    public void Heal(int heal)
    { 
        int healthAfterDamage = health + heal;
        SetHealthTo(healthAfterDamage);
    }

    public int GetMaxHealth()
    {
        return maxHealth;   
    }

    public virtual void InitVariable()
    {
        maxHealth = initialMaxHealth;
        SetHealthTo(initialHealth);
        isDead = false;
    }
}