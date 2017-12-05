using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RefreshEnemySpawnRate : MonoBehaviour
{

    UpgradeToolTip utt;

    public GameObject[] relatedGobs;
    // Use this for initialization
    void Start()
    {
        GetComponent<OnMouseEnterScript>().enabled = false;
        GetComponent<Image>().enabled = false;

        foreach (var gob in relatedGobs)
        {
            gob.GetComponent<OnMouseEnterScript>().enabled = false;
            gob.GetComponent<Image>().enabled = false;
        }

        utt = GetComponent<UpgradeToolTip>();
    }

    // Update is called once per frame
    void Update()
    {
        if (utt.Level > 0)
        {
            GetComponent<OnMouseEnterScript>().enabled = true;
            GetComponent<Image>().enabled = true;

            if (relatedGobs != null)
                foreach (var gob in relatedGobs)
                {
                    gob.GetComponent<OnMouseEnterScript>().enabled = true;
                    gob.GetComponent<Image>().enabled = true;
                }
        }
    }

    public void UpgradeCheck()
    {
        UpgradeToolTip DeflectRate = GameObject.Find("DeflectRate").GetComponent<UpgradeToolTip>();
        UpgradeToolTip EnemySpawnRate = GameObject.Find("EnemySpawnRate").GetComponent<UpgradeToolTip>();
        if (DeflectRate.Level / 2 == EnemySpawnRate.Level + 1 && DeflectRate.Level % 2 == 0)
            EnemySpawnRate.Upgrade();
    }

    public void PiercingUnlockCheck()
    {
        if (GameObject.Find("DeflectPower").GetComponent<UpgradeToolTip>().CurrentBonus >= 0.25)
        {
            GameObject.Find("PiercingProjectileUnlock").GetComponent<UpgradeToolTip>().Level = 1;
            GameObject.Find("Upgrades").GetComponent<Upgrades>().PiercingAbilityUnlocked = true;
        }
    }
    public void SplittingUnlockCheck()
    {
        if (GameObject.Find("PiercingProjectilesCount").GetComponent<UpgradeToolTip>().CurrentBonus >= 2)
        {
            GameObject.Find("ProjectileSplitUnlock").GetComponent<UpgradeToolTip>().Level = 1;
            GameObject.Find("Upgrades").GetComponent<Upgrades>().SplitAbilityUnlocked = true;
        }
    }
    public void DeflectingProjectilesUnlockCheck()
    {
        if (GameObject.Find("SplitChance").GetComponent<UpgradeToolTip>().CurrentBonus >= 0.15)
        {
            GameObject.Find("ProjectileDeflectUnlock").GetComponent<UpgradeToolTip>().Level = 1;
            GameObject.Find("Upgrades").GetComponent<Upgrades>().DeflectingProjectileAbilityUnlocked = true;
        }
    }
}
