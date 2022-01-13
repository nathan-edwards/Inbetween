using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public static class SoundManager
{
    
    // List of possible sounds to assign sound assets to
    public enum Sound
    {
        PlayerPickup,
        PlayerMove,
        PlayerAttack,
        EnemyHit,
        EnemyDie,
    }

    // A dictionary that will store the last time a certain sound has been played to
    // easier control how often a sound is player such as the player movement
    private static Dictionary<Sound, float> soundTimerDictionary;

    // Initializes the dictionary to reference later
    public static void Initialize()
    {
        soundTimerDictionary = new Dictionary<Sound, float>();
        soundTimerDictionary[Sound.PlayerMove] = 0f;
    }
    
    // Function that plays the audio on the object this is called when a position for the sound is not required
    public static void PlaySound(Sound sound)
    {
        if (CanPlaySound(sound))
        {
            // Creates a new sound object in the scene to play sound
            GameObject soundGameObject = new GameObject("Sound");
            // Attaches a AudioSource component to the newly created Sound game object
            AudioSource audioSource = soundGameObject.AddComponent<AudioSource>();
            // Places the audio clip into the object and plays it once
            audioSource.PlayOneShot(GetAudioClip(sound));
        }
    }

    // Function that plays the audio on the object this is called when a position for the sound is required
    public static void PlaySound(Sound sound, Vector3 position)
    {
        if (CanPlaySound(sound))
        {
            // Creates a new sound object in the scene to play sound
            GameObject soundGameObject = new GameObject("Sound");
            // Moves the object to the position given in the argument
            soundGameObject.transform.position = position;
            // Attaches a AudioSource component to the newly created Sound game object
            AudioSource audioSource = soundGameObject.AddComponent<AudioSource>();
            // Places the audio clip into the object and plays it once
            audioSource.clip = GetAudioClip(sound);
            audioSource.Play();
        }
    }
 
    // This function is used to prevent a sound from being played too many times at once by introducing an delay
    private static bool CanPlaySound(Sound sound)
    {
        switch (sound)
        {
            // Any sound that does not need to have a interval will switch here
            default:
                return true;
            // The player sound is played repeatedly, therefore a interval is required
            case Sound.PlayerMove:
                if (soundTimerDictionary.ContainsKey(sound))
                {
                    float lastTimePlayed = soundTimerDictionary[sound];
                    // A half a second delay is added between each sound play
                    float playerMoveTimerMax = .5f;
                    if (lastTimePlayed + playerMoveTimerMax < Time.time)
                    {
                        soundTimerDictionary[sound] = Time.time;
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
                else
                {
                    return true;
                }
        }
    }

    // Retrieves the correct audio clip from the game assets object in the scene
    private static AudioClip GetAudioClip(Sound sound)
    {
        foreach (GameAssets.SoundAudioClip soundAudioClip in GameAssets.i.soundAudioClipArray)
        {
            if (soundAudioClip.sound == sound)
            {
                return soundAudioClip.audioClip;
            }
        }
        Debug.LogError("Sound " + sound + " not found");
        return null;
    }
}
