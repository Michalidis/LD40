using System.Collections;
using UnityEngine;

public class EnemyDeathManager : MonoBehaviour {

    public ParticleSystem deathAnimation;
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
            Kill();
        }
    }

    void Kill()
    {
        PrepareAndPlanParticleDeath();

        GetComponent<ProjectileShooter>().enabled = false;
        transform.position *= 200;
        Destroy(gameObject, 5f);
    }

    void PrepareAndPlanParticleDeath()
    {
        ParticleSystem ps = Instantiate(deathAnimation);
        ps.transform.position = transform.position;
        Destroy(ps, 2f);
    }
}
