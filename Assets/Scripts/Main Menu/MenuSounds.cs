using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuSounds : MonoBehaviour
{

    public AudioSource pressed;
    public AudioSource entered;
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void PlayPressed()
    {
        pressed.Play();
    }
    public void PlayEntered()
    {
        entered.Play();
    }
}
