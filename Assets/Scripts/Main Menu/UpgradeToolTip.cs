using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class UpgradeToolTip : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{

    public string ToolTipText;

    public float CurrentBonus;
    public float BonusIncreasePerUpgrade;
    public float NextBonus;

    public int UpgradeCost;
    public int CostIncreasePerUpgrade;

    public int Level;
    private Text textTarget;

    // Use this for initialization
    void Start()
    {
        textTarget = GameObject.Find("ToolTip").GetComponent<Text>();

        transform.GetComponent<Button>().onClick.AddListener(Upgrade);
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void OnPointerExit(PointerEventData eventData)
    {
        textTarget.text = "";
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        PrintToolTip();
    }

    void PrintToolTip()
    {
        textTarget.text = "Current Level: " + Level
            + ToolTipText
            + "\nUpgrade Cost: " + UpgradeCost + " Metal Gears."
            + "\nCurrent Bonus: " + CurrentBonus * 100 + "%."
            + "\nNext Bonus: " + NextBonus * 100 + "%.";
    }

    public void Upgrade()
    {
        Statistics stats = GameObject.Find("IndestructibleInfo").GetComponentInChildren<Statistics>();

        if (stats.Currency >= UpgradeCost)
            PerformUpgradePurchase(stats);
    }

    void PerformUpgradePurchase(Statistics stats)
    {
        CurrentBonus = NextBonus;
        NextBonus += BonusIncreasePerUpgrade;

        stats.Currency -= UpgradeCost;
        UpgradeCost += CostIncreasePerUpgrade;

        BonusIncreasePerUpgrade = (float)(BonusIncreasePerUpgrade * 0.95);
        CostIncreasePerUpgrade = (int)(CostIncreasePerUpgrade * 1.15);

        Level++;

        PrintToolTip();
    }
}
