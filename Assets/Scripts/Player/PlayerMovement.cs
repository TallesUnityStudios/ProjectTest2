using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class PlayerMovement : MonoBehaviour
{
    private float _currentSpeed;
    public HealthManager healManager;
    public Rigidbody2D myRigidbody;

    [Header("WalkingPlayer")]
    public Vector2 friction = new Vector2 (.1f, 0);
    public float speed = 10;

    [Header("PlayerRunning")]
    public float runningSpeed = 20;

    [Header("JumpingPlayer")]
    public float jumpForce = 15;
    public float jumpScaleY = 1.2f;
    public float jumpScaleX = 0.8f;
    public float animationDuration = .5f;
    public Ease ease = Ease.OutBack;

    [Header("Animations Running")]
    public string boolRun = "Run";
    public string boolFlashRun = "FlashRun";
    public string triggerJump = "Jump";
    public string triggerDeathPlayer = "DeathPlayer";
    public Animator animator;

    private void Awake()
    {
        if (healManager != null)
        {
            healManager.OnKill += OnPlayerKill;
        }
    }

    private void OnPlayerKill()
    {
        healManager.OnKill -= OnPlayerKill;
        animator.SetTrigger(triggerDeathPlayer);
    }

    private void Update()
    {
        HandleMoviments();
        HandleJumping();
    }

    private void HandleMoviments()
    {
        if (Input.GetKey(KeyCode.LeftShift))
        {
            _currentSpeed = runningSpeed;
            animator.SetBool(boolFlashRun, true);
        }
        else
        {
            _currentSpeed = speed;
            animator.SetBool(boolFlashRun, false);
        }

        if (Input.GetKey(KeyCode.A))
        {
            //myRigidbody.MovePosition(myRigidbody.position - movement * Time.deltaTime);
            myRigidbody.velocity = new Vector2(-_currentSpeed, myRigidbody.velocity.y);
            if (myRigidbody.transform.localScale.x != -1)
            {
                myRigidbody.transform.DOScaleX(-1, .1f);
            }
            animator.SetBool(boolRun, true);

        }
        else if (Input.GetKey(KeyCode.D))
        {
            //myRigidbody.MovePosition(myRigidbody.position + movement * Time.deltaTime);
            myRigidbody.velocity = new Vector2(_currentSpeed, myRigidbody.velocity.y);
            if (myRigidbody.transform.localScale.x != 1)
            {
                myRigidbody.transform.DOScaleX(1, .1f);
            }
            animator.SetBool(boolRun, true);
        }
        else
        {
            animator.SetBool(boolRun, false);
        }

        if (myRigidbody.velocity.x > 0)
        {
            myRigidbody.velocity -= friction;
        }
        else if (myRigidbody.velocity.x < 0)
        {
            myRigidbody.velocity += friction;
        }
    }

    private void HandleJumping()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            myRigidbody.velocity = Vector2.up * jumpForce;
            myRigidbody.transform.localScale = Vector2.one;
            animator.SetTrigger(triggerJump);
           
            DOTween.Kill(myRigidbody.transform);

            HandleScaleJumping();
        }
    }

    private void HandleScaleJumping()
    {
        myRigidbody.transform.DOScaleY(jumpScaleY, animationDuration).SetLoops(2, LoopType.Yoyo).SetEase(ease);
        myRigidbody.transform.DOScaleX(jumpScaleX, animationDuration).SetLoops(2, LoopType.Yoyo).SetEase(ease);
    }
}
