using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayRainSound : MonoBehaviour
{
    public AudioSource audioSource;
    private void OnTriggerStay(Collider other)
    {
        if(other.tag == "Player")
        {
            audioSource.volume = 0.8f;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if(other.tag == "Player")
        {
            audioSource.volume = 0.4f;
        }
    }
}
