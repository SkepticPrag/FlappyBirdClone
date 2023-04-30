using UnityEngine;

public class MenuController : MonoBehaviour
{
    [SerializeField] private GameObject MainMenuPanel;
    [SerializeField] private GameObject PausePanel;
    [SerializeField] private GameObject ScorePanels;
    [SerializeField] private GameObject GameOverPanel;
    [SerializeField] private GameObject PauseButtonUI;
    [SerializeField] private GameObject _exitButton;

    private static MenuController instance;
    public static MenuController Instance { get { return instance; } }

    private void Awake()
    {
        if (instance == null) { instance = this; }
        else if (instance != this)
            Destroy(gameObject);

        if (Application.platform != RuntimePlatform.WindowsPlayer)
            _exitButton.SetActive(true);
    }


    public void PlayButton()
    {
        MainMenuPanel.SetActive(false);
        ScorePanels.SetActive(true);
        PauseButtonUI.SetActive(true);
        GameManager.Instance.StartGame();
    }

    public void ResumeButton()
    {
        PausePanel.SetActive(false);
        PauseButtonUI.SetActive(true);
        GameManager.Instance.ResumeGameplay();
    }

    public void RetryButton()
    {
        GameOverPanel.SetActive(false);
        PauseButtonUI.SetActive(true);

        GameManager.Instance.Retry();
    }

    public void MainMenuButton()
    {
        PauseButtonUI.SetActive(false);
        GameOverPanel.SetActive(false);
        PausePanel.SetActive(false);
        ScorePanels.SetActive(false);
        MainMenuPanel.SetActive(true);
        GameManager.Instance.MainMenu();
    }

    public void ExitGameButton()
    {
        Application.Quit();
    }

    public void PauseButton()
    {
        PauseButtonUI.SetActive(false);
        PausePanel.SetActive(true);
        GameManager.Instance.Pause();
    }

    public void GameOverMenu()
    {
        GameOverPanel.SetActive(true);
        PauseButtonUI.SetActive(false);

    }
}
