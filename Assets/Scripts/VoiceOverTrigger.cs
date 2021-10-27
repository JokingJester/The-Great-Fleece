using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VoiceOverTrigger : MonoBehaviour
{
    [SerializeField] private AudioClip _audioClip;
    [SerializeField] private PlaySubtitles _playSubtitles;
    [SerializeField] private int number;
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            StartCoroutine(_playSubtitles.PlaySubtitle(number));
            Camera.main.transform.GetComponent<AudioSource>().PlayOneShot(_audioClip, 0.7f);
            Destroy(GetComponent<BoxCollider>());
        }
    }
}
