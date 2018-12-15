using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour {

    public AudioClip amb_ambiance_rural, amb_ambiance_suburban, amb_ambiance_urban;
    //public AudioClip sfx_menu_select_lowpitch, sfx_menu_select_midpitch, sfx_menu_select_highpitch;

    public float ruralVolume = .001f, suburbanVolume = .005f, urbanVolume = .003f;

    AudioSource ambianceSource;

    public GameObject menu/*, vo*/;

    private void Awake()
    {
        ambianceSource = GetComponent<AudioSource>();
        
    }

    public void PlayAmbienceRural ()
    {
        if (ambianceSource.clip != amb_ambiance_rural)
        {
            ambianceSource.clip = amb_ambiance_rural;
            ambianceSource.Stop();
        }

        if (!ambianceSource.isPlaying)
        {
            ambianceSource.volume = ruralVolume;
            ambianceSource.Play();
            Debug.Log("Playing Rural Ambience");
        }
        else
        {
            Debug.Log("Rural Ambiance is already playing");
        }
    }

    public void PlayAmbienceSuburban ()
    {
        if (ambianceSource.clip != amb_ambiance_suburban)
        {
            ambianceSource.clip = amb_ambiance_suburban;
            ambianceSource.Stop();
        }

        if (!ambianceSource.isPlaying)
        {
            ambianceSource.volume = suburbanVolume;
            ambianceSource.Play();
            Debug.Log("Playing Suburban Ambiance");
        }
        else
        {
            Debug.Log("Suburban Ambiance is already playing");
        }
    }

    public void PlayAmbienceUrban ()
    {
        if (ambianceSource.clip != amb_ambiance_urban)
        {
            ambianceSource.clip = amb_ambiance_urban;
            ambianceSource.Stop();
        }

        if (!ambianceSource.isPlaying)
        {
            ambianceSource.volume = urbanVolume;
            ambianceSource.Play();
            Debug.Log("Playing Urban Ambience");
        }
        else
        {
            Debug.Log("Urban Ambiance is already playing");
        }
    }

    
    public void PlayMenuSelectLow()
    {
        menu.GetComponent<AudioManager_Menu>().PlayMenuSelectLow();
    }

    public void PlayMenuSelectMid()
    {
        menu.GetComponent<AudioManager_Menu>().PlayMenuSelectMid();
    }

    public void PlayMenuSelectHigh()
    {
        menu.GetComponent<AudioManager_Menu>().PlayMenuSelectHigh();
    }
    

}
