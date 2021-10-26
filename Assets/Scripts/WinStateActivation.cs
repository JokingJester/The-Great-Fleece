using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinStateActivation : MonoBehaviour
{
    [SerializeField] private GameObject _winCutscene;
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player" && GameManager.Instance.HasCard == true)
        {
            _winCutscene.SetActive(true);
        }
    }
}
