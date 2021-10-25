using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class GuardVision : MonoBehaviour
{
    private Animator _anim;
    private NavMeshAgent _agent;
    [SerializeField] private GameObject _gameOverCutscene;

    private void Start()
    {
        _anim = GetComponentInParent<Animator>();
        _agent = GetComponentInParent<NavMeshAgent>();
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            Player player = other.gameObject.GetComponent<Player>();
            if (player != null)
                player.StopMoving();
            StartCoroutine(CaptureRoutine());
        }
    }

    IEnumerator CaptureRoutine()
    {
        _agent.speed = 0;
        _agent.angularSpeed = 50;
        if (_anim != null)
            _anim.SetTrigger("Capture");
        yield return new WaitForSeconds(1f);
        _gameOverCutscene.SetActive(true);
    }
}
