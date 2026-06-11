using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemCollactableBase : MonoBehaviour
{
    public string CompararTag = "Player";
    public ParticleSystem effectSystem;

    [Header("SOUNDS")]
    public AudioClip collectSound;

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
        OnCollect();
        gameObject.SetActive(false);
    }

    protected virtual void OnCollect()
    {
       if (effectSystem != null) effectSystem.Play();

        if (collectSound != null)
            AudioSource.PlayClipAtPoint(collectSound, transform.position);
    }
}