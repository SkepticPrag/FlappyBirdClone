using System.Collections;
using UnityEngine;
using TMPro;

public class Countdown : MonoBehaviour
{

    [SerializeField] private GameObject _countdownPanel;
    [SerializeField] private TMP_Text _countdownText;

    public void StartCountdown()
    {
        StartCoroutine("CountdownTimer");
    }

    private IEnumerator CountdownTimer()
    {
        _countdownPanel.SetActive(true);

        int countdownTime = 3;

        while (countdownTime > 0)
        {
            _countdownText.text = countdownTime.ToString();

            yield return new WaitForSecondsRealtime(1f);

            countdownTime--;
        }

        _countdownPanel.SetActive(false);

        GameManager.Instance.ResumeGame();
    }
}
