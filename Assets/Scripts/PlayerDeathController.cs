using System.Collections;
using UnityEngine;

public class PlayerDeathController : MonoBehaviour
{
    private SoundPlayer BoomBox;
    public ParticleSystem DeathParticleSystem;
    // Use this for initialization
    void Start()
    {
        BoomBox = GameObject.Find("BoomBox").GetComponent<SoundPlayer>();
        DeathParticleSystem.Stop();
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.layer == 8 || collision.gameObject.layer == 10 || collision.gameObject.layer == 12)
        {
            GetComponent<Animator>().SetBool("isDead", true);
            BoomBox.PlaySound(SoundPlayer.SoundType.PlayerDeath, transform.position);
            DeathParticleSystem.Play();
            DisableComponents();
            StartCoroutine(DelayParticleStopAndLoadMenu());
        }
    }

    void UpdateStatistics()
    {
        GameObject.Find("StatisticsManagement").GetComponent<PersistentInfoManager>().UpdatePersistentStatistics();
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
        UpdateStatistics();
        GetComponent<SceneLoader>().LoadMenuScene();
    }
}
