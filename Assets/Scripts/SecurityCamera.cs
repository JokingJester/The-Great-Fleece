using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SecurityCamera : MonoBehaviour
{
    private Animator _anim;
    [SerializeField] private GameObject _redCone;
    [SerializeField] private GameObject _gameOverCutscene;

    private void Start()
    {
        _anim = GetComponentInParent<Animator>();
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            Player player = other.GetComponent<Player>();
            if (player != null)
                player.StopMoving();
            StartCoroutine(FreezeRoutine());
        }
    }

    IEnumerator FreezeRoutine()
    {
        _anim.enabled = false;
        _redCone.transform.rotation = this.transform.rotation;
        this.GetComponent<MeshRenderer>().enabled = false;
        _redCone.SetActive(true);
        yield return new WaitForSeconds(0.5f);
        _gameOverCutscene.SetActive(true);
    }
}
