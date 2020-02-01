using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public AudioClip softSong;
    public AudioClip metalSong;
    public AudioClip gameOverSong;
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

    public void PlayGameOverSong(){
        PlayClip(gameOverSong);
    }

     void PlayClip(AudioClip clip){
        audioSource.clip = clip;
        audioSource.Play();
    }

    public void ChangeMusiCToMetal()
    {

    }
}
