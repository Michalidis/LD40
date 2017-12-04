using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Upgrades : MonoBehaviour
{

    public float deflect_power;
    public float deflect_rate;
    public float deflect_radius;

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
    }
}
