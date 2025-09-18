using System.Collections.Generic;
using UnityEngine;
using System;
public class ShopKeeper : MonoBehaviour
{
    public Animator anim;
    public CanvasGroup shopCanvasGroup;
    public ShopManager shopManager;
    public static ShopKeeper currentShopKeeper;
    [SerializeField] private List<ShopItems> shopItems;
    [SerializeField] private List<ShopItems> shopWeapons;
    [SerializeField] private List<ShopItems> ShopArmour;
    public static event Action<ShopManager , bool> OnShopStateChanged; 
    private bool PlayerInRange;
    private bool isShopOpen;

    void Start()
    {
        Debug.Log("click 'o' to  open shop!");
    }

    void Update()
    {
        if (PlayerInRange)
        {
            if (Input.GetButton("Interact"))
            {
                if (!isShopOpen)
                {
                    Time.timeScale = 0;
                    currentShopKeeper = this;
                    isShopOpen = true;
                    OnShopStateChanged?.Invoke(shopManager , true);
                    shopCanvasGroup.alpha = 1;
                    shopCanvasGroup.blocksRaycasts = true;
                    shopCanvasGroup.interactable = true;
                    OpeItemShop();
                }
                else
                {
                    Time.timeScale = 1;
                    currentShopKeeper = null;
                    isShopOpen = false;
                    OnShopStateChanged?.Invoke(shopManager , false);
                    shopCanvasGroup.alpha = 0;
                    shopCanvasGroup.blocksRaycasts = false;
                    shopCanvasGroup.interactable = false;
                }
            }
        }
    }
    

    public void OpeItemShop()
    {
        shopManager.PopulateShopItems(shopItems);
    }

    public void OpenWeaponShop()
    {
        shopManager.PopulateShopItems(shopWeapons);
    }
    
    public void OpenArmourShop()
    {
        shopManager.PopulateShopItems(ShopArmour);     
    }
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            anim.SetBool("PlayerInRange" , true);
            PlayerInRange = true;
        }
    }

    void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            anim.SetBool("PlayerInRange" , false);
            PlayerInRange = false;
        }
    }
}
