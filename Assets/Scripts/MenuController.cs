using UnityEngine;

public class MenuController : MonoBehaviour
{
    [SerializeField] private GameObject MainMenuPanel;
    [SerializeField] private GameObject PausePanel;
    [SerializeField] private GameObject ScorePanels;
    [SerializeField] private GameObject GameOverPanel;
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
        GameManager.Instance.StartGame();
    }

    public void ResumeButton()
    {
        PausePanel.SetActive(false);
    }

    public void RetryButton()
    {
        GameOverPanel.SetActive(false);
        GameManager.Instance.Retry();
    }

    public void MainMenuButton()
    {
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
        PausePanel.SetActive(true);
    }

    public void GameOverMenu()
    {
        GameOverPanel.SetActive(true);
    }
}
