using System.Collections;
using UnityEngine;

public class Enemy_knokback : MonoBehaviour
{

    private Rigidbody2D rb;
    private Enemy_Movement enemy_Movement;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        enemy_Movement = GetComponent<Enemy_Movement>();
    }
    public void Knokback(Transform forceTransform , float KnokbackForce , float knockbackTime ,float stunTime)
    {
        enemy_Movement.ChangeState(EnemyState.Knokback);
        StartCoroutine(StunTimer(knockbackTime, stunTime));
        Vector2 direction = (transform.position - forceTransform.position).normalized;
        rb.linearVelocity = direction * KnokbackForce;
        Debug.Log("Konkback applied");
    }
    IEnumerator StunTimer(float knockbackTime , float stunTime)
    {
        yield return new WaitForSeconds(knockbackTime);
        rb.linearVelocity = Vector2.zero;
        yield return new WaitForSeconds(stunTime);
        enemy_Movement.ChangeState(EnemyState.Idle);
    }
}
