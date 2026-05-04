using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunPlayer : MonoBehaviour
{
    [Header("Settings Projectille")]
    public Vector3 directionProjectille;
    public float timetoDestroy = 1.5f;
    public float side = 1f;
    public int damageAmount = 5;

    private void Awake()
    {
        Destroy(gameObject, timetoDestroy);
    }

    private void Update()
    {
       transform.Translate(side * Time.deltaTime * directionProjectille);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        var enemy = collision.transform.GetComponent<EnemyMovement>();
        if (enemy != null)
        {
            enemy.Damage(damageAmount);
            Destroy(gameObject);
        }
    }
}
