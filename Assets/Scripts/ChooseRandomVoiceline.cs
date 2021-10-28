using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChooseRandomVoiceline : MonoBehaviour
{
    [SerializeField] private GameObject _vo1;
    [SerializeField] private GameObject _vo2;
    [SerializeField] private PlaySubtitles _playSubtitles;
    private void OnEnable()
    {
        int randomNumber = Random.Range(0, 3);
        if(randomNumber == 1 || randomNumber == 2)
        {
            _vo2.SetActive(false);
            _playSubtitles.captured = true;
            StartCoroutine(_playSubtitles.PlaySubtitle(5));
        }
        else
        {
            _vo1.SetActive(false);
            StartCoroutine(_playSubtitles.PlaySubtitle(6));
        }
    }
}
