using UnityEngine;

public class GameManager : MonoBehaviour
{
    public bool IsGameplayOn = false;

    private MenuManager _menuManager;
    private EventManager _eventManager;


    private static GameManager instance;
    public static GameManager Instance { get { return instance; } }

    private void Awake()
    {
        if (instance == null) { instance = this; }
        else if (instance != this)
            Destroy(gameObject);

        _menuManager = GetComponent<MenuManager>();
        _eventManager = GetComponent<EventManager>();
    }

    public void StartGame()
    {
        IsGameplayOn = true;
        _eventManager.EnableGameplay();
    }

    public void Pause()
    {
        Time.timeScale = 0;
    }

    public void ResumeGame()
    {
        Time.timeScale = 1;
    }

    public void MainMenu()
    {
        IsGameplayOn = false;

        if (Time.timeScale == 0)
            Time.timeScale = 1;

        ScoreManager.Instance.ResetScore();
        ObjectPool.Instance.DisableEveryPipe();
        _eventManager.ResetGameplay();
    }

    public void GameOver()
    {
        PlayerPrefs.Save();
        IsGameplayOn = false;
        _eventManager.DisableGameplay();
        _menuManager.GameOverMenu();
    }

    public void Retry()
    {
        ScoreManager.Instance.ResetScore();
        ObjectPool.Instance.DisableEveryPipe();
        _eventManager.RestartGameplay();
        IsGameplayOn = true;
    }
}
