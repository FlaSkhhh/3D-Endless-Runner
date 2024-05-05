using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GamOverSound : MonoBehaviour
{
    public Sound[] sounds;
    bool walking = false;

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    void GirlAngry()
    {
        sounds[0].source = gameObject.AddComponent<AudioSource>();
        sounds[0].source.clip = sounds[0].clip;
        sounds[0].source.volume = sounds[0].volume;
        sounds[0].source.pitch = sounds[0].pitch;
        sounds[0].source.Play();
    }

    void ManPunch()
    {
        sounds[1].source = gameObject.AddComponent<AudioSource>();
        sounds[1].source.clip = sounds[1].clip;
        sounds[1].source.volume = sounds[1].volume;
        sounds[1].source.pitch = sounds[1].pitch;
        sounds[1].source.Play();
    }

    void GirlWalk()
    {
        if (walking)
        {
            return;
        }
        sounds[2].source = gameObject.AddComponent<AudioSource>();
        sounds[2].source.clip = sounds[2].clip;
        sounds[2].source.volume = sounds[2].volume;
        sounds[2].source.pitch = sounds[2].pitch;
        sounds[2].source.Play();
        Invoke("GirlWalkStop", 2.08f);
        walking = true;
    }

    void GirlWalkStop()
    {
        sounds[2].source.Stop();
    }

    void ManWalk()
    {
        if (walking)
        {
            return;
        }
        sounds[3].source = gameObject.AddComponent<AudioSource>();
        sounds[3].source.clip = sounds[3].clip;
        sounds[3].source.volume = sounds[3].volume;
        sounds[3].source.pitch = sounds[3].pitch;
        sounds[3].source.Play();
        Invoke("ManWalkPause", 2.04f);
        walking = true;
    }

    void ManWalkPause()
    {
        sounds[3].source.Stop();
    }
}
