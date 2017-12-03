﻿using System.Collections;
using UnityEngine;

public class EnemyDeathManager : MonoBehaviour
{
    private SoundPlayer BoomBox;
    public ParticleSystem deathAnimation;
    // Use this for initialization
    void Start()
    {
        BoomBox = GameObject.Find("BoomBox").GetComponent<SoundPlayer>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.layer == 12)
        {
            Kill();
            BoomBox.PlaySound(SoundPlayer.SoundType.Explosion, transform.position);
        }
    }

    void Kill()
    {
        PrepareAndPlanParticleDeath();

        foreach (var ps in GetComponents<ProjectileShooter>())
            ps.enabled = false;
        transform.position *= 200;
        Destroy(gameObject, 5f);
    }

    void PrepareAndPlanParticleDeath()
    {
        ParticleSystem ps = Instantiate(deathAnimation);
        ps.transform.position = transform.position;
        Destroy(ps.gameObject, 5f);
    }
}
