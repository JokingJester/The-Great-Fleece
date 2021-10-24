using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraTrigger : MonoBehaviour
{
    [SerializeField] private Transform _cameraProgressionAngle;
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            Camera.main.transform.position = _cameraProgressionAngle.position;
            Camera.main.transform.rotation = _cameraProgressionAngle.rotation;
        }
    }
}
