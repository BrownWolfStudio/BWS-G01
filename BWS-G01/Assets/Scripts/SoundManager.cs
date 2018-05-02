using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    // Singleton Instance
    public static SoundManager Instance = null;

    // AudioSource from which AudioClip will be played
    private AudioSource SoundEffectsAudio;

    // This will run when the object loads into the scene
    void Start ()
    {
        // Prevents this gameObject from getting destroyed between scene changes
        DontDestroyOnLoad(gameObject);

        // Check if there is any existing instance of SoundManager
        // If not then assign this class to Instance
        if (Instance == null)
        {
            Instance = this;
        }

        // If there is alreads an Instance than destroy the GameObject to
        // which this script is attached to avoid multiple instance
        // In theory, this block should never run
        // If it runs then there is something very wrong
        else if (Instance != this)
        {
            Destroy(gameObject);
        }
        
        // Get AudioSource attached to this gameObject
        // and assign it
        SoundEffectsAudio = GetComponent<AudioSource>();
    }

    // A public method to play audio from any script
    // To play it use: SoundManager.Instance.PlayOneShot(clip);
    public void PlayOneShot (AudioClip clip)
    {
        // Plays the audio file
        SoundEffectsAudio.PlayOneShot(clip);
    }

    // A public method to set the volume for the AudioSource
    // To set the volume use: SoundManager.Instance.SetVolume(10f);
    // Passed volume should be between 0 - 100
    public void SetVolume (float vol)
    {
        // Sets the volume
        SoundEffectsAudio.volume = vol * 1 / 100;
    }
}
