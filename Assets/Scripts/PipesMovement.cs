using System.Collections;
using UnityEngine;

public class PipesMovement : MonoBehaviour
{
    [SerializeField] private float _speed;

    public delegate void OnGameFinishedDisablePipes();
    public static OnGameFinishedDisablePipes onGameFinishedDisablePipes;

    public delegate void OnGameResumed();
    public static OnGameResumed onGameResumed;

    private void OnEnable()
    {
        onGameResumed += RestartCoroutine;
        onGameFinishedDisablePipes += StopDeactivatePipesCoroutine;
        StartCoroutine("DeactivatePipes");
    }

    private void RestartCoroutine()
    {
        StartCoroutine("DeactivatePipes");
    }

    private void StopDeactivatePipesCoroutine()
    {
        StopCoroutine("DeactivatePipes");
    }

    private IEnumerator DeactivatePipes()
    {
        yield return new WaitForSeconds(10f);

        gameObject.SetActive(false);
    }

    void FixedUpdate()
    {
        if (GameManager.Instance.IsGameplayOn)
            transform.position += Vector3.left * _speed * Time.deltaTime;
    }
}
