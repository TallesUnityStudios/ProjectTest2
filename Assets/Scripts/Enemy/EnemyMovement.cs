using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    [Header("Damage Settings")]
    public int damage = 100;
    public Animator animator;
    public string triggerEnemyAttack = "EnemyAttack";

    [Header("Death Settings")]
    public HealthManager healthManager;
    public string triggerEnemyDeath = "EnemyDeath";

    private void Awake()
    {
        if (healthManager != null)
        {
            healthManager.OnKill += OnEnemyKill;
        }
    }

    private void OnEnemyKill()
    {
        healthManager.OnKill -= OnEnemyKill;
        PlayDeathAnimation();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        var healthplayer = collision.gameObject.GetComponent<HealthManager>();
        if (healthplayer != null)
        {
            healthplayer.Damage(damage);
            PlayAttackAnimation();
        }
    }
    private void PlayAttackAnimation()
    {
        animator.SetTrigger(triggerEnemyAttack);
    }
    private void PlayDeathAnimation()
    {
        animator.SetTrigger(triggerEnemyDeath);
    }
    public void Damage(int amount)
    {
        healthManager.Damage(amount);
    }
}
