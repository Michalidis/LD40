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
        List<AudioSource> unplayedTracks = new List<AudioSource>();
        foreach (var track in MusicTracks)
            unplayedTracks.Add(track);

        yield return new WaitForSeconds(0.3f);
        while (true)
        {
            if (unplayedTracks.Count > 0)
            {
                int trackIndex = GetRandomIndex(unplayedTracks);
                AudioSource track = unplayedTracks[trackIndex];
                unplayedTracks.RemoveAt(trackIndex);
                track.Play();
                yield return new WaitForSeconds(track.clip.length);
            }
            else
                foreach (var track in MusicTracks)
                    unplayedTracks.Add(track);
        }
    }

    private int GetRandomIndex(List<AudioSource> collection)
    {
        int rnd_index = Random.Range(0, collection.Count);
        return rnd_index;
    }

}
