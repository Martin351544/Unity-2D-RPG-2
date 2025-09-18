using System;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ExpManager : MonoBehaviour
{
    public int level;
    public int currentEXP;
    public int expToLevel = 10;
    public float expGrowthMultiplier = 1.2f;
    public Slider expSlider;
    public TMP_Text currentLevelText;

    void Start()
    {
        UpdateUi();
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            GainExperience(2);
        }
    }
    void OnEnable()
    {
        Enemy_Health.OnMonsterDefeated += GainExperience;
    }
    private void OnDisable() 
    {
        Enemy_Health.OnMonsterDefeated -= GainExperience;
    }
    public void GainExperience(int amount)
    {
        currentEXP += amount;
        if (currentEXP > expToLevel)
        {
            LevelUp();
        }
        UpdateUi();
    }
    private void LevelUp()
    {
        level ++;
        currentEXP -= expToLevel;
        expToLevel += Mathf.RoundToInt(expToLevel * expGrowthMultiplier);
    }
    public void UpdateUi()
    {  
        expSlider.maxValue = expToLevel;
        expSlider.value = currentEXP;
        currentLevelText.text = "Level : " + level;
    }
}
