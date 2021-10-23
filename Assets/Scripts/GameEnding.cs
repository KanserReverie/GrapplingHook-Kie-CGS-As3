using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameEnding : MonoBehaviour
{
    public float fadeDuration = 1f;
    public float displayDuration = 1f;
    public GameObject player;
    private bool m_IsPlayerAtExit = false;
    private bool m_IsPlayerCaught = false;
    private float m_Timer;
    public CanvasGroup exitBackgroundImageCanvasGroup;
    public CanvasGroup caughtBackgroundImageCanvasGroup;

    public void CaughtPlayer() => m_IsPlayerCaught = true;

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject == player)
        {
            m_IsPlayerAtExit = true;
        }
    }

    private void Update()
    {
        if(m_IsPlayerAtExit)
        {
            EndLevel(exitBackgroundImageCanvasGroup, false);
        }
        else if(m_IsPlayerCaught)
        {
            EndLevel(caughtBackgroundImageCanvasGroup, true);
        }
    }

    private void EndLevel(CanvasGroup _imageCanvasGroup, bool _doRestart)
    {
        m_Timer += Time.deltaTime;
        _imageCanvasGroup.alpha = m_Timer / fadeDuration;

        if(m_Timer > fadeDuration + displayDuration)
        {
            if(_doRestart)
            {
                SceneManager.LoadScene(0);
            }
            else
            { 
                Application.Quit();
            }
        }
    }
}
