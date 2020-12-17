using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuSettings : MonoBehaviour
{
    private AudioSource audioSrc;

    private float musicVolume = 0f;

    void Start()
    {
        audioSrc = GetComponent<AudioSource>();
    }

    void Update()
    {
        audioSrc.volume = musicVolume;
        PlayerPrefs.SetFloat("volume", musicVolume);
    }

    public void SetVolume(float vol)
    {
        musicVolume = vol;
    }
}
