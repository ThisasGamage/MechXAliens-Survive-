using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStats : CharacterStats
{
    [SerializeField] private int initMaxHealth = 0;
    [SerializeField] private int initialDamage = 0;
    [SerializeField] private float initialAttackSpeed = 0;
    [SerializeField] private bool initialCanAttack = true;

    [SerializeField] private int damage;
    public float attackSpeed;

    [SerializeField] private bool canAttack;

    private void Start()
    {
        InitVariable();
    }

    public void DealDamage(CharacterStats statsToDamage)
    {
        statsToDamage.TakeDamage(damage);
    }

    public override void Die()
    {
        base.Die();
        PlayerHUD.instance.UpdateScoreAmount();
        Destroy(gameObject);
        
    }

    public override void InitVariable()
    {
        maxHealth = initMaxHealth;
        SetHealthTo(maxHealth);
        isDead = false;

        damage = initialDamage;
        attackSpeed = initialAttackSpeed;
        canAttack = true;
    }
}
