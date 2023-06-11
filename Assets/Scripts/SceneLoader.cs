using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using DG.Tweening;

public class SceneLoader : MonoBehaviour
{
    [SerializeField] private CanvasGroup blackScreenTransition;

    private void Awake()
    {

    }

    private void Start()
    {
        blackScreenTransition.blocksRaycasts = true;
        blackScreenTransition.alpha = 1;

        blackScreenTransition.DOFade(0, 0.5f).OnComplete(() =>
        {
            blackScreenTransition.blocksRaycasts = false;
        });
    }

    public void IncreaseLevelAtNumber(int amount)
    {
        int nextScene = SceneManager.GetActiveScene().buildIndex + amount;

        if (nextScene > PlayerPrefs.GetInt("levelAt"))
        {
            PlayerPrefs.SetInt("levelAt", nextScene);
        }
    }

    public void LoadNextScene()
    {
        int nextScene = SceneManager.GetActiveScene().buildIndex + 1;

        if (nextScene > PlayerPrefs.GetInt("levelAt"))
        {
            PlayerPrefs.SetInt("levelAt", nextScene);
        }

        blackScreenTransition.DOFade(1, 0.5f).OnComplete(() =>
        {
            GameMusicPlayer.Instance.SetMusicVolume(0.1f);
            SceneManager.LoadScene(nextScene);
        });
    }

    public void LoadCurrentScene()
    {
        GameMusicPlayer.Instance.SetMusicVolume(0.1f);
        blackScreenTransition.DOFade(1, 0.5f).OnComplete(() =>
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        });
    }

    public void LoadMainMenu()
    {
        blackScreenTransition.DOFade(1, 0.5f).OnComplete(() =>
        {
            GameMusicPlayer.Instance.SetMusicVolume(1);
            SceneManager.LoadScene(0);
        });
    }

    public void LoadLevel(int numberOfLevel)
    {
        blackScreenTransition.DOFade(1, 0.5f).OnComplete(() =>
        {
            GameMusicPlayer.Instance.SetMusicVolume(0.1f);
            SceneManager.LoadScene(numberOfLevel);
        });
    }

    public void LoadGameWinScene()
    {
        int nextScene = SceneManager.GetActiveScene().buildIndex + 1;

        if (nextScene > PlayerPrefs.GetInt("levelAt"))
        {
            PlayerPrefs.SetInt("levelAt", nextScene);
        }
        
        blackScreenTransition.DOFade(1, 0.5f).OnComplete(() =>
        {
            GameMusicPlayer.Instance.SetMusicVolume(0);
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        });
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
