using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StarCatcher : MonoBehaviour {

    public StarEmitter emitter;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.layer == 15)
        {
            collision.gameObject.GetComponent<Renderer>().enabled = false;
            emitter.count++;
            emitter.stars.Enqueue(collision.gameObject);
        }
    }
}
