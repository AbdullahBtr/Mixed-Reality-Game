using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{

    public AudioSource audioSource;
    public AudioClip[] audioClips;




    void Awake()
    {
        audioSource = GetComponent<AudioSource>();
    }
    // Start is called before the first frame update
    void Start()
    {
        playSound(0);
    }


    public void playSound(int index)
    {
        audioSource.clip = audioClips[index];
        audioSource.Play();
    }

    public void stopSound(int index)
    {
        audioSource.clip = audioClips[index];
        audioSource.Stop();
    }

}
