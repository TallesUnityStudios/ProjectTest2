using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class HealthManager : MonoBehaviour
{
    [Header("Health Settings")]
    public int maxHealth = 100;
    private int _currentHealth;

    [Header("Death Settings")]
    [SerializeField] private DamageColor _damageColor;
    private bool _isDead;
    public bool destroyOnDeath = true;
    public float destroyDelay = 1f;
    public Action OnKill;

    private void Awake()
    {
        Init();
        if (_damageColor == null)
        {
            _damageColor = GetComponent<DamageColor>();
        }
    }

    private void Init()
    {
        _isDead = false;
        _currentHealth = maxHealth;
    }

    public void Damage(int damage)
    {
        if (_isDead) return;

        _currentHealth -= damage;
        if (_currentHealth <= 0)
        {
            Kill();
        }

        if (_damageColor != null)
        {
            _damageColor.Flash();
        }
    }

    private void Kill()
    {
        _isDead = true;
        if (destroyOnDeath)
        {
            Destroy(gameObject, destroyDelay);
        }
        
        OnKill?.Invoke();
    }
}

