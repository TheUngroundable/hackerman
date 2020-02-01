using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public AudioClip softSong;
    public AudioClip metalSong;
    private AudioSource audioSource;
    void Start() {
        audioSource = GetComponent<AudioSource>();
        PlayClip(softSong);
    }

    public void PlaySoftSong()
    {
        PlayClip(softSong);
    }

    public void PlayMetalSong()
    {
        PlayClip(metalSong);
    }

     void PlayClip(AudioClip clip){
        audioSource.clip = clip;
        audioSource.Play();
    }

    public void ChangeMusiCToMetal()
    {

    }
}
