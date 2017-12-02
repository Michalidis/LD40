using UnityEngine;

public class collisionRestricter : MonoBehaviour {

	// Use this for initialization
	void Start () {
        Physics2D.IgnoreLayerCollision(8, 9, true);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
