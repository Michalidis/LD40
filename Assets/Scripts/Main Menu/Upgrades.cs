using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Upgrades : MonoBehaviour
{

    private UpgradeToolTipHolder _deflect_power;
    private UpgradeToolTipHolder _deflect_rate;
    private UpgradeToolTipHolder _deflect_radius;
    private UpgradeToolTipHolder _movement_speed;

    public float deflect_power;
    public float deflect_rate;
    public float deflect_radius;
    public float movement_speed;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void SetButtonData()
    {
        if (_deflect_power != null)
        {
            Upgrades globalUpgrades = GameObject.Find("IndestructibleInfo").GetComponentInChildren<Upgrades>();

            FindAndAssignProperToolTips("DeflectPower", _deflect_power);
            FindAndAssignProperToolTips("DeflectRadius", _deflect_radius);
            FindAndAssignProperToolTips("DeflectRate", _deflect_rate);
            FindAndAssignProperToolTips("FlySpeed", _movement_speed);
        }
    }

    public void GetButtonData()
    {
        Upgrades globalUpgrades = GameObject.Find("IndestructibleInfo").GetComponentInChildren<Upgrades>();

        globalUpgrades._deflect_power = GetToolTip("DeflectPower");
        globalUpgrades._deflect_radius = GetToolTip("DeflectRadius");
        globalUpgrades._deflect_rate = GetToolTip("DeflectRate");
        globalUpgrades._movement_speed = GetToolTip("FlySpeed");

        deflect_power = _deflect_power.CurrentBonus;
        deflect_radius = _deflect_radius.CurrentBonus;
        deflect_rate = _deflect_rate.CurrentBonus;
        movement_speed = _movement_speed.CurrentBonus;
    }

    private void FindAndAssignProperToolTips(string gobName, UpgradeToolTipHolder toolTip)
    {
        UpgradeToolTip gobToolTip = GameObject.Find(gobName).GetComponent<UpgradeToolTip>();

        gobToolTip.ToolTipText = toolTip.ToolTipText;
        gobToolTip.CurrentBonus = toolTip.CurrentBonus;
        gobToolTip.BonusIncreasePerUpgrade = toolTip.BonusIncreasePerUpgrade;
        gobToolTip.NextBonus = toolTip.NextBonus;
        gobToolTip.UpgradeCost = toolTip.UpgradeCost;
        gobToolTip.CostIncreasePerUpgrade = toolTip.CostIncreasePerUpgrade;
        gobToolTip.Level = toolTip.Level;

    }

    private UpgradeToolTipHolder GetToolTip(string fromObjectName)
    {
        return new UpgradeToolTipHolder(GameObject.Find(fromObjectName).GetComponent<UpgradeToolTip>());
    }

    class UpgradeToolTipHolder
    {
        public string ToolTipText;

        public float CurrentBonus;
        public float BonusIncreasePerUpgrade;
        public float NextBonus;

        public int UpgradeCost;
        public int CostIncreasePerUpgrade;

        public int Level;

        public UpgradeToolTipHolder(UpgradeToolTip utt)
        {
            ToolTipText = utt.ToolTipText;
            CurrentBonus = utt.CurrentBonus;
            BonusIncreasePerUpgrade = utt.BonusIncreasePerUpgrade;
            NextBonus = utt.NextBonus;
            UpgradeCost = utt.UpgradeCost;
            CostIncreasePerUpgrade = utt.CostIncreasePerUpgrade;
            Level = utt.Level;
        }
    }
}
