using UnityEngine;

public class Enemy_Compbat : MonoBehaviour
{
    public int damage = 1;
    public Transform attackPoint;
    public float weaponRange;
    public float stunTime;
    public float KnokbackForce;
    public LayerMask playerLayer;
    public void Attack()
    {
        Collider2D[] hits = Physics2D.OverlapCircleAll(attackPoint.position , weaponRange , playerLayer);

        if (hits.Length > 0)
        {
            hits [0].GetComponent<Player_Health>().ChangeHealth(-damage);
            hits [0].GetComponent<PlayerMovement>().Knokback(transform , KnokbackForce , stunTime);
        }
    }
}
