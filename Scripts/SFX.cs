using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SFX : MonoBehaviour
{
    public AudioSource audioSource;
    public AudioClip[] sfxtrack;
    public AudioClip currentTrack;

    public bool button = true;

    void Start()
    {

    }


    void Update()
    {
        currentTrack = audioSource.clip;
    }

    public void buttonPress() {
        if(button) {
            audioSource.clip = sfxtrack[0];
            audioSource.Play();
            button = false;
        }
        else {
            audioSource.clip = sfxtrack[1];
            audioSource.Play();
            button = true;
        }
    }

    public void destroyPlanet() {
        audioSource.clip = sfxtrack[4];
        audioSource.Play();
    }

    public void sparePlanet() {
        audioSource.clip = sfxtrack[5];
        audioSource.Play();
    }

    public void zoomIn() {
        audioSource.clip = sfxtrack[8];
        audioSource.Play();
    }

    public void zoomOut() {
        audioSource.clip = sfxtrack[9];
        audioSource.Play();
    }
}
