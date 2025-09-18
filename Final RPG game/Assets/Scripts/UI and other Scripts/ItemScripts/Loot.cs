using System;
using UnityEngine;

public class Loot : MonoBehaviour

{
    public ItemSO itemSO;
    public SpriteRenderer sr;
    public Animator anim;

    public bool canBePickedUp = true;
    public int quantity;
    public static event Action<ItemSO , int> OnItemLooted;


    void OnValidate()
    {
        if (itemSO == null)
            return;

        UpdateAppearence();
    }

    private void UpdateAppearence()
    {
        sr.sprite = itemSO.icon;
        this.name = itemSO.itemName;

        
    } 

    public void Initialize(ItemSO itemSO , int quantity)
    {
        this.itemSO = itemSO;
        this.quantity = quantity;
        canBePickedUp = false;
        UpdateAppearence();

    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player") && canBePickedUp == true)
        {
            OnItemLooted?.Invoke(itemSO , quantity);
            Destroy(gameObject , .5f);
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            canBePickedUp = true;
        }
    }


}
