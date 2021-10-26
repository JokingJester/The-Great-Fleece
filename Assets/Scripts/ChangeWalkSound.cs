using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeWalkSound : MonoBehaviour
{
    public bool onMarble;
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            PlayWalkSound playWalkSound = other.GetComponentInChildren<PlayWalkSound>();
            if(playWalkSound != null)
            {
                playWalkSound._onMarble = onMarble;
            }
        }
    }
}
