using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MazzaAudioManager : MonoBehaviour
{
    private static MazzaAudioManager _instance;
    public static MazzaAudioManager Instance { get { return _instance; } }
    private AudioSource audioSource;

    public Object[] hits;

    public float volume = 1;
    private void Awake() {
        if (_instance != null && _instance != this) { 
            Destroy(this.gameObject); 
        } else { 
            _instance = this;
        }
    }
    void Start() {
        audioSource = GetComponent<AudioSource>();
        hits = Resources.LoadAll("SFX/Mazza", typeof(AudioClip));
    }

    public void PlayHit() {
        PlaySound(hits);
    }
    private void PlaySound(Object[] array){
        int randomRange = Random.Range(0, (array.Length-1));
        AudioClip arrayClip = array[randomRange] as AudioClip;
        audioSource.PlayOneShot(arrayClip, volume);
    }
}
