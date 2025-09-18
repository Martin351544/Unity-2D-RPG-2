using System.Collections;
using UnityEngine;

public class Enemy_Health : MonoBehaviour
{
    public int expReward = 3;
    public float DeathTime;
    private EnemySpawner enemySpawner;
    public delegate void MonsterDefeated(int exp);
    public static event MonsterDefeated OnMonsterDefeated;
    public Animator anim;
    public int currentHealth;
    public int MaxHealth;
    
    void Start()
    {
        currentHealth = MaxHealth;
    }
    public void SetSpawner(EnemySpawner spawner)
    {
        enemySpawner = spawner;
    }

    public void ChangeHealth(int amount)
    {
        currentHealth += amount;

        if (currentHealth > MaxHealth)
        {
            currentHealth = MaxHealth; 
        }
        else if (currentHealth <= 0 )
        {
            OnMonsterDefeated(expReward);
            Destroy(gameObject);
            anim.Play("Death");

            enemySpawner.enemiesSpawned -= 1;
        }
    }
    IEnumerator WaitForDeath()
    {
        yield return new WaitForSeconds(DeathTime);
    }

}
