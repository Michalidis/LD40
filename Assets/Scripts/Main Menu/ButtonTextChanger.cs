using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonTextChanger : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void SetToLoading()
    {
        Text t = GetComponentInChildren<Text>();
        t.text = "Loading...";
        t.color = Color.red;
    }
}
