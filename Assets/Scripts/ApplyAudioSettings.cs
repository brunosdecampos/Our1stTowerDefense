using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class ApplyAudioSettings : MonoBehaviour
{
    AudioSource source;
    public bool isMusic = false;
    bool soundOn;

    // Use this for initialization
    void Start ()
    {
        source = GetComponent<AudioSource>();
        soundOn = true;
        if (isMusic)
        {
            if (PlayerPrefs.HasKey("MusicOn"))
            {
                soundOn = Convert.ToBoolean(PlayerPrefs.GetInt("MusicOn"));
            }
        }
        else
        {
            if (PlayerPrefs.HasKey("EffectsOn"))
            {
                soundOn = Convert.ToBoolean(PlayerPrefs.GetInt("EffectsOn"));
            }
        }
        if (!soundOn)
        {
            source.Stop();
        }
	}
	
	// Update is called once per frame
	void Update ()
    {
		
	}
}
