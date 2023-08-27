using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseAndButtons : MonoBehaviour
{
    public bool isPaused = false;
    [SerializeField] Animator changeAnim;
    [SerializeField] GameObject userUI;
    [SerializeField] GameObject pauseCanvas;
    [SerializeField] GameObject optionsCanvas;
    [SerializeField] GameObject gameWonCanvas;
    [SerializeField] GameObject gameLostCanvas;
    [SerializeField] GameObject tutCanvas;
    private void Start()
    {
        Time.timeScale = 0f;
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (!isPaused)
            {
                Pause();
            }
            else
            {
                UnPause();
            }
        }
    }

    public void Pause()
    {
        Debug.Log("Pausing");
        userUI.SetActive(false);
        pauseCanvas.SetActive(true);
        isPaused = true;
        Time.timeScale = 0f;
    }
    public void UnPause()
    {
        isPaused = false;
        userUI.SetActive(true);
        pauseCanvas.SetActive(false);
        Time.timeScale = 1f;
    }
    public void GoToMenu()
    {
        StartCoroutine(GoToMenuE());
    }
    public IEnumerator GoToMenuE()
    {
        Time.timeScale = 1f;
        changeAnim.SetTrigger("Change");
        yield return new WaitForSecondsRealtime(1f);
        SceneManager.LoadScene("Menu");
    }
    public void PlayGame()
    {
        StartCoroutine(PlayGameE());
    }
    public IEnumerator PlayGameE()
    {
        Time.timeScale = 1f;
        changeAnim.SetTrigger("Change");
        yield return new WaitForSecondsRealtime(1f);
        SceneManager.LoadScene(1);
    }
    public void ResetScene()
    {
        StartCoroutine(ResetSceneE());
    }
    public IEnumerator ResetSceneE()
    {
        Time.timeScale = 1f;
        changeAnim.SetTrigger("Change");
        yield return new WaitForSecondsRealtime(1f);
        SceneManager.LoadScene(1);
    }

    public void ShowOptions()
    {
        if (pauseCanvas.activeInHierarchy)
        {
            pauseCanvas.SetActive(false);
            optionsCanvas.SetActive(true);
        }
        else
        {
            pauseCanvas.SetActive(true);
            optionsCanvas.SetActive(false);
        }
    }
    public void ExitGame()
    {
        Application.Quit();
    }
    public void GameWon()
    {
        Time.timeScale = 0f;
        userUI.SetActive(false);
        gameWonCanvas.SetActive(true);
    }
    public void GameLost()
    {
        Time.timeScale = 0f;
        gameLostCanvas.SetActive(true);
    }
    public void HideTut()
    {
        Time.timeScale = 1f;
        tutCanvas.SetActive(false);
        userUI.SetActive(true);
    }
}
