using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Audio : MonoBehaviour
{
    public AudioSource audioSource;
    public AudioClip[] soundtrack;
    public AudioClip currentTrack;
    public int currentSceneNum = 0;

    void Start()
    {
        audioSource = gameObject.GetComponent<AudioSource>();
        
    }

    void Awake() {
        DontDestroyOnLoad(this.gameObject);
    }
    void Update()
    {
        audioSource = gameObject.GetComponent<AudioSource>();
        currentTrack = audioSource.clip;
        Scene currentScene = SceneManager.GetActiveScene();
        switch (currentScene.name) {
            case "Main":
                if (currentSceneNum == 0) {
                    audioSource.clip = soundtrack[2];
                    audioSource.Play();
                    currentSceneNum++;
                }
                break;
            case "Credits":
                if(currentSceneNum == 1) {
                    audioSource.clip = soundtrack[3];
                    audioSource.Play();
                    currentSceneNum++;
                }
                break;
        }
    }

}
