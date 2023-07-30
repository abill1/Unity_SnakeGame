
/*****************************************************************************************
* AudioManager
*   Stores all sound objects in the Game. 
*   Any sound can be played by using PlaySound() and passing in the name from the Sound 
*   Class Object
*   Any sound can be stopped by using StopSound() and passing in the name from the Sound 
*   Class Object
*****************************************************************************************/

using UnityEngine;
using UnityEngine.Audio;
using System;

public class AudioManager : MonoBehaviour
{
    //********************************************************************************
    // Singleton
    //********************************************************************************

    private static AudioManager Instance;

    //********************************************************************************
    // Editor Accessible Fields
    //********************************************************************************

    [SerializeField] private Sound[] sounds;

    //********************************************************************************
    // Unity Code
    //********************************************************************************

    void Awake()
    {
        DontDestroyOnLoad(this);
        if (AudioManager.GetInstance() == null)
        {
            Instance = this;

            foreach (Sound sound in sounds)
            {
                AudioSource source = gameObject.AddComponent<AudioSource>();
                sound.InitializeSoundSource(source);

            }
        }
    }

    //********************************************************************************
    // Utility Methods
    //********************************************************************************

    public static void PlaySound(string _soundName)
    {
        Sound sound = Array.Find(AudioManager.GetInstance().sounds, sound => sound.GetName() == _soundName);
        if(sound == null)
            Debug.Log("Unable to find sound with name " + _soundName);

        sound.GetAudioSource().Play();
        
    }

    public static void StopSound(string _soundName)
    {
        Sound sound = Array.Find(AudioManager.GetInstance().sounds, sound => sound.GetName() == _soundName);
        if (sound == null)
            Debug.Log("Unable to find sound with name " + _soundName);

        sound.GetAudioSource().Stop();

    }

    //********************************************************************************
    // Get Singleton Instance
    //********************************************************************************

    public static AudioManager GetInstance() { return Instance; }

}

