using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{
    [SerializeField] private GameObject prefab;
    [SerializeField] private int _poolSize;
    [SerializeField] private List<GameObject> PoolList;


    private static ObjectPool instance;
    public static ObjectPool Instance { get { return instance; } }

    private void Awake()
    {
        if (instance == null) { instance = this; }
        else if (instance != this)
            Destroy(gameObject);
    }


    private void Start()
    {
        AddPipesToPool(_poolSize);
    }

    private void AddPipesToPool(int amount)
    {
        for (int i = 0; i < amount; i++)
        {
            GameObject gameObject = Instantiate(prefab);
            gameObject.SetActive(false);
            PoolList.Add(gameObject);
            gameObject.transform.parent = transform;
        }
    }

    public GameObject RequestPipes(Vector3 position, Quaternion rotation)
    {
        for (int i = 0; i < PoolList.Count; i++)
        {
            if (!PoolList[i].activeSelf)
            {
                PoolList[i].transform.position = position;
                PoolList[i].transform.rotation = rotation;
                PoolList[i].SetActive(true);
                return PoolList[i];
            }
        }

        AddPipesToPool(1);
        PoolList[PoolList.Count - 1].SetActive(true);
        return PoolList[PoolList.Count - 1];
    }

}
