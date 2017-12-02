using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileProperties : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void ChangeToReflected()
    {
        gameObject.layer = 12;
        gameObject.GetComponent<SpriteRenderer>().color = Color.red;
    }

}
