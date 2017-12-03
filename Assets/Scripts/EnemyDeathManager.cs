using System.Collections;
using UnityEngine;

public class EnemyDeathManager : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.layer == 12)
        {
            StartCoroutine(SendToUndeworldAndKill());
        }
    }

    IEnumerator SendToUndeworldAndKill()
    {
        GetComponent<ProjectileShooter>().enabled = false;
        transform.position *= 200;
        yield return new WaitForSeconds(5);
        Destroy(gameObject);
    }
}
