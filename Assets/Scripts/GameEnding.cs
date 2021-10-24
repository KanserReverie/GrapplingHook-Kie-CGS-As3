using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// This class ends the scene for the player.
/// </summary>
public class GameEnding : MonoBehaviour
{
    [SerializeField] private float fadeDuration = 1f;
    [SerializeField] private float displayDuration = 1f;
    [SerializeField] private GameObject player;
    private bool m_IsPlayerAtExit = false;
    private bool m_IsPlayerCaught = false;
    private float m_Timer;
    private bool m_HasAudioPlayed;
    [SerializeField] private CanvasGroup exitBackgroundImageCanvasGroup;
    [SerializeField] private AudioSource exitAudio;
    [SerializeField] private CanvasGroup caughtBackgroundImageCanvasGroup;
    [SerializeField] private AudioSource caughtAudio;

    /// <summary>
    /// If the player is caught.
    /// </summary>
    public void CaughtPlayer() => m_IsPlayerCaught = true;

    /// <summary>
    /// If the player enters the escape pad.
    /// </summary>
    /// <param name="other"> Collider of the object.</param>
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
            EndLevel(exitBackgroundImageCanvasGroup, false, exitAudio);
        }
        else if(m_IsPlayerCaught)
        {
            EndLevel(caughtBackgroundImageCanvasGroup, true, caughtAudio);
        }
    }

    private void EndLevel(CanvasGroup _imageCanvasGroup, bool _doRestart, AudioSource _audioSource)
    {
        if(!m_HasAudioPlayed)
        {
            _audioSource.Play();
            m_HasAudioPlayed = true;
        }
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
