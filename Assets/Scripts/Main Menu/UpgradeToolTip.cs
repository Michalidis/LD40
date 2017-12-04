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

        if (UpgradeCost > 0)
        {
            transform.GetComponent<Button>().onClick.AddListener(Upgrade);
            transform.GetComponent<Button>().onClick.AddListener(GameObject.Find("IndestructibleInfo").GetComponentInChildren<Statistics>().RewriteStatistics_MainMenuONLY);
        }
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
        if (UpgradeCost > 0)
            textTarget.text = "Current Level: " + Level + "\n"
                + ToolTipText
                + "\nUpgrade Cost: " + UpgradeCost + " Metal Gears."
                + "\nCurrent Bonus: " + CurrentBonus * 100 + "%."
                + "\nNext Bonus: " + NextBonus * 100 + "%.";
        else if (UpgradeCost <= 0 && CurrentBonus <= 0 && NextBonus <= 0)
            textTarget.text = ToolTipText;
        else
            textTarget.text = "Current Level: " + Level + "\n"
                + ToolTipText
                + "\nCurrent Bonus: " + CurrentBonus * 100 + "%."
                + "\nNext Bonus: " + NextBonus * 100 + "%."
                + "\nCannot Be Purchased!";

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

        if (BonusIncreasePerUpgrade != 1)
            BonusIncreasePerUpgrade = (float)(BonusIncreasePerUpgrade * 0.985);

        CostIncreasePerUpgrade = (int)(CostIncreasePerUpgrade * 1.10);
        Level++;

        PrintToolTip();
    }
}
