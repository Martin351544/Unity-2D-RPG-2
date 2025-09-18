using UnityEngine;

public class Player_combat : MonoBehaviour
{
    public Transform attackPoint;
    public LayerMask enemyLayer;
    public Animator anim;
    public float coolDown = 2;
    private float timer;

    void Update()
    {
        if (timer>0)
        {
            timer -= Time.deltaTime;
        }
    }
    public void Attack()
    {
        if (timer <= 0)
        {
            anim.SetBool("isAttacking" , true );

            timer = coolDown;
        }
    }

    public void DealDamage()
    {
        Collider2D[] enemys = Physics2D.OverlapCircleAll(attackPoint.position , StatsManager.Instance.weaponRange , enemyLayer);
        if (enemys.Length > 0)
        {
            enemys[0].GetComponent<Enemy_Health>().ChangeHealth(-StatsManager.Instance.damage);
            enemys[0].GetComponent<Enemy_knokback>().Knokback(transform , StatsManager.Instance.KnokbackForce , StatsManager.Instance.stunTime , StatsManager.Instance.knockbackTime);
        }
    }
    public void FinishAttacking()
    {
        anim.SetBool("isAttacking" , false);
    }

}
