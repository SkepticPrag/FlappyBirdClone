using System.Collections;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public bool IsGameplayOn = false;

    private static GameManager instance;
    public static GameManager Instance { get { return instance; } }

    private void Awake()
    {
        if (instance == null) { instance = this; }
        else if (instance != this)
            Destroy(gameObject);
    }

    public void StartGame()
    {
        IsGameplayOn = true;
        PlayerStateManager.onGameStartedEnablePlayer?.Invoke();
        PipesSpawner.onGameStartedEnableSpawner?.Invoke();
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
        IsGameplayOn = false;

        if (Time.timeScale == 0)
            Time.timeScale = 1;

        ScoreManager.Instance.ResetScore();
        ObjectPool.Instance.DisableEveryPipe();

        PlayerStateManager.onGameRestartedResetPlayer?.Invoke();
        PlayerStateManager.onGameFinishedDisablePlayer?.Invoke();
        PipesSpawner.onGameFinishedDisableSpawner?.Invoke();
        PipesStateManager.onGameFinishedDisablePipes?.Invoke();
    }

    public void GameOver()
    {
        PlayerPrefs.Save();
        IsGameplayOn = false;
        PlayerStateManager.onGameFinishedDisablePlayer?.Invoke();
        PipesSpawner.onGameFinishedDisableSpawner?.Invoke();
        PipesStateManager.onGameFinishedDisablePipes?.Invoke();
        MenuController.Instance.GameOverMenu();
    }

    public void Retry()
    {
        ScoreManager.Instance.ResetScore();
        ObjectPool.Instance.DisableEveryPipe();
        PlayerStateManager.onGameRestartedResetPlayer?.Invoke();
        PlayerStateManager.onGameStartedEnablePlayer?.Invoke();
        PipesSpawner.onGameStartedEnableSpawner?.Invoke();
        IsGameplayOn = true;
    }
}
