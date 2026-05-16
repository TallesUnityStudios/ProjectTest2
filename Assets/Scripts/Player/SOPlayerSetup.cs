using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

[CreateAssetMenu]
public class SOPlayerSetup : ScriptableObject
{
    [Header("WalkingPlayer")]
    public Vector2 friction = new Vector2(.1f, 0);
    public float speed = 10;

    [Header("PlayerRunning")]
    public float runningSpeed = 20;

    [Header("JumpingPlayer")]
    public float jumpForce = 15;
    public float jumpScaleY = 1.2f;
    public float jumpScaleX = 0.8f;
    public float animationDuration = .5f;
    public Ease ease = Ease.OutBack;

    [Header("Animations")]
    public string boolRun = "Run";
    public string boolFlashRun = "FlashRun";
    public string triggerJump = "Jump";
    public string triggerDeathPlayer = "DeathPlayer";
}
