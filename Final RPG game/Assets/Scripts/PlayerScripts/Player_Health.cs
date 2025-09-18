using UnityEngine;
using UnityEngine.UI;

public class Player_Health : MonoBehaviour
{
    public SpriteRenderer player;
    public PlayerMovement playerMovement;

    public Sprite EmptyHeart;
    public Sprite FullHeart;
    public Image[] Hearts;

    public void ChangeHealth(int amount)
    {
        StatsManager.Instance.currentHealth += amount;

        if (StatsManager.Instance.currentHealth <= 0)
        {
            Destroy(player.gameObject);
        }
    }
    void Update()
    {
        for (int i = 0; i < Hearts.Length; i++)
        {
            if (i < StatsManager.Instance.currentHealth)
            {
                Hearts[i].sprite = FullHeart;
            }
            else
            {
                Hearts[i].sprite = EmptyHeart;
            }
            if (i < StatsManager.Instance.maxHealth)
            {
                Hearts[i].enabled = true;
            }

            else
            {
                Hearts[i].enabled = false;
            }
        }
    }

}
