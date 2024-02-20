using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.Video;
public class Intro : MonoBehaviour
{
    public RawImage rawImage;
    public KeyCode skipButton = KeyCode.Space; 
    bool introFinished = false; 

    void Start()
    {
        rawImage.enabled = true;
    }

    void Update()
    {
        if (!introFinished && Input.GetKeyDown(skipButton))
        {
            FinishIntro();
        }
    }

    void FinishIntro()
    {
        introFinished = true;
        SceneManager.LoadScene("MainScene");
    }
}
