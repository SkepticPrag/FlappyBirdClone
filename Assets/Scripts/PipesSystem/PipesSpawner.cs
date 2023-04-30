using UnityEngine;

public class PipesSpawner : MonoBehaviour
{
    [SerializeField] private float _heightRange;

    public delegate void OnGameStartedEnableSpawner();
    public static OnGameStartedEnableSpawner onGameStartedEnableSpawner;

    public delegate void OnGameFinishedDisableSpawner();
    public static OnGameFinishedDisableSpawner onGameFinishedDisableSpawner;

    private void Awake()
    {
        onGameStartedEnableSpawner += InvokePipeSpawner;
        onGameFinishedDisableSpawner += StopInvoke;
    }

    private void InvokePipeSpawner()
    {
        InvokeRepeating("SpawnPipes", 0f, 1.5f);
    }

    private void StopInvoke()
    {
        CancelInvoke();
    }

    private void SpawnPipes()
    {
        Vector3 spawnPosition = transform.position + new Vector3(0, Random.Range(-_heightRange, _heightRange), 0);
        ObjectPool.Instance.RequestPipes(spawnPosition, Quaternion.identity);
    }

    private void OnDestroy()
    {
        onGameStartedEnableSpawner -= InvokePipeSpawner;
        onGameFinishedDisableSpawner -= StopInvoke;
    }
}