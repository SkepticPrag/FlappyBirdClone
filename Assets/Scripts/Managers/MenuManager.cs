using System.Collections;
using UnityEngine;

public class MenuManager : MonoBehaviour
{
    [SerializeField] private GameObject _mainMenuPanel;
    [SerializeField] private GameObject _pausePanel;
    [SerializeField] private GameObject _scorePanels;
    [SerializeField] private GameObject _gameOverPanel;
    [SerializeField] private GameObject _highestScorePanel;
    [SerializeField] private GameObject _pauseButtonUI;
    [SerializeField] public GameObject ExitButton;

    private Countdown _countdown;

    private void Awake()
    {
        _countdown = GetComponent<Countdown>();
    }

    public void PlayButton()
    {
        _mainMenuPanel.SetActive(false);
        _scorePanels.SetActive(true);
        _pauseButtonUI.SetActive(true);
        GameManager.Instance.StartGame();
    }

    public void ResumeButton()
    {
        _pausePanel.SetActive(false);
        _pauseButtonUI.SetActive(true);

        _countdown.StartCountdown();
    }

    public void RetryButton()
    {
        _gameOverPanel.SetActive(false);
        _pauseButtonUI.SetActive(true);

        GameManager.Instance.Retry();
    }

    public void MainMenuButton()
    {
        _pauseButtonUI.SetActive(false);
        _gameOverPanel.SetActive(false);
        _pausePanel.SetActive(false);
        _scorePanels.SetActive(false);

        StartCoroutine("ShowHighestScore");
    }

    public void ExitGameButton()
    {
        Application.Quit();
    }

    public void PauseButton()
    {
        _pauseButtonUI.SetActive(false);
        _pausePanel.SetActive(true);

        GameManager.Instance.Pause();
    }

    public void GameOverMenu()
    {
        _gameOverPanel.SetActive(true);
        _pauseButtonUI.SetActive(false);

    }

    private IEnumerator ShowHighestScore()
    {
        _highestScorePanel.SetActive(true);
        yield return new WaitForSecondsRealtime(3f);
        _highestScorePanel.SetActive(false);
        _mainMenuPanel.SetActive(true);
        GameManager.Instance.MainMenu();
    }

}
