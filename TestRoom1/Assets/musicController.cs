using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class musicController : MonoBehaviour
{
    private AudioSource audioSrc;

    private float musicVolume = 0f;

    void Start()
    {
        audioSrc = GetComponent<AudioSource>();
        audioSrc.volume = PlayerPrefs.GetFloat("volume");
    }

    void Update()
    {
        audioSrc.volume = PlayerPrefs.GetFloat("volume");
    }

    public void SetVolume(float vol)
    {
        musicVolume = vol;
    }
}
