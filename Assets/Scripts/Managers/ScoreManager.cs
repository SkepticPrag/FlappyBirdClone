using UnityEngine;
using TMPro;

public class ScoreManager : MonoBehaviour
{
    private int _currentScore = 0;
    private int _bestScore = 0;

    [SerializeField] private TMP_Text _bestScoreText;
    [SerializeField] private TMP_Text _currentScoreText;

    [SerializeField] private TMP_Text _scorePanelBestScoreText;
    [SerializeField] private TMP_Text _scorePanelYourScoreText;

    private static ScoreManager instance;
    public static ScoreManager Instance { get { return instance; } }

    private void Awake()
    {
        if (instance == null) { instance = this; }
        else if (instance != this)
            Destroy(gameObject);

        GetHighestScore();
    }

    private void GetHighestScore()
    {
        _bestScore = PlayerPrefs.GetInt("HighScore", 0);
        _bestScoreText.text = _bestScore.ToString();
        _scorePanelBestScoreText.text = _bestScore.ToString();
    }

    private void SetNewHighScore()
    {
        PlayerPrefs.SetInt("HighScore", _currentScore);
        _bestScoreText.text = _currentScore.ToString();
        _scorePanelBestScoreText.text = _bestScore.ToString();
    }

    public void ScoreUp()
    {
        _currentScore++;
        _currentScoreText.text = _currentScore.ToString();
        _scorePanelYourScoreText.text = _currentScore.ToString();

        if (_currentScore > PlayerPrefs.GetInt("HighScore", 0))
            SetNewHighScore();
    }

    public void ResetScore()
    {
        _currentScore = 0;
        _currentScoreText.text = _currentScore.ToString();
        _scorePanelYourScoreText.text = _currentScore.ToString();
    }
}
