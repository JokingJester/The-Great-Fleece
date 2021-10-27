using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaySubtitles : MonoBehaviour
{
    public SubtitleAttributes[] intro;
    public SubtitleAttributes[] coin;
    public SubtitleAttributes[] cameraDialogue;
    public SubtitleAttributes[] keycardDialogue;
    public void Start()
    {
        StartCoroutine(PlaySubtitle(1));
    }
    private void Update()
    {
        
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
                    yield return new WaitForSeconds(attribute.seconds);
                    UIManager.Instance.DisplaySubtitleText(attribute.message);
                }
                yield return new WaitForSeconds(5);
                UIManager.Instance.DisableSubtitle();
                break;

            case 3:
                foreach (var attribute in cameraDialogue)
                {
                    yield return new WaitForSeconds(attribute.seconds);
                    UIManager.Instance.DisplaySubtitleText(attribute.message);
                }
                yield return new WaitForSeconds(3);
                UIManager.Instance.DisableSubtitle();
                break;

            case 4:
                foreach (var attribute in keycardDialogue)
                {
                    yield return new WaitForSeconds(attribute.seconds);
                    UIManager.Instance.DisplaySubtitleText(attribute.message);
                }
                yield return new WaitForSeconds(2);
                UIManager.Instance.DisableSubtitle();
                break;
        }
    }
}
