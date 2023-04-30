using UnityEngine;

public class MenuController : MonoBehaviour
{
    [SerializeField] private GameObject _mainMenuPanel;
    [SerializeField] private GameObject _pausePanel;
    [SerializeField] private GameObject _scorePanels;
    [SerializeField] private GameObject _gameOverPanel;
    [SerializeField] private GameObject _pauseButtonUI;
    [SerializeField] public GameObject ExitButton;

    private static MenuController instance;
    public static MenuController Instance { get { return instance; } }

    private void Awake()
    {
        if (instance == null) { instance = this; }
        else if (instance != this)
            Destroy(gameObject);
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

        GameManager.Instance.ResumeGameplay();
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
        _mainMenuPanel.SetActive(true);

        GameManager.Instance.MainMenu();
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
}
