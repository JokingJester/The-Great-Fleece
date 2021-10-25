using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
[RequireComponent(typeof(NavMeshAgent))]
public class GuardAI : MonoBehaviour
{
    private Animator _anim;
    private bool _reverse;
    public bool _stopMoving;
    private int _currentTarget;
    [SerializeField] private List<Transform> _waypoints;
    private NavMeshAgent _agent;
    private Vector3 _coinDirection;

    void Start()
    {
        _anim = GetComponent<Animator>();
        _agent = GetComponent<NavMeshAgent>();
        if (_waypoints.Count > 1 && _anim != null)
            _anim.SetBool("Walk", true);
    }

    void Update()
    {
        if (_anim.GetBool("Alerted") == true)
        {
            _stopMoving = true;
            var direction = _coinDirection - transform.position;
            Quaternion rotation = Quaternion.LookRotation(direction, Vector3.up);
            rotation.x = 0;
            rotation.z = 0;
            transform.rotation = rotation;
        }


        if (_stopMoving == true)
            return;
        if(_waypoints.Count > 1 && _waypoints[_currentTarget] != null)
        {
            _agent.SetDestination(_waypoints[_currentTarget].position);

            float distance = Vector3.Distance(transform.position, _waypoints[_currentTarget].position);
            if (distance < 1)
            {
                if (_waypoints.Count - 1 == _currentTarget && _reverse == false || _currentTarget == 0 && _reverse == true)
                {
                    StartCoroutine(IdleRoutine());
                }

                _currentTarget = _reverse == false ? _currentTarget = _currentTarget + 1 : _currentTarget = _currentTarget - 1;
            }
        }
    }

    public void LookAtCoin(Vector3 pos)
    {
        if(_anim != null)
        {
            _coinDirection = pos;
            _anim.SetTrigger("Alert");
            _anim.SetBool("Alerted", true);
            _agent.SetDestination(transform.position);
        }
    }

    IEnumerator IdleRoutine()
    {
        if(_anim != null)
            _anim.SetBool("Walk", false);
        _stopMoving = true;
        _reverse = !_reverse;
        yield return new WaitForSeconds(Random.Range(2, 5));
        if (_anim != null)
            _anim.SetBool("Walk", true);
        _stopMoving = false;
    }
}
