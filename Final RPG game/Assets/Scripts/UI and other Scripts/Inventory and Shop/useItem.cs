using System.Collections;
using UnityEngine;

public class useItem : MonoBehaviour
{
    public void ApplyItemEffects(ItemSO itemSO)
    {
        if (itemSO.currentHealth > 0)
            StatsManager.Instance.UpdateHealth(itemSO.currentHealth);
        if (itemSO.maxHealth > 0)
            StatsManager.Instance.UpdateHealth(itemSO.maxHealth);
        if (itemSO.speed > 0)
            StatsManager.Instance.UpdateSpeed(itemSO.speed);
        if (itemSO.damage > 0)
            StatsManager.Instance.UpdateDamage(itemSO.damage);
        if (itemSO.duration > 0)
            StartCoroutine(EffectTimer(itemSO , itemSO.duration));
    }


    private IEnumerator EffectTimer(ItemSO itemSO , float duration)
    {
        yield return new WaitForSeconds(duration);
        if (itemSO.currentHealth > 0)
            StatsManager.Instance.UpdateHealth(-itemSO.currentHealth);
        if (itemSO.maxHealth > 0)
            StatsManager.Instance.UpdateHealth(-itemSO.maxHealth);
        if (itemSO.speed > 0)
            StatsManager.Instance.UpdateSpeed(-itemSO.speed);
        if (itemSO.damage > 0)
            StatsManager.Instance.UpdateDamage(-itemSO.damage);

    }
    
}
