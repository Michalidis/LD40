using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundPlayer : MonoBehaviour
{

    public GameObject player;

    public GameObject ProjectileShootingSounds_Container;
    public GameObject Explosion_Container;
    public GameObject Deflect_Container;
    public GameObject Bounce_Container;
    public GameObject Swish_Container;

    private AudioSource[] ProjectileShootingSounds;
    private AudioSource[] Explosions;
    private AudioSource[] Deflects;
    private AudioSource[] Bounces;
    private AudioSource[] Swishes;
    // Use this for initialization
    void Start()
    {
        ProjectileShootingSounds = ProjectileShootingSounds_Container.GetComponents<AudioSource>();
        Explosions = Explosion_Container.GetComponents<AudioSource>();
        Deflects = Deflect_Container.GetComponents<AudioSource>();
        Bounces = Bounce_Container.GetComponents<AudioSource>();
        Swishes = Swish_Container.GetComponents<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void PlaySound(SoundType sound, Vector3 soundSource)
    {
        switch (sound)
        {
            case SoundType.ProjectileShootSound:
                Play(ProjectileShootingSounds);
                break;
            case SoundType.Explosion:
                Play(Explosions);
                break;
            case SoundType.Deflect:
                Play(Deflects);
                break;
            case SoundType.BounceOffWalls:
                Play(Bounces);
                break;
            case SoundType.Swish:
                Play(Swishes);
                break;
            default:
                break;
        }
    }

    private void Play(AudioSource[] sounds)
    {
        int rnd_num = Random.Range(0, sounds.Length - 1);
        sounds[rnd_num].Play();
    }
    public enum SoundType
    {
        ProjectileShootSound,
        Explosion,
        Deflect,
        BounceOffWalls,
        Swish
    }
}
