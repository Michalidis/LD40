using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpgradeButtonDataRetriever : MonoBehaviour
{
    // Use this for initialization
    void Start()
    {
        GameObject.Find("Upgrades").GetComponent<Upgrades>().SetButtonData();
    }

    // Update is called once per frame
    void Update()
    {

    }
}
