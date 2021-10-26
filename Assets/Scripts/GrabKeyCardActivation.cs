using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrabKeyCardActivation : MonoBehaviour
{
    [SerializeField] private GameObject _cutscene;
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            Destroy(GetComponent<BoxCollider>());
            _cutscene.SetActive(true);
            StartCoroutine(DisableCutsceneRoutine());
        }
    }

    IEnumerator DisableCutsceneRoutine()
    {
        yield return new WaitForSeconds(6f);
        _cutscene.SetActive(false);
    }
}
