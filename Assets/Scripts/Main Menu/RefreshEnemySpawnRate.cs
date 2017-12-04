using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RefreshEnemySpawnRate : MonoBehaviour
{

    UpgradeToolTip utt;
    // Use this for initialization
    void Start()
    {
        GetComponent<OnMouseEnterScript>().enabled = false;
        GetComponent<Image>().enabled = false;
        utt = GetComponent<UpgradeToolTip>();
    }

    // Update is called once per frame
    void Update()
    {
        if (utt.Level > 0)
        {
            GetComponent<OnMouseEnterScript>().enabled = true;
            GetComponent<Image>().enabled = true;
        }
    }

    public void UpgradeCheck()
    {
        if (GameObject.Find("DeflectRate").GetComponent<UpgradeToolTip>().Level % 2 == 0)
            GameObject.Find("EnemySpawnRate").GetComponent<UpgradeToolTip>().Upgrade();
    }
}
