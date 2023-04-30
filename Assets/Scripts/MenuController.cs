using UnityEngine;
using UnityEngine.UI;

public class MenuController : MonoBehaviour
{
    [SerializeField] private GameObject MainMenu;
    [SerializeField] private GameObject PauseMenu;
    [SerializeField] private GameObject ScorePanels;
    [SerializeField] private Button _exitButton;


    private void Awake()
    {
        if (Application.platform != RuntimePlatform.WindowsEditor)
            _exitButton.gameObject.SetActive(true);
    }


    public void StartGame()
    {
        MainMenu.SetActive(false);
        ScorePanels.SetActive(true);
    }

    public void ExitGame()
    {
        Application.Quit();
    }
}
