using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Audio;

public class AudioPlay{

    private AudioPlay instance;


    public AudioClip AddAudioClip(string path)
    {
        AudioClip clip = Resources.Load<AudioClip>(path);
        return clip;
    }

    public void AddAudioSource(GameObject a)
    {
        a.AddComponent<AudioSource>();
    }

    public void AddAudioClip(GameObject a, string path)
    {
        a.GetComponent<AudioSource>().clip = Resources.Load<AudioClip>(path);
    }

    public void Play(GameObject a)
    {
        if (!a.GetComponent<AudioSource>().isPlaying)
        {
            a.GetComponent<AudioSource>().Play();
        }
    }

    public void PlayOnShot(GameObject a, string address, float volume)
    {
        AudioClip clip = Resources.Load<AudioClip>(address);
        a.GetComponent<AudioSource>().PlayOneShot(clip, volume);
    }

    public void PlayClipAtPoint(AudioClip clip, Vector2 position, float volume)
    {
        AudioSource.PlayClipAtPoint(clip, position, volume);
    }

    public void PlayClipAtPoint(AudioClip clip, Vector2 position)
    {
        AudioSource.PlayClipAtPoint(clip, position);
    }

    public void Pause(GameObject a)
    {
        if (a.GetComponent<AudioSource>().isPlaying)
        {
            a.GetComponent<AudioSource>().Pause();
        }
    }

    public void UnPause(GameObject a)
    {
        if (!a.GetComponent<AudioSource>().isPlaying)
        {
            a.GetComponent<AudioSource>().UnPause();
        }
    }

    public void Stop(GameObject a)
    {
        if (a.GetComponent<AudioSource>().isPlaying)
        {
            a.GetComponent<AudioSource>().Stop();
        }
    }

    public void ChangeStatus(AudioSource toChange, AudioClip clip, bool mute, bool playOnWake, bool loop, float volume, float pitch)
    {
        toChange.clip = clip;
        toChange.mute = mute;
        toChange.playOnAwake = playOnWake;
        toChange.loop = loop;
        toChange.volume = volume;
        toChange.pitch = pitch;
    }
}
