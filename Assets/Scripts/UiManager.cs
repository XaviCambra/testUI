using FMODUnity;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UiManager : MonoBehaviour
{
    public void PlaySound(EventReference sound)
    {
        AudioManager.instance.PlayOneShot(sound);
    }

    public void PlaySound(string sound)
    {
        AudioManager.instance.PlayOneShot(sound);
    }
}
