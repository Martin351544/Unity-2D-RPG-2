
using UnityEngine;
using TMPro;
public class InventoryManager : MonoBehaviour
{
    
    public InventorySlot[] itemSlots;
    public int gold;
    public StatsUi statsUI;
    public TMP_Text goldText;
    public useItem useItem;
    public GameObject lootPrefab;
    public Transform player;

    void Start()
    {
        foreach (var slot in itemSlots)
        {
            slot.UpdateUI();
        }
    }
///
    private void OnEnable()
    {
        Loot.OnItemLooted += AddItem;
    }
    private void OnDisable()
    {
        Loot.OnItemLooted -= AddItem;
    }
///
    public void AddItem(ItemSO itemSO , int quantity)
    {
        if (itemSO.isGold)
        {
            gold += quantity;
            goldText.text = gold.ToString();
            return;
        }
        foreach (var slot in itemSlots)
        {
            if (slot.itemSO == itemSO && slot.quantity < itemSO.stackSize)
            {
                int availableSpace  = itemSO.stackSize - slot.quantity;
                int amountToAdd = Mathf.Min(availableSpace , quantity);

                slot.quantity += amountToAdd;
                quantity -= amountToAdd;

                slot.UpdateUI();

                if (quantity <= 0)
                {
                    return;
                }
                
            }
            if (quantity > 0)
            {
                DropLoot(itemSO , quantity);
            }
        }

        foreach (var slot in itemSlots)
        {
            if (slot.itemSO == null) 
            {   
                int amountToAdd = Mathf.Min(itemSO.stackSize , quantity);
                slot.itemSO = itemSO;
                slot.quantity = quantity;
                slot.UpdateUI(); 
                return;  
            }
        }

    }

    private void DropLoot(ItemSO itemSO , int quantity)
    {
        itemSO = null;
        Debug.Log(itemSO + "Was Dropped");
    }
    public void DropItem(InventorySlot slot)
    {
        DropLoot(slot.itemSO , 1 );
        slot.quantity --;
        if (slot.quantity <= 0)
        {
            slot.itemSO = null;
        }
        slot.UpdateUI();
    }
    

    public void UseItem(InventorySlot slot)
    {
        if (slot.itemSO != null && slot.quantity >= 0)
        {
            useItem.ApplyItemEffects(slot.itemSO);

            slot.quantity --;
            if (slot.quantity <= 0)
            {
                slot.itemSO = null;
            }
            slot.UpdateUI();
        }
    }
}
