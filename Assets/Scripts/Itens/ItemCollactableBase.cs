using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemCollactableBase : MonoBehaviour
{
    public string CompararTag = "Player";
    public ParticleSystem effectSystem;

    private void Awake()
    {
        if (effectSystem != null) effectSystem.transform.SetParent(null);   
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag(CompararTag))
        {
            Collect();
        }
    }

    protected virtual void Collect()
    {
        gameObject.SetActive(false);
        OnCollect();
    }

    protected virtual void OnCollect()
    {
       if (effectSystem != null) effectSystem.Play();
    }
}