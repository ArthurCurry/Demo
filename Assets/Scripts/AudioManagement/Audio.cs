using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Audio
{
    public class AudioCreate
    {
        public void AddAudioSource(GameObject a)
        {
            a.AddComponent<AudioSource>();
        }

        public void AddAudioClip(GameObject a , string path)
        {
            a.GetComponent<AudioSource>().clip = Resources.Load<AudioClip>(path);
        }
    }

    public class AudioPlay
    {
        public void Play(GameObject a)
        {
            if (!a.GetComponent<AudioSource>().isPlaying)
            {
                a.GetComponent<AudioSource>().Play();
            }
        }

        public void PlayOnShot(GameObject a, string address)
        {
            AudioClip clip = Resources.Load<AudioClip>(address);
            a.GetComponent<AudioSource>().PlayOneShot(clip);
        }

        public void PlayClipAtPoint(AudioClip clip, Vector3 position, float volume)
        {
            AudioSource.PlayClipAtPoint(clip, position, volume);
        }

        public void PlayClipAtPoint(AudioClip clip, Vector3 position)
        {
            AudioSource.PlayClipAtPoint(clip, position);
        }
    }

    public class AudioPause
    {
        public void Pause(GameObject a)
        {
            if (a.GetComponent<AudioSource>().isPlaying)
            {
                a.GetComponent<AudioSource>().Pause();
            }
        }

        public void UnPause(GameObject a)
        {
            if(!a.GetComponent <AudioSource >().isPlaying)
            {
                a.GetComponent<AudioSource>().UnPause();
            }
        }
    }

    public class AuidoStop
    {
        public void Stop(GameObject a)
        {
            if(a.GetComponent<AudioSource>().isPlaying)
            {
                a.GetComponent<AudioSource>().Stop();
            }
        }
    }

    public class AudioManager
    {
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
}
