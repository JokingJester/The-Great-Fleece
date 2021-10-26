using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayWalkSound : MonoBehaviour
{
    [SerializeField] private AudioClip _carpetSound;
    [SerializeField] private AudioClip _marbleSound;
    public bool _onMarble;
    public void SoftWalk()
    {
        if(_onMarble == false)
            AudioSource.PlayClipAtPoint(_carpetSound, Camera.main.transform.position, 0.5f);
        else
            AudioSource.PlayClipAtPoint(_marbleSound, Camera.main.transform.position, 0.5f);
    }
}
