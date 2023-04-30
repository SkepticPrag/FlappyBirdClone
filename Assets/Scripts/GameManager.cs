using System.Collections;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    private int _currentScore = 0;
    private int _bestScore = 0;

    public bool IsGameplayOn = false;

    [SerializeField] private TMP_Text _bestScoreText;
    [SerializeField] private TMP_Text _currentScoreText;

    private static GameManager instance;
    public static GameManager Instance { get { return instance; } }

    private void Awake()
    {
        if (instance == null) { instance = this; }
        else if (instance != this)
            Destroy(gameObject);

        _bestScore = PlayerPrefs.GetInt("HighScore", 0);
        _bestScoreText.text = _bestScore.ToString();
    }

    public void StartGame()
    {
        IsGameplayOn = true;
        PlayerMovement.onGameStartedEnablePlayer?.Invoke();
        PipesSpawner.onGameStartedEnableSpawner?.Invoke();
    }

    public void ScoreUp()
    {
        _currentScore++;
        if (_currentScore > PlayerPrefs.GetInt("HighScore", 0))
            SetNewHighScore();

        UpdateCurrentScore();
    }

    public void ResumeGameplay()
    {
        StartCoroutine("ResumeGame");
    }

    public void Pause()
    {
        Time.timeScale = 0;
    }

    private IEnumerator ResumeGame()
    {
        yield return new WaitForSecondsRealtime(3f);

        Time.timeScale = 1;
    }

    public void MainMenu()
    {
        _currentScore = 0;
        UpdateCurrentScore();
        ObjectPool.Instance.DisableEveryPipe();
        PlayerMovement.onGameRestartedResetPlayer?.Invoke();

    }

    public void GameOver()
    {
        PlayerPrefs.Save();
        IsGameplayOn = false;
        PlayerMovement.onGameFinishedDisablePlayer?.Invoke();
        PipesSpawner.onGameFinishedDisableSpawner?.Invoke();
        PipesMovement.onGameFinishedDisablePipes?.Invoke();
        MenuController.Instance.GameOverMenu();
    }

    public void Retry()
    {
        _currentScore = 0;
        UpdateCurrentScore();
        ObjectPool.Instance.DisableEveryPipe();
        PlayerMovement.onGameRestartedResetPlayer?.Invoke();
        PlayerMovement.onGameStartedEnablePlayer?.Invoke();
        PipesSpawner.onGameStartedEnableSpawner?.Invoke();
        IsGameplayOn = true;
    }

    private void UpdateCurrentScore()
    {
        _currentScoreText.text = _currentScore.ToString();
    }

    private void SetNewHighScore()
    {
        PlayerPrefs.SetInt("HighScore", _currentScore);
        _bestScoreText.text = _currentScore.ToString();
    }
}
