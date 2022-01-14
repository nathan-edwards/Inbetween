using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.Audio;

public static class SoundManager
{
    
    // List of possible sounds to assign sound assets to
    public enum Sound
    {
        PlayerPickup,
        PlayerMove,
        PlayerAttack,
        PlayerHit,
        PlayerDeath,
        EnemyHit,
        EnemyDie,
        EnemyAttack,
    }

    // A dictionary that will store the last time a certain sound has been played to
    // easier control how often a sound is player such as the player movement
    private static Dictionary<Sound, float> soundTimerDictionary;
    private static GameObject oneShotGameObject;
    private static AudioSource oneShotAudioSource;
    private static AudioMixer _mixer = Resources.Load("MainMixer") as AudioMixer;
    private static AudioMixerGroup _mixerGroup = _mixer.FindMatchingGroups(string.Empty)[0];


    // Initializes the dictionary to reference later
    public static void Initialize()
    {
        soundTimerDictionary = new Dictionary<Sound, float>();
        soundTimerDictionary[Sound.PlayerMove] = 0f;
        soundTimerDictionary[Sound.PlayerHit] = 0f;
        soundTimerDictionary[Sound.EnemyAttack] = 0f;

    }
    
    // Function that plays the audio on the object this is called when a position for the sound is not required
    public static void PlaySound(Sound sound)
    {
        if (CanPlaySound(sound))
        {
            if (oneShotGameObject == null)
            {
                // Creates a new sound object in the scene to play sound
                oneShotGameObject = new GameObject("One Shot Sound");
                // Attaches a AudioSource component to the newly created Sound game object
                oneShotAudioSource = oneShotGameObject.AddComponent<AudioSource>();
                oneShotAudioSource.outputAudioMixerGroup = _mixerGroup;

            }
            
            // Places the audio clip into the object and plays it once
            oneShotAudioSource.PlayOneShot(GetAudioClip(sound));
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
            audioSource.outputAudioMixerGroup = _mixerGroup;
            audioSource.Play();
            
            Object.Destroy(soundGameObject, audioSource.clip.length);
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
            case Sound.PlayerHit:
                if (soundTimerDictionary.ContainsKey(sound))
                {
                    float lastTimePlayed = soundTimerDictionary[sound];
                    // A half a second delay is added between each sound play
                    float playerHitTimerMax = 1f;
                    if (lastTimePlayed + playerHitTimerMax < Time.time)
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
            case Sound.EnemyAttack:
                if (soundTimerDictionary.ContainsKey(sound))
                {
                    float lastTimePlayed = soundTimerDictionary[sound];
                    // A half a second delay is added between each sound play
                    float enemyAttackTimerMax = 1f;
                    if (lastTimePlayed + enemyAttackTimerMax < Time.time)
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
