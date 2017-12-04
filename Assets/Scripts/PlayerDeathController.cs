using System.Collections;
using UnityEngine;

public class PlayerDeathController : MonoBehaviour
{

    public ParticleSystem DeathParticleSystem;
    // Use this for initialization
    void Start()
    {
        DeathParticleSystem.Stop();
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        GetComponent<Animator>().SetBool("isDead", true);
        DeathParticleSystem.Play();
        DisableComponents();
        StartCoroutine(DelayParticleStopAndLoadMenu());
    }

    void DisableComponents()
    {
        GetComponent<PlayerMovement>().enabled = false;
        GetComponent<ProjectileReflecter>().enabled = false;
        GetComponent<PolygonCollider2D>().enabled = false;
        GetComponent<PlayerDeathController>().enabled = false;
    }

    IEnumerator DelayParticleStopAndLoadMenu()
    {
        yield return new WaitForSeconds(0.3f);
        GetComponentInChildren<ParticleSystem>().Stop();
        yield return new WaitForSeconds(1.7f);
        GetComponent<SceneLoader>().LoadMenuScene();
    }
}
