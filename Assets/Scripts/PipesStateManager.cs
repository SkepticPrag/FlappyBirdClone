using System.Collections;
using UnityEngine;

public class PipesStateManager : MonoBehaviour
{
    public delegate void OnGameFinishedDisablePipes();
    public static OnGameFinishedDisablePipes onGameFinishedDisablePipes;

    public delegate void OnGameResumed();
    public static OnGameResumed onGameResumed;

    private void OnEnable()
    {
        onGameResumed += RestartCoroutine;
        onGameFinishedDisablePipes += StopPipesCoroutine;
        StartCoroutine("DeactivatePipes");
    }

    private void RestartCoroutine()
    {
        if (gameObject.activeSelf)
            StartCoroutine("DeactivatePipes");
    }

    private void StopPipesCoroutine()
    {
        StopCoroutine("DeactivatePipes");
    }

    private IEnumerator DeactivatePipes()
    {
        yield return new WaitForSeconds(10f);

        gameObject.SetActive(false);
    }

    private void OnDestroy()
    {
        onGameResumed -= RestartCoroutine;
        onGameFinishedDisablePipes -= StopPipesCoroutine;
    }
}
