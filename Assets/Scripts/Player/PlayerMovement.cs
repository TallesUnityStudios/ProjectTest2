using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class PlayerMovement : MonoBehaviour
{
    private float _currentSpeed;
    public HealthManager healManager;
    public Rigidbody2D myRigidbody;
    public Animator animator;

    [Header("Setup")]
    public SOPlayerSetup soPlayerSetup;

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
        animator.SetTrigger(soPlayerSetup.triggerDeathPlayer);
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
            _currentSpeed = soPlayerSetup.runningSpeed;
            animator.SetBool(soPlayerSetup.boolFlashRun, true);
        }
        else
        {
            _currentSpeed = soPlayerSetup.speed;
            animator.SetBool(soPlayerSetup.boolFlashRun, false);
        }

        if (Input.GetKey(KeyCode.A))
        {
            //myRigidbody.MovePosition(myRigidbody.position - movement * Time.deltaTime);
            myRigidbody.velocity = new Vector2(-_currentSpeed, myRigidbody.velocity.y);
            if (myRigidbody.transform.localScale.x != -1)
            {
                myRigidbody.transform.DOScaleX(-1, soPlayerSetup.animationDuration);
            }
            animator.SetBool(soPlayerSetup.boolRun, true);

        }
        else if (Input.GetKey(KeyCode.D))
        {
            //myRigidbody.MovePosition(myRigidbody.position + movement * Time.deltaTime);
            myRigidbody.velocity = new Vector2(_currentSpeed, myRigidbody.velocity.y);
            if (myRigidbody.transform.localScale.x != 1)
            {
                myRigidbody.transform.DOScaleX(1, soPlayerSetup.animationDuration);
            }
            animator.SetBool(soPlayerSetup.boolRun, true);
        }
        else
        {
            animator.SetBool(soPlayerSetup.boolRun, false);
        }

        if (myRigidbody.velocity.x > 0)
        {
            myRigidbody.velocity -= soPlayerSetup.friction;
        }
        else if (myRigidbody.velocity.x < 0)
        {
            myRigidbody.velocity += soPlayerSetup.friction;
        }
    }

    private void HandleJumping()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            myRigidbody.velocity = Vector2.up * soPlayerSetup.jumpForce;
            myRigidbody.transform.localScale = Vector2.one;
            animator.SetTrigger(soPlayerSetup.triggerJump);
           
            DOTween.Kill(myRigidbody.transform);

            HandleScaleJumping();
        }
    }

    private void HandleScaleJumping()
    {
        myRigidbody.transform.DOScaleY(soPlayerSetup.jumpScaleY, soPlayerSetup.animationDuration).SetLoops(2, LoopType.Yoyo).SetEase(soPlayerSetup.ease);
        myRigidbody.transform.DOScaleX(soPlayerSetup.jumpScaleX, soPlayerSetup.animationDuration).SetLoops(2, LoopType.Yoyo).SetEase(soPlayerSetup.ease);
    }
}
