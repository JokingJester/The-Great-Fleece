using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class GameManager : MonoBehaviour
{
    private static GameManager _instance;
    public static GameManager Instance
    {
        get
        {
            if(_instance == null)
            {
                Debug.LogError("Game Manager Is Null");
            }
            return _instance;
        }
    }
    public bool HasCard { get; set; }
    public PlayableDirector _playableDirector;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.S))
        {
            _playableDirector.time = 61.60f;
        }
    }
    private void Awake()
    {
        _instance = this;
    }
}
