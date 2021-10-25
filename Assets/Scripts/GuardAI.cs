using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
[RequireComponent(typeof(NavMeshAgent))]
public class GuardAI : MonoBehaviour
{
    private bool _reverse;
    private bool _stopMoving;
    private int _currentTarget;
    [SerializeField] private List<Transform> _waypoints;
    private NavMeshAgent _agent;

    void Start()
    {
        _agent = GetComponent<NavMeshAgent>();
    }

    void Update()
    {
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

    IEnumerator IdleRoutine()
    {
        _stopMoving = true;
        _reverse = !_reverse;
        yield return new WaitForSeconds(Random.Range(2, 5));
        _stopMoving = false;
    }
}
