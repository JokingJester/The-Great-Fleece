using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaySubtitles : MonoBehaviour
{
    public SubtitleAttributes[] intro;
    public SubtitleAttributes[] coin;
    public SubtitleAttributes[] cameraDialogue;
    public SubtitleAttributes[] keycardDialogue;
    public SubtitleAttributes[] gameover1;
    public SubtitleAttributes[] gameover2;

    public bool captured;
    public void Start()
    {
        StartCoroutine(PlaySubtitle(1));
    }
    public IEnumerator PlaySubtitle(int number)
    {
        switch (number)
        {
            case 1:
                foreach(var attribute in intro)
                {
                    if (GameManager.Instance.skippedIntro == true)
                    {
                        UIManager.Instance.DisableSubtitle();
                        yield break;
                    }
                    yield return new WaitForSeconds(attribute.seconds);
                    if (GameManager.Instance.skippedIntro == true)
                    {
                        UIManager.Instance.DisableSubtitle();
                        yield break;
                    }
                    UIManager.Instance.DisplaySubtitleText(attribute.message);
                }
                break;

            case 2:
                foreach (var attribute in coin)
                {
                    if (captured == true)
                    {
                        UIManager.Instance.DisableSubtitle();
                        yield break;
                    }
                    yield return new WaitForSeconds(attribute.seconds);
                    if (captured == true)
                    {
                        UIManager.Instance.DisableSubtitle();
                        yield break;
                    }
                    UIManager.Instance.DisplaySubtitleText(attribute.message);
                }
                yield return new WaitForSeconds(5);
                UIManager.Instance.DisableSubtitle();
                break;

            case 3:
                foreach (var attribute in cameraDialogue)
                {
                    if (captured == true)
                    {
                        UIManager.Instance.DisableSubtitle();
                        yield break;
                    }
                    yield return new WaitForSeconds(attribute.seconds);
                    if (captured == true)
                    {
                        UIManager.Instance.DisableSubtitle();
                        yield break;
                    }
                    UIManager.Instance.DisplaySubtitleText(attribute.message);
                }
                yield return new WaitForSeconds(3);
                UIManager.Instance.DisableSubtitle();
                break;

            case 4:
                foreach (var attribute in keycardDialogue)
                {
                    if (captured == true)
                    {
                        UIManager.Instance.DisableSubtitle();
                        yield break;
                    }
                    yield return new WaitForSeconds(attribute.seconds);
                    if (captured == true)
                    {
                        UIManager.Instance.DisableSubtitle();
                        yield break;
                    }
                    UIManager.Instance.DisplaySubtitleText(attribute.message);
                }
                yield return new WaitForSeconds(2);
                UIManager.Instance.DisableSubtitle();
                break;

            case 5:
                foreach (var attribute in gameover1)
                {
                    yield return new WaitForSeconds(attribute.seconds);
                    UIManager.Instance.DisplaySubtitleText(attribute.message);
                }
                yield return new WaitForSeconds(1.2f);
                UIManager.Instance.DisableSubtitle();
                break;

            case 6:
                foreach (var attribute in gameover2)
                {
                    yield return new WaitForSeconds(attribute.seconds);
                    UIManager.Instance.DisplaySubtitleText(attribute.message);
                }
                yield return new WaitForSeconds(3.5f);
                UIManager.Instance.DisableSubtitle();
                break;
        }
    }
}
