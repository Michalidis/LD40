using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FightButtonOnClickEventAdder : MonoBehaviour {

	// Use this for initialization
	void Start () {
        Button b = GetComponent<Button>();
        b.onClick.AddListener(GameObject.Find("Upgrades").GetComponent<Upgrades>().GetButtonData);
        b.onClick.AddListener(GetComponent<SceneLoader>().LoadGameScene);
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
