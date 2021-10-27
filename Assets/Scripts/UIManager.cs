using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    private static UIManager _instance;
    public static UIManager Instance
    {
        get
        {
            if(_instance == null)
            {
                Debug.LogError("NUll");
            }
            return _instance;
        }
    }

    public GameObject _blackBG;
    public Text _subtitleText;
    private void Awake()
    {
        _instance = this;
    }
    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void Quit()
    {
        SceneManager.LoadScene(0);
    }

    public void DisplaySubtitleText(string message)
    {
        _blackBG.SetActive(true);
        _subtitleText.text = message;
        _subtitleText.gameObject.SetActive(true);
    }

    public void DisableSubtitle()
    {
        _blackBG.SetActive(false);
        _subtitleText.gameObject.SetActive(false);
    }
}
