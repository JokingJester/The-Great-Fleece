using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VoiceOverTrigger : MonoBehaviour
{
    [SerializeField] private AudioClip _audioClip;
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            Camera.main.transform.GetComponent<AudioSource>().PlayOneShot(_audioClip, 0.7f);
        }
    }
}
