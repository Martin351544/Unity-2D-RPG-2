using UnityEngine;

public class ShopButtonTogle : MonoBehaviour
{
    public void OpenItemShop()
    {
        if(ShopKeeper.currentShopKeeper != null)
        {
            ShopKeeper.currentShopKeeper.OpeItemShop();
        }
    }
    public void OpenWeaponShop()
    {
        if(ShopKeeper.currentShopKeeper != null)
        {
            ShopKeeper.currentShopKeeper.OpenWeaponShop();
        }
    }
    public void OpenArmourShop()
    {
        if(ShopKeeper.currentShopKeeper != null)
        {
            ShopKeeper.currentShopKeeper.OpenArmourShop();
        }
    }
}
