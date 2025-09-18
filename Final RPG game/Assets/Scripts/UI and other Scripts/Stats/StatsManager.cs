using Unity.VisualScripting.Antlr3.Runtime.Misc;
using UnityEngine;

public class StatsManager : MonoBehaviour
{
    public StatsUi statsUI;
    public static StatsManager Instance;

    [Header("Combat Stats")]
    public int damage;
    public float weaponRange;
    public float KnokbackForce;
    public float knockbackTime;
    public float stunTime;

    [Header("Movement Stats")]
    public int speed;

    [Header("Health Stats")]
    public int maxHealth;
    public int currentHealth;


    void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
            Destroy(gameObject);
    }
    public void updateMaxHealth(int amount)
    {
        maxHealth += amount;
    }
    public void UpdateHealth(int amount)
    {
        currentHealth += amount;
    }
    public void UpdateSpeed(int amount)
    {
        speed += amount;
        statsUI.UpdateAllStats();
    }
    public void UpdateDamage(int amount)
    {
        damage += amount;
        statsUI.UpdateAllStats();
    }
}
