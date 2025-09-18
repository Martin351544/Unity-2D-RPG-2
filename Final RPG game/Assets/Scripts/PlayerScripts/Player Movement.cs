using System.Collections;
using UnityEngine.Tilemaps;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public int facingDirection = 1;
    public Rigidbody2D rb;
    public Animator anim;
    public Player_combat player_combat;

    void Update()
    {
        if (Input.GetButton("Slash"))
        {
            player_combat.Attack();
        }
    }

    private bool isKnckedBack;
    void FixedUpdate()
    {
        if (isKnckedBack == false)
        {
            float horizontal = Input.GetAxis("Horizontal");
            float vertical = Input.GetAxis("Vertical");

            if (horizontal > 0 && transform.localScale.x < 0 || 
            horizontal < 0 && transform.localScale.x > 0)
            {
                Flip();
            }

            anim.SetFloat("horizontal" , Mathf.Abs(horizontal));
            anim.SetFloat("vertical" , Mathf.Abs(vertical));

            rb.linearVelocity = new Vector2(horizontal , vertical) * StatsManager.Instance.speed;
        }
    }

    void Flip()
    {
        facingDirection *= -1;
        transform.localScale = new Vector3 (transform.localScale.x * -1 , transform.localScale.y , transform.localScale.z);
    }


    public void Knokback(Transform enemy , float force , float stunTime)
    {
        isKnckedBack = true;
        Vector2 direction = (transform.position - enemy.position).normalized;
        rb.linearVelocity = direction * force;
        StartCoroutine(KnokbackCounter(stunTime));
    }
    IEnumerator KnokbackCounter(float stunTime)
    {
        yield return new WaitForSeconds(stunTime);
        rb.linearVelocity = Vector2.zero;
        isKnckedBack = false;
    }
}
