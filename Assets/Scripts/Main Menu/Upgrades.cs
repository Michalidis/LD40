using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Upgrades : MonoBehaviour
{

    public float deflect_power;
    public float deflect_rate;
    public float deflect_radius;
    public float movement_speed;

    // Use this for initialization
    void Start()
    {
        Reset();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void Reset()
    {
        Upgrades globalUpgrades = GameObject.Find("IndestructibleInfo").GetComponentInChildren<Upgrades>();

        globalUpgrades.deflect_power = 0;
        globalUpgrades.deflect_radius = 0;
        globalUpgrades.deflect_rate = 1;
        globalUpgrades.movement_speed = 0;
    }

    public void GetData()
    {
        Upgrades globalUpgrades = GameObject.Find("IndestructibleInfo").GetComponentInChildren<Upgrades>();

        globalUpgrades.deflect_power = GetBonus("DeflectPower");
        globalUpgrades.deflect_radius = GetBonus("DeflectRadius");
        globalUpgrades.deflect_rate = GetBonus("DeflectRate");
        globalUpgrades.movement_speed = GetBonus("FlySpeed");
    }

    private float GetBonus(string fromObjectName)
    {
        return GameObject.Find(fromObjectName).GetComponent<UpgradeToolTip>().CurrentBonus;
    }
}
