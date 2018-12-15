using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VoicePacks : MonoBehaviour
{

    /* In this script, I'm creating an array for all the voice lines that will make it easier to call by character when we need them
    The order of voice CLIPs in the array is:
    0 - BuildQue
    1 - HireChef
    2 - FireChef
    3 - SelectRestaurant
    4 - AddRecipe
    5 - GoodTurn
    6 - BadTurn
    7 - NeutralTurn
    8 - TurnRecap
    9 - Win
    

    The order of voice VOICEPACKS in the array is:
    0 - Gordon
    1 - Donald
    2 - Guy
    3 - Shy
    4 - Paula
    5 - Antonio
    */

    

    public AudioClip[] GordonClips, DonaldClips, GuyClips, ShyClips, PaulaClips, AntonioClips, RobotClips;

    public AudioSource voSource;

    public int whatRoundWasIt, whatPlayerWasIt;

    public int randomChanceRestaurant, randomChanceBuildQue, randomChanceHireChef, randomChanceFireChef;

    bool selectRestaurantHasPlayed, buildQueHasPlayed, hireChefHasPlayed, fireChefHasPlayed;  

    //input is what voicepack to use, and output is the corresponding array
    public AudioClip DetermineVoicePack(int voicePack, int clip)
    {
        if (voicePack == 0)
        {
            return GordonClips[clip];
        }
        else if (voicePack == 1)
        {
            return DonaldClips[clip];
        }
        else if (voicePack == 2)
        {
            return GuyClips[clip];
        }
        else if (voicePack == 3)
        {
            return ShyClips[clip];
        }
        else if (voicePack == 4)
        {
            return PaulaClips[clip];
        }
        else if (voicePack == 5)
        {
            return AntonioClips[clip];
        }
        else if (voicePack == 6)
        {
            return RobotClips[clip];
        }
        else
        {
            return null;
        }

    }

    public void PlayBuildQueOpenVO (int voicePack)
    {
        /* 
         * If it's the first time a restaurant has been selected this turn, play this clip.
         * If it's not the first time, randomly play this clip
        */

        if (!buildQueHasPlayed)
        {
            voSource.PlayOneShot(DetermineVoicePack(voicePack, 0));
            Debug.Log("Playing clip 0 from " + voicePack.ToString());

            whatRoundWasIt = GameController.Instance().GetRoundNumber();
            whatPlayerWasIt = GameController.Instance().GetPlayerNumber();
            buildQueHasPlayed = true;
        }
        else if (whatRoundWasIt == GameController.Instance().GetRoundNumber() && whatPlayerWasIt == GameController.Instance().GetPlayerNumber())
        {
            var randomChanceToPlay = Random.Range(0, 100);
            if (randomChanceToPlay >= randomChanceBuildQue)
            {
                voSource.PlayOneShot(DetermineVoicePack(voicePack, 0));
                Debug.Log("Playing clip 0 from " + voicePack.ToString());
            }
        }
        else
        {
            buildQueHasPlayed = false;
            PlayBuildQueOpenVO(voicePack);
        }

    }

    public void PlayHireChefVO (int voicePack)
    {
        /* 
         * If it's the first time a restaurant has been selected this turn, play this clip.
         * If it's not the first time, randomly play this clip
        */

        if (!buildQueHasPlayed)
        {
            voSource.PlayOneShot(DetermineVoicePack(voicePack, 1));
            Debug.Log("Playing clip 1 from " + voicePack.ToString());

            whatRoundWasIt = GameController.Instance().GetRoundNumber();
            whatPlayerWasIt = GameController.Instance().GetPlayerNumber();
            hireChefHasPlayed = true;
        }
        else if (whatRoundWasIt == GameController.Instance().GetRoundNumber() && whatPlayerWasIt == GameController.Instance().GetPlayerNumber())
        {
            var randomChanceToPlay = Random.Range(0, 100);
            if (randomChanceToPlay >= randomChanceHireChef)
            {
                voSource.PlayOneShot(DetermineVoicePack(voicePack, 1));
                Debug.Log("Playing clip 1 from " + voicePack.ToString());
            }
        }
        else
        {
            buildQueHasPlayed = false;
            PlayHireChefVO(voicePack);
        }
    }

    public void PlayFireChefVO(int voicePack)
    {
        /* 
         * If it's the first time a restaurant has been selected this turn, play this clip.
         * If it's not the first time, randomly play this clip
        */

        if (!fireChefHasPlayed)
        {
            voSource.PlayOneShot(DetermineVoicePack(voicePack, 2));
            Debug.Log("Playing clip 2 from " + voicePack.ToString());

            whatRoundWasIt = GameController.Instance().GetRoundNumber();
            whatPlayerWasIt = GameController.Instance().GetPlayerNumber();
            fireChefHasPlayed = true;
        }
        else if (whatRoundWasIt == GameController.Instance().GetRoundNumber() && whatPlayerWasIt == GameController.Instance().GetPlayerNumber())
        {
            var randomChanceToPlay = Random.Range(0, 100);
            if (randomChanceToPlay >= randomChanceHireChef)
            {
                voSource.PlayOneShot(DetermineVoicePack(voicePack, 2));
                Debug.Log("Playing clip 2 from " + voicePack.ToString());
            }
        }
        else
        {
            fireChefHasPlayed = false;
            PlayFireChefVO(voicePack);
        }
    }

    public void PlaySelectRestaurantVO(int voicePack)
    {
        /* 
         * If it's the first time a restaurant has been selected this turn, play this clip.
         * If it's not the first time, randomly play this clip
        */

        if (!selectRestaurantHasPlayed)
        {
            voSource.PlayOneShot(DetermineVoicePack(voicePack, 3));
            Debug.Log("Playing clip 3 from " + voicePack.ToString());

            whatRoundWasIt = GameController.Instance().GetRoundNumber();
            whatPlayerWasIt = GameController.Instance().GetPlayerNumber();
            selectRestaurantHasPlayed = true;
        }
        else if (whatRoundWasIt == GameController.Instance().GetRoundNumber() && whatPlayerWasIt == GameController.Instance().GetPlayerNumber())
        {
            var randomChanceToPlay = Random.Range(0, 100);
            if (randomChanceToPlay >= randomChanceRestaurant)
            {
                voSource.PlayOneShot(DetermineVoicePack(voicePack, 3));
                Debug.Log("Playing clip 3 from " + voicePack.ToString());
            }
        }
        else
        {
            selectRestaurantHasPlayed = false;
            PlaySelectRestaurantVO(voicePack);
        }
    }

    public void PlayAddRecipeVO(int voicePack)
    {
        voSource.PlayOneShot(DetermineVoicePack(voicePack, 4));
        Debug.Log("Playing clip 4 from " + voicePack.ToString());
    }

    public void PlayGoodTurnVO(int voicePack)
    {
        voSource.PlayOneShot(DetermineVoicePack(voicePack, 5));
        Debug.Log("Playing clip 5 from " + voicePack.ToString());
    }

    public void PlayBadTurnVO(int voicePack)
    {
        voSource.PlayOneShot(DetermineVoicePack(voicePack, 6));
        Debug.Log("Playing clip 6 from " + voicePack.ToString());
    }

    public void PlayNeutralTurnVO(int voicePack)
    {
        voSource.PlayOneShot(DetermineVoicePack(voicePack, 7));
        Debug.Log("Playing clip 7 from " + voicePack.ToString());
    }

    public void PlayTurnRecapVO(int voicePack)
    {
        /*
         *  Will this ever be in the game? :(
         */
        voSource.PlayOneShot(DetermineVoicePack(voicePack, 8));
        Debug.Log("Playing clip 8 from " + voicePack.ToString());
    }

    public void PlayWinVO(int voicePack)
    {
        voSource.PlayOneShot(DetermineVoicePack(voicePack, 9));
        Debug.Log("Playing clip 9 from " + voicePack.ToString());
    }
}
