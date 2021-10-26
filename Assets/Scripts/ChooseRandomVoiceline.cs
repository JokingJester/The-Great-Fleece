using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChooseRandomVoiceline : MonoBehaviour
{
    [SerializeField] private GameObject _vo1;
    [SerializeField] private GameObject _vo2;
    private void OnEnable()
    {
        int randomNumber = Random.Range(0, 3);
        if(randomNumber == 1 || randomNumber == 2)
        {
            _vo2.SetActive(false);
        }
        else
        {
            _vo1.SetActive(false);
        }
    }
}
