using UnityEngine;

public class PipesMovement : MonoBehaviour
{

    [SerializeField] private float _speed;

    void Update()
    {
        transform.position += Vector3.left * _speed * Time.deltaTime;
    }
}
