using UnityEngine;
using TMPro;
using System.Collections.Generic;
using System.Linq;
public class ShopInfo : MonoBehaviour
{
    [Header("Canvas Feild")]
    public CanvasGroup infoPanel;

    [Header("Text Feild")]
    public TMP_Text itemNameText;
    public TMP_Text itemDiscriptionText;

    [Header("stat Feild")]
    public TMP_Text[] statsTexts;

    private RectTransform infoPanelRect;



    private void Awake() 
    {
        infoPanelRect = GetComponent<RectTransform>();
    }



    public void ShowItemInfo(ItemSO itemSO)
    {
        infoPanel.alpha = 1;

        itemNameText.text = itemSO.itemName;
        itemDiscriptionText.text = itemSO.itemDesctription;

        List<string> stats = new List<string>();
        if (itemSO.currentHealth > 0) stats.Add("Health: " + itemSO.currentHealth.ToString());
        if (itemSO.currentHealth > 0) stats.Add("damage: " + itemSO.damage.ToString());
        if (itemSO.speed > 0) stats.Add("Speed: " + itemSO.speed.ToString());
        if (itemSO.duration > 0) stats.Add("Duration: " + itemSO.duration.ToString());

        if (stats.Count <= 0)
            return;
        
        for (int i = 0; i < statsTexts.Length; i++)
        {
            if (i < stats.Count)
            {
                statsTexts[i].text = stats[i];
                statsTexts[i].gameObject.SetActive(true);
            }
            else
            {
                statsTexts[i].gameObject.SetActive(false);
            }

        }
    }



    public void HideItemInfo()
    {
        infoPanel.alpha = 0;

        itemNameText.text = "";
        itemDiscriptionText.text = "";
        
    }



    public void FollowMouse()
    {
        Vector3 mousPosition = Input.mousePosition;
        Vector3 offset = new Vector3 (10 ,-10 ,0);

        infoPanelRect.position = mousPosition + offset;
    }
}
