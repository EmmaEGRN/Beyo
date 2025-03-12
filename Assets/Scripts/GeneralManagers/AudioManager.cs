using UnityEngine;
using UnityEngine.Audio;
using System;
public class AudioManager : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public Sound[] sounds;

    void Awake()
    {
        foreach (Sound s in sounds)
        {

            s.source = gameObject.AddComponent<AudioSource>();
            s.source.clip = s.clip;
            s.source.volume = s.volume;
            s.source.pitch = s.pitch;
            s.source.name = s.name;
            s.source.loop = s.loop;
        }
    }
    // Update is called once per frame
    public void Play(String name)
    {
        
       Sound s = Array.Find(sounds, sound => sound.name == name);
        if (s == null) {
            Debug.LogWarning("Sound " + name + " not found!");
            return;
                }
        s.source.Play();
    } 
}
