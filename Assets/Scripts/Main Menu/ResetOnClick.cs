﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ResetOnClick : MonoBehaviour
{

    // Use this for initialization
    void Start()
    {
        GetComponent<Button>().onClick.AddListener(
            GameObject.Find("Statistics").GetComponent<Statistics>().ResetStatistics_MainMenuONLY);
    }

    // Update is called once per frame
    void Update()
    {

    }


}
