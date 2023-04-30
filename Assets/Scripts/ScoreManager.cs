using UnityEngine;
using TMPro;

public class ScoreManager : MonoBehaviour
{
    private int _currentScore = 0;
    private int _bestScore = 0;

    [SerializeField] private TMP_Text _bestScoreText;
    [SerializeField] private TMP_Text _currentScoreText;

    private static ScoreManager instance;
    public static ScoreManager Instance { get { return instance; } }

    private void Awake()
    {
        if (instance == null) { instance = this; }
        else if (instance != this)
            Destroy(gameObject);

        _bestScore = PlayerPrefs.GetInt("HighScore", 0);
        _bestScoreText.text = _bestScore.ToString();
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

    public void ScoreUp()
    {
        _currentScore++;
        if (_currentScore > PlayerPrefs.GetInt("HighScore", 0))
            SetNewHighScore();

        UpdateCurrentScore();
    }

    public void ResetScore()
    {
        _currentScore = 0;
        UpdateCurrentScore();
    }
}
