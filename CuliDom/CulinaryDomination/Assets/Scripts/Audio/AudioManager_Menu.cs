using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager_Menu : MonoBehaviour {

    public AudioSource menuSource;

    public AudioClip sfx_menu_select_lowpitch, sfx_menu_select_midpitch, sfx_menu_select_highpitch, sfx_bidding_end, sfx_payment_register, sfx_payment_coins;

    public bool paymentTestingRegister = true;

    private void Start()
    {
        //StartCoroutine(TestPlayLow());
    }

    public void PlayMenuSelectLow()
    {
        menuSource.clip = sfx_menu_select_lowpitch;
        //menuSource.PlayOneShot(sfx_menu_select_lowpitch);
        menuSource.Play();
        Debug.Log("Play Menu Select LowPitch");
    }

    public void PlayMenuSelectMid()
    {
        menuSource.PlayOneShot(sfx_menu_select_midpitch);
        Debug.Log("Play Menu Select MidPitch");
    }

    public void PlayMenuSelectHigh()
    {
        menuSource.PlayOneShot(sfx_menu_select_highpitch);
        Debug.Log("Play Menu Select HighPitch");
    }

    public void PlayBiddingEnd()
    {
        menuSource.PlayOneShot(sfx_bidding_end);
        Debug.Log("Play Bidding End");
    }

    public void PlayPayment()
    {
        /*
         * this if condition is only in to test which of these clips sounds better, and can be removed when we decide on this
         */

        if (paymentTestingRegister)
        {
            menuSource.PlayOneShot(sfx_payment_register);
        }
        else
        {
            menuSource.PlayOneShot(sfx_payment_coins);
        }
    }

    IEnumerator TestPlayLow()
    {
        menuSource.Play();
        Debug.Log("Coroutine Played");
        yield return new WaitForSeconds(2.0f);
        StartCoroutine(TestPlayLow());
    }
}
