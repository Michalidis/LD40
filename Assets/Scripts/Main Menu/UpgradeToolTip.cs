using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class UpgradeToolTip : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{

    public string ToolTipText;

    public float CurrentBonus;
    public float NextBonus;

    public int NextCost;

    private Text textTarget;

    // Use this for initialization
    void Start()
    {
        textTarget = GameObject.Find("ToolTip").GetComponent<Text>();
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
        textTarget.text = ToolTipText
            + "\nUpgrade Cost - " + NextCost + " Metal Gears."
            + "\nCurrent Bonus - " + CurrentBonus * 100 + "%."
            + "\nNext Bonus - " + NextBonus * 100 + "%.";
    }
}
