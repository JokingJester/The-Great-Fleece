using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
[RequireComponent(typeof(NavMeshAgent))]
public class Player : MonoBehaviour
{
    private Animator _anim;
    private SpriteRenderer _rippleRenderer;
    private bool _thrownCoin;
    private NavMeshAgent _agent;
    [SerializeField] private Animator _rippleAnim;
    [SerializeField] private AudioClip _coinSound;
    [SerializeField] private GameObject _coinPrefab;
    void Start()
    {
        _agent = GetComponent<NavMeshAgent>();
        _anim = GetComponentInChildren<Animator>();
        _rippleRenderer = _rippleAnim.GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        bool clickedLeftMouseButton = Input.GetMouseButtonDown(0);
        bool clickedRightMouseButton = Input.GetMouseButtonDown(1);
        if (clickedLeftMouseButton == true && _agent.speed != 0 || clickedRightMouseButton == true && _thrownCoin == false)
        {
            RaycastHit hitInfo;
            if(Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hitInfo))
            {
                _rippleAnim.SetTrigger("Ripple");
                GameObject ripple = _rippleAnim.gameObject;
                ripple.transform.position = hitInfo.point;
                if (clickedLeftMouseButton == true)
                {
                    _agent.SetDestination(hitInfo.point);
                    _rippleRenderer.color = new Color(255, 255, 255, 255);
                }
                else
                {
                    StartCoroutine(ThrowRoutine());
                    _thrownCoin = true;
                    GameObject coin = Instantiate(_coinPrefab, _rippleAnim.gameObject.transform.position, Quaternion.identity);
                    coin.transform.position = new Vector3(coin.transform.position.x, -2, coin.transform.position.z);
                    ripple.transform.position = new Vector3(ripple.transform.position.x, -1.97f, ripple.transform.position.z);
                    _rippleRenderer.color = new Color(242, 255, 0, 255);
                    AudioSource.PlayClipAtPoint(_coinSound, Camera.main.transform.position, 0.5f);
                    DistractClosestGuard(hitInfo.point);
                }
            }
        }

        if(_agent.speed != 0)
        {
            bool walk = _agent.remainingDistance == 0 ? false : true;
            _anim.SetBool("Walk", walk);
        }
    }

    public void StopMoving()
    {
        _agent.speed = 0;
        _agent.SetDestination(transform.position);
        _anim.SetBool("Walk", false);
    }

    public void DistractClosestGuard(Vector3 pos)
    {
        GameObject[] allGuards = GameObject.FindGameObjectsWithTag("Guard1");
        GameObject closestGuard = null;
        float closestDistance = 1000;
        float distance;
        foreach(var guard in allGuards)
        {
            distance = Vector3.Distance(pos, guard.transform.position);
            if(distance < closestDistance)
            {
                closestDistance = distance;
                closestGuard = guard.gameObject;
            }
        }
        if(closestGuard != null)
        closestGuard.GetComponent<GuardAI>().LookAtCoin(pos);
    }

    IEnumerator ThrowRoutine()
    {
        StopMoving();
        _anim.SetTrigger("Throw");
        yield return new WaitForSeconds(1.4f);
        _agent.speed = 6;
    }
}
