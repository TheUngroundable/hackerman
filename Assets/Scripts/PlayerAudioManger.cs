using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAudioManger : MonoBehaviour
{
    private static PlayerAudioManger _instance;
    public static PlayerAudioManger Instance { get { return _instance; } }
    private AudioSource audioSource;

    public Object[] steps;
    public Object[] swearings;

    public float volume;
    private void Awake() {
        if (_instance != null && _instance != this) { 
            Destroy(this.gameObject); 
        } else { 
            _instance = this;
        }
    }
    void Start() {
        audioSource = GetComponent<AudioSource>();
        steps = Resources.LoadAll("SFX/Steps", typeof(AudioClip));
        swearings = Resources.LoadAll("SFX/Imprecazioni", typeof(AudioClip));
    }

    public void playMovementSound() {
        PlaySound(steps);
    }

    public void playSwearingsSound() {   
        PlaySound(swearings);
    }

    private void PlaySound(Object[] array){
        int randomRange = Random.Range(0, (array.Length-1));
        AudioClip arrayClip = array[randomRange] as AudioClip;
        audioSource.PlayOneShot(arrayClip, volume);
    }
}
