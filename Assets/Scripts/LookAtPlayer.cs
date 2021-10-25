using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAtPlayer : MonoBehaviour
{
    [SerializeField] private Transform _player;
    [SerializeField] private Transform _startCam;

    private void Start()
    {
        Camera.main.transform.position = _startCam.transform.position;
        Camera.main.transform.rotation = _startCam.transform.rotation;
    }
    void Update()
    {
        transform.LookAt(_player);
    }
}
