using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStats : CharacterStats
{
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
        maxHealth = 25;
        SetHealthTo(maxHealth);
        isDead = false;

        damage = 10;
        attackSpeed = 1.5f;
        canAttack = true;
    }

    public void IncreaseStats(int waveNumber)
    {
        damage += waveNumber * 5;
        maxHealth += waveNumber * 10;
        SetHealthTo(maxHealth);
    }
}
