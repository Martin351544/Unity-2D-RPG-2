using System;
using UnityEngine.Tilemaps;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.XR;

public class Enemy_Movement : MonoBehaviour
{
    public float speed;
    public float attackRange = 2;
    public float attackCooldown = 2;
    public float playerDetectionRange = 5;
    public Transform detectionPoint;
    public LayerMask playerLayer;


    private float attackCooldownTimer;
    private EnemyState enemyState;
    private int facingDirection = -1;


    private Animator anim;
    private Rigidbody2D rb;
    private Transform player;


    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        ChangeState(EnemyState.Idle);
    }



    void Update()
    {
        CheckForPlayer();
        if (enemyState != EnemyState.Knokback)
        {
            if (attackCooldownTimer > 0)
            {
                attackCooldownTimer -= Time.deltaTime;
            }

            if (enemyState == EnemyState.Chasing)
            {
                Chase();
            }
            else if(enemyState ==EnemyState.attacking) 
            {
                rb.linearVelocity = Vector2.zero;
            }
        }

    }

    void Chase()
    {
        if (player.position.x > transform.position.x && facingDirection == -1 ||
            player.position.x < transform.position.x && facingDirection == 1)
            {

                Flip();

            }

            Vector2 direction = (player.position - transform.position).normalized;
            rb.linearVelocity = direction * speed;

    }

    void Flip()
    {

        facingDirection *=-1;
        transform.localScale = new Vector3(transform.localScale.x * -1 , transform.localScale.y , transform.localScale.z);

    }

    private void CheckForPlayer()
    {
        Collider2D[] hits = Physics2D.OverlapCircleAll(detectionPoint.position , playerDetectionRange , playerLayer);

        if (hits.Length > 0)
        {
            player = hits[0].transform;

            if (Vector2.Distance(transform.position , player.position) <= attackRange && attackCooldownTimer <= 0)
            {
                attackCooldownTimer = attackCooldown;
                ChangeState(EnemyState.attacking);
            }
            else if (Vector2.Distance(transform.position , player.position) > attackRange && enemyState != EnemyState.attacking)
            {
                ChangeState(EnemyState.Chasing);
            }

        }
        else
        {
            rb.linearVelocity = Vector2.zero;
            ChangeState(EnemyState.Idle);
        }
    }

    public void ChangeState(EnemyState newState)
        {
            
            if (enemyState == EnemyState.Idle)
                anim.SetBool("isIdle" , false);

            else if (enemyState == EnemyState.Chasing)
                anim.SetBool("isChasing" , false);

            else if (enemyState == EnemyState.attacking)
                anim.SetBool("isAttacking" , false);
            
            enemyState = newState;
            if (enemyState == EnemyState.attacking)
                anim.SetBool("isAttacking" , true);

            else if (enemyState == EnemyState.Idle)
                anim.SetBool("isIdle" , true);

            else if (enemyState == EnemyState.Chasing)
                anim.SetBool("isChasing" , true);
        
    }
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(detectionPoint.position , playerDetectionRange);
    }

}


    public enum EnemyState
    {
        Idle,
        Chasing,
        attacking,
        Knokback
    }
