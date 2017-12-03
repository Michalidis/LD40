using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicPlayer : MonoBehaviour
{

    public GameObject MusicTracks_Container;
    private AudioSource[] MusicTracks;


    // Use this for initialization
    void Start()
    {
        MusicTracks = MusicTracks_Container.GetComponents<AudioSource>();
        StartCoroutine(PlayMusic());
    }

    // Update is called once per frame
    void Update()
    {

    }

    IEnumerator PlayMusic()
    {
        AudioSource[] unplayedTracks = new AudioSource[MusicTracks.Length];
        MusicTracks.CopyTo(unplayedTracks, 0);

        yield return new WaitForSeconds(0.3f);
        while (true)
        {
            if (unplayedTracks.Length > 0)
            {
                AudioSource track = unplayedTracks[GetRandomIndex(unplayedTracks)];
                track.Play();
                yield return new WaitForSeconds(track.clip.length);
            }
            else
                MusicTracks.CopyTo(unplayedTracks, 0);
        }
    }

    private int GetRandomIndex(AudioSource[] collection)
    {
        int rnd_index = Random.Range(0, collection.Length);
        return rnd_index;
    }

}
