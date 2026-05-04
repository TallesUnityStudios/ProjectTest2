using System.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class DamageColor : MonoBehaviour
{
    public List<SpriteRenderer> spriteRenderers;

    [Header("Damage Color Settings")]
    public Color damageColor = Color.red;
    public float damageDuration = 0.2f;
    private Tween _currentColorTween;

    private void OnValidate()
    {
        spriteRenderers = new List<SpriteRenderer>();
        foreach (var child in transform.GetComponentsInChildren<SpriteRenderer>())
        {
            spriteRenderers.Add(child);
        }
    }

    public void Flash()
    {
        if (_currentColorTween != null)
        {
            _currentColorTween.Kill();
            spriteRenderers.ForEach(sprite => sprite.color = Color.white);
        }

        foreach (var damageSprite in spriteRenderers)
        {
            _currentColorTween = damageSprite.DOColor(damageColor, damageDuration).SetLoops(2, LoopType.Yoyo);
        }
    }
}
