using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicManager : MonoBehaviour
{
    public static MusicManager instance;

    private AudioSource audioSource;


    void Awake()
    {
        MakeInstance();

        audioSource = GetComponent<AudioSource>();
    }

    private void MakeInstance() {
        if(instance != null) {
            Destroy(gameObject);
        } else {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }

    public void PlayMusic(bool play) {
        if(play) {
            if(!audioSource.isPlaying) {
                audioSource.Play();
            }
        } else {
            if(audioSource.isPlaying) {
                audioSource.Stop();
            }
        }
    }
}
