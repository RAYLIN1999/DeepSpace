using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class AudioManager : MonoBehaviour
{
    //Get a single instance of AudioManager
    public static AudioManager instance;

    public AudioType[] AudioTypes;

    private void Awake()
    {
        instance = this;
        foreach (AudioType type in AudioTypes)
        {
            type.Source = gameObject.AddComponent<AudioSource>();

            type.Source.clip = type.Clip;
            type.Source.name = type.Name;
            type.Source.volume = type.Volume;
            type.Source.pitch = type.Pitch;
            type.Source.loop = type.Loop;

        }
    }

    private void Start()
    {
        
    }

    public void Play(string name)
    {
        foreach(AudioType type in AudioTypes)
        {
            if(type.Name == name)
            {
                type.Source.Play();
                return;
            }
        }

        Debug.LogWarning("Can't find this music.");
    }

    public void Pause(string name)
    {
        foreach (AudioType type in AudioTypes)
        {
            if (type.Name == name)
            {
                type.Source.Pause();
                return;
            }
        }

        Debug.LogWarning("Can't find this music.");
    }

    public void Stop(string name)
    {
        foreach (AudioType type in AudioTypes)
        {
            if (type.Name == name)
            {
                type.Source.Stop();
                return;
            }
        }

        Debug.LogWarning("Can't find this music.");
    }
}
