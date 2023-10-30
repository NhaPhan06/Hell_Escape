using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class AudioManager : MonoBehaviour
{

    // Start is called before the first frame update
    [Header("--------------- Audio Source-----------------")]
    [SerializeField] AudioSource musicSource;
    [SerializeField] AudioSource SFXSource;
    [Header("--------------- Audio Clip-----------------")]
    public AudioClip bacground;
    public AudioClip chieu1;
    public AudioClip chieu2;
    public AudioClip nextScene;
    public AudioClip win;

    private void Start()
    {
        musicSource.clip = bacground;
        musicSource.Play();
    }

    public void PlaySFX(AudioClip clip)
    {
        SFXSource.PlayOneShot(clip);
    }
}
