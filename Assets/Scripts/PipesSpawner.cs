using System.Collections;
using UnityEngine;

public class PipesSpawner : MonoBehaviour
{

    [SerializeField] private GameObject _pipes;
    [SerializeField] private float _heightRange;

    private void Start()
    {
        InvokeRepeating("SpawnPipes", 1.5f, 1.5f);
    }

    private void SpawnPipes()
    {
        Vector3 spawnPosition = transform.position + new Vector3(0, Random.Range(-_heightRange, _heightRange),0);
        GameObject pipes = Instantiate(_pipes, spawnPosition, Quaternion.identity);

        Destroy(pipes, 10);
    }

}
