
/*****************************************************************************************
* Sound
*   A wrapper class for Unity Audio class methods. Stores the audio to be used in the 
*   game and methods to manipulate the audio like volume and pitch. Additionally, the 
*   audio can be set to loop for audio like a theme that is needed to repeat throughout
*   a scene. 
*****************************************************************************************/

using UnityEngine.Audio;
using UnityEngine;

[System.Serializable]
public class Sound 
{
    //********************************************************************************
    // Editor Accessible Fields
    //********************************************************************************

    [SerializeField] private string name;
    [SerializeField] private AudioClip clip;
    [SerializeField] [Range(0.0f, 1.0f)] private float volume;
    [SerializeField] private float pitch;
    [SerializeField] private bool loop;

    //********************************************************************************
    // Private Member Data
    //********************************************************************************

    private AudioSource audio_source;

    //********************************************************************************
    // Getters
    //********************************************************************************

    public AudioSource GetAudioSource() { return audio_source; }
    public string GetName() { return name; }

    //********************************************************************************
    // Setters
    //********************************************************************************

    public void InitializeSoundSource(AudioSource _source)
    {
        SetAudioSource(_source);
        audio_source.name = name;
        audio_source.clip = clip;
        audio_source.volume = volume;
        audio_source.pitch = pitch;
        audio_source.loop = loop;

    }

    public void SetAudioSource(AudioSource _source)
    {
        Debug.Assert(_source != null, "AudioSource not initialized.");
        audio_source = _source;
    }

    //********************************************************************************
    // private helpers
    //********************************************************************************


}

