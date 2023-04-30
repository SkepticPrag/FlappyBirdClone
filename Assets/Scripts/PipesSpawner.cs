using UnityEngine;

public class PipesSpawner : MonoBehaviour
{
    [SerializeField] private float _heightRange;

    private void InvokePipeSpawner()
    {
        InvokeRepeating("SpawnPipes", 1.5f, 1.5f);
    }

    private void SpawnPipes()
    {
        Vector3 spawnPosition = transform.position + new Vector3(0, Random.Range(-_heightRange, _heightRange), 0);
        ObjectPool.Instance.RequestPipes(spawnPosition, Quaternion.identity);
    }

}
